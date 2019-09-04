// <copyright file="ILinkCollection.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Links
{
    using System.Collections.Generic;

    /// <summary>
    /// Implemented by types that expose a link collection.
    /// </summary>
    public interface ILinkCollection
    {
        /// <summary>
        /// Gets all the links in a link collection.
        /// </summary>
        IEnumerable<WebLink> Links { get; }

        /// <summary>
        /// Adds a link to the collection.
        /// </summary>
        /// <param name="link">The link to add.</param>
        void AddLink(WebLink link);

        /// <summary>
        /// Enumerate the relations in the link collection.
        /// </summary>
        /// <returns>An enumerable collection of strings that represent the rels in the <c>_links</c> collection.</returns>
        IEnumerable<string> GetLinkRelations();

        /// <summary>
        /// Enumerate the links for a particular relation.
        /// </summary>
        /// <param name="rel">The relation for which to get the link or links.</param>
        /// <returns>An enumerable collection of web links that correspond to the given relation, or an empty enumerable if there are no such links.</returns>
        IEnumerable<WebLink> GetLinksForRelation(string rel);

        /// <summary>
        /// Removes a link from a <c>_links</c> collection.
        /// </summary>
        /// <param name="link">The link to remove.</param>
        void RemoveLink(WebLink link);
    }
}