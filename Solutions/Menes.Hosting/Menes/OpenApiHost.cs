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
        private readonly IPathMatcher matcher;
        private readonly IOpenApiOperationInvoker<TRequest, TResponse> operationInvoker;
        private readonly IOpenApiResultBuilder<TResponse> resultBuilder;

        /// <summary>
        /// Creates an instance of the <see cref="OpenApiHost{TRequest, TResponse}"/>.
        /// </summary>
        /// <param name="matcher">The path matcher.</param>
        /// <param name="operationInvoker">The OpenAPI operation invoker.</param>
        /// <param name="resultBuilder">The OpenAPI result builder.</param>
        public OpenApiHost(IPathMatcher matcher, IOpenApiOperationInvoker<TRequest, TResponse> operationInvoker, IOpenApiResultBuilder<TResponse> resultBuilder)
        {
            this.matcher = matcher;
            this.operationInvoker = operationInvoker;
            this.resultBuilder = resultBuilder;
        }

        /// <inheritdoc/>
        public async Task<TResponse> HandleRequestAsync(string path, string method, TRequest request, object parameters)
        {
            // Try to find an Open API operation which matches the incoming request.
            if (this.matcher.FindOperationPathTemplate(path, method, out OpenApiOperationPathTemplate operationPathTemplate))
            {
                // Now execute the operation
                return await this.operationInvoker.InvokeAsync(path, method, request, operationPathTemplate).ConfigureAwait(false);
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
    }
}
