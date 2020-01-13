// <copyright file="OpenApiRequestScopeFactory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Builds a new request scope using <see cref="IOpenApiScopeBuilder{TRequest}"/> instances.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    public class OpenApiRequestScopeFactory<TRequest> : IOpenApiRequestScopeFactory<TRequest>
    {
        private readonly IEnumerable<IOpenApiScopeBuilder<TRequest>> scopeBuilders;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiRequestScopeFactory{TRequest}"/> class.
        /// </summary>
        /// <param name="scopeBuilders">The scope builders from which to build the new scope.</param>
        public OpenApiRequestScopeFactory(IEnumerable<IOpenApiScopeBuilder<TRequest>> scopeBuilders)
        {
            this.scopeBuilders = scopeBuilders;
        }

        /// <inheritdoc/>
        public async Task<IServiceScope> BuildScopeAsync(IServiceProvider serviceProvider, string path, string method, TRequest request, object parameters, OpenApiOperationPathTemplate operationPathTemplate)
        {
            IServiceScope scope = serviceProvider.CreateScope();
            foreach (IOpenApiScopeBuilder<TRequest> scopeBuilder in this.scopeBuilders)
            {
                await scopeBuilder.BuildScope(serviceProvider, path, method, request, parameters, operationPathTemplate).ConfigureAwait(false);
            }

            return scope;
        }
    }
}
