// <copyright file="IHttpResponseResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Populates an <see cref="HttpResponse"/> with the outcome (or failure) of an operation.
    /// </summary>
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
