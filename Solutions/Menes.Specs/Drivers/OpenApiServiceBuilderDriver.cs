// <copyright file="OpenApiServiceBuilderDriver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Drivers
{
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;
    using Menes.OpenApi;
    using Menes.OpenApi.SchemaModel;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// A driver for the OpenApi Service Builder specs.
    /// </summary>
    public class OpenApiServiceBuilderDriver : IDisposable
    {
        private readonly IDocumentResolver documentResolver = new FileSystemDocumentResolver();
        private readonly IConfiguration configuration;
        private readonly OpenApiServiceBuilder builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiServiceBuilderDriver"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="builder">The <see cref="OpenApiServiceBuilder"/> instance to drive.</param>
        public OpenApiServiceBuilderDriver(IConfiguration configuration, OpenApiServiceBuilder builder)
        {
            this.configuration = configuration;
            this.builder = builder;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.documentResolver.Dispose();
        }

        /// <summary>
        /// Load the OpenApi document at the given location.
        /// </summary>
        /// <param name="inputFileNameOrUri">The input FileName or Reference that points to the open api document.</param>
        /// <returns>A <see cref="Task{T}"/> which provides the <see cref="Document"/> when complete.</returns>
        public async Task<Document> LoadOpenApiDocument(string inputFileNameOrUri)
        {
            JsonElement? result = await this.documentResolver.TryResolve(new JsonReference(inputFileNameOrUri)).ConfigureAwait(false);
            if (result is JsonElement doc)
            {
                var document = new Document(doc);
                if (!document.IsValid())
                {
                    throw new ArgumentException($"The document at '{inputFileNameOrUri}' is not a valid OpenApi document.", nameof(inputFileNameOrUri));
                }
            }

            throw new ArgumentException($"Unable to resolve the document at '{inputFileNameOrUri}'.", nameof(inputFileNameOrUri));
        }

        /// <summary>
        /// Builds the services found in the given Open API document.
        /// </summary>
        /// <param name="reference">The reference to the document for which to build services.</param>
        /// <returns>A <see cref="Task"/> which completes when the services are built.</returns>
        public async Task BuildServices(string reference)
        {
            await this.builder.BuildServices(reference).ConfigureAwait(false);
        }
    }
}
