// <copyright file="OpenApiContextBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Class responsible for building an <see cref="IOpenApiContext"/> for an incoming request.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TContextType">The type of the context.</typeparam>
    public class OpenApiContextBuilder<TRequest, TContextType> : IOpenApiContextBuilder<TRequest>
        where TContextType : class, IOpenApiContext, new()
    {
        private readonly IEnumerable<IOpenApiContextBuilderComponent<TRequest>> contextBuilderComponents;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiContextBuilder{TRequest, TTenant}"/> class.
        /// </summary>
        /// <param name="contextBuilderComponents">The collection of registered <see cref="IOpenApiContextBuilderComponent{TRequest}"/> instances.</param>
        public OpenApiContextBuilder(IEnumerable<IOpenApiContextBuilderComponent<TRequest>> contextBuilderComponents)
        {
            this.contextBuilderComponents = contextBuilderComponents;
        }

        /// <inheritdoc/>
        public async Task<IOpenApiContext> BuildAsync(TRequest request, object parameters)
        {
            var context = new TContextType
            {
                AdditionalContext = parameters,
            };

            foreach (IOpenApiContextBuilderComponent<TRequest> builder in this.contextBuilderComponents)
            {
                await builder.BuildAsync(context, request, parameters).ConfigureAwait(false);
            }

            return context;
        }
    }
}