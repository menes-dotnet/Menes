// <copyright file="OpenApiServiceBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApi.SchemaModel
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;

    /// <summary>
    /// Builds OpenAPI service output.
    /// </summary>
    public class OpenApiServiceBuilder
    {
        private readonly Stack<Document.ServerValueArray> serverStack = new Stack<Document.ServerValueArray>();
        private readonly IDocumentResolver resolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiServiceBuilder"/> class.
        /// </summary>
        /// <param name="resolver">The document resolver to use.</param>
        public OpenApiServiceBuilder(IDocumentResolver resolver)
        {
            this.resolver = resolver;
        }

        /// <summary>
        /// Build services for the given OpenApi document.
        /// </summary>
        /// <param name="rootReference">The root reference from which to load the document.</param>
        /// <returns>A <see cref="Task"/> which completes when the services are built.</returns>
        public async Task BuildServices(string rootReference)
        {
            Document openApiDocument = await this.ResolveReference<Document>(rootReference).ConfigureAwait(false);

            this.PushRootServers(openApiDocument);

            await this.ProcessPaths(openApiDocument).ConfigureAwait(false);
        }

        private async Task ProcessPaths(Document openApiDocument)
        {
            foreach (Property pathProperty in openApiDocument.Paths.EnumerateObject())
            {
                if (IsPathItemValue(pathProperty))
                {
                    Document.PathItemValue pathItem = pathProperty.ValueAs<Document.PathItemValue>();
                    await this.ProcessPathItem(pathProperty.Name, pathItem).ConfigureAwait(false);
                }
            }

            static bool IsPathItemValue(Property pathProperty)
            {
                return Document.PathsValue.PatternPropertyPathItemValue.IsMatch(pathProperty.Name);
            }
        }

        private async Task ProcessPathItem(string path, Document.PathItemValue pathItem)
        {
            if (pathItem.Ref.IsNotNullOrUndefined())
            {
                pathItem = await this.ResolveReference<Document.PathItemValue>(pathItem.Ref).ConfigureAwait(false);
            }

            if (pathItem.Servers.IsNotNullOrUndefined())
            {
                this.serverStack.Push(pathItem.Servers.As<Document.ServerValueArray>());
            }

            foreach (Property property in pathItem.EnumerateObject())
            {
                if (IsOperationValue(property))
                {
                    await this.ProcessOperation(property.Name, property.ValueAs<Document.OperationValue>()).ConfigureAwait(false);
                }
            }

            if (pathItem.Servers.IsNotNullOrUndefined())
            {
                this.serverStack.Pop();
            }

            static bool IsOperationValue(Property pathItemProperty)
            {
                return Document.PathItemValue.PatternPropertyOperationValue.IsMatch(pathItemProperty.Name);
            }
        }

        private Task ProcessOperation(string verb, Document.OperationValue operation)
        {
            if (operation.Servers.IsNotNullOrUndefined())
            {
                this.serverStack.Push(operation.Servers.As<Document.ServerValueArray>());
            }

            //// DO WHATEVER WE NEED TO DO

            if (operation.Servers.IsNotNullOrUndefined())
            {
                this.serverStack.Pop();
            }

            return Task.CompletedTask;
        }

        private void PushRootServers(Document openApiDocument)
        {
            if (openApiDocument.Servers.IsNotNullOrUndefined())
            {
                this.serverStack.Push(openApiDocument.Servers);
            }
            else
            {
                this.serverStack.Push(
                    Document.ServerValueArray.From(Document.ServerValue.Create("/")));
            }
        }

        private async Task<T> ResolveReference<T>(string reference)
            where T : struct, IJsonValue
        {
            JsonElement? openApiElement = await this.resolver.TryResolve(new JsonReference(reference)).ConfigureAwait(false);

            if (openApiElement is JsonElement element)
            {
                T entity = new JsonAny(element).As<T>();
                if (!entity.IsValid())
                {
                    throw new ArgumentException($"The entity at '{reference}' is not a valid {typeof(T).Name}.", nameof(reference));
                }

                return entity;
            }

            throw new ArgumentException($"Unable to resolve the {typeof(T).Name} at '{reference}'.", nameof(reference));
        }
    }
}
