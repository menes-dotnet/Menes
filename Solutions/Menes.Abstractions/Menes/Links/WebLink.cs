// <copyright file="WebLink.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Links
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a hypermedia link to a related resource. Follows the general pattern described
    /// in RFC 8288 (https://tools.ietf.org/html/rfc8288).
    /// </summary>
    public class WebLink : IEquatable<WebLink>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebLink"/> struct.
        /// </summary>
        public WebLink()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebLink"/> struct.
        /// </summary>
        /// <param name="rel">The link relation type.</param>
        /// <param name="href">The link url.</param>
        public WebLink(string rel, string href)
        {
            this.Rel = rel;
            this.Href = href;
        }

        /// <summary>
        /// Gets or sets the relation type of this link.
        /// </summary>
        /// <example>self.</example>
        public string Rel { get; set; }

        /// <summary>
        /// Gets or sets the Uri of the link.
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="left">The left hand side of the comparison.</param>
        /// <param name="right">The right hand side of the comparison.</param>
        /// <returns>True if the links are equivalent.</returns>
        public static bool operator ==(WebLink left, WebLink right)
        {
            return EqualityComparer<WebLink>.Default.Equals(left, right);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="left">The left hand side of the comparison.</param>
        /// <param name="right">The right hand side of the comparison.</param>
        /// <returns>True if the links are not equivalent.</returns>
        public static bool operator !=(WebLink left, WebLink right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as WebLink);
        }

        /// <inheritdoc/>
        public bool Equals(WebLink other)
        {
            return other != null &&
                   this.Rel == other.Rel &&
                   this.Href == other.Href;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (this.Href, this.Rel).GetHashCode();
        }
    }
}
