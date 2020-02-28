// <copyright file="IOpenApiWebLinkResolver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Links
{
    /// <summary>
    /// Interface for a class which can build <see cref="OpenApiWebLink"/> objects for response
    /// link collections.
    /// </summary>
    public interface IOpenApiWebLinkResolver
    {
        /// <summary>
        /// Resolves the url for the given link and returns an <see cref="OpenApiWebLink"/> containing
        /// the details.
        /// </summary>
        /// <param name="owner">The object that owns this link. This object's class, or its content
        /// type, should have a corresponding registration set up as part of the Open Api host
        /// intitialisation.</param>
        /// <param name="relationType">The link relation type. This is the "rel" attribute for the link.</param>
        /// <param name="parameters">Any parameters which are needed to build the link.</param>
        /// <returns>The resolved <see cref="OpenApiWebLink"/>.</returns>
        /// <remarks>
        /// <para>
        /// Content type handling is hierarchical. For example, if you have set up a map for
        /// content type <c>application/vnd.menes.petstore.pet</c> as part of host initialisation,
        /// and you call this method with an object that has a. <c>ContentType</c> property with
        /// the value <c>application/vnd.menes.petstore.pet.cat</c>, then in the absence of an
        /// exact match for that content type, the link will be resolved using the parent content type.
        /// </para>
        /// <para>
        /// If your object does not have a. <c>ContentType</c> property but it's class has
        /// a static. <c>RegisteredContentType</c> field (or constant) then this will be used for
        /// the lookup.
        /// </para>
        /// <para>
        /// Hierarchical handling does not apply to types. If you have mapped a type to an operation,
        /// then the map will not apply to subclases of that type. In this scenario, you should use
        /// content types instead.
        /// </para>
        /// </remarks>
        OpenApiWebLink ResolveByOwnerAndRelationType(
            object owner,
            string relationType,
            params (string, object?)[] parameters);

        /// <summary>
        /// Resolves the url for the given link and returns an <see cref="OpenApiWebLink"/> containing
        /// the details.
        /// </summary>
        /// <param name="owner">The object that owns this link. This object's class, or its content
        /// type, should have a corresponding registration set up as part of the Open Api host
        /// intitialisation.</param>
        /// <param name="relationType">The link relation type. This is the "rel" attribute for the link.</param>
        /// <param name="context">A user-defined context in which the link is being used. This allows you to discriminate between operations with the same content type and relation, targetting different operations, in different APIs.</param>
        /// <param name="parameters">Any parameters which are needed to build the link.</param>
        /// <returns>The resolved <see cref="OpenApiWebLink"/>.</returns>
        /// <remarks>
        /// <para>
        /// Content type handling is hierarchical. For example, if you have set up a map for
        /// content type. <c>application/vnd.menes.petstore.pet</c> as part of host initialisation,
        /// and you call this method with an object that has a. <c>ContentType</c> property with
        /// the value <c>application/vnd.menes.petstore.pet.cat</c>, then in the absence of an
        /// exact match for that content type, the link will be resolved using the parent content type.
        /// </para>
        /// <para>
        /// If your object does not have a. <c>ContentType</c> property but it's class has
        /// a static. <c>RegisteredContentType</c> field (or constant) then this will be used for
        /// the lookup.
        /// </para>
        /// <para>
        /// Hierarchical handling does not apply to types. If you have mapped a type to an operation,
        /// then the map will not apply to subclases of that type. In this scenario, you should use
        /// content types instead.
        /// </para>
        /// </remarks>
        OpenApiWebLink ResolveByOwnerAndRelationTypeAndContext(
            object owner,
            string relationType,
            string context,
            params (string, object?)[] parameters);

        /// <summary>
        /// Resolves the url for the given link and returns an <see cref="OpenApiWebLink"/> containing
        /// the details.
        /// </summary>
        /// <param name="operationId">The operation ID for the link.</param>
        /// <param name="relationType">The link relation type. This is the "rel" attribute for the link.</param>
        /// <param name="parameters">Any parameters which are needed to build the link.</param>
        /// <returns>The resolved <see cref="OpenApiWebLink"/>.</returns>
        OpenApiWebLink ResolveByOperationIdAndRelationType(
            string operationId,
            string relationType,
            params (string, object?)[] parameters);
    }
}
