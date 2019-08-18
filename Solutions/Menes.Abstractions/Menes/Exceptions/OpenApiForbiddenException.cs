// <copyright file="OpenApiForbiddenException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception which, when thrown from an <see cref="IOpenApiService"/> operation method,
    /// indicates that an HTTP 403 Forbidden response should be returned.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This typically indicates that the client has successfully authenticated, and that the
    /// service has determined that the client is not allowed to do whatever it is trying to do.
    /// </para>
    /// </remarks>
    public class OpenApiForbiddenException : Exception
    {
        /// <summary>
        /// Standard constructor for any derived exceptions.
        /// </summary>
        protected OpenApiForbiddenException()
        {
        }

        /// <summary>
        /// Standard constructor for any derived exceptions.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        protected OpenApiForbiddenException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>Constructor used by .NET serialization infrastructure..</summary>
        /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null.</exception>
        /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0).</exception>
        protected OpenApiForbiddenException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>Creates a <see cref="OpenApiForbiddenException"/> with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        private OpenApiForbiddenException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create an <see cref="OpenApiForbiddenException"/> without any problem details attached.
        /// </summary>
        /// <param name="message">
        /// A description of the error that will not be reported back to the client. (It will be
        /// visible only within the server, and may be useful for diagnostic purposes.)
        /// </param>
        /// <returns>A new <see cref="OpenApiForbiddenException"/>.</returns>
        public static OpenApiForbiddenException WithoutProblemDetails(string message) => new OpenApiForbiddenException(message);

        /// <summary>
        /// Create an <see cref="OpenApiForbiddenException"/> without any problem details attached.
        /// </summary>
        /// <param name="title">
        /// A description of the error that will be reported back to the client as the title of a
        /// Problem Details structure in the response body. This is also used as the exception's
        /// <c>Message</c> property.
        /// </param>
        /// <param name="explanation">
        /// An optional, more detailed explanation of the problem. If specified, this will be
        /// included Problem Details structure in the response body.
        /// </param>
        /// <returns>A new <see cref="OpenApiForbiddenException"/>.</returns>
        public static OpenApiForbiddenException WithProblemDetails(
            string title,
            string explanation = null)
        {
            var result = new OpenApiForbiddenException(title);
            result.AddProblemDetailsTitle(title);
            if (explanation != null)
            {
                result.AddProblemDetailsExplanation(explanation);
            }

            return result;
        }
    }
}
