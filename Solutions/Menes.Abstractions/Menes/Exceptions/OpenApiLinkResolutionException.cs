// <copyright file="OpenApiLinkResolutionException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Exceptions
{
    using System;

    /// <summary>
    /// Exception that represents a failure to resolve a named link relation to an OpenApi operation Url.
    /// </summary>
    public class OpenApiLinkResolutionException : Exception
    {
        /// <summary>Initializes a new instance of the <see cref="OpenApiLinkResolutionException"/> class with the supplied information.</summary>
        /// <param name="relationType">The link relation type.</param>
        /// <param name="fullTypeName">The full type name of the owner of the link.</param>
        /// <param name="contentType">The content type of the owner.</param>
        public OpenApiLinkResolutionException(string relationType, string fullTypeName, string? contentType)
            : base($"Unable to find the Operation Id link rel=\"{relationType}\" with owner of type \"{fullTypeName}\" and contentType \"{contentType ?? "not present"}\". Ensure you have registered an appropriate link map.")
        {
            this.RelationType = relationType;
            this.FullTypeName = fullTypeName;
            this.ContentType = contentType;
            this.AddProblemDetails();
        }

        /// <summary>Gets the link relation type.</summary>
        public string RelationType { get; }

        /// <summary>Gets the full type name of the owner of the link.</summary>
        public string FullTypeName { get; }

        /// <summary>Gets the content type of the owner.</summary>
        public string? ContentType { get; }

        private void AddProblemDetails()
        {
            this.AddProblemDetailsTitle("Unable to resolve link");
            this.AddProblemDetailsExplanation(this.Message);
            this.AddProblemDetailsType("/endjin/openapi/errors/link/no-link-map-registered");

            this.AddProblemDetailsExtension("Link relation type", this.RelationType);

            if (!string.IsNullOrEmpty(this.ContentType))
            {
                this.AddProblemDetailsExtension("Owner ContentType", this.ContentType!); // ! required as netstandard2.0 lacks nullable attributes
            }

            this.AddProblemDetailsExtension("Owner CLR type", this.FullTypeName);
        }
    }
}
