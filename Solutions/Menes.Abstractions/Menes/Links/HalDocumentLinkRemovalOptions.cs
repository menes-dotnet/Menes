// <copyright file="HalDocumentLinkRemovalOptions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Links
{
    using System;
    using Menes.Hal;

    /// <summary>
    /// Options for processing HalDocuments to remove forbidden
    /// links using <see cref="OpenApiAccessCheckerExtensions.RemoveForbiddenLinksAsync"/>.
    /// </summary>
    [Flags]
    public enum HalDocumentLinkRemovalOptions
    {
        /// <summary>
        /// No options.
        /// </summary>
        /// <remarks>
        /// If no options are supplied, removal will be carried out:
        /// <list type="bullet">
        ///     <item>
        ///         safely - meaning that all links will be checked, and any
        ///         embedded documents that correspond to a link that is removed
        ///         will also be removed.
        ///     </item>
        ///     <item>
        ///         recursively - meaning that in addition to checking the supplied document,
        ///         the link check will also search the <see cref="HalDocument.EmbeddedResources"/>
        ///         collection for child <see cref="HalDocument"/>s and remove any forbidden links
        ///         from them as well as the parent.
        ///     </item>
        /// </list>
        /// </remarks>
        None = 0,

        /// <summary>
        /// The link check should not search the <see cref="HalDocument.EmbeddedResources"/> collection for child
        /// <see cref="HalDocument"/>s.
        /// </summary>
        NonRecursive = 1,

        /// <summary>
        /// Perform an unsafe check. With this options set, link checking will skip any <c>self</c> links
        /// and will also not validate any links that have a corresponding document in the <see cref="HalDocument.EmbeddedResources"/>
        /// collection.
        /// </summary>
        Unsafe = 2,
    }
}
