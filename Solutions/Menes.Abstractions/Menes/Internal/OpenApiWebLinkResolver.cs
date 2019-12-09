// <copyright file="OpenApiWebLinkResolver.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using Corvus.ContentHandling;
    using Menes.Exceptions;
    using Menes.Links;

    /// <summary>
    /// Class which can contruct <see cref="OpenApiWebLink"/> objects for link relations.
    /// </summary>
    public class OpenApiWebLinkResolver : IOpenApiWebLinkResolver
    {
        private readonly IOpenApiDocumentProvider templateProvider;
        private readonly IOpenApiLinkOperationMapper linkOperationMapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiWebLinkResolver"/> class.
        /// </summary>
        /// <param name="templateProvider">The template provider to build the Url.</param>
        /// <param name="linkOperationMapper">The class that contains mappings of object/content types to links.</param>
        public OpenApiWebLinkResolver(IOpenApiDocumentProvider templateProvider, IOpenApiLinkOperationMapper linkOperationMapper)
        {
            this.templateProvider = templateProvider;
            this.linkOperationMapper = linkOperationMapper;
        }

        /// <inheritdoc/>
        public OpenApiWebLink ResolveByOwnerAndRelation(object owner, string relationType, params (string, object)[] parameters)
        {
            if (this.linkOperationMapper.TryGetOperationId(owner, relationType, out string operationId))
            {
                ResolvedOperationRequestInfo operation = this.templateProvider.GetResolvedOperationRequestInfo(operationId, parameters);
                return new OpenApiWebLink(operationId, operation.Uri, operation.OperationType);
            }

            ContentFactory.TryGetContentType(owner, out string contentType);
            string fullTypeName = owner.GetType().FullName;

            throw new OpenApiLinkResolutionException(relationType, fullTypeName, contentType);
        }

        /// <inheritdoc/>
        public OpenApiWebLink ResolveByOwnerRelationAndContext(object owner, string relationType, string context, params (string, object)[] parameters)
        {
            if (this.linkOperationMapper.TryGetOperationId(owner, relationType, context, out string operationId))
            {
                ResolvedOperationRequestInfo operation = this.templateProvider.GetResolvedOperationRequestInfo(operationId, parameters);
                return new OpenApiWebLink(operationId, operation.Uri, operation.OperationType);
            }

            ContentFactory.TryGetContentType(owner, out string contentType);
            string fullTypeName = owner.GetType().FullName;

            throw new OpenApiLinkResolutionException(relationType, fullTypeName, contentType);
        }

        /// <inheritdoc/>
        public OpenApiWebLink ResolveByOperationIdAndRelation(string operationId, string relationType, params (string, object)[] parameters)
        {
            ResolvedOperationRequestInfo operation = this.templateProvider.GetResolvedOperationRequestInfo(operationId, parameters);
            return new OpenApiWebLink(operationId, operation.Uri, operation.OperationType);
        }
    }
}
