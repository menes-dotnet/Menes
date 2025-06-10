// <copyright file="OpenApiLinkOperationMapper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using Corvus.ContentHandling;
    using Corvus.Extensions;

    /// <summary>
    /// Class that handles mapping of content types/objects and link relation types to Open API operation Ids.
    /// </summary>
    public class OpenApiLinkOperationMapper : IOpenApiLinkOperationMapper
    {
        private const string GlobalContext = "menes.globallinkcontext";
        private readonly IDictionary<string, string> operationMappings;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiLinkOperationMapper"/> class.
        /// </summary>
        public OpenApiLinkOperationMapper()
        {
            this.operationMappings = new Dictionary<string, string>();
        }

        /// <inheritdoc/>
        public void MapByContentTypeAndRelationTypeAndOperationId(string contentType, string relationType, string operationId)
        {
            this.MapByContentTypeAndRelationTypeAndContextAndOperationId(contentType, relationType, GlobalContext, operationId);
        }

        /// <inheritdoc/>
        public void MapByContentTypeAndRelationTypeAndOperationId<T>(string relationType, string operationId)
        {
            this.MapByContentTypeAndRelationTypeAndContextAndOperationId<T>(relationType, GlobalContext, operationId);
        }

        /// <inheritdoc/>
        public void MapByContentTypeAndRelationTypeAndContextAndOperationId(string contentType, string relationType, string context, string operationId)
        {
            var mediaType = new MediaType(contentType, relationType);
            string key = GetKey(context, mediaType);
            if (!this.operationMappings.AddIfNotExists(key, operationId))
            {
                throw new InvalidOperationException($"You attempted to add the operation with ID '{operationId}' for the media type '{mediaType}' in the context '{context}', but the operation with ID '{this.operationMappings[key]}' has already been mapped for this type and context. Consider using the WebLinkCollection.ResolveAndAdd() overload that takes the operation ID in your implementation, or specify a different context.");
            }
        }

        /// <inheritdoc/>
        public void MapByContentTypeAndRelationTypeAndContextAndOperationId<T>(string relationType, string context, string operationId)
        {
            string contentType = GetContentType<T>();
            this.MapByContentTypeAndRelationTypeAndContextAndOperationId(contentType, relationType, context, operationId);
        }

        /// <inheritdoc/>
        public bool TryGetOperationId(object owner, string relationType, out string operationId)
        {
            return this.TryGetOperationId(owner, relationType, GlobalContext, out operationId);
        }

        /// <inheritdoc/>
        public bool TryGetOperationId(object owner, string relationType, string context, out string operationId)
        {
            if (ContentFactory.TryGetContentType(owner, out string? ownerContentType) && this.TryGetOperationId(ownerContentType, relationType, context, out operationId))
            {
                return true;
            }

            string fullTypeName = owner.GetType().FullName!;

            return this.TryGetOperationId(fullTypeName, relationType, context, out operationId);
        }

        private static string GetKey(string context, MediaType mediaType)
        {
            return $"{context}::{mediaType}";
        }

        private static string GetContentType<T>()
        {
            ContentFactory.TryGetContentType<T>(out string? contentType);
            return contentType ?? typeof(T).FullName!;
        }

        private bool TryGetOperationId(string contentType, string relationType, string context, out string operationName)
        {
            var targetMediaType = new MediaType(contentType, relationType);
            return this.operationMappings.TryGetRecursive(targetMediaType, m => GetKey(context, m), out operationName!);
        }
    }
}