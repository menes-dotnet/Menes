// <copyright file="HalDocument.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Corvus.Extensions.Json;
    using Menes.Links;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A HAL document.
    /// </summary>
    /// <remarks>
    /// You will typically create an instance of this type using the <see cref="IHalDocumentFactory"/>.
    /// </remarks>
    public sealed class HalDocument : IHalDocument
    {
        private Dictionary<string, List<WebLink>> links = new Dictionary<string, List<WebLink>>();
        private Dictionary<string, List<IHalDocument>> embeddedResources = new Dictionary<string, List<IHalDocument>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HalDocument"/> class.
        /// </summary>
        /// <param name="serializerSettingsProvider">The Json serializer settings provider.</param>
        public HalDocument(IJsonSerializerSettingsProvider serializerSettingsProvider)
        {
            this.SerializerSettings = serializerSettingsProvider.Instance;
        }

        /// <summary>
        /// Gets the serializer settings for the HAL document.
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; }

        /// <summary>
        /// Gets the properties for the HalDocument.
        /// </summary>
        public JObject Properties
        {
            get => this.PropertiesInternalNullable ??= new JObject();
            internal set => this.PropertiesInternalNullable = value ?? throw new ArgumentNullException();
        }

        /// <inheritdoc/>
        public IEnumerable<WebLink> Links
        {
            get
            {
                this.EnsureLinks();

                foreach (List<WebLink> linkList in this.links.Values)
                {
                    foreach (WebLink link in linkList)
                    {
                        yield return link;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public IEnumerable<IHalDocument> EmbeddedResources
        {
            get
            {
                this.EnsureEmbeddedResources();

                foreach (List<IHalDocument> halDocumentList in this.embeddedResources.Values)
                {
                    foreach (IHalDocument halDocument in halDocumentList)
                    {
                        yield return halDocument;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the underlying store for <see cref="Properties"/>, making it possible to
        /// detect when it has not been set.
        /// </summary>
        /// <remarks>
        /// The public <see cref="Properties"/> property's get accessor will construct a new
        /// <see cref="JObject"/> if a value is not already present so as to avoid ever returning
        /// null. In most cases this is what we want, but our seralization support code can handle
        /// the case where this was never given a value more efficiently.
        /// </remarks>
        internal JObject? PropertiesInternalNullable { get; set; }

        /// <inheritdoc/>
        public void RemoveEmbeddedResource(string rel, WebLink resourceLink)
        {
            this.GetEmbeddedResourcesForRelation(rel)
                .Where(r => r.GetLinksForRelation("self").Any(link => link.Href == resourceLink.Href)).ToList()
                .ForEach(r => this.RemoveEmbeddedResource(rel, r));
        }

        /// <inheritdoc/>
        public void SetProperties<T>(T properties)
        {
            if (properties is JObject jobject)
            {
                this.Properties = jobject;
            }
            else
            {
                this.Properties = JObject.FromObject(properties, JsonSerializer.Create(this.SerializerSettings));
            }
        }

        /// <inheritdoc/>
        public bool HasEmbeddedResourceForLink(string rel, WebLink resourceLink)
        {
            return this.GetEmbeddedResourcesForRelation(rel)
                .Any(r => r.GetLinksForRelation("self").Any(link => link.Href == resourceLink.Href));
        }

        /// <inheritdoc/>
        public bool TryGetPropertiesAs<T>([MaybeNullWhen(false)] out T result)
        {
            if (typeof(JObject).IsAssignableFrom(typeof(T)))
            {
                result = (T)(object)this.Properties;
                return true;
            }

            using JsonReader reader = this.Properties.CreateReader();
            try
            {
                result = JsonSerializer.Create(this.SerializerSettings).Deserialize<T>(reader);
                return true;
            }
            catch (JsonSerializationException)
            {
                result = default!;
                return false;
            }
        }

        /// <inheritdoc/>
        public void AddLink(string rel, WebLink link)
        {
            List<WebLink> linkList = this.EnsureListForLink(rel);
            linkList.Add(link);
        }

        /// <inheritdoc/>
        public void RemoveLink(string rel, WebLink link)
        {
            List<WebLink> linkList = this.EnsureListForLink(rel);
            linkList.Remove(link);
            if (linkList.Count == 0)
            {
                this.links.Remove(rel);
            }
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetLinkRelations()
        {
            this.EnsureLinks();

            foreach (string href in this.links.Keys)
            {
                yield return href;
            }
        }

        /// <inheritdoc/>
        public IEnumerable<WebLink> GetLinksForRelation(string rel)
        {
            this.EnsureLinks();

            if (this.links.TryGetValue(rel, out List<WebLink> linkList))
            {
                foreach (WebLink link in linkList)
                {
                    yield return link;
                }
            }

            yield break;
        }

        /// <inheritdoc/>
        public void AddEmbeddedResource(string rel, IHalDocument embeddedResource)
        {
            List<IHalDocument> embeddedResourceList = this.EnsureListForEmbeddedResource(rel);
            embeddedResourceList.Add(embeddedResource);
        }

        /// <inheritdoc/>
        public void AddEmbeddedResources(string rel, IEnumerable<IHalDocument> resources)
        {
            List<IHalDocument> embeddedResourceList = this.EnsureListForEmbeddedResource(rel);
            embeddedResourceList.AddRange(resources);
        }

        /// <inheritdoc/>
        public void RemoveEmbeddedResource(string rel, IHalDocument embeddedResource)
        {
            List<IHalDocument> embeddedResourceList = this.EnsureListForEmbeddedResource(rel);
            embeddedResourceList.Remove(embeddedResource);

            if (embeddedResourceList.Count == 0)
            {
                this.embeddedResources.Remove(rel);
            }
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetEmbeddedResourceRelations()
        {
            this.EnsureEmbeddedResources();

            foreach (string href in this.embeddedResources.Keys)
            {
                yield return href;
            }
        }

        /// <inheritdoc/>
        public IEnumerable<IHalDocument> GetEmbeddedResourcesForRelation(string rel)
        {
            this.EnsureEmbeddedResources();

            if (this.embeddedResources.TryGetValue(rel, out List<IHalDocument> embeddedResourceList))
            {
                foreach (IHalDocument embeddedResource in embeddedResourceList)
                {
                    yield return embeddedResource;
                }
            }

            yield break;
        }

        private List<WebLink> EnsureListForLink(string rel)
        {
            this.EnsureLinks();

            if (!this.links.TryGetValue(rel, out List<WebLink> linkList))
            {
                linkList = new List<WebLink>();
                this.links.Add(rel, linkList);
            }

            return linkList;
        }

        private void EnsureLinks()
        {
            if (this.links == null)
            {
                this.links = new Dictionary<string, List<WebLink>>();
            }
        }

        private List<IHalDocument> EnsureListForEmbeddedResource(string rel)
        {
            this.EnsureLinks();

            if (!this.embeddedResources.TryGetValue(rel, out List<IHalDocument> halDocumentList))
            {
                halDocumentList = new List<IHalDocument>();
                this.embeddedResources.Add(rel, halDocumentList);
            }

            return halDocumentList;
        }

        private void EnsureEmbeddedResources()
        {
            if (this.embeddedResources == null)
            {
                this.embeddedResources = new Dictionary<string, List<IHalDocument>>();
            }
        }
    }
}