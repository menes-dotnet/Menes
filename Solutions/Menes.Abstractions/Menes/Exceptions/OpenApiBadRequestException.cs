// <copyright file="OpenApiBadRequestException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Exceptions
{
    using System;

    /// <summary>
    /// An exception which, when thrown from an <see cref="IOpenApiService"/> operation method,
    /// indicates that an HTTP 400 Bad Request response should be returned.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A strict interpretation of the HTTP specification indicates that a 400 should only be
    /// returned if there is a syntax problem with the request. However, it doesn't define a
    /// status code for "syntactically well-formed, but utter nonsense". WebDAV does define a
    /// response that means that (422 Unprocessable Entity) but it's not all that widely used,
    /// and isn't technically HTTP compliant. RFC 7231 has codified the widespread practice of
    /// a more broad interpretation of 400, meaning "something is wrong in your request", so
    /// although that's also not strictly HTTP compliant, it is an officially recognized and
    /// widely used deviation from the original HTTP spec.
    /// </para>
    /// </remarks>
    public class OpenApiBadRequestException : Exception
    {
        /// <summary>
        /// Creates an <see cref="OpenApiBadRequestException"/> suitable for use in OpenApi
        /// operations in which the corresponding 400 response in the service definition does not
        /// define a response body.
        /// </summary>
        /// <param name="message">
        /// The value for this exception's <see cref="Exception.Message"/> property.
        /// </param>
        public OpenApiBadRequestException(string message = "Bad request")
            : base(message)
        {
        }

        /// <summary>
        /// Creates an <see cref="OpenApiBadRequestException"/> suitable for use in OpenApi
        /// operations in which the corresponding 400 response in the service definition defines
        /// a response body containing a Problem Details structure.
        /// </summary>
        /// <param name="title">
        /// A short description of the error. This is used as the <see cref="Exception.Message"/>
        /// property, and will also be returned in the Problem Details in the response body.
        /// </param>
        /// <param name="explanation">
        /// A longer description of the problem. This is returned in the Problem Details in the
        /// response body.
        /// </param>
        /// <param name="detailsType">
        /// An optional URI identifying the problem type. If specified, this is returned in the
        /// Problem Details in the response body.
        /// response body.
        /// </param>
        /// <param name="detailsInstance">
        /// An optional URI identifying the problem instance. If specified, this is returned in the
        /// Problem Details in the response body.
        /// </param>
        /// <remarks>
        /// <para>
        /// This exception does not use the <see cref="OpenApiProblemDetailsExtensions"/> extension
        /// methods to populate the exception data with problem details, because explaining to
        /// attackers exactly why you didn't like their token makes their lives easier. We take
        /// a description of what is wrong with the credentials to enable problems to be logged,
        /// and it may be appropriate for these messages to be visible to an administrator or to
        /// support personnel, but it should not be included in the response to the client.
        /// </para>
        /// </remarks>
        public OpenApiBadRequestException(
            string title,
            string explanation,
            string? detailsType = null,
            string? detailsInstance = null)
            : base(title)
        {
            this.AddProblemDetailsTitle(title);

            this.Explanation = explanation;
            this.AddProblemDetailsExplanation(explanation);

            if (detailsType != null)
            {
                this.DetailsType = detailsType;
                this.AddProblemDetailsType(detailsType);
            }

            if (detailsInstance != null)
            {
                this.DetailsInstance = detailsInstance;
                this.AddProblemDetailsInstance(detailsInstance);
            }
        }

        /// <summary>
        /// Gets the detailed explanation of the problem, if present.
        /// </summary>
        public string? Explanation { get; }

        /// <summary>
        /// Gets the URI identifying the problem type, if present.
        /// </summary>
        public string? DetailsType { get; }

        /// <summary>
        /// Gets the URI identifying the problem instance, if present.
        /// </summary>
        public string? DetailsInstance { get; }
    }
}
