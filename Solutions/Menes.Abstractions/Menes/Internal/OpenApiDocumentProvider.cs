// <copyright file="OpenApiDocumentProvider.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using Corvus.Extensions;
    using Menes.Exceptions;
    using Menes.Internal;
    using Menes.Validation;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using Tavis.UriTemplates;

    /// <summary>
    /// A URI template provider for Open API operations.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Clients can inject an instance of this template provider, supplied by the
    /// Open API hosting environment, and use it to obtain URI templates for operations
    /// exposed by that host.
    /// </para>
    /// <para>
    /// Having obtained a URI template, you can use <see cref="UriTemplate.SetParameter(string, object)"/>
    /// to build the URI for your operation, and <see cref="UriTemplate.Resolve()"/> to obtain the URI
    /// formatted with those parameters.
    /// </para>
    /// <para>
    /// Commonly, you will just use the <see cref="GetResolvedOperationRequestInfo"/> method which also handles query string parameters.
    /// to build that directly.
    /// </para>
    /// <para>
    /// </para>
    /// </remarks>
    public class OpenApiDocumentProvider : IOpenApiDocumentProvider
    {
        private readonly IList<OpenApiPathTemplate> pathTemplates = new List<OpenApiPathTemplate>();
        private readonly ILogger<OpenApiDocumentProvider> logger;
        private readonly List<OpenApiDocument> addedOpenApiDocuments;
        private IDictionary<string, OpenApiPathTemplate> pathTemplatesByOperationId;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiDocumentProvider"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public OpenApiDocumentProvider(ILogger<OpenApiDocumentProvider> logger)
        {
            this.logger = logger;
            this.addedOpenApiDocuments = new List<OpenApiDocument>();
        }

        /// <inheritdoc/>
        public IReadOnlyList<OpenApiDocument> AddedOpenApiDocuments
        {
            get { return this.addedOpenApiDocuments; }
        }

        /// <inheritdoc/>
        public UriTemplate GetUriTemplateForOperation(string operationId)
        {
            return new UriTemplate(this.pathTemplatesByOperationId[operationId]?.UriTemplate.ToString());
        }

        /// <inheritdoc/>
        public ResolvedOperationRequestInfo GetResolvedOperationRequestInfo(string operationId, params (string Name, object Value)[] parameters)
        {
            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug("Getting URI for [{operation}]", operationId);
            }

            OpenApiPathTemplate pathTemplate = this.pathTemplatesByOperationId[operationId];
            KeyValuePair<OperationType, OpenApiOperation> operation = pathTemplate.PathItem.Operations.First(x => x.Value.OperationId == operationId);
            UrlEncoder encoder = UrlEncoder.Default;
            var template = new UriTemplate(pathTemplate.UriTemplate.ToString());
            var paramNames = template.GetParameterNames().ToDictionary(k => k, v => v);
            var queryString = new StringBuilder();

            // TODO: Validate all required parameters are present
            foreach ((string name, object value) in parameters)
            {
                if (this.logger.IsEnabled(LogLevel.Debug))
                {
                    this.logger.LogDebug("Creating URI using parameter name [{name}] value [{value}]", name, value);
                }

                if (paramNames.ContainsKey(name))
                {
                    if (this.logger.IsEnabled(LogLevel.Debug))
                    {
                        this.logger.LogDebug("Set template parameter using parameter name [{name}] value [{value}]", name, value);
                    }

                    template.SetParameter(name, value);
                }
                else if (operation.Value.Parameters.Any(p => p.Name == name && p.In == ParameterLocation.Query) && value != null)
                {
                    if (queryString.Length == 0)
                    {
                        queryString.Append("?").Append(encoder.Encode(name)).Append("=").Append(encoder.Encode(value.ToString()));
                    }
                    else
                    {
                        queryString.Append("&").Append(encoder.Encode(name)).Append("=").Append(encoder.Encode(value.ToString()));
                    }
                }
            }

            return new ResolvedOperationRequestInfo
            {
                Uri = template.Resolve() + queryString.ToString(),
                OperationType = operation.Key,
            };
        }

        /// <summary>
        /// Add an OpenApi document to the path template provider.
        /// </summary>
        /// <param name="document">The document to add.</param>
        public void Add(OpenApiDocument document)
        {
            OpenApiDocumentValidationResult validationResult = document.ValidateDocument();
            if (!validationResult.IsValid)
            {
                throw new OpenApiServiceMismatchException(
                    $"Invalid OpenApiDocument: {string.Join(Environment.NewLine, validationResult.Errors.Select(e => $"{e.RuleName}: {e.Message} ({e.Pointer})"))}");
            }

            this.addedOpenApiDocuments.Add(document);
            this.pathTemplates.AddRange(document.Paths.Select(path => new OpenApiPathTemplate(path.Key, path.Value)));
            this.pathTemplatesByOperationId = this.pathTemplates.SelectMany(t => t.PathItem.Operations.Select(o => new { o.Value.OperationId, PathTemplate = t })).ToDictionary(k => k.OperationId, v => v.PathTemplate);
            if (this.logger.IsEnabled(LogLevel.Trace))
            {
                this.logger.LogTrace("Added Document [{document}] to template provider", document.Info?.Title ?? "No title provided.");
            }
        }

        /// <inheritdoc/>
        public bool GetOperationPathTemplate(string requestPath, string method, out OpenApiOperationPathTemplate operationPathTemplate)
        {
            foreach (OpenApiPathTemplate template in this.pathTemplates)
            {
                if (template.Match.IsMatch(requestPath))
                {
                    if (template.PathItem.Operations.TryGetValue(method.ToOperationType(), out OpenApiOperation operation))
                    {
                        this.logger.LogInformation(
                            "Matched request [{method}] [{requestPath}] with template [{template}] to [{operation}]",
                            method,
                            requestPath,
                            template.UriTemplate,
                            operation.GetOperationId());

                        // This is the success path
                        operationPathTemplate = new OpenApiOperationPathTemplate(operation, template);
                        return true;
                    }
                }
            }

            if (this.logger.IsEnabled(LogLevel.Debug))
            {
                this.logger.LogDebug("Failed to match request [{method}] [{requestPath}] to any template", method, requestPath);
            }

            operationPathTemplate = null;
            return false;
        }
    }
}