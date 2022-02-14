// <copyright file="OpenApiNotFoundException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception which, when thrown from an <see cref="IOpenApiService"/> operation method,
    /// indicates that an HTTP 404 Not Found response should be returned.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This indicates that a request was made for a resource that does not exist.
    /// </para>
    /// </remarks>
    public class OpenApiNotFoundException : Exception
    {
        /// <summary>Creates an <see cref="OpenApiNotFoundException"/> with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <remarks>
        /// <para>
        /// This exception does not use the <see cref="OpenApiProblemDetailsExtensions"/> extension
        /// methods to populate the exception data with problem details, because attackers might
        /// probe the system, and providing detailed information about why something wasn't found
        /// can help them.
        /// </para>
        /// </remarks>
        public OpenApiNotFoundException(string message = "Resource not found")
            : base(message)
        {
        }

        /// <summary>
        /// Standard constructor for any derived exceptions.
        /// </summary>
        protected OpenApiNotFoundException()
        {
        }

        /// <summary>
        /// Standard constructor for any derived exceptions.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        protected OpenApiNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>Constructor used by .NET serialization infrastructure..</summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0).</exception>
        protected OpenApiNotFoundException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
        }
    }
}