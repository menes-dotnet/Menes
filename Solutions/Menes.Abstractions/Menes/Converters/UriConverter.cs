// <copyright file="UriConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using System;
    using System.Text.Json.Nodes;

    using Menes.Validation;

    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An OpenAPI converter for dates.
    /// </summary>
    public class UriConverter : IOpenApiConverter
    {
        private readonly OpenApiSchemaValidator validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UriConverter"/> class.
        /// </summary>
        /// <param name="validator">The <see cref="OpenApiSchemaValidator"/>.</param>
        public UriConverter(OpenApiSchemaValidator validator)
        {
            this.validator = validator;
        }

        /// <inheritdoc/>
        public bool CanConvert(OpenApiSchema schema, bool ignoreFormat = false)
        {
            return schema.Type == "string" && schema.Format == "uri";
        }

        /// <inheritdoc/>
        public object ConvertFrom(string content, OpenApiSchema schema)
        {
            var result = new Uri(content, UriKind.RelativeOrAbsolute);

            this.validator.ValidateAndThrow(content, schema);

            return result;
        }

        /// <inheritdoc/>
        public string ConvertTo(object instance, OpenApiSchema schema)
        {
            string result = instance.ToString()!;

            this.validator.ValidateAndThrow(result, schema);

            return JsonValue.Create(result)!.ToJsonString();
        }
    }
}