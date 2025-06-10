// <copyright file="OpenApiServiceExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable RCS1175

namespace Menes
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Net;
    using Corvus.ContentHandling;
    using Menes.Links;

    /// <summary>
    /// Extension methods to help create responses for the OpenAPI service.
    /// </summary>
    public static class OpenApiServiceExtensions
    {
        /// <summary>
        /// Add audit data to an OpenAPI result.
        /// </summary>
        /// <param name="result">The result to which to add the audit data.</param>
        /// <param name="auditData">The audit data to add.</param>
        /// <returns>The <see cref="OpenApiResult"/> with audit data added.</returns>
        public static OpenApiResult WithAuditData(this OpenApiResult result, params (string, object)[] auditData)
        {
            result.AuditData = auditData.ToDictionary(x => x.Item1, x => x.Item2);
            return result;
        }

        /// <summary>
        /// Instantiate an OK result with an object to return in the response body.
        /// </summary>
        /// <typeparam name="T">The type of the response body.</typeparam>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="result">The object to return in the response body.</param>
        /// <param name="contentType">The content type of the response (defaults to application/json).</param>
        /// <returns>An OpenApi result with the OK status code and the object in the response body against the relevant content type.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult OkResult<T>(this IOpenApiService service, [DisallowNull] T result, string? contentType = null)
            where T : notnull
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                Results = { { GetContentType(result, contentType), result } },
            };
        }

        /// <summary>
        /// Instantiate an OK result without a response body.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <returns>An OpenApi result with the OK status code.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult OkResult(this IOpenApiService service)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.OK,
            };
        }

        /// <summary>
        /// Instantiate a Not Found result.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <returns>An OpenApi result with the NotFound status code.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult NotFoundResult(this IOpenApiService service)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.NotFound,
            };
        }

        /// <summary>
        /// Instantiate a Conflict result.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <returns>An OpenApi result with the Conflict status code.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult ConflictResult(this IOpenApiService service)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Conflict,
            };
        }

        /// <summary>
        /// Instantiate a Not Modified result.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <returns>An OpenApi result with the NotModified status code.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult NotModifiedResult(this IOpenApiService service)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.NotModified,
            };
        }

        /// <summary>
        /// Instantiate a Created result, with the specified location in a Location header.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <returns>An OpenApi result with the Created status code and Location header.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult CreatedResult(this IOpenApiService service)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Created,
            };
        }

        /// <summary>
        /// Instantiate a Created result, with the specified location in a Location header.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="location">The location at which the object was created.</param>
        /// <returns>An OpenApi result with the Created status code and Location header.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult CreatedResult(this IOpenApiService service, string location)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Created,
                Results = { { "Location", location } },
            };
        }

        /// <summary>
        /// Instantiate a Created result, with the specified location in a Location header.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="linkResolver">An openapi link resolver.</param>
        /// <param name="operationId">The operation ID.</param>
        /// <param name="parameters">The parameters for the link.</param>
        /// <returns>An OpenApi result with the Created status code and Location header.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult CreatedResult(
            this IOpenApiService service,
            IOpenApiWebLinkResolver linkResolver,
            string operationId,
            params (string, object?)[] parameters)
        {
            OpenApiWebLink link = linkResolver.ResolveByOperationIdAndRelationType(operationId, "self", parameters);
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Created,
                Results = { { "Location", link.Href } },
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
        /// <returns>An OpenApi result with the Created status code and the object in the response body against the relevant content type.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult CreatedResult<T>(
            this IOpenApiService service,
            string location,
            [DisallowNull] T result,
            string? contentType = null)
            where T : notnull
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Created,
                Results = { { "Location", location }, { GetContentType(result, contentType), result! } },
            };
        }

        /// <summary>
        /// Instantiate an Accepted result, with the specified location in a Location header.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <param name="location">The location at which you can request status.</param>
        /// <returns>An OpenApi result with the Accepted status code and Location header.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult AcceptedResult(this IOpenApiService service, string location)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Accepted,
                Results = { { "Location", location } },
            };
        }

        /// <summary>
        /// Instantiate a Not Implemented result.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <returns>An OpenApi result with the Not Implemented status code.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult NotImplementedResult(this IOpenApiService service)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.NotImplemented,
            };
        }

        /// <summary>
        /// Instantiate a Forbidden result.
        /// </summary>
        /// <param name="service">The open api service serving the response.</param>
        /// <returns>An OpenApi result with the Not Implemented status code.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "For symmetry with other extension methods")]
        public static OpenApiResult ForbiddenResult(this IOpenApiService service)
        {
            return new OpenApiResult
            {
                StatusCode = (int)HttpStatusCode.Forbidden,
            };
        }

        private static string GetContentType<T>(T instance, string? contentType)
            where T : notnull
        {
            return contentType ?? GetContentTypeOrNull(instance) ?? "application/json";
        }

        private static string? GetContentTypeOrNull<T>(T instance)
            where T : notnull
        {
            return ContentFactory.TryGetContentType(instance, out string? contentType) ? contentType : null;
        }
    }
}

#pragma warning restore RCS1175