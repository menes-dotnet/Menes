// <copyright file="StringConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using Menes.Validation;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An OpenAPI converter for strings.
    /// </summary>
    public class StringConverter : IOpenApiConverter
    {
        private readonly OpenApiSchemaValidator validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringConverter"/> class.
        /// </summary>
        /// <param name="validator">The <see cref="OpenApiSchemaValidator"/>.</param>
        public StringConverter(OpenApiSchemaValidator validator)
        {
            this.validator = validator;
        }

        /// <inheritdoc/>
        public bool CanConvert(OpenApiSchema schema, bool ignoreFormat = false)
        {
            return schema.Type == "string" && (ignoreFormat || string.IsNullOrEmpty(schema.Format));
        }

        /// <inheritdoc/>
        public object ConvertFrom(string content, OpenApiSchema schema)
        {
            this.validator.ValidateAndThrow(content, schema);

            return content;
        }

        /// <inheritdoc/>
        public string ConvertTo(object instance, OpenApiSchema schema)
        {
            string result;

            if (instance is string stringValue)
            {
                result = stringValue;
            }
            else
            {
                result = instance.ToString()!;
            }

            this.validator.ValidateAndThrow(result, schema);

            return result;
        }
    }
}