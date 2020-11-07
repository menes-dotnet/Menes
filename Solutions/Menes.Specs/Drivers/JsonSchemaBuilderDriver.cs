// <copyright file="JsonSchemaBuilderDriver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Drivers
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;
    using Menes.Json.Schema;
    using Menes.JsonSchema.TypeBuilder;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// A driver for specs for the <see cref="JsonSchemaBuilder"/>.
    /// </summary>
    public class JsonSchemaBuilderDriver : IDisposable
    {
        private readonly IConfiguration configuration;
        private readonly JsonSchemaBuilder builder;
        private readonly IDocumentResolver documentResolver = new FileSystemDocumentResolver();

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaBuilderDriver"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="builder">The <see cref="JsonSchemaBuilder"/> instance to drive.</param>
        public JsonSchemaBuilderDriver(IConfiguration configuration, JsonSchemaBuilder builder)
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
        /// Get the <see cref="JsonElement"/> at the given reference location.
        /// </summary>
        /// <param name="filename">The name of the file containing the element.</param>
        /// <param name="referenceFragment">The local reference to the element in the file.</param>
        /// <returns>The element, found in the specified document.</returns>
        public Task<JsonElement?> GetElement(string filename, string referenceFragment)
        {
            string baseDirectory = this.configuration["jsonSchemaBuilderDriverSettings:testBaseDirectory"];
            string path = Path.Combine(baseDirectory, filename);
            return this.documentResolver.TryResolve(new JsonReference(path, referenceFragment));
        }
    }
}
