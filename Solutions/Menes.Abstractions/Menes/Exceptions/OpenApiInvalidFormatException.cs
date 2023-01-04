// <copyright file="OpenApiInvalidFormatException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Exceptions
{
    using System;

    /// <summary>
    /// An exception that indicates that data has been found not to be in the format required
    /// by an OpenAPI specification.
    /// </summary>
    /// <remarks>
    /// <para>
    /// We share validation code across multiple contexts (validation of inputs, default values
    /// in an Open API spec, and outputs) and the required externally visible behaviour depends on
    /// the context in which the problem is detected. The common layer needs to be able to throw
    /// an exception indicating only that a problem has been detected, and this then needs to be
    /// turned into a more suitable exception by the higher layers of code.
    /// </para>
    /// </remarks>
    public class OpenApiInvalidFormatException : Exception
    {
        /// <summary>
        /// Creates an <see cref="OpenApiInvalidFormatException"/>.
        /// </summary>
        /// <param name="message">
        /// The value for this exception's <see cref="Exception.Message"/> property.
        /// </param>
        public OpenApiInvalidFormatException(string message = "Bad request")
            : base(message)
        {
        }

        /// <summary>
        /// Creates an <see cref="OpenApiInvalidFormatException"/>.
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
        public OpenApiInvalidFormatException(
            string title,
            string explanation,
            string? detailsType = null,
            string? detailsInstance = null)
            : base(title)
        {
            this.Explanation = explanation;
            this.DetailsType = detailsType;
            this.DetailsInstance = detailsInstance;
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