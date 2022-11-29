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
    public class WebLink : IEquatable<WebLink?>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebLink"/> struct.
        /// </summary>
        /// <param name="href">The link url.</param>
        /// <param name="name">The name of the link (optional).</param>
        /// <param name="isTemplated">Whether the link is templated (optional).</param>
        /// <param name="hreflang">The language of the resource at the href.</param>
        /// <param name="profile">Additional semantics of the target resource..</param>
        /// <param name="title">the human-readable title of the link.</param>
        /// <param name="type">The media type indication of the target resource.</param>
        public WebLink(string href, string? name = null, bool? isTemplated = null, string? hreflang = null, string? profile = null, string? title = null, string? type = null)
        {
            this.Href = href;
            this.Name = name;
            this.IsTemplated = isTemplated;
            this.Hreflang = hreflang;
            this.Profile = profile;
            this.Title = title;
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets the URI of the target resource.
        /// </summary>
        /// <remarks>
        /// Either a URI [RFC3986] or URI Template [RFC6570] of the target
        /// resource.
        /// </remarks>
        public string Href { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <remarks>
        /// When present, may be used as a secondary key for selecting link
        /// objects that contain the same relation type.
        /// </remarks>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the link is templated (or null if the property is not set).
        /// </summary>
        /// <remarks>
        /// Is true when the link object's href property is a URI Template.
        /// Defaults to false.
        /// </remarks>
        public bool? IsTemplated { get; set; }

        /// <summary>
        /// Gets or sets a value for the human-readable title of the link.
        /// </summary>
        /// <remarks>
        /// When present, is used to label the destination of a link such that
        /// it can be used as a human-readable identifier (e.g. a menu entry)
        /// in the language indicated by the Content-Language header (if
        /// present).
        /// </remarks>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets additional semantics of the target resource.
        /// </summary>
        /// <remarks>
        /// A URI that, when dereferenced, results in a profile to allow
        /// clients to learn about additional semantics (constraints,
        /// conventions, extensions) that are associated with the target
        /// resource representation, in addition to those defined by the HAL
        /// media type and relations.
        /// </remarks>
        public string? Profile { get; set; }

        /// <summary>
        /// Gets or sets media type indication of the target resource.
        /// </summary>
        /// <remarks>
        /// When present, used as a hint to indicate the media type expected
        /// when dereferencing the target resource.
        /// </remarks>
        public string? Type { get; set; }

        /// <summary>
        /// Gets or sets language indication of the target resource [RFC5988].
        /// </summary>
        /// <remarks>
        /// When present, is a hint in RFC5646 format indicating what the
        /// language of the result of dereferencing the link should be.  Note
        /// that this is only a hint; for example, it does not override the
        /// Content-Language header of a HTTP response obtained by actually
        /// following the link.
        /// </remarks>
        public string? Hreflang { get; set; }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="left">The left hand side of the comparison.</param>
        /// <param name="right">The right hand side of the comparison.</param>
        /// <returns>True if the links are equivalent.</returns>
        public static bool operator ==(WebLink? left, WebLink? right)
        {
            return EqualityComparer<WebLink?>.Default.Equals(left, right);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="left">The left hand side of the comparison.</param>
        /// <param name="right">The right hand side of the comparison.</param>
        /// <returns>True if the links are not equivalent.</returns>
        public static bool operator !=(WebLink? left, WebLink? right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as WebLink);
        }

        /// <inheritdoc/>
        public bool Equals(WebLink? other)
        {
            return other != null &&
                   this.Href == other.Href &&
                   this.IsTemplated == other.IsTemplated &&
                   this.Name == other.Name &&
                   this.Hreflang == other.Hreflang &&
                   this.Title == other.Title &&
                   this.Type == other.Type &&
                   this.Profile == other.Profile;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Href, this.Name, this.IsTemplated, this.Hreflang, this.Title, this.Type, this.Profile);
        }
    }
}