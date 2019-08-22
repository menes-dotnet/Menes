// <copyright file="OpenApiHostConfiguration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Provides the means to configure the OpenApi service.
    /// </summary>
    public class OpenApiHostConfiguration
    {
        /// <summary>
        /// Creates an instance of the <see cref="OpenApiHostConfiguration"/>.
        /// </summary>
        /// <param name="documents">The document collection.</param>
        /// <param name="exceptionMap">The exception map.</param>
        /// <param name="linkMap">The link map.</param>
        public OpenApiHostConfiguration(IOpenApiDocuments documents, IOpenApiExceptionMap exceptionMap, IOpenApiLinkOperationMap linkMap)
        {
            this.Documents = documents;
            this.Exceptions = exceptionMap;
            this.Links = linkMap;
        }

        /// <summary>
        /// Gets the document provider.
        /// </summary>
        public IOpenApiDocuments Documents { get; }

        /// <summary>
        /// Gets the exception mapper.
        /// </summary>
        public IOpenApiExceptionMap Exceptions { get; }

        /// <summary>
        /// Gets the operation link mapper.
        /// </summary>
        public IOpenApiLinkOperationMap Links { get; }
    }
}
