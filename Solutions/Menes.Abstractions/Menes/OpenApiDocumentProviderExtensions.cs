// <copyright file="OpenApiDocumentProviderExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Reflection;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Extension methods to add embedded document definition support to the <see cref="IOpenApiDocumentProvider"/>.
    /// </summary>
    public static class OpenApiDocumentProviderExtensions
    {
        /// <summary>
        /// Registers an Open API YAML file stored as an embedded resource.
        /// </summary>
        /// <typeparam name="T">The service type for which to register the Open API definition.</typeparam>
        /// <param name="documents">The Open API documents registry.</param>
        public static void RegisterOpenApiServiceWithEmbeddedDefinition<T>(
            this IOpenApiDocuments documents)
            where T : IOpenApiService
        {
            OpenApiDocument openApiDocument = OpenApiServiceDefinitions.GetOpenApiServiceFromEmbeddedDefinition<T>();
            documents.Add(openApiDocument);
        }

        /// <summary>
        /// Registers an Open API YAML file stored as an embedded resource.
        /// </summary>
        /// <param name="documents">The Open API documents registry.</param>
        /// <param name="assembly">The assembly in which the resource is stored.</param>
        /// <param name="resourceName">The name of the embedded resource.</param>
        public static void RegisterOpenApiServiceWithEmbeddedDefinition(
            this IOpenApiDocuments documents,
            Assembly assembly,
            string resourceName)
        {
            OpenApiDocument openApiDocument = OpenApiServiceDefinitions.GetOpenApiServiceFromEmbeddedDefinition(assembly, resourceName);
            documents.Add(openApiDocument);
        }
    }
}