// <copyright file="MenesCatchAllMiddleware.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AspNetCore
{
    using System.Threading.Tasks;

    using Menes.Internal;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Middleware that passes all requests on to Menes. This never forwards requests further down the pipeline.
    /// </summary>
    internal class MenesCatchAllMiddleware : IMiddleware
    {
        private static readonly object EmptyParameters = new ();
        private readonly IOpenApiHost<HttpRequest, IHttpResponseResult> host;

        /// <summary>
        /// Creates a <see cref="MenesCatchAllMiddleware"/>.
        /// </summary>
        /// <param name="host">The Menes host.</param>
        public MenesCatchAllMiddleware(IOpenApiHost<HttpRequest, IHttpResponseResult> host)
        {
            this.host = host;
        }

        /// <inheritdoc/>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await this.host.HandleRequestAsync(context, EmptyParameters);
        }
    }
}