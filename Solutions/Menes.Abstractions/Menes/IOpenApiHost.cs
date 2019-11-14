// <copyright file="IOpenApiHost.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Threading.Tasks;

    /// <summary>
    /// Interface implemented by Open API hosts.
    /// </summary>
    public interface IOpenApiHost
    {
    }

    /// <summary>
    /// Interface implemented by Open API hosts.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface IOpenApiHost<TRequest, TResponse> : IOpenApiHost
    {
        /// <summary>
        /// Handle the request, producing a response.
        /// </summary>
        /// <param name="path">The request path.</param>
        /// <param name="method">The request method.</param>
        /// <param name="request">The underlying request body.</param>
        /// <param name="parameters">The dynamically created parameters for the request.</param>
        /// <returns>A <see cref="Task{T}"/> which when complete, provides the response.</returns>
        Task<TResponse> HandleRequestAsync(string path, string method, TRequest request, object parameters);
    }
}