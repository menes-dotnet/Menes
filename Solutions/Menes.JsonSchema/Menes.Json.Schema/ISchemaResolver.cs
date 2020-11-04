// <copyright file="ISchemaResolver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Resolves a schema reference to a schema.
    /// </summary>
    public interface ISchemaResolver
    {
        /// <summary>
        /// Gets the dociument resolver for the schema resolver.
        /// </summary>
        IDocumentResolver DocumentResolver { get; }

        /// <summary>
        /// Resolve a schema which has a reference.
        /// </summary>
        /// <param name="baseUri">The ambient base URI.</param>
        /// <param name="rootDocument">The root document.</param>
        /// <param name="schema">The schema to resolve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<(string, JsonDocument, JsonSchema)> Resolve(string baseUri, JsonDocument rootDocument, JsonSchema schema);

        /// <summary>
        /// Load a schema at a given reference.
        /// </summary>
        /// <param name="jsonRef">The json reference at which to load the schema.</param>
        /// <returns>A <see cref="Task{T}"/> which when complete provides the base URI, document and schema triple.</returns>
        Task<(string, JsonDocument, JsonSchema)> LoadSchema(JsonRef jsonRef);

        /// <summary>
        /// Reset the schema resolver.
        /// </summary>
        void Reset();

        /// <summary>
        ///  Manualy add a schema to the schema resolver.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="root">The root document.</param>
        /// <param name="schema">The schema to add.</param>
        void AddSchema(string baseUri, JsonDocument root, JsonSchema schema);
    }
}