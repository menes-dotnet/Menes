// <copyright file="IOpenApiExceptionMap.cs" company="Endjin Limited">
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
    public interface IOpenApiExceptionMap
    {
        /// <inheritdoc cref="Map{TException}" />
        /// <typeparam name="TException">
        ///     The type of exception that will be mapped.
        /// </typeparam>
        /// <typeparam name="TFormatter">
        ///     The type of formatter for the exception mapping.
        /// </typeparam>
        void Map<TException, TFormatter>(int statusCode, string? operationId = null)
            where TException : Exception
            where TFormatter : IExceptionMapper;

        /// <summary>
        ///     Maps a specific exception type to a response.
        /// </summary>
        /// <param name="statusCode">
        ///     The status code to map.
        /// </param>
        /// <param name="operationId">
        ///     The operation Id that this map applies to (optional).
        /// </param>
        /// <typeparam name="TException">
        ///     The type of exception that will be mapped.
        /// </typeparam>
        /// <remarks>
        ///     <para>
        ///         Mapping exception types to status codes provides a simple way to reduce the
        ///         need for error handling in your code. If executing your service method results
        ///         in a mapped exception being thrown, the exception will be handled and the specified
        ///         response code returned.
        ///     </para>
        ///     <para>
        ///         Note that if the mapped status code is not a valid response for the operation
        ///         being executed, a 500 status will be returned.
        ///     </para>
        ///     <para>
        ///         All unhandled errors will result in a 500 status being returned. For this reason,
        ///         you are not allowed to map any exception type to the 500 status code.
        ///     </para>
        /// </remarks>
        void Map<TException>(int statusCode, string? operationId = null)
            where TException : Exception;
    }
}