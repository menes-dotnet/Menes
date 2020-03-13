// <copyright file="IEmbeddedResourcesCollection.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Hal
{
    using System.Collections.Generic;
    using Menes.Links;

    /// <summary>
    /// A collection of <see cref="IHalDocument"/>s by relation type.
    /// </summary>
    public interface IEmbeddedResourcesCollection
    {
        /// <summary>
        /// Gets all of the embedded resources in the document.
        /// </summary>
        IEnumerable<IHalDocument> EmbeddedResources { get; }

        /// <summary>
        /// Adds a embeddedResource to the <c>_embeddedResources</c> collection.
        /// </summary>
        /// <param name="rel">The relation for the embedded resource.</param>
        /// <param name="embeddedResource">The embeddedResource to add.</param>
        void AddEmbeddedResource(string rel, IHalDocument embeddedResource);

        /// <summary>
        /// Adds a collection of embedded resources for a particular relation.
        /// </summary>
        /// <param name="rel">The relation type.</param>
        /// <param name="resources">The resources to embed.</param>
        void AddEmbeddedResources(string rel, IEnumerable<IHalDocument> resources);

        /// <summary>
        /// Enumerate the rels in the embeddedResource collection.
        /// </summary>
        /// <returns>An enumerable collection of strings that represent the rels in the <c>_embeddedResources</c> collection.</returns>
        IEnumerable<string> GetEmbeddedResourceRelations();

        /// <summary>
        /// Enumerate the embeddedResources for a particular relation.
        /// </summary>
        /// <param name="rel">The relaltion for which to get the embeddedResource or embeddedResources.</param>
        /// <returns>An enumerable collection of web embeddedResources that correspond to the given relation, or an empty enumerable if there are no such embeddedResources.</returns>
        IEnumerable<IHalDocument> GetEmbeddedResourcesForRelation(string rel);

        /// <summary>
        /// Determine if the document contains an embedded resource for the provided link.
        /// </summary>
        /// <param name="rel">The relation type of the link.</param>
        /// <param name="resourceLink">The link with which to compare.</param>
        /// <returns>True if there is a resource whose self link matches the resource link.</returns>
        bool HasEmbeddedResourceForLink(string rel, WebLink resourceLink);

        /// <summary>
        /// Removes a embeddedResource from the <c>_embeddedResources</c> collection.
        /// </summary>
        /// <param name="rel">The relation for the embedded resource.</param>
        /// <param name="embeddedResource">The embeddedResource to remove.</param>
        void RemoveEmbeddedResource(string rel, IHalDocument embeddedResource);

        /// <summary>
        /// Removes an embedded resource based on its href.
        /// </summary>
        /// <param name="rel">The relation type of the link.</param>
        /// <param name="resourceLink">The link for the embedded resource from the links collection.</param>
        /// <remarks>This finds the embdedded resources that match the rel type of the resource link, whose self link href matches the href of the resource link.</remarks>
        void RemoveEmbeddedResource(string rel, WebLink resourceLink);
    }
}