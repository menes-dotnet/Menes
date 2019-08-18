// <copyright file="IOpenApiDocuments.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Collections.Generic;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// A collection of OpenAPI documents.
    /// </summary>
    public interface IOpenApiDocuments
    {
        /// <summary>
        /// Gets the list of OpenApi documents that have been added to this host.
        /// </summary>
        IReadOnlyList<OpenApiDocument> AddedOpenApiDocuments { get; }

        /// <summary>
        /// Add an OpenApi document to the path templates the path templates.
        /// </summary>
        /// <param name="document">The Open API document.</param>
        void Add(OpenApiDocument document);
    }
}