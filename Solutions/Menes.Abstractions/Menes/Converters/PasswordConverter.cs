// <copyright file="PasswordConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using Menes.Validation;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An OpenAPI converter for passwords.
    /// </summary>
    public class PasswordConverter : IOpenApiConverter
    {
        private readonly OpenApiSchemaValidator validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordConverter"/> class.
        /// </summary>
        /// <param name="validator">The <see cref="OpenApiSchemaValidator"/>.</param>
        public PasswordConverter(OpenApiSchemaValidator validator)
        {
            this.validator = validator;
        }

        /// <inheritdoc/>
        public bool CanConvert(OpenApiSchema schema, bool ignoreFormat = false)
        {
            return schema.Type == "string" && schema.Format == "password";
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
            string result = (string)instance;

            this.validator.ValidateAndThrow(result, schema);

            return $"\"{result}\"";
        }
    }
}