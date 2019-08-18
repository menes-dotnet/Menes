// <copyright file="OpenApiServiceExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable RCS1175

namespace Menes
{
    using System.Linq;
    using System.Net;

    /// <summary>
    /// Extension methods to help create responses for the OpenAPI service.
    /// </summary>
    public static class OpenApiServiceExtensions
    {
        /// <summary>
        /// Instantiate an OK result with an object to return in the response body.
        /// </summary>
        /// <typeparam name="T">The type of the response body.</typeparam>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="result">The object to return in the response body.</param>
        /// <param name="contentType">The content type of the response (defaults to application/json).</param>
        /// <param name="auditData">Any additional audit data to add to the result.</param>
        /// <returns>An OpenApi result with the OK status code and the object in the response body against the relevant content type.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult OkResult<T>(this IOpenApiService service, T result, string contentType = "application/json", (string, object)[] auditData = null)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                Results = { { contentType, result } },
                AuditData = auditData?.ToDictionary(x => x.Item1, x => x.Item2),
            };
        }

        /// <summary>
        /// Instantiate an OK result without a response body.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="auditData">Any additional audit data to add to the result.</param>
        /// <returns>An OpenApi result with the OK status code.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult OkResult(this IOpenApiService service, (string, object)[] auditData = null)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                AuditData = auditData?.ToDictionary(x => x.Item1, x => x.Item2),
            };
        }

        /// <summary>
        /// Instantiate a Not Found result.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="auditData">Any additional audit data to add to the result.</param>
        /// <returns>An OpenApi result with the OK status code and the object in the response body against the relevant content type.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult NotFoundResult(this IOpenApiService service, (string, object)[] auditData = null)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                AuditData = auditData?.ToDictionary(x => x.Item1, x => x.Item2),
            };
        }

        /// <summary>
        /// Instantiate a Created result, with the specified location in a Location header.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="auditData">Any additional audit data to add to the result.</param>
        /// <returns>An OpenApi result with the Created status code and Location header.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult CreatedResult(this IOpenApiService service, (string, object)[] auditData = null)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Created,
                AuditData = auditData?.ToDictionary(x => x.Item1, x => x.Item2),
            };
        }

        /// <summary>
        /// Instantiate a Created result, with the specified location in a Location header.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="location">The location at which the object was created.</param>
        /// <param name="auditData">Any additional audit data to add to the result.</param>
        /// <returns>An OpenApi result with the Created status code and Location header.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult CreatedResult(this IOpenApiService service, string location, (string, object)[] auditData = null)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Created,
                Results = { { "Location", location } },
                AuditData = auditData?.ToDictionary(x => x.Item1, x => x.Item2),
            };
        }

        /// <summary>
        /// Instantiate a Created result, with the specified location in a Location header.
        /// </summary>
        /// <typeparam name="T">The type of the response body.</typeparam>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="location">The location at which the object was created.</param>
        /// <param name="result">The object to return in the response body.</param>
        /// <param name="contentType">The content type of the response (defaults to application/json).</param>
        /// <param name="auditData">Any additional audit data to add to the result.</param>
        /// <returns>An OpenApi result with the Created status code and the object in the response body against the relevant content type.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult CreatedResult<T>(this IOpenApiService service, string location, T result, string contentType = "application/json", (string, object)[] auditData = null)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Created,
                Results = { { "Location", location }, { contentType, result } },
                AuditData = auditData?.ToDictionary(x => x.Item1, x => x.Item2),
            };
        }

        /// <summary>
        /// Instantiate an Accepted result, with the specified location in a Location header.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="location">The location at which you can request status.</param>
        /// <param name="auditData">Any additional audit data to add to the result.</param>
        /// <returns>An OpenApi result with the Accepted status code and Location header.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult AcceptedResult(this IOpenApiService service, string location, (string, object)[] auditData = null)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Accepted,
                Results = { { "Location", location } },
                AuditData = auditData?.ToDictionary(x => x.Item1, x => x.Item2),
            };
        }

        /// <summary>
        /// Instantiate a Not Implemented result.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="auditData">Any additional audit data to add to the result.</param>
        /// <returns>An OpenApi result with the Not Implemented status code.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult NotImplementedResult(this IOpenApiService service, (string, object)[] auditData = null)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.NotImplemented,
                AuditData = auditData?.ToDictionary(x => x.Item1, x => x.Item2),
            };
        }
    }
}

#pragma warning restore RCS1175