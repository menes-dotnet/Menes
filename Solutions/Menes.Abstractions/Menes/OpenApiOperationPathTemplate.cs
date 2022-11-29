// <copyright file="OpenApiOperationPathTemplate.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Corvus.Extensions;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// A URI match for an operation.
    /// </summary>
    public class OpenApiOperationPathTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiOperationPathTemplate"/> class.
        /// </summary>
        /// <param name="operation">The matching OpenAPI operation.</param>
        /// <param name="openApiPathTemplate">The matching OpenAPI path template.</param>
        public OpenApiOperationPathTemplate(OpenApiOperation operation, OpenApiPathTemplate openApiPathTemplate)
        {
            this.Operation = operation;
            this.OpenApiPathTemplate = openApiPathTemplate;
        }

        /// <summary>
        /// Gets the operation for the match result.
        /// </summary>
        public OpenApiOperation Operation { get; }

        /// <summary>
        /// Gets the OpenApi path template that matched.
        /// </summary>
        public OpenApiPathTemplate OpenApiPathTemplate { get; }

        /// <summary>
        /// Builds the list of Open API parameters for this match.
        /// </summary>
        /// <returns>The list of OpenAPI parameters for the match.</returns>
        public IList<OpenApiParameter> BuildOpenApiParameters()
        {
            Dictionary<string, OpenApiParameter> openApiParameters = this.OpenApiPathTemplate.PathItem.Parameters.ToDictionary(k => k.Name, v => v) ?? new Dictionary<string, OpenApiParameter>();
            foreach (OpenApiParameter parameter in this.Operation.Parameters)
            {
                openApiParameters.ReplaceIfExists(parameter.Name, parameter);
            }

            return openApiParameters.Values.ToList();
        }

        /// <summary>
        /// Builds the set of template parameters for the match from a request uri.
        /// </summary>
        /// <param name="requestUri">The uri for the request.</param>
        /// <returns>A dictionary of parameter names to values.</returns>
        public IDictionary<string, object>? BuildTemplateParameterValues(Uri requestUri)
        {
            return this.OpenApiPathTemplate.UriTemplate.GetParameters(requestUri);
        }
    }
}