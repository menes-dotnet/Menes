// <copyright file="SchemaResolver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Resolves a schema reference to a schema.
    /// </summary>
    public class SchemaResolver : ISchemaResolver
    {
        /// <summary>
        /// Gets the default schema resolver.
        /// </summary>
        public static readonly ISchemaResolver Default = new SchemaResolver(Schema.DocumentResolver.Default);
        private readonly ConcurrentDictionary<string, JsonDocument> resolvedDocuments = new ConcurrentDictionary<string, JsonDocument>();
        private readonly ConcurrentDictionary<string, (string, JsonDocument, JsonSchema)> resolvedSchemas = new ConcurrentDictionary<string, (string, JsonDocument, JsonSchema)>();
        private readonly Stack<string> referencesBeingResolved = new Stack<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaResolver"/> class.
        /// </summary>
        /// <param name="documentResolver">The document resolver to use.</param>
        public SchemaResolver(IDocumentResolver documentResolver)
        {
            this.DocumentResolver = documentResolver;
        }

        /// <inheritdoc/>
        public IDocumentResolver DocumentResolver { get; }

        /// <inheritdoc/>
        public void Reset()
        {
            this.resolvedDocuments.Clear();
            this.resolvedSchemas.Clear();
            this.DocumentResolver.Reset();
        }

        /// <inheritdoc/>
        public async Task<(string, JsonDocument, JsonSchema)> LoadSchema(JsonRef jsonRef)
        {
            if (this.resolvedSchemas.TryGetValue(jsonRef.ToString(), out (string, JsonDocument, JsonSchema) result))
            {
                return result;
            }

            JsonDocument? rootDocument = await this.ResolveDocumentAndFindAnchors(jsonRef).ConfigureAwait(false);

            if (!(rootDocument is JsonDocument))
            {
                throw new InvalidOperationException($"Unable to resolve {jsonRef}");
            }

            if (this.resolvedSchemas.TryGetValue(jsonRef.ToString(), out (string, JsonDocument, JsonSchema) result2))
            {
                return result2;
            }

            return await this.Resolve(jsonRef, rootDocument, resolveReferences: false).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<(string, JsonDocument, JsonSchema)> Resolve(string baseUri, JsonDocument rootDocument, JsonSchema schema)
        {
            if (!(schema.Ref is JsonString jsonRef))
            {
                if (schema.Id is JsonString id)
                {
                    string combiningUri = new JsonRef(id).Uri.ToString();
                    if (baseUri != combiningUri)
                    {
                        baseUri = CombineUris(baseUri, combiningUri);
                    }
                }

                return (baseUri, rootDocument, schema);
            }

            var reference = new JsonRef(jsonRef);
            if (!reference.HasUri)
            {
                reference = reference.WithUri(baseUri);
            }
            else
            {
                string combiningUri = reference.Uri.ToString();
                if (baseUri != combiningUri)
                {
                    reference = reference.WithUri(CombineUris(baseUri, combiningUri));
                }
            }

            if (this.resolvedSchemas.TryGetValue(jsonRef, out (string, JsonDocument, JsonSchema) result))
            {
                if (result.Item3.Ref is JsonString cachedChildRef && !this.referencesBeingResolved.Contains(cachedChildRef))
                {
                    result = await this.Resolve(result.Item1, result.Item2, result.Item3).ConfigureAwait(false);
                }

                return result;
            }

            this.referencesBeingResolved.Push(reference.ToString());
            result = await this.Resolve(reference, rootDocument).ConfigureAwait(false);
            this.referencesBeingResolved.Pop();
            return result;
        }

        /// <inheritdoc/>
        public void AddSchema(string baseUri, JsonDocument root, JsonSchema schema)
        {
            this.FindAnchors(baseUri, root, schema.HasJsonElement ? schema.JsonElement : JsonAny.From(schema).JsonElement);
            this.resolvedDocuments.TryAdd(baseUri, root);
            (string, JsonDocument document, JsonSchema) result = (baseUri, root, schema);
            this.resolvedSchemas.TryAdd(baseUri, result);
        }

        private static string CombineUris(string baseUri, string combiningUri)
        {
            var originalUri = new Uri(baseUri, UriKind.RelativeOrAbsolute);
            var newUri = new Uri(combiningUri, UriKind.RelativeOrAbsolute);

            if (originalUri.IsAbsoluteUri && !newUri.IsAbsoluteUri)
            {
                return new Uri(originalUri, newUri).ToString();
            }

            return combiningUri;
        }

        private async Task<(string, JsonDocument, JsonSchema)> Resolve(JsonRef reference, JsonDocument rootDocument, bool resolveReferences = true)
        {
            JsonDocument? document = rootDocument;
            if (reference.HasUri)
            {
                document = await this.ResolveDocumentAndFindAnchors(reference).ConfigureAwait(false);
            }

            if (document is null)
            {
                throw new JsonSchemaException($"Unable to resolve the document at URI {reference.Uri.ToString()}");
            }

            string referenceString = reference.ToString();

            if (this.resolvedSchemas.TryGetValue(referenceString, out (string, JsonDocument, JsonSchema) cachedResult))
            {
                if (resolveReferences && cachedResult.Item3.Ref is JsonString cachedChildRef && !this.referencesBeingResolved.Contains(cachedChildRef))
                {
                    cachedResult = await this.Resolve(cachedResult.Item1, cachedResult.Item2, cachedResult.Item3).ConfigureAwait(false);
                }

                return cachedResult;
            }

            (string, JsonDocument document, JsonSchema) result = (reference.Uri.ToString(), document, this.ResolveSchema(document, reference));
            this.resolvedSchemas.TryAdd(reference.ToString(), result);

            if (resolveReferences && result.Item3.Ref is JsonString childRef && !this.referencesBeingResolved.Contains(childRef))
            {
                result = await this.Resolve(result.Item1, result.Item2, result.Item3).ConfigureAwait(false);
            }

            return result;
        }

        private async Task<JsonDocument?> ResolveDocumentAndFindAnchors(JsonRef reference)
        {
            string referenceUri = reference.Uri.ToString();

            if (this.resolvedDocuments.TryGetValue(referenceUri, out JsonDocument value))
            {
                return value;
            }

            JsonDocument? result = await this.DocumentResolver.TryResolveDocument(reference).ConfigureAwait(false);
            if (result is null)
            {
                return result;
            }

            this.FindAnchors(referenceUri, result, result.RootElement);

            this.resolvedDocuments.TryAdd(referenceUri, result);

            return result;
        }

        private void FindAnchors(string baseUri, JsonDocument root, JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Object)
            {
                if (element.TryGetProperty("$id", out JsonElement id))
                {
                    // Switch the base URI context if we have an ID
                    var jsonRef = new JsonRef(id.GetString());
                    if (jsonRef.HasUri)
                    {
                        string combiningUri = jsonRef.Uri.ToString();

                        if (baseUri != combiningUri)
                        {
                            baseUri = CombineUris(baseUri, combiningUri);
                            this.DocumentResolver.AddDocument(baseUri, root);
                            this.resolvedSchemas.TryAdd(new JsonRef(baseUri, jsonRef.Pointer).ToString(), (baseUri, root, new JsonSchema(element)));
                            this.resolvedDocuments.TryAdd(baseUri, root);
                        }
                    }
                }

                JsonElement.ObjectEnumerator enumerator = element.EnumerateObject();
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.NameEquals("$anchor"))
                    {
                        this.resolvedSchemas.TryAdd(new JsonRef(baseUri, enumerator.Current.Value.GetString()).ToString(), (baseUri, root, new JsonSchema(element)));
                    }
                    else
                    {
                        this.FindAnchors(baseUri, root, enumerator.Current.Value);
                    }
                }
            }
            else if (element.ValueKind == JsonValueKind.Array)
            {
                JsonElement.ArrayEnumerator enumerator = element.EnumerateArray();
                while (enumerator.MoveNext())
                {
                    this.FindAnchors(baseUri, root, enumerator.Current);
                }
            }
        }

        private JsonSchema ResolveSchema(JsonDocument document, JsonRef reference)
        {
            JsonSchema schema;
            if (reference.HasPointer)
            {
                schema = new JsonSchema(JsonPointer.ResolvePointer(document.RootElement, reference.Pointer));
            }
            else
            {
                schema = new JsonSchema(document.RootElement);
            }

            return schema;
        }
    }
}
