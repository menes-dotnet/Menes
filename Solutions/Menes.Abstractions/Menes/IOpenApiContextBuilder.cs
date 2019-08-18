// <copyright file="IOpenApiContextBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface implemented by types responsible for building an <see cref="IOpenApiContext{TTenant}"/> for an incoming request.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TTenant">The type of the tenant.</typeparam>
    public interface IOpenApiContextBuilder<TRequest, TTenant>
    {
        /// <summary>
        /// Builds an <see cref="IOpenApiContext{TTenant}" /> for an incoming request.
        /// </summary>
        /// <param name="request">The incoming reqeust.</param>
        /// <returns>The context for the request.</returns>
        Task<IOpenApiContext<TTenant>> BuildAsync(TRequest request);
    }
}