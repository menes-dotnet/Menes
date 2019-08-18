// <copyright file="BooleanConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using Menes.Validation;
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// An OpenAPI converter for booleans.
    /// </summary>
    public class BooleanConverter : IOpenApiConverter
    {
        private readonly OpenApiSchemaValidator validator;
        private readonly OpenApiConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanConverter"/> class.
        /// </summary>
        /// <param name="validator">The <see cref="OpenApiSchemaValidator"/>.</param>
        /// <param name="configuration">The OpenAPI host configuration.</param>
        public BooleanConverter(OpenApiSchemaValidator validator, OpenApiConfiguration configuration)
        {
            this.validator = validator;
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        public bool CanConvert(OpenApiSchema schema, bool ignoreFormat = false)
        {
            return schema.Type == "boolean" && (ignoreFormat || string.IsNullOrEmpty(schema.Format));
        }

        /// <inheritdoc/>
        public object ConvertFrom(string content, OpenApiSchema schema)
        {
            JToken token = content;
            bool result = (bool)token;

            this.validator.ValidateAndThrow(result, schema);

            return result;
        }

        /// <inheritdoc/>
        public string ConvertTo(object instance, OpenApiSchema schema)
        {
            string result = JsonConvert.SerializeObject(instance, this.configuration.Formatting, this.configuration.DefaultSerializerSettings);

            this.validator.ValidateAndThrow(result, schema);

            return result;
        }
    }
}