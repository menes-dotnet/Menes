// <copyright file="IHttpResponseResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Threading.Tasks;

    using Menes.Hosting.AspNetCore;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Populates an <see cref="HttpResponse"/> with the outcome (or failure) of an operation.
    /// </summary>
    /// <remarks>
    /// Used in direct pipeline mode (<see cref="OpenApiHostDirectPipelineExtensions.HandleRequestAsync(IOpenApiHost{HttpRequest, IHttpResponseResult}, HttpContext, object)"/>).
    /// This enables Menes to build a description of how the HTTP response is to be generated,
    /// which can then be applied to the <see cref="HttpResponse"/> supplied by ASP.NET once
    /// Menes is done.
    /// </remarks>
    public interface IHttpResponseResult
    {
        /// <summary>
        /// Populates the response.
        /// </summary>
        /// <param name="httpResponse">The response to populate.</param>
        /// <returns>A task that completes when the response has been populated.</returns>
        Task ExecuteResultAsync(HttpResponse httpResponse);
    }
}