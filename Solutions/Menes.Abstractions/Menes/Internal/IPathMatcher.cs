// <copyright file="IPathMatcher.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    /// <summary>
    /// An interface implemented by components which attempt to
    /// match a URI against an OpenAPI document.
    /// </summary>
    public interface IPathMatcher
    {
        /// <summary>
        /// Tries to match a path and methods against the operations in an OpenAPI document.
        /// </summary>
        /// <param name="path">The original request path.</param>
        /// <param name="method">The original request method.</param>
        /// <param name="operationPathTemplate">The result of the match.</param>
        /// <returns>True if a match was found otherwise false.</returns>
        bool FindOperationPathTemplate(string path, string method, out OpenApiOperationPathTemplate operationPathTemplate);
    }
}