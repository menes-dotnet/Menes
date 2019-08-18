// <copyright file="IOpenApiLinkOperationMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// Handles mapping of content types/objects and link relation types to Open API operation IDs.
    /// </summary>
    public interface IOpenApiLinkOperationMapper : IOpenApiLinkOperationMap
    {
        /// <summary>
        /// Tries to find the appropriate operation Id for the given owner, relation type and context.
        /// </summary>
        /// <param name="owner">The object that will own the link.</param>
        /// <param name="relationType">The relation type.</param>
        /// <param name="context">A user-defined context in which the link is being used. This allows you to discriminate between operations with the same content type and relation, targetting different operations, in different APIs.</param>
        /// <param name="operationId">The operation Id.</param>
        /// <returns>True if a mapping was found, false otherwise.</returns>
        bool TryGetOperationId(object owner, string relationType, string context, out string operationId);

        /// <summary>
        /// Tries to find the appropriate operation Id for the given owner, relation type, in the global context.
        /// </summary>
        /// <param name="owner">The object that will own the link.</param>
        /// <param name="relationType">The relation type.</param>
        /// <param name="operationId">The operation Id.</param>
        /// <returns>True if a mapping was found, false otherwise.</returns>
        bool TryGetOperationId(object owner, string relationType, out string operationId);
    }
}