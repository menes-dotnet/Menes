// <copyright file="OpenApiServiceDefinitions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.IO;
    using System.Reflection;
    using Menes.Exceptions;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;

    /// <summary>
    /// Methods for working with Open API service definitions.
    /// </summary>
    public static class OpenApiServiceDefinitions
    {
        /// <summary>
        /// Gets an Open API YAML file stored as an embedded resource.
        /// </summary>
        /// <typeparam name="T">The service type that has an Open API definition stored in a resource.</typeparam>
        /// <returns>The parsed document.</returns>
        public static OpenApiDocument GetOpenApiServiceFromEmbeddedDefinition<T>()
            where T : IOpenApiService
        {
            EmbeddedOpenApiDefinitionAttribute? attribute = typeof(T).GetCustomAttribute<EmbeddedOpenApiDefinitionAttribute>();
            if (attribute == null)
            {
                throw new ArgumentException(
                    $"Type {typeof(T).FullName} does not have the EmbeddedOpenApiDefinitionAttribute attribute", "T");
            }

            OpenApiDocument openApiDocument = ReadOpenApiServiceFromEmbeddedDefinitionWithDiagnostics(
                typeof(T).Assembly, attribute.ResourceName, out OpenApiDiagnostic diagnostics);

            if (diagnostics.Errors.Count > 0)
            {
                throw new OpenApiServiceMismatchException($"Errors reading the YAML file for service {typeof(T).FullName} at resource name attribute.ResourceName")
                    .AddProblemDetailsExtension("OpenApiErrors", diagnostics.Errors);
            }

            return openApiDocument;
        }

        /// <summary>
        /// Gets an Open API YAML file stored as an embedded resource.
        /// </summary>
        /// <param name="assembly">The assembly in which the resource is stored.</param>
        /// <param name="resourceName">The name of the embedded resource.</param>
        /// <returns>The parsed document.</returns>
        public static OpenApiDocument GetOpenApiServiceFromEmbeddedDefinition(
            Assembly assembly,
            string resourceName)
        {
            OpenApiDocument openApiDocument = ReadOpenApiServiceFromEmbeddedDefinitionWithDiagnostics(
                assembly, resourceName, out OpenApiDiagnostic diagnostics);

            if (diagnostics.Errors.Count > 0)
            {
                throw new OpenApiServiceMismatchException($"Errors reading the YAML file at resource name {resourceName}")
                    .AddProblemDetailsExtension("OpenApiErrors", diagnostics.Errors);
            }

            return openApiDocument;
        }

        /// <summary>
        /// Gets an Open API YAML file stored as an embedded resource, and returns parsing diagnostics.
        /// </summary>
        /// <param name="assembly">The assembly in which the resource is stored.</param>
        /// <param name="resourceName">The name of the embedded resource.</param>
        /// <param name="diagnostics">Diagnostics will be returned through this parameter.</param>
        /// <returns>The parsed document.</returns>
        public static OpenApiDocument ReadOpenApiServiceFromEmbeddedDefinitionWithDiagnostics(
            Assembly assembly,
            string resourceName,
            out OpenApiDiagnostic diagnostics)
        {
            using Stream stream = assembly.GetManifestResourceStream(resourceName)!;
            return new OpenApiStreamReader().Read(stream, out diagnostics);
        }
    }
}