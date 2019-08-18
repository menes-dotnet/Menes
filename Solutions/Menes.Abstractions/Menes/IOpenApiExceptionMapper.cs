// <copyright file="IOpenApiExceptionMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using Menes.ExceptionMappers;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Maps exceptions coming from the code to a specific OpenAPI repsonse.
    /// </summary>
    /// <remarks>
    /// <para>In general, you should avoid mapping exceptions globally, but target a particular <see cref="OpenApiOperation"/> by ID.</para>
    /// <para>You can also modify how particular exceptions are mapped to the response by implementing an <see cref="IExceptionMapper"/>. The defaults will handled POCOs and problem details objects (see <see cref="OpenApiProblemDetailsExtensions"/>).</para>
    /// </remarks>
    public interface IOpenApiExceptionMapper : IOpenApiExceptionMap
    {
        /// <summary>
        ///     Tries to map an exception/response combination to an <see cref="OpenApiResult"/>.
        /// </summary>
        /// <param name="exception">
        ///     The exception to map.
        /// </param>
        /// <param name="operation">
        ///     The operation that is being invoked.
        /// </param>
        /// <returns>
        ///     An OpenApi result for the exception/operation.
        /// </returns>
        OpenApiResult GetResponse(Exception exception, OpenApiOperation operation);
    }
}