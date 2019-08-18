// <copyright file="OpenApiPathTemplate.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System.Text.RegularExpressions;
    using Microsoft.OpenApi.Models;
    using Tavis.UriTemplates;

    /// <summary>
    /// A path template from the OpenAPI document.
    /// </summary>
    public class OpenApiPathTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiPathTemplate"/> class.
        /// </summary>
        /// <param name="uriTemplate">The uri template.</param>
        /// <param name="item">The path item.</param>
        public OpenApiPathTemplate(string uriTemplate, OpenApiPathItem item)
        {
            this.UriTemplate = new UriTemplate(uriTemplate);
            this.PathItem = item;
            this.Match = new Regex(UriTemplate.CreateMatchingRegex(uriTemplate), RegexOptions.Compiled);
        }

        /// <summary>
        /// Gets the <see cref="OpenApiPathItem"/>.
        /// </summary>
        public OpenApiPathItem PathItem { get; }

        /// <summary>
        /// Gets the <see cref="UriTemplate"/>.
        /// </summary>
        public UriTemplate UriTemplate { get; }

        /// <summary>
        /// Gets the <see cref="Regex"/> which provides a match.
        /// </summary>
        public Regex Match { get; }
    }
}