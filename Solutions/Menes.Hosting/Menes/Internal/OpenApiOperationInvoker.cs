// <copyright file="OpenApiOperationInvoker.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using Corvus.Extensions;
    using Corvus.Monitoring.Instrumentation;
    using Menes.Auditing;
    using Menes.Exceptions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Invokes an OpenApiOperation.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public class OpenApiOperationInvoker<TRequest, TResponse> : IOpenApiOperationInvoker<TRequest, TResponse>
    {
        private readonly IOpenApiServiceOperationLocator operationLocator;
        private readonly IOpenApiParameterBuilder<TRequest> parameterBuilder;
        private readonly IOpenApiAccessChecker accessChecker;
        private readonly IOpenApiExceptionMapper exceptionMapper;
        private readonly IOpenApiResultBuilder<TResponse> resultBuilder;
        private readonly IAuditContext auditContext;
        private readonly ILogger<OpenApiOperationInvoker<TRequest, TResponse>> logger;
        private readonly IOpenApiConfiguration configuration;
        private readonly IOperationsInstrumentation<OpenApiOperationInvoker<TRequest, TResponse>> operationsInstrumentation;
        private readonly IExceptionsInstrumentation<OpenApiOperationInvoker<TRequest, TResponse>> exceptionsInstrumentation;
        private readonly IOpenApiRequestScopeFactory<TRequest> scopeFactory;

        /// <summary>
        /// Creates an instance of the <see cref="OpenApiOperationInvoker{TRequest, TResponse}"/>.
        /// </summary>
        /// <param name="scopeFactory">The factory for the request scope.</param>
        /// <param name="operationLocator">The operation locator.</param>
        /// <param name="parameterBuilder">The parameter builder.</param>
        /// <param name="accessChecker">The access checker.</param>
        /// <param name="exceptionMapper">The exception mapper.</param>
        /// <param name="resultBuilder">The result builder.</param>
        /// <param name="configuration">The <see cref="IOpenApiConfiguration"/>.</param>
        /// <param name="auditContext">The audit context.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="operationsInstrumentation">Operations instrumentation.</param>
        /// <param name="exceptionsInstrumentation">Exceptions instrumentation.</param>
        public OpenApiOperationInvoker(
            IOpenApiRequestScopeFactory<TRequest> scopeFactory,
            IOpenApiServiceOperationLocator operationLocator,
            IOpenApiParameterBuilder<TRequest> parameterBuilder,
            IOpenApiAccessChecker accessChecker,
            IOpenApiExceptionMapper exceptionMapper,
            IOpenApiResultBuilder<TResponse> resultBuilder,
            IOpenApiConfiguration configuration,
            IAuditContext auditContext,
            ILogger<OpenApiOperationInvoker<TRequest, TResponse>> logger,
            IOperationsInstrumentation<OpenApiOperationInvoker<TRequest, TResponse>> operationsInstrumentation,
            IExceptionsInstrumentation<OpenApiOperationInvoker<TRequest, TResponse>> exceptionsInstrumentation)
        {
            this.operationLocator = operationLocator;
            this.parameterBuilder = parameterBuilder;
            this.accessChecker = accessChecker;
            this.exceptionMapper = exceptionMapper;
            this.resultBuilder = resultBuilder;
            this.auditContext = auditContext;
            this.logger = logger;
            this.operationsInstrumentation = operationsInstrumentation;
            this.configuration = configuration;
            this.exceptionsInstrumentation = exceptionsInstrumentation;
            this.scopeFactory = scopeFactory;
        }

        /// <inheritdoc/>
        public async Task<TResponse> InvokeAsync(IServiceProvider serviceProvider, string path, string method, TRequest request, object parameters, OpenApiOperationPathTemplate operationPathTemplate)
        {
            using IServiceScope newScope = await this.scopeFactory.BuildScopeAsync(serviceProvider, path, method, request, parameters, operationPathTemplate).ConfigureAwait(false);

            string operationId = operationPathTemplate.Operation.OperationId;
            if (!this.operationLocator.TryGetOperation(operationId, out OpenApiServiceOperation openApiServiceOperation))
            {
                throw new OpenApiServiceMismatchException(
                    $"The service's formal definition includes an operation '{operationPathTemplate.Operation.GetOperationId()}', but the service class does not provide an implementation");
            }

            string operationName = openApiServiceOperation.GetName();
            this.logger.LogInformation(
                "Executing operation [{openApiServiceOperation}] for [{path}] [{method}]",
                operationName,
                path,
                method);
            var instrumentationDetail = new AdditionalInstrumentationDetail { Properties = { { "Menes.OperationId", operationId } } };
            using IOperationInstance instrumentationOperation = this.operationsInstrumentation.StartOperation(
                operationName,
                instrumentationDetail);

            try
            {
                IDictionary<string, object> namedParameters = await this.BuildRequestParametersAsync(request, operationPathTemplate).ConfigureAwait(false);

                await this.CheckAccessPoliciesAsync(path, method, operationId).ConfigureAwait(false);
                object result = openApiServiceOperation.Execute(newScope.ServiceProvider, namedParameters);

                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                                        "Invoked operation [{openApiServiceOperation}] with parameters [{@namedParameters}] for request [{path}] [{method}], continuing to build result",
                                        openApiServiceOperation.GetName(),
                                        namedParameters.Keys,
                                        path,
                                        method);
                }

                if (result is Task task)
                {
                    if (this.logger.IsEnabled(LogLevel.Debug))
                    {
                        this.logger.LogDebug(
                                                "Awaiting task {task} from invoking operation [{openApiServiceOperation}] for [{request}]",
                                                task.Id,
                                                openApiServiceOperation.GetName(),
                                                path,
                                                method);
                    }

                    result = await task.CastWithConversion<object>().ConfigureAwait(false);

                    if (this.logger.IsEnabled(LogLevel.Debug))
                    {
                        this.logger.LogDebug(
                                                "Result from awaited task [{task}] from invoking operation [{openApiServiceOperation}] for request [{path}] [{method}]",
                                                task.Id,
                                                openApiServiceOperation.GetName(),
                                                path,
                                                method);
                    }
                }

                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug(
                        "Building result for request [{path}] [{method}] from invoking operation [{openApiServiceOperation}]",
                        path,
                        method,
                        openApiServiceOperation.GetName());
                }

                await this.auditContext.AuditResultAsync(result, operationPathTemplate.Operation).ConfigureAwait(false);

                return this.BuildResult(result, operationPathTemplate.Operation);
            }
            catch (OpenApiServiceMismatchException ce)
            {
                // Something somewhere is misconfigured, so all bets are now off.
                this.LogConfigurationError(ce);
                await this.auditContext.AuditFailureAsync(500, operationPathTemplate.Operation).ConfigureAwait(false);
                return this.BuildErrorResult(500);
            }
            catch (Exception ex)
            {
                this.exceptionsInstrumentation.ReportException(ex, instrumentationDetail);

                try
                {
                    this.logger.LogError(
                        ex,
                        "Exception occurred invoking operation [{openApiServiceOperation}] for [{path}] [{method}]",
                        openApiServiceOperation.GetName(),
                        path,
                        method);

                    OpenApiResult result = this.GetResultForException(ex, operationPathTemplate.Operation);
                    await this.auditContext.AuditResultAsync(result, operationPathTemplate.Operation).ConfigureAwait(false);
                    return this.BuildResult(result, operationPathTemplate.Operation);
                }
                catch (OpenApiServiceMismatchException ce)
                {
                    this.LogConfigurationError(ce);
                    await this.auditContext.AuditFailureAsync(500, operationPathTemplate.Operation).ConfigureAwait(false);
                    return this.BuildErrorResult(500);
                }
            }
        }

        private async Task CheckAccessPoliciesAsync(
            string path,
            string method,
            string operationId)
        {
            AccessControlPolicyResult result = await this.accessChecker.CheckAccessPolicyAsync(path, operationId, method).ConfigureAwait(false);

            if (result.ResultType == AccessControlPolicyResultType.NotAuthenticated)
            {
                Exception x = this.configuration.AccessPolicyUnauthenticatedResponse switch
                {
                    ResponseWhenUnauthenticated.Unauthorized => new OpenApiUnauthorizedException("Unauthorized"),
                    ResponseWhenUnauthenticated.Forbidden    => OpenApiForbiddenException.WithoutProblemDetails("Forbidden"),
                    ResponseWhenUnauthenticated.ServerError  => new OpenApiServiceMismatchException("Unauthenticated requests should not be reaching this service"),

                    _ => new OpenApiServiceMismatchException($"Unknown AccessPolicyUnauthenticatedResponse: {this.configuration.AccessPolicyUnauthenticatedResponse}"),
                };
                if (!string.IsNullOrWhiteSpace(result.Explanation))
                {
                    x.AddProblemDetailsExplanation(result.Explanation);
                }

                throw x;
            }

            if (!result.Allow)
            {
                throw string.IsNullOrWhiteSpace(result.Explanation)
                                    ? OpenApiForbiddenException.WithoutProblemDetails("Forbidden")
                                    : OpenApiForbiddenException.WithProblemDetails("Forbidden", result.Explanation);
            }
        }

        private OpenApiResult GetResultForException(Exception ex, OpenApiOperation operation)
        {
            // Because we're using reflection, it's possible that we might have a TargetInvocationException
            // containing our actual exception - if so, unwrap it.
            Exception targetException = ex;

            if (ex is TargetInvocationException tie)
            {
                targetException = tie.InnerException;
            }

            this.logger.LogError(
                "Error excecuting operation [{openApiServiceOperation}], [{exceptionMessage}]",
                operation.OperationId,
                targetException.Message);

            return this.exceptionMapper.GetResponse(targetException, operation);
        }

        private void LogConfigurationError(OpenApiServiceMismatchException ex)
        {
            this.logger.LogError(
                "An inconsistency has been detected in your OpenApi Service's configuration, or it is behaving inconsistently with its configuration: [{exception}]",
                ex);
        }

        /// <summary>
        /// Build a response for the given status code.
        /// </summary>
        /// <param name="statusCode">The specified status code.</param>
        /// <returns>A repsonse corresponding to the relevant status code.</returns>
        private TResponse BuildErrorResult(int statusCode)
        {
            return this.resultBuilder.BuildErrorResult(statusCode);
        }

        /// <summary>
        /// Build a response for the request of a service operation.
        /// </summary>
        /// <param name="result">The result of the service operation.</param>
        /// <param name="operation">The Open API operation definition.</param>
        /// <returns>A response corresponding to the result of the request.</returns>
        private TResponse BuildResult(object result, OpenApiOperation operation)
        {
            return this.resultBuilder.BuildResult(result, operation);
        }

        /// <summary>
        /// Build the parameters from the request.
        /// </summary>
        /// <param name="request">The original request.</param>
        /// <param name="operationPathTemplate">The result of matching an operation to the request.</param>
        /// <returns>A dictionary of parameter names to parameter values.</returns>
        private Task<IDictionary<string, object>> BuildRequestParametersAsync(TRequest request, OpenApiOperationPathTemplate operationPathTemplate)
        {
            return this.parameterBuilder.BuildParametersAsync(request, operationPathTemplate);
        }
    }
}
