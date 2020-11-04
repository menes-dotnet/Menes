// <copyright file="SchemaResolver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System;
    using System.Collections.Concurrent;
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

            return await this.Resolve(jsonRef, rootDocument).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<(string, JsonDocument, JsonSchema)> Resolve(string baseUri, JsonDocument rootDocument, JsonSchema schema)
        {
            if (!(schema.Ref is JsonString jsonRef))
            {
                return (baseUri, rootDocument, schema);
            }

            var reference = new JsonRef(jsonRef);
            if (!reference.HasUri)
            {
                reference = reference.WithUri(baseUri);
            }
            else
            {
                reference = reference.WithUri(CombineUris(baseUri, reference.Uri.ToString()));
            }

            if (this.resolvedSchemas.TryGetValue(jsonRef, out (string, JsonDocument, JsonSchema) result))
            {
                return result;
            }

            return await this.Resolve(reference, rootDocument).ConfigureAwait(false);
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
                var builder = new UriBuilder(originalUri.Scheme, originalUri.Host, originalUri.Port)
                {
                    Path = newUri.ToString(),
                };
                return builder.ToString();
            }

            return combiningUri;
        }

        private async Task<(string, JsonDocument, JsonSchema)> Resolve(JsonRef reference, JsonDocument rootDocument)
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

            if (this.resolvedSchemas.TryGetValue(reference.ToString(), out (string, JsonDocument, JsonSchema) cachedResult))
            {
                return cachedResult;
            }

            (string, JsonDocument document, JsonSchema) result = (reference.Uri.ToString(), document, this.ResolveSchema(document, reference));
            this.resolvedSchemas.TryAdd(reference.ToString(), result);
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
                        baseUri = CombineUris(baseUri, jsonRef.Uri.ToString());
                        this.DocumentResolver.AddDocument(baseUri, root);
                        this.resolvedDocuments.TryAdd(baseUri, root);
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
