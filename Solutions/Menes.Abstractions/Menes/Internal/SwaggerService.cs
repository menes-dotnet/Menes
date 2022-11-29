// <copyright file="SwaggerService.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An OpenAPI service that will return the OpenAPI definition in YAML or JSON form.
    /// </summary>
    public class SwaggerService : IOpenApiService
    {
        /// <summary>
        /// The OpenApi operation id for the swagger endpoint.
        /// </summary>
        public const string SwaggerOperationId = "getSwagger";

        private readonly IOpenApiDocumentProvider templateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerService"/> class.
        /// </summary>
        /// <param name="templateProvider">
        /// The template provider that contains the list of OpenApi documents.
        /// </param>
        public SwaggerService(IOpenApiDocumentProvider templateProvider)
        {
            this.templateProvider = templateProvider;
        }

        /// <summary>
        /// Constructs an OpenApi document that will mapper the /swagger endpoint to the operation.
        /// </summary>
        /// <returns>
        /// The <see cref="OpenApiDocument"/>.
        /// </returns>
        public static OpenApiDocument BuildSwaggerDocument()
        {
            var jsonMediaType = new OpenApiMediaType { Schema = new OpenApiSchema { Type = "object" } };
            var response = new OpenApiResponse();

            response.Content.Add("application/json", jsonMediaType);
            response.Description = "OK";

            var operation = new OpenApiOperation
            {
                OperationId = SwaggerOperationId,
                Summary = "View swagger definition for this API",
                Description = "View swagger definition for this API",
            };

            operation.Responses.Add("200", response);

            var pathItem = new OpenApiPathItem();
            pathItem.Operations.Add(OperationType.Get, operation);

            return new OpenApiDocument
            {
                Paths = new OpenApiPaths
                {
                    { "/swagger", pathItem },
                },
            };
        }

        /// <summary>
        /// The swagger operation.
        /// </summary>
        /// <returns>
        /// The <see cref="OpenApiResult"/>.
        /// </returns>
        [OperationId("getSwagger")]
        public OpenApiResult Swagger()
        {
            OpenApiDocument mergedDocument = Merge(this.templateProvider.AddedOpenApiDocuments);

            return this.OkResult(mergedDocument);
        }

        private static OpenApiDocument Merge(IEnumerable<OpenApiDocument> documents)
        {
            var merged = new OpenApiDocument
            {
                Info = documents.FirstOrDefault()?.Info,
                Components = new OpenApiComponents(),
                Paths = new OpenApiPaths(),
            };

            foreach (OpenApiDocument document in documents)
            {
                MergeLists(merged.Servers, document.Servers, (x, y) => x?.Url == y?.Url);

                foreach (KeyValuePair<string, OpenApiPathItem> openApiPath in document.Paths)
                {
                    if (!merged.Paths.ContainsKey(openApiPath.Key))
                    {
                        merged.Paths.Add(openApiPath.Key, new OpenApiPathItem());
                    }

                    OpenApiPathItem mergedPath = merged.Paths[openApiPath.Key];
                    MergeDictionaries(mergedPath.Operations, openApiPath.Value.Operations);
                }

                MergeLists(merged.Tags, document.Tags, (x, y) => x?.Name == y?.Name);

                if (document.Components != null)
                {
                    MergeDictionaries(merged.Components.Schemas, document.Components.Schemas);
                    MergeDictionaries(merged.Components.Callbacks, document.Components.Callbacks);
                    MergeDictionaries(merged.Components.Examples, document.Components.Examples);
                    MergeDictionaries(merged.Components.Extensions, document.Components.Extensions);
                    MergeDictionaries(merged.Components.Headers, document.Components.Headers);
                    MergeDictionaries(merged.Components.Links, document.Components.Links);
                    MergeDictionaries(merged.Components.Parameters, document.Components.Parameters);
                    MergeDictionaries(merged.Components.RequestBodies, document.Components.RequestBodies);
                    MergeDictionaries(merged.Components.Responses, document.Components.Responses);
                    MergeDictionaries(merged.Components.SecuritySchemes, document.Components.SecuritySchemes);
                }
            }

            return merged;
        }

        private static void MergeDictionaries<TKey, TValue>(IDictionary<TKey, TValue> target, IDictionary<TKey, TValue> source)
        {
            foreach (KeyValuePair<TKey, TValue> current in source)
            {
                if (!target.ContainsKey(current.Key))
                {
                    target.Add(current.Key, current.Value);
                }
            }
        }

        private static void MergeLists<T>(IList<T> target, IList<T> source, Func<T, T, bool> equalityChecker)
        {
            foreach (T current in source)
            {
                if (target.All(x => !equalityChecker(current, x)))
                {
                    target.Add(current);
                }
            }
        }
    }
}