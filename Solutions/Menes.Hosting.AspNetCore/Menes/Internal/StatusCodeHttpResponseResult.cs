// <copyright file="StatusCodeHttpResponseResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// An <see cref="IHttpResponseResult"/> that sets an HTTP status code.
    /// </summary>
    internal class StatusCodeHttpResponseResult : IHttpResponseResult
    {
        private readonly int statusCode;

        /// <summary>
        /// Creates a <see cref="StatusCodeHttpResponseResult"/>.
        /// </summary>
        /// <param name="statusCode">The status code to set on the response.</param>
        public StatusCodeHttpResponseResult(int statusCode)
        {
            this.statusCode = statusCode;
        }

        /// <inheritdoc/>
        public Task ExecuteResultAsync(HttpResponse httpResponse)
        {
            httpResponse.StatusCode = this.statusCode;
            return Task.CompletedTask;
        }
    }
}
