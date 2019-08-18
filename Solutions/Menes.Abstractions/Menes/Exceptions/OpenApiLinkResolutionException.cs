// <copyright file="OpenApiLinkResolutionException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Exceptions
{
    using System;

    /// <summary>
    /// Exception that represents a failure to resolve a named link relation to an OpenApi operation Url.
    /// </summary>
    [Serializable]
    public class OpenApiLinkResolutionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiLinkResolutionException"/> class.
        /// </summary>
        public OpenApiLinkResolutionException()
        {
            this.AddProblemDetails();
        }

        /// <summary>Initializes a new instance of the <see cref="OpenApiLinkResolutionException"/> class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public OpenApiLinkResolutionException(string message)
            : base(message)
        {
            this.AddProblemDetails();
        }

        /// <summary>Initializes a new instance of the <see cref="OpenApiLinkResolutionException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public OpenApiLinkResolutionException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.AddProblemDetails();
        }

        /// <summary>Initializes a new instance of the <see cref="OpenApiLinkResolutionException"/> class with the supplied information.</summary>
        /// <param name="relationType">The link relation type.</param>
        /// <param name="fullTypeName">The full type name of the owner of the link.</param>
        /// <param name="contentType">The content type of the owner.</param>
        public OpenApiLinkResolutionException(string relationType, string fullTypeName, string contentType)
            : base($"Unable to find the Operation Id link rel=\"{relationType}\" with owner of type \"{fullTypeName}\" and contentType \"{contentType ?? "not present"}\". Ensure you have registered an appropriate link map.")
        {
            this.RelationType = relationType;
            this.FullTypeName = fullTypeName;
            this.ContentType = contentType;
            this.AddProblemDetails();
        }

        /// <summary>Initializes a new instance of the <see cref="OpenApiLinkResolutionException"/> class with serialized data.</summary>
        /// <param name="info">The <see cref="System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null.</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0).</exception>
        protected OpenApiLinkResolutionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            this.AddProblemDetails();
        }

        /// <summary>Gets the link relation type.</summary>
        public string RelationType { get; }

        /// <summary>Gets the full type name of the owner of the link.</summary>
        public string FullTypeName { get; }

        /// <summary>Gets the content type of the owner.</summary>
        public string ContentType { get; }

        private void AddProblemDetails()
        {
            this.AddProblemDetailsTitle("Unable to resolve link");
            this.AddProblemDetailsExplanation(this.Message);
            this.AddProblemDetailsType("/endjin/openapi/errors/link/no-link-map-registered");

            if (!string.IsNullOrEmpty(this.RelationType))
            {
                this.AddProblemDetailsExtension("Link relation type", this.RelationType);
            }

            if (!string.IsNullOrEmpty(this.ContentType))
            {
                this.AddProblemDetailsExtension("Owner ContentType", this.ContentType);
            }

            if (!string.IsNullOrEmpty(this.FullTypeName))
            {
                this.AddProblemDetailsExtension("Owner CLR type", this.FullTypeName);
            }
        }
    }
}
