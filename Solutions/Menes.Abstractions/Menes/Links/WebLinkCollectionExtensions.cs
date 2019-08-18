// <copyright file="WebLinkCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Links
{
    /// <summary>
    /// Extension methods for the WebLinkCollection class.
    /// </summary>
    public static class WebLinkCollectionExtensions
    {
        /// <summary>
        /// Adds a new link resolved using the given resolver for the specified object and relation type.
        /// </summary>
        /// <param name="linkCollection">The <see cref="WebLinkCollection"/> to add to.</param>
        /// <param name="linkResolver">The <see cref="IOpenApiWebLinkResolver"/> to use for resolving links.</param>
        /// <param name="owner">The owner of the link. An operation map for the owner and relation type must be defined on startup.</param>
        /// <param name="rel">The link relation type.</param>
        /// <param name="parameters">Any parameters that will be required to build the link.</param>
        /// <returns>A new <see cref="WebLink"/> which has been added to the given link collection.</returns>
        public static OpenApiWebLink ResolveAndAdd(this WebLinkCollection linkCollection, IOpenApiWebLinkResolver linkResolver, object owner, string rel, params (string, object)[] parameters)
        {
            OpenApiWebLink link = linkResolver.Resolve(owner, rel, parameters);
            linkCollection.Add(link);
            return link;
        }

        /// <summary>
        /// Adds a new link resolved using the given resolver for the specified object and relation type, in the given context.
        /// </summary>
        /// <param name="linkCollection">The <see cref="WebLinkCollection"/> to add to.</param>
        /// <param name="linkResolver">The <see cref="IOpenApiWebLinkResolver"/> to use for resolving links.</param>
        /// <param name="owner">The owner of the link. An operation map for the owner and relation type must be defined on startup.</param>
        /// <param name="rel">The link relation type.</param>
        /// <param name="context">The context in which to resolve the link.</param>
        /// <param name="parameters">Any parameters that will be required to build the link.</param>
        /// <returns>A new <see cref="WebLink"/> which has been added to the given link collection.</returns>
        public static OpenApiWebLink ResolveAndAdd(this WebLinkCollection linkCollection, IOpenApiWebLinkResolver linkResolver, object owner, string rel, string context, params (string, object)[] parameters)
        {
            OpenApiWebLink link = linkResolver.Resolve(owner, rel, context, parameters);
            linkCollection.Add(link);
            return link;
        }

        /// <summary>
        /// Adds a new link resolved using the given resolver for the specified object and relation type.
        /// </summary>
        /// <param name="linkCollection">The <see cref="WebLinkCollection"/> to add to.</param>
        /// <param name="linkResolver">The <see cref="IOpenApiWebLinkResolver"/> to use for resolving links.</param>
        /// <param name="operationId">The ID of the operation for the link.</param>
        /// <param name="rel">The link relation type.</param>
        /// <param name="parameters">Any parameters that will be required to build the link.</param>
        /// <returns>A new <see cref="WebLink"/> which has been added to the given link collection.</returns>
        public static OpenApiWebLink ResolveAndAdd(this WebLinkCollection linkCollection, IOpenApiWebLinkResolver linkResolver, string operationId, string rel, params (string, object)[] parameters)
        {
            OpenApiWebLink link = linkResolver.Resolve(rel, operationId, parameters);
            linkCollection.Add(link);
            return link;
        }
    }
}
