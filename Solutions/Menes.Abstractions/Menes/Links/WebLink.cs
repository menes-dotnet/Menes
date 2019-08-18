// <copyright file="WebLink.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Links
{
    /// <summary>
    /// Represents a hypermedia link to a related resource. Follows the general pattern described
    /// in RFC 8288 (https://tools.ietf.org/html/rfc8288).
    /// </summary>
    public class WebLink
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
        /// Checks equality of two WebLink instances.
        /// </summary>
        /// <param name="lhs">The left hand side of the expression.</param>
        /// <param name="rhs">The right hand side of the expression.</param>
        /// <returns>True if the two instances are equal, false otherwise.</returns>
        public static bool operator ==(WebLink lhs, WebLink rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Checks inequality of two WebLink instances.
        /// </summary>
        /// <param name="lhs">The left hand side of the expression.</param>
        /// <param name="rhs">The right hand side of the expression.</param>
        /// <returns>False if the two instances are equal, true otherwise.</returns>
        public static bool operator !=(WebLink lhs, WebLink rhs) => !lhs.Equals(rhs);

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is WebLink link)
            {
                return (this.Href, this.Rel) == (link.Href, link.Rel);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return (this.Href, this.Rel).GetHashCode();
        }
    }
}
