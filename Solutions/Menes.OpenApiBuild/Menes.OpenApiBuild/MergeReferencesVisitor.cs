// <copyright file="MergeReferencesVisitor.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApiBuild
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.OpenApi;
    using Microsoft.OpenApi.Extensions;
    using Microsoft.OpenApi.Interfaces;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;
    using Microsoft.OpenApi.Services;
    using Microsoft.OpenApi.Validations;

    /// <summary>
    /// A visitor that merges external file references into the base document.
    /// </summary>
    internal class MergeReferencesVisitor : OpenApiVisitorBaseEx
    {
        private readonly HashSet<string> loadedDocuments = new HashSet<string>();
        private readonly OpenApiDocument rootDocument;

        private DirectoryInfo currentDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MergeReferencesVisitor"/> class.
        /// </summary>
        /// <param name="rootDocument">The root document for the merge.</param>
        /// <param name="rootDirectory">The root directory for the merge.</param>
        public MergeReferencesVisitor(OpenApiDocument rootDocument, DirectoryInfo rootDirectory)
        {
            this.currentDirectory = rootDirectory;
            this.rootDocument = rootDocument;
        }

        /// <inheritdoc/>
        public override void Visit(IOpenApiReferenceable referenceable)
        {
            this.TryMerge(referenceable);

            base.Visit(referenceable);
        }

        private static OpenApiComponents LoadOpenApiComponents(string path)
        {
            OpenApiComponents openApiComponents;
            using (StreamReader? textReader = File.OpenText(path))
            {
                var reader = new OpenApiTextReaderReader();
                openApiComponents = reader.ReadFragment<OpenApiComponents>(textReader, OpenApiSpecVersion.OpenApi3_0, out OpenApiDiagnostic diagnostic);

                ThrowOnError(diagnostic.Errors);
            }

            return openApiComponents;
        }

        private static void ThrowOnError(IEnumerable<OpenApiError> errors)
        {
            if (errors.Any())
            {
                throw new Exception(string.Join(Environment.NewLine, errors.Select(e => e.Message)));
            }
        }

        private void TryMerge(IOpenApiReferenceable referenceable)
        {
            if (referenceable.UnresolvedReference && referenceable.Reference.IsExternal)
            {
                this.MergeReferencedDocument(referenceable);
                referenceable.Reference.ExternalResource = null;
                string? id = referenceable.Reference.Id;
                if (id.StartsWith("components/callbacks"))
                {
                    referenceable.Reference.Id = id.Substring("components/callbacks".Length + 1);
                    referenceable.Reference.Type = ReferenceType.Callback;
                }
                else if (id.StartsWith("components/examples"))
                {
                    referenceable.Reference.Id = id.Substring("components/examples".Length + 1);
                    referenceable.Reference.Type = ReferenceType.Example;
                }
                else if (id.StartsWith("components/headers"))
                {
                    referenceable.Reference.Id = id.Substring("components/headers".Length + 1);
                    referenceable.Reference.Type = ReferenceType.Header;
                }
                else if (id.StartsWith("components/links"))
                {
                    referenceable.Reference.Id = id.Substring("components/links".Length + 1);
                    referenceable.Reference.Type = ReferenceType.Link;
                }
                else if (id.StartsWith("components/parameters"))
                {
                    referenceable.Reference.Id = id.Substring("components/parameters".Length + 1);
                    referenceable.Reference.Type = ReferenceType.Parameter;
                }
                else if (id.StartsWith("components/requestBodies"))
                {
                    referenceable.Reference.Id = id.Substring("components/requestBodies".Length + 1);
                    referenceable.Reference.Type = ReferenceType.RequestBody;
                }
                else if (id.StartsWith("components/responses"))
                {
                    referenceable.Reference.Id = id.Substring("components/responses".Length + 1);
                    referenceable.Reference.Type = ReferenceType.Response;
                }
                else if (id.StartsWith("components/schemas"))
                {
                    referenceable.Reference.Id = id.Substring("components/schemas".Length + 1);
                    referenceable.Reference.Type = ReferenceType.Schema;
                }
                else if (id.StartsWith("components/callbacks"))
                {
                    referenceable.Reference.Id = id.Substring("components/callbacks".Length + 1);
                    referenceable.Reference.Type = ReferenceType.SecurityScheme;
                }
                else
                {
                    throw new Exception($"Unrecognized reference type: {id}");
                }
            }
        }

        private void MergeReferencedDocument(IOpenApiReferenceable referenceable)
        {
            string? path = Path.Combine(this.currentDirectory.FullName, referenceable.Reference.ExternalResource.Replace('/', Path.DirectorySeparatorChar).Replace('\\', Path.DirectorySeparatorChar));

            if (!this.loadedDocuments.Contains(path))
            {
                // Ensure we don't attempt to load this again
                // placed at the start to prevent circular dependencies
                this.loadedDocuments.Add(path);

                OpenApiComponents? components = LoadOpenApiComponents(path);

                ThrowOnError(components.Validate(ValidationRuleSet.GetDefaultRuleSet()));

                this.WalkLoadedComponents(path, components);
                this.MergeComponents(components, this.rootDocument.Components);
            }
        }

        private void MergeComponents(OpenApiComponents source, OpenApiComponents target)
        {
            foreach (KeyValuePair<string, OpenApiCallback> component in source.Callbacks)
            {
                target.Callbacks.Add(component);
            }

            foreach (KeyValuePair<string, OpenApiExample> component in source.Examples)
            {
                target.Examples.Add(component);
            }

            foreach (KeyValuePair<string, OpenApiHeader> component in source.Headers)
            {
                target.Headers.Add(component);
            }

            foreach (KeyValuePair<string, OpenApiLink> component in source.Links)
            {
                target.Links.Add(component);
            }

            foreach (KeyValuePair<string, OpenApiParameter> component in source.Parameters)
            {
                target.Parameters.Add(component);
            }

            foreach (KeyValuePair<string, OpenApiRequestBody> component in source.RequestBodies)
            {
                target.RequestBodies.Add(component);
            }

            foreach (KeyValuePair<string, OpenApiResponse> component in source.Responses)
            {
                target.Responses.Add(component);
            }

            foreach (KeyValuePair<string, OpenApiSchema> component in source.Schemas)
            {
                target.Schemas.Add(component);
            }

            foreach (KeyValuePair<string, OpenApiSecurityScheme> component in source.SecuritySchemes)
            {
                target.SecuritySchemes.Add(component);
            }
        }

        private void WalkLoadedComponents(string path, OpenApiComponents components)
        {
            DirectoryInfo? previousDirectory = this.currentDirectory;
            try
            {
                this.currentDirectory = new FileInfo(path).Directory;
                var walker = new OpenApiWalkerEx(this);
                var tempDoc = new OpenApiDocument { Components = components };
                walker.Walk(tempDoc);
            }
            finally
            {
                this.currentDirectory = previousDirectory;
            }
        }
    }
}
