// <copyright file="IOpenApiContextBuilderComponent.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface implemented by types responsible for setting properties on an <see cref="IOpenApiContext{TTenant}"/> for an incoming request.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TTenant">The type of the tenant.</typeparam>
    public interface IOpenApiContextBuilderComponent<TRequest, TTenant>
    {
        /// <summary>
        /// Sets properties on an <see cref="IOpenApiContext{TTenant}"/> for an incoming request.
        /// </summary>
        /// <param name="context">The <see cref="IOpenApiContext{TTenant}"/> for the current request.</param>
        /// <param name="request">The incoming request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task BuildAsync(IOpenApiContext<TTenant> context, TRequest request);
    }
}
