// <copyright file="PathMatcher.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Default implementation of a path matcher.
    /// </summary>
    public class PathMatcher : IPathMatcher
    {
        private readonly IOpenApiDocumentProvider templateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathMatcher"/> class.
        /// </summary>
        /// <param name="templateProvider">The path template provider.</param>
        public PathMatcher(IOpenApiDocumentProvider templateProvider)
        {
            this.templateProvider = templateProvider;
        }

        /// <inheritdoc/>
        public bool FindOperationPathTemplate(string path, string method, [NotNullWhen(true)] out OpenApiOperationPathTemplate? operationPathTemplate)
        {
            return this.templateProvider.GetOperationPathTemplate(path, method, out operationPathTemplate);
        }
    }
}