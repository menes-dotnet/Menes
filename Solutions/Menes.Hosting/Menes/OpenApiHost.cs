// <copyright file="OpenApiHost.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Threading.Tasks;
    using Menes.Internal;

    /// <summary>
    /// Dispatches an OpenApi operation.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the repsonse.</typeparam>
    public class OpenApiHost<TRequest, TResponse> : IOpenApiHost<TRequest, TResponse>
    {
        private readonly IOpenApiServiceOperationLocator operationLocator;
        private readonly IPathMatcher matcher;
        private readonly IOpenApiContextBuilder<TRequest> contextBuilder;
        private readonly IOpenApiOperationInvoker<TRequest, TResponse> operationInvoker;
        private readonly IOpenApiResultBuilder<TResponse> resultBuilder;

        /// <summary>
        /// Creates an instance of the <see cref="OpenApiHost{TRequest, TResponse}"/>.
        /// </summary>
        /// <param name="operationLocator">The operation locator.</param>
        /// <param name="matcher">The path matcher.</param>
        /// <param name="contextBuilder">The OpenAPI context builder.</param>
        /// <param name="operationInvoker">The OpenAPI operation invoker.</param>
        /// <param name="resultBuilder">The OpenAPI result builder.</param>
        public OpenApiHost(IOpenApiServiceOperationLocator operationLocator, IPathMatcher matcher, IOpenApiContextBuilder<TRequest> contextBuilder, IOpenApiOperationInvoker<TRequest, TResponse> operationInvoker, IOpenApiResultBuilder<TResponse> resultBuilder)
        {
            this.operationLocator = operationLocator;
            this.matcher = matcher;
            this.contextBuilder = contextBuilder;
            this.operationInvoker = operationInvoker;
            this.resultBuilder = resultBuilder;
        }

        /// <inheritdoc/>
        public async Task<TResponse> HandleRequestAsync(string path, string method, TRequest request, object parameters)
        {
            IOpenApiContext context = await this.BuildContextAsync(request, parameters).ConfigureAwait(false);

            // Try to find an Open API operation which matches the incoming request.
            if (this.matcher.FindOperationPathTemplate(path, method, out OpenApiOperationPathTemplate operationPathTemplate))
            {
                // Now execute the operation
                return await this.operationInvoker.InvokeAsync(path, method, request, operationPathTemplate, context).ConfigureAwait(false);
            }

            // We didn't find an operation which correspons to the path and method in the OpenAPI document
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

        /// <summary>
        /// Build an OpenAPI context from the request.
        /// </summary>
        /// <param name="request">The request from which to build the OpenAPI context.</param>
        /// <param name="parameters">The dynamically built parameters from which to build the context.</param>
        /// <returns>A <see cref="Task{TResult}"/> which, when complete, provides the <see cref="IOpenApiContext"/>.</returns>
        private async Task<IOpenApiContext> BuildContextAsync(TRequest request, object parameters)
        {
            return await this.contextBuilder.BuildAsync(request, parameters).ConfigureAwait(false);
        }
    }
}
