// <copyright file="HalDocumentJsonConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Menes.Hal;
    using Menes.Links;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A type converter for serializing a <see cref="HalDocument"/> as a standard
    /// HAL document.
    /// </summary>
    public class HalDocumentJsonConverter : CustomCreationConverter<HalDocument>
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
        public override bool CanRead => false;

        /// <inheritdoc/>
        public override bool CanWrite => true;

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return typeof(HalDocument).IsAssignableFrom(objectType);
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jobject = JObject.Load(reader);
            HalDocument halDocument = this.halDocumentFactory.CreateHalDocument();

            DeserializeLinks(serializer, jobject, halDocument);
            DeserializeEmbeddedResources(serializer, jobject, halDocument);

            jobject.Remove("_embedded");
            jobject.Remove("_links");

            halDocument.Properties = jobject;

            return halDocument;
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var halDocument = (HalDocument)value;
            JObject result = (JObject)halDocument.Properties?.DeepClone() ?? new JObject();

            SerializeLinks(halDocument, result, serializer);
            SerializeEmbeddedResources(halDocument, result, serializer);

            result.WriteTo(writer);
        }

        /// <inheritdoc/>
        public override HalDocument Create(Type objectType)
        {
            // Do nothing
            return null;
        }

        private static void SerializeLinks(HalDocument halDocument, JObject result, JsonSerializer serializer)
        {
            var linksObject = new JObject();

            foreach (string relation in halDocument.GetLinkRelations())
            {
                WebLink[] links = halDocument.GetLinksForRelation(relation).ToArray();
                if (links.Length == 0)
                {
                    continue;
                }

                if (links.Length == 1)
                {
                    linksObject.Add(relation, JObject.FromObject(links[0], serializer));
                }
                else
                {
                    var linksArray = new JArray();
                    links.ForEach(link => linksArray.Add(JObject.FromObject(links[0], serializer)));
                    linksObject.Add(relation, linksArray);
                }
            }

            if (linksObject.HasValues)
            {
                result.Add("_links", linksObject);
            }
        }

        private static void SerializeEmbeddedResources(HalDocument halDocument, JObject result, JsonSerializer serializer)
        {
            var embeddedResourcesObject = new JObject();

            foreach (string relation in halDocument.GetEmbeddedResourceRelations())
            {
                HalDocument[] embeddedResources = halDocument.GetEmbeddedResourcesForRelation(relation).ToArray();
                if (embeddedResources.Length == 0)
                {
                    continue;
                }

                if (embeddedResources.Length == 1)
                {
                    embeddedResourcesObject.Add(relation, JObject.FromObject(embeddedResources[0], serializer));
                }
                else
                {
                    var embeddedResourcesArray = new JArray();
                    embeddedResources.ForEach(embeddedResource => embeddedResourcesArray.Add(JObject.FromObject(embeddedResource, serializer)));
                    embeddedResourcesObject.Add(relation, embeddedResourcesArray);
                }
            }

            if (embeddedResourcesObject.HasValues)
            {
                result.Add("_embedded", embeddedResourcesObject);
            }
        }

        private static void DeserializeLinks(JsonSerializer serializer, JObject jobject, HalDocument halDocument)
        {
            foreach (KeyValuePair<string, JToken> link in (JObject)jobject["_links"])
            {
                if (link.Value is JArray array)
                {
                    foreach (JToken linkItem in array)
                    {
                        WebLink weblink = linkItem.ToObject<WebLink>(serializer);
                        halDocument.AddLink(link.Key, weblink);
                    }
                }
                else
                {
                    WebLink weblink = link.Value.ToObject<WebLink>(serializer);
                    halDocument.AddLink(link.Key, weblink);
                }
            }
        }

        private static void DeserializeEmbeddedResources(JsonSerializer serializer, JObject jobject, HalDocument halDocument)
        {
            foreach (KeyValuePair<string, JToken> resource in (JObject)jobject["_embedded"])
            {
                if (resource.Value is JArray array)
                {
                    foreach (JToken resourceItem in array)
                    {
                        halDocument.AddEmbeddedResource(resource.Key, serializer.Deserialize<HalDocument>(resourceItem.CreateReader()));
                    }
                }
                else
                {
                    halDocument.AddEmbeddedResource(resource.Key, serializer.Deserialize<HalDocument>(resource.Value.CreateReader()));
                }
            }
        }
    }
}
