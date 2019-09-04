// <copyright file="OpenApiHostConfiguration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    /// <summary>
    /// Provides the means to configure the OpenApi service host.
    /// </summary>
    public class OpenApiHostConfiguration : IOpenApiHostConfiguration
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

        /// <inheritdoc/>
        public IOpenApiDocuments Documents { get; }

        /// <inheritdoc/>
        public IOpenApiExceptionMap Exceptions { get; }

        /// <inheritdoc/>
        public IOpenApiLinkOperationMap Links { get; }
    }
}
