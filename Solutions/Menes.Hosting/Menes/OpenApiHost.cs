// <copyright file="OpenApiHost.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Threading.Tasks;
    using Menes.Internal;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Dispatches an OpenApi operation.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the repsonse.</typeparam>
    public class OpenApiHost<TRequest, TResponse> : IOpenApiHost<TRequest, TResponse>
    {
        private readonly IPathMatcher matcher;
        private readonly IOpenApiOperationInvoker<TRequest, TResponse> operationInvoker;
        private readonly IOpenApiResultBuilder<TResponse> resultBuilder;
        private readonly IServiceProvider serviceProvider;
        private readonly IOpenApiRequestScopeFactory<TRequest> scopeFactory;

        /// <summary>
        /// Creates an instance of the <see cref="OpenApiHost{TRequest, TResponse}"/>.
        /// </summary>
        /// <param name="serviceProvider">The service provider for the host.</param>
        /// <param name="scopeFactory">The factory for the request scope.</param>
        /// <param name="matcher">The path matcher.</param>
        /// <param name="operationInvoker">The OpenAPI operation invoker.</param>
        /// <param name="resultBuilder">The OpenAPI result builder.</param>
        public OpenApiHost(IServiceProvider serviceProvider, IOpenApiRequestScopeFactory<TRequest> scopeFactory, IPathMatcher matcher, IOpenApiOperationInvoker<TRequest, TResponse> operationInvoker, IOpenApiResultBuilder<TResponse> resultBuilder)
        {
            this.matcher = matcher;
            this.operationInvoker = operationInvoker;
            this.resultBuilder = resultBuilder;
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            this.scopeFactory = scopeFactory;
        }

        /// <inheritdoc/>
        public async Task<TResponse> HandleRequestAsync(string path, string method, TRequest request, object parameters)
        {
            // Try to find an Open API operation which matches the incoming request.
            if (this.matcher.FindOperationPathTemplate(path, method, out OpenApiOperationPathTemplate operationPathTemplate))
            {
                using IServiceScope newScope = await this.scopeFactory.BuildScopeAsync(this.serviceProvider, path, method, request, parameters, operationPathTemplate).ConfigureAwait(false);
                return await this.operationInvoker.InvokeAsync(newScope.ServiceProvider, path, method, request, operationPathTemplate).ConfigureAwait(false);
            }

            // We didn't find an operation which corresponds to the path and method in the OpenAPI document
            return this.BuildServiceOperationNotFoundResult();
        }

        /// <summary>
        /// Build a response for the case where a service operation is not found that corresponds to the request.
        /// </summary>
        /// <returns>A response for when the service operation is not found.</returns>
        private TResponse BuildServiceOperationNotFoundResult()
        {
            return this.resultBuilder.BuildServiceOperationNotFoundResult();
        }
    }
}
