// <copyright file="StringConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using Menes.Validation;
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// An OpenAPI converter for strings.
    /// </summary>
    public class StringConverter : IOpenApiConverter
    {
        private readonly OpenApiSchemaValidator validator;
        private readonly IOpenApiConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringConverter"/> class.
        /// </summary>
        /// <param name="validator">The <see cref="OpenApiSchemaValidator"/>.</param>
        /// <param name="configuration">The OpenAPI host configuration.</param>
        public StringConverter(OpenApiSchemaValidator validator, IOpenApiConfiguration configuration)
        {
            this.validator = validator;
            this.configuration = configuration;
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
            string result = JsonConvert.SerializeObject(instance, this.configuration.Formatting, this.configuration.SerializerSettings);

            this.validator.ValidateAndThrow(JToken.Parse(result), schema);

            return result;
        }
    }
}