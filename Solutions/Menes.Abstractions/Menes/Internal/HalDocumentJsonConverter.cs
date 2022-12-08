// <copyright file="HalDocumentJsonConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using System.Text.Json.Serialization;

    using Menes.Hal;
    using Menes.Links;

    /// <summary>
    /// A type converter for serializing a <see cref="HalDocument"/> as a standard
    /// HAL document.
    /// </summary>
    public class HalDocumentJsonConverter : JsonConverter<HalDocument>
    {
        private readonly IHalDocumentFactory halDocumentFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="HalDocumentJsonConverter"/> class.
        /// </summary>
        /// <param name="halDocumentFactory">The <see cref="IHalDocumentFactory"/>.</param>
        public HalDocumentJsonConverter(IHalDocumentFactory halDocumentFactory)
        {
            this.halDocumentFactory = halDocumentFactory;
        }

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return typeof(HalDocument).IsAssignableFrom(objectType);
        }

        /// <inheritdoc/>
        public override HalDocument? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (typeToConvert != typeof(HalDocument))
            {
                throw new ArgumentException(
                    $"Unable to create new {typeToConvert.Name} - only {nameof(HalDocument)} is supported",
                    nameof(typeToConvert));
            }

            var jobject = (JsonObject)JsonNode.Parse(ref reader)!;
            HalDocument halDocument = this.halDocumentFactory.CreateHalDocument();

            DeserializeLinks(options, jobject, halDocument);
            DeserializeEmbeddedResources(options, jobject, halDocument);

            jobject.Remove("_embedded");
            jobject.Remove("_links");

            halDocument.Properties = jobject;

            return halDocument;
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, HalDocument value, JsonSerializerOptions options)
        {
            JsonObject result = value.PropertiesInternalNullable is JsonObject props
                ? (JsonObject)JsonNode.Parse(props.ToJsonString())!
                : new JsonObject();

            SerializeLinks(value, result, options);
            SerializeEmbeddedResources(value, result, options);

            result.WriteTo(writer);
        }

        private static void SerializeLinks(HalDocument halDocument, JsonObject result, JsonSerializerOptions serializerOptions)
        {
            var linksObject = new JsonObject();

            foreach (string relation in halDocument.GetLinkRelations())
            {
                WebLink[] links = halDocument.GetLinksForRelation(relation).ToArray();
                if (links.Length == 0)
                {
                    continue;
                }

                if (links.Length == 1)
                {
                    using MemoryStream ms = new();
                    JsonSerializer.Serialize(ms, links[0], serializerOptions);
                    ms.Position = 0;
                    linksObject.Add(relation, JsonNode.Parse(ms));
                }
                else
                {
                    var linksArray = new JsonArray();
                    foreach (JsonNode? link in linksArray)
                    {
                        using MemoryStream ms = new();
                        JsonSerializer.Serialize(ms, links[0], serializerOptions);
                        ms.Position = 0;
                        linksArray.Add(JsonNode.Parse(ms));
                    }

                    linksObject.Add(relation, linksArray);
                }
            }

            if (linksObject.Count != 0)
            {
                result.Add("_links", linksObject);
            }
        }

        private static void SerializeEmbeddedResources(HalDocument halDocument, JsonObject result, JsonSerializerOptions serializer)
        {
            var embeddedResourcesObject = new JsonObject();

            foreach (string relation in halDocument.GetEmbeddedResourceRelations())
            {
                HalDocument[] embeddedResources = halDocument.GetEmbeddedResourcesForRelation(relation).ToArray();
                if (embeddedResources.Length == 0)
                {
                    continue;
                }

                if (embeddedResources.Length == 1)
                {
                    using MemoryStream ms = new();
                    JsonSerializer.Serialize(ms, embeddedResources[0], serializer);
                    ms.Position = 0;

                    embeddedResourcesObject.Add(relation, JsonNode.Parse(ms));
                }
                else
                {
                    var embeddedResourcesArray = new JsonArray();
                    foreach (HalDocument embeddedResource in embeddedResources)
                    {
                        using MemoryStream ms = new();
                        JsonSerializer.Serialize(ms, embeddedResources[0], serializer);
                        ms.Position = 0;
                        embeddedResourcesArray.Add(JsonNode.Parse(ms));
                    }

                    embeddedResourcesObject.Add(relation, embeddedResourcesArray);
                }
            }

            if (embeddedResourcesObject.Count != 0)
            {
                result.Add("_embedded", embeddedResourcesObject);
            }
        }

        private static void DeserializeLinks(JsonSerializerOptions options, JsonObject jobject, HalDocument halDocument)
        {
            var links = (JsonObject?)jobject["_links"];
            if (links != null)
            {
                foreach (KeyValuePair<string, JsonNode?> link in links)
                {
                    if (link.Value is JsonArray array)
                    {
                        foreach (JsonNode? linkItem in array)
                        {
                            WebLink weblink = linkItem.Deserialize<WebLink>(options)!;
                            halDocument.AddLink(link.Key, weblink);
                        }
                    }
                    else
                    {
                        WebLink weblink = link.Value.Deserialize<WebLink>(options)!;
                        halDocument.AddLink(link.Key, weblink);
                    }
                }
            }
        }

        private static void DeserializeEmbeddedResources(JsonSerializerOptions options, JsonObject jobject, HalDocument halDocument)
        {
            var resources = (JsonObject?)jobject["_embedded"];
            if (resources != null)
            {
                foreach (KeyValuePair<string, JsonNode?> resource in resources)
                {
                    if (resource.Value is JsonArray array)
                    {
                        foreach (JsonNode? resourceItem in array)
                        {
                            halDocument.AddEmbeddedResource(resource.Key, resourceItem.Deserialize<HalDocument>(options)!);
                        }
                    }
                    else
                    {
                        halDocument.AddEmbeddedResource(resource.Key, resource.Value.Deserialize<HalDocument>(options)!);
                    }
                }
            }
        }
    }
}