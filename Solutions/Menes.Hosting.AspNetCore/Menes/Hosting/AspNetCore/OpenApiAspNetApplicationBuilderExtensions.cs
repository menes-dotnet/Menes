// <copyright file="OpenApiAspNetApplicationBuilderExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hosting.AspNetCore
{
    using Microsoft.AspNetCore.Builder;

    /// <summary>
    /// Extension methods for adding Menes to an ASP.NET Core pipeline.
    /// </summary>
    public static class OpenApiAspNetApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds middleware that directs all requests to Menes.
        /// </summary>
        /// <param name="app">The pipeline builder.</param>
        /// <returns>The modified pipeline builder.</returns>
        public static IApplicationBuilder UseMenesCatchAll(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MenesCatchAllMiddleware>();
        }
    }
}