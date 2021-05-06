// <copyright file="OpenApiActionResult.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Menes.Converters;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An <see cref="ActionResult"/> for <see cref="OpenApiResult"/> instances.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Given an <see cref="OpenApiResult"/> and an <see cref="OpenApiOperation"/>, this validates
    /// that the result conforms to the requirements of the operation, and then writes the result to the
    /// appropriate parts of the response (e.g. headers, response body).
    /// </para>
    /// <para>
    /// CAVEAT: It does not currently support writing cookies.
    /// </para>
    /// </remarks>
    internal sealed class OpenApiActionResult : ActionResult
    {
        private readonly OpenApiHttpResponseResult httpResponseResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiActionResult"/> class.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        private OpenApiActionResult(
            OpenApiResult openApiResult,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
        {
            this.httpResponseResult = new OpenApiHttpResponseResult(
                openApiResult, operation, converters, logger);
        }

        /// <inheritdoc/>
        public override Task ExecuteResultAsync(ActionContext context)
        {
            return this.httpResponseResult.ExecuteResultAsync(context.HttpContext.Response);
        }

        /// <summary>
        /// Creates a new <see cref="OpenApiActionResult"/> from an <see cref="OpenApiResult"/>.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        /// <returns>A new <see cref="OpenApiActionResult"/>.</returns>
        internal static OpenApiActionResult FromOpenApiResult(
            OpenApiResult openApiResult,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
            => new OpenApiActionResult(openApiResult, operation, converters, logger);

        /// <summary>
        /// Creates a new <see cref="OpenApiActionResult"/> from a plain object.
        /// </summary>
        /// <param name="result">The result object, or null.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="converters">The OpenAPI converters to use.</param>
        /// <param name="logger">A logger for the operation.</param>
        /// <returns>A new <see cref="OpenApiActionResult"/>.</returns>
        internal static OpenApiActionResult FromPoco(
            object result,
            OpenApiOperation operation,
            IEnumerable<IOpenApiConverter> converters,
            ILogger logger)
            => new OpenApiActionResult(GetOpenApiResultForPoco(result, operation, logger), operation, converters, logger);

        /// <summary>
        /// Determines if the action result can be constructed from the provided result and operation definition.
        /// </summary>
        /// <param name="poco">The poco from which to attempt to construct a result.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <returns>True if an action result can be constructed from this operation result.</returns>
        internal static bool CanConstructFrom(object poco, OpenApiOperation operation, ILogger logger)
        {
            return CanConstructFrom(GetOpenApiResultForPoco(poco, operation, logger), operation);
        }

        /// <summary>
        /// Determines if the action result can be constructed from the provided result and operation definition.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <param name="operation">The OpenAPI operation definition.</param>
        /// <returns>True if an action result can be constructed from this operation result.</returns>
        internal static bool CanConstructFrom(OpenApiResult openApiResult, OpenApiOperation operation)
        {
            return OpenApiHttpResponseResult.CanConstructFrom(openApiResult, operation);
        }

        /// <summary>
        /// Builds an <see cref="OpenApiResult"/> for a POCO.
        /// </summary>
        /// <param name="result">
        /// The POCO result returned by the underlying operation implementation.
        /// </param>
        /// <param name="operation">
        /// The OpenAPI operation that was invoked.
        /// </param>
        /// <param name="logger">A logger.</param>
        /// <returns>An <see cref="OpenApiResult"/>.</returns>
        internal static OpenApiResult GetOpenApiResultForPoco(object result, OpenApiOperation operation, ILogger logger)
        {
            return OpenApiHttpResponseResult.GetOpenApiResultForPoco(result, operation, logger);
        }
    }
}