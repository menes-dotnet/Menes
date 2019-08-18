// <copyright file="OpenApiContextBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Class responsible for building an <see cref="IOpenApiContext{TTenant}"/> for an incoming request.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TTenant">The type of the tenant.</typeparam>
    public class OpenApiContextBuilder<TRequest, TTenant> : IOpenApiContextBuilder<TRequest, TTenant>
    {
        private readonly IEnumerable<IOpenApiContextBuilderComponent<TRequest, TTenant>> contextBuilderComponents;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiContextBuilder{TRequest, TTenant}"/> class.
        /// </summary>
        /// <param name="contextBuilderComponents">The collection of registered <see cref="IOpenApiContextBuilderComponent{TRequest, TTenant}"/> instances.</param>
        public OpenApiContextBuilder(IEnumerable<IOpenApiContextBuilderComponent<TRequest, TTenant>> contextBuilderComponents)
        {
            this.contextBuilderComponents = contextBuilderComponents;
        }

        /// <summary>
        /// Builds an <see cref="IOpenApiContext{TTenant}" /> for an incoming request using all registered <see cref="IOpenApiContextBuilderComponent{TRequest, TTenant}"/> services.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>The context for the request.</returns>
        public async Task<IOpenApiContext<TTenant>> BuildAsync(TRequest request)
        {
            var context = new OpenApiContext<TTenant>();

            foreach (IOpenApiContextBuilderComponent<TRequest, TTenant> builder in this.contextBuilderComponents)
            {
                await builder.BuildAsync(context, request).ConfigureAwait(false);
            }

            return context;
        }
    }
}
