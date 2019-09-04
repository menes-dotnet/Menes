// <copyright file="HalDocument.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    using System.Collections.Generic;
    using System.Linq;
    using Corvus.ContentHandling;
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
    public class HalDocument : ILinkCollection
    {
        /// <summary>
        /// The standard content type for a HalDocument.
        /// </summary>
        public const string RegisteredContentType = "application/hal+json";

        private Dictionary<string, List<WebLink>> links = new Dictionary<string, List<WebLink>>();
        private Dictionary<string, List<HalDocument>> embeddedResources = new Dictionary<string, List<HalDocument>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="HalDocument"/> class.
        /// </summary>
        /// <param name="serializerSettingsProvider">The Json serializer settings provider.</param>
        public HalDocument(IJsonSerializerSettingsProvider serializerSettingsProvider)
        {
            this.SerializerSettings = serializerSettingsProvider.Instance;
        }

        /// <summary>
        /// Gets the content type for the HalDocument.
        /// </summary>
        /// <remarks>This is set from the target object when you call <see cref="SetProperties{T}(T)"/> and defaults to <c>application/hal+json</c>.</remarks>
        public string ContentType { get; private set; } = RegisteredContentType;

        /// <summary>
        /// Gets the serializer settings for the HAL document.
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; private set; }

        /// <summary>
        /// Gets the properites for the HalDocument.
        /// </summary>
        public JObject Properties
        {
            get;
            internal set;
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

        /// <summary>
        /// Gets all of the embedded resources in the document.
        /// </summary>
        public IEnumerable<HalDocument> EmbeddedResources
        {
            get
            {
                this.EnsureEmbeddedResources();

                foreach (List<HalDocument> halDocumentList in this.embeddedResources.Values)
                {
                    foreach (HalDocument halDocument in halDocumentList)
                    {
                        yield return halDocument;
                    }
                }
            }
        }

        /// <summary>
        /// Removes an embedded resource based on its self link.
        /// </summary>
        /// <param name="selfLink">The self link for the embedded resource.</param>
        public void RemoveEmbeddedResource(WebLink selfLink)
        {
            this.GetEmbeddedResourcesForRelation(selfLink.Rel)
                .Where(r => r.GetLinksForRelation("self").Any(links => links == selfLink))
                .ForEach(r => this.RemoveEmbeddedResource(selfLink.Rel, r));
        }

        /// <summary>
        /// Sets the properties of the HalDocument using an object instance.
        /// </summary>
        /// <typeparam name="T">The type of the properties object.</typeparam>
        /// <param name="properties">The object from which to derive the properties.</param>
        public void SetProperties<T>(T properties)
        {
            this.Properties = JObject.FromObject(properties, JsonSerializer.Create(this.SerializerSettings));

            if (ContentFactory.TryGetContentType(properties, out string contentType))
            {
                this.ContentType = contentType;
            }
        }

        /// <summary>
        /// Determine if the document contains an embedded resource for the provided link.
        /// </summary>
        /// <param name="resourceLink">The link with which to compare.</param>
        /// <returns>True if there is a resource whose self link matches the resource link.</returns>
        public bool HasEmbeddedResourceForLink(WebLink resourceLink)
        {
            return this.GetEmbeddedResourcesForRelation(resourceLink.Rel)
                .Any(r => r.GetLinksForRelation("self").Any(links => links == resourceLink));
        }

        /// <summary>
        /// Gets the properties of the HalDocument as an object instance.
        /// </summary>
        /// <typeparam name="T">The type of the properties object.</typeparam>
        /// <param name="result">The properties deserialized to the relevant type.</param>
        /// <returns>True if it was possible to get the properties as the given type.</returns>
        public bool TryGetProperties<T>(out T result)
        {
            if (typeof(JObject).IsAssignableFrom(typeof(T)))
            {
                result = (T)(object)this.Properties;
                return true;
            }

            using (JsonReader reader = this.Properties.CreateReader())
            {
                try
                {
                    result = JsonSerializer.Create(this.SerializerSettings).Deserialize<T>(reader);
                    return true;
                }
                catch (JsonSerializationException)
                {
                    result = default;
                    return false;
                }
            }
        }

        /// <inheritdoc/>
        public void AddLink(WebLink link)
        {
            List<WebLink> linkList = this.EnsureListForLink(link);
            linkList.Add(link);
        }

        /// <inheritdoc/>
        public void RemoveLink(WebLink link)
        {
            List<WebLink> linkList = this.EnsureListForLink(link);
            linkList.Remove(link);
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

        /// <summary>
        /// Adds a embeddedResource to the <c>_embeddedResources</c> collection.
        /// </summary>
        /// <param name="rel">The relation for the embedded resource.</param>
        /// <param name="embeddedResource">The embeddedResource to add.</param>
        public void AddEmbeddedResource(string rel, HalDocument embeddedResource)
        {
            List<HalDocument> embeddedResourceList = this.EnsureListForEmbeddedResource(rel);
            embeddedResourceList.Add(embeddedResource);
        }

        /// <summary>
        /// Adds a collection of embedded resources for a particular relation.
        /// </summary>
        /// <param name="rel">The relation type.</param>
        /// <param name="resources">The resources to embed.</param>
        public void AddEmbeddedResources(string rel, IEnumerable<HalDocument> resources)
        {
            List<HalDocument> embeddedResourceList = this.EnsureListForEmbeddedResource(rel);
            embeddedResourceList.AddRange(resources);
        }

        /// <summary>
        /// Removes a embeddedResource from the <c>_embeddedResources</c> collection.
        /// </summary>
        /// <param name="rel">The relation for the embedded resource.</param>
        /// <param name="embeddedResource">The embeddedResource to remove.</param>
        public void RemoveEmbeddedResource(string rel, HalDocument embeddedResource)
        {
            List<HalDocument> embeddedResourceList = this.EnsureListForEmbeddedResource(rel);
            embeddedResourceList.Remove(embeddedResource);
        }

        /// <summary>
        /// Enumerate the rels in the embeddedResource collection.
        /// </summary>
        /// <returns>An enumerable collection of strings that represent the rels in the <c>_embeddedResources</c> collection.</returns>
        public IEnumerable<string> GetEmbeddedResourceRelations()
        {
            this.EnsureEmbeddedResources();

            foreach (string href in this.embeddedResources.Keys)
            {
                yield return href;
            }
        }

        /// <summary>
        /// Enumerate the embeddedResources for a particular relation.
        /// </summary>
        /// <param name="rel">The relaltion for which to get the embeddedResource or embeddedResources.</param>
        /// <returns>An enumerable collection of web embeddedResources that correspond to the given relation, or an empty enumerable if there are no such embeddedResources.</returns>
        public IEnumerable<HalDocument> GetEmbeddedResourcesForRelation(string rel)
        {
            this.EnsureEmbeddedResources();

            if (this.embeddedResources.TryGetValue(rel, out List<HalDocument> embeddedResourceList))
            {
                foreach (HalDocument embeddedResource in embeddedResourceList)
                {
                    yield return embeddedResource;
                }
            }

            yield break;
        }

        private List<WebLink> EnsureListForLink(WebLink link)
        {
            this.EnsureLinks();

            if (!this.links.TryGetValue(link.Rel, out List<WebLink> linkList))
            {
                linkList = new List<WebLink>();
                this.links.Add(link.Rel, linkList);
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

        private List<HalDocument> EnsureListForEmbeddedResource(string rel)
        {
            this.EnsureLinks();

            if (!this.embeddedResources.TryGetValue(rel, out List<HalDocument> halDocumentList))
            {
                halDocumentList = new List<HalDocument>();
                this.embeddedResources.Add(rel, halDocumentList);
            }

            return halDocumentList;
        }

        private void EnsureEmbeddedResources()
        {
            if (this.embeddedResources == null)
            {
                this.embeddedResources = new Dictionary<string, List<HalDocument>>();
            }
        }
    }
}