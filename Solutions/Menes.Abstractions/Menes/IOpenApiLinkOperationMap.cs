// <copyright file="IOpenApiLinkOperationMap.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using Corvus.ContentHandling;

    /// <summary>
    /// Handles mapping of content types/objects and link relation types to Open API operation IDs.
    /// </summary>
    public interface IOpenApiLinkOperationMap
    {
        /// <summary>
        /// Adds a link mapping from a content type and relation to an operation Url.
        /// </summary>
        /// <param name="contentType">The content type that should be used for the mapping.</param>
        /// <param name="relationType">The relation type of the link to be generated.</param>
        /// <param name="operationId">The Id of the operation that will be used to resolve the link.</param>
        /// <remarks>
        /// <para>
        /// This should be used where there is a single global operation for links with a given content type and relation type.
        /// </para>
        /// </remarks>
        void Map(string contentType, string relationType, string operationId);

        /// <summary>
        /// Adds a link mapping from a content type and relation to an operation Url.
        /// </summary>
        /// <typeparam name="T">The type that should be used to acquire the content type for the mapping. This should follow the <see cref="ContentFactory"/> pattern.</typeparam>
        /// <param name="relationType">The relation type of the link to be generated.</param>
        /// <param name="operationId">The Id of the operation that will be used to resolve the link.</param>
        /// <remarks>This should be used where there is a single global operation for a given content type and relation type.</remarks>
        void Map<T>(string relationType, string operationId);

        /// <summary>
        /// Adds a link mapping from a content type and relation to an operation Url.
        /// </summary>
        /// <param name="contentType">The content type that should be used for the mapping.</param>
        /// <param name="relationType">The relation type of the link to be generated.</param>
        /// <param name="context">A user-defined context in which the link is being used. This allows you to discriminate between operations with the same content type and relation, targetting different operations, in different APIs.</param>
        /// <param name="operationId">The Id of the operation that will be used to resolve the link.</param>
        void Map(string contentType, string relationType, string context, string operationId);

        /// <summary>
        /// Adds a link mapping from a content type and relation to an operation Url.
        /// </summary>
        /// <typeparam name="T">The type that should be used to acquire the content type for the mapping. This should follow the <see cref="ContentFactory"/> pattern.</typeparam>
        /// <param name="relationType">The relation type of the link to be generated.</param>
        /// <param name="context">A user-defined context in which the link is being used. This allows you to discriminate between operations with the same content type and relation, targetting different operations.</param>
        /// <param name="operationId">The Id of the operation that will be used to resolve the link.</param>
        void Map<T>(string relationType, string context, string operationId);
    }
}