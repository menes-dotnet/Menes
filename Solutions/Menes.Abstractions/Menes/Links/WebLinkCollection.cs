// <copyright file="WebLinkCollection.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Links
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a collection of hypermedia links for a resource.
    /// </summary>
    public abstract class WebLinkCollection : ICollection<WebLink>
    {
        private readonly List<WebLink> links = new List<WebLink>();

        /// <summary>
        /// Gets the number of links in the collection.
        /// </summary>
        public int Count => this.links.Count;

        /// <inheritdoc />
        public bool IsReadOnly => false;

        /// <inheritdoc />
        public void Add(WebLink item)
        {
            this.links.Add(item);
        }

        /// <summary>
        /// Creates and adds a new <see cref="WebLink"/> with the given Href and Rel properties to the collection.
        /// </summary>
        /// <param name="rel">The relation type of this link.</param>
        /// <param name="href">The url for the link.</param>
        /// <returns>The new link.</returns>
        public WebLink Add(string rel, string href)
        {
            var result = new WebLink(rel, href);
            this.Add(result);
            return result;
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.links.Clear();
        }

        /// <inheritdoc />
        public bool Contains(WebLink item)
        {
            return this.links.Contains(item);
        }

        /// <inheritdoc />
        public void CopyTo(WebLink[] array, int arrayIndex)
        {
            this.links.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc/>
        public IEnumerator<WebLink> GetEnumerator() => this.links.GetEnumerator();

        /// <inheritdoc />
        public bool Remove(WebLink item)
        {
            return this.links.Remove(item);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.links.GetEnumerator();
    }
}
