// <copyright file="HalDocument.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Menes.Links;

    /// <summary>
    /// A HAL document.
    /// </summary>
    /// <remarks>
    /// You will typically create an instance of this type using the <see cref="IHalDocumentFactory"/>.
    /// </remarks>
    public class HalDocument : ILinkCollection
    {
        private Dictionary<string, List<WebLink>> links = new();
        private Dictionary<string, List<HalDocument>> embeddedResources = new();

        /////// <summary>
        /////// Initializes a new instance of the <see cref="HalDocument"/> class.
        /////// </summary>
        /////// <param name="serializerSettingsProvider">The Json serializer settings provider.</param>
        ////public HalDocument(IJsonSerializerSettingsProvider serializerSettingsProvider)
        ////{
        ////    this.SerializerSettings = serializerSettingsProvider.Instance;
        ////}

        /////// <summary>
        /////// Gets the serializer settings for the HAL document.
        /////// </summary>
        ////public JsonSerializerSettings SerializerSettings { get; }

        /////// <summary>
        /////// Gets the properties for the HalDocument.
        /////// </summary>
        ////public JObject Properties
        ////{
        ////    get => this.PropertiesInternalNullable ??= new JObject();
        ////    internal set => this.PropertiesInternalNullable = value ?? throw new ArgumentNullException(nameof(this.Properties));
        ////}

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

        /////// <summary>
        /////// Gets or sets the underlying store for <see cref="Properties"/>, making it possible to
        /////// detect when it has not been set.
        /////// </summary>
        /////// <remarks>
        /////// The public <see cref="Properties"/> property's get accessor will construct a new
        /////// <see cref="JObject"/> if a value is not already present so as to avoid ever returning
        /////// null. In most cases this is what we want, but our seralization support code can handle
        /////// the case where this was never given a value more efficiently.
        /////// </remarks>
        ////internal JObject? PropertiesInternalNullable { get; set; }

        /// <summary>
        /// Removes an embedded resource based on its href.
        /// </summary>
        /// <param name="rel">The relation type of the link.</param>
        /// <param name="resourceLink">The link for the embedded resource from the links collection.</param>
        /// <remarks>This finds the embdedded resources that match the rel type of the resource link, whose self link href matches the href of the resource link.</remarks>
        public void RemoveEmbeddedResource(string rel, WebLink resourceLink)
        {
            this.GetEmbeddedResourcesForRelation(rel)
                .Where(r => r.GetLinksForRelation("self").Any(link => link.Href == resourceLink.Href)).ToList()
                .ForEach(r => this.RemoveEmbeddedResource(rel, r));
        }

        /// <summary>
        /// Sets the properties of the HalDocument using an object instance.
        /// </summary>
        /// <typeparam name="T">The type of the properties object.</typeparam>
        /// <param name="properties">The object from which to derive the properties.</param>
        public void SetProperties<T>(T properties)
            where T : notnull
        {
            ////this.Properties = JObject.FromObject(properties, JsonSerializer.Create(this.SerializerSettings));
        }

        /// <summary>
        /// Determine if the document contains an embedded resource for the provided link.
        /// </summary>
        /// <param name="rel">The relation type of the link.</param>
        /// <param name="resourceLink">The link with which to compare.</param>
        /// <returns>True if there is a resource whose self link matches the resource link.</returns>
        public bool HasEmbeddedResourceForLink(string rel, WebLink resourceLink)
        {
            return this.GetEmbeddedResourcesForRelation(rel)
                .Any(r => r.GetLinksForRelation("self").Any(link => link.Href == resourceLink.Href));
        }

        /// <summary>
        /// Gets the properties of the HalDocument as an object instance.
        /// </summary>
        /// <typeparam name="T">The type of the properties object.</typeparam>
        /// <param name="result">The properties deserialized to the relevant type.</param>
        /// <returns>True if it was possible to get the properties as the given type.</returns>
        public bool TryGetProperties<T>([MaybeNullWhen(false)] out T result)
        {
            ////if (typeof(JObject).IsAssignableFrom(typeof(T)))
            ////{
            ////    result = (T)(object)this.Properties;
            ////    return true;
            ////}

            ////using JsonReader reader = this.Properties.CreateReader();
            ////try
            ////{
            ////    result = JsonSerializer.Create(this.SerializerSettings).Deserialize<T>(reader)!;
            ////    return true;
            ////}
            ////catch (JsonSerializationException)
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

            if (this.links.TryGetValue(rel, out List<WebLink>? linkList))
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

            if (embeddedResourceList.Count == 0)
            {
                this.embeddedResources.Remove(rel);
            }
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

            if (this.embeddedResources.TryGetValue(rel, out List<HalDocument>? embeddedResourceList))
            {
                foreach (HalDocument embeddedResource in embeddedResourceList)
                {
                    yield return embeddedResource;
                }
            }

            yield break;
        }

        private List<WebLink> EnsureListForLink(string rel)
        {
            this.EnsureLinks();

            if (!this.links.TryGetValue(rel, out List<WebLink>? linkList))
            {
                linkList = new List<WebLink>();
                this.links.Add(rel, linkList);
            }

            return linkList;
        }

        private void EnsureLinks()
        {
            this.links ??= new Dictionary<string, List<WebLink>>();
        }

        private List<HalDocument> EnsureListForEmbeddedResource(string rel)
        {
            this.EnsureLinks();

            if (!this.embeddedResources.TryGetValue(rel, out List<HalDocument>? halDocumentList))
            {
                halDocumentList = new List<HalDocument>();
                this.embeddedResources.Add(rel, halDocumentList);
            }

            return halDocumentList;
        }

        private void EnsureEmbeddedResources()
        {
            this.embeddedResources ??= new Dictionary<string, List<HalDocument>>();
        }
    }
}