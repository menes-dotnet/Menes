// <copyright file="DateConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using System;
    using Menes.Validation;
    using Microsoft.OpenApi.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// An OpenAPI converter for dates.
    /// </summary>
    public class DateConverter : IOpenApiConverter
    {
        private readonly OpenApiSchemaValidator validator;
        private readonly IOpenApiConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateConverter"/> class.
        /// </summary>
        /// <param name="validator">The <see cref="OpenApiSchemaValidator"/>.</param>
        /// <param name="configuration">The OpenAPI host configuration.</param>
        public DateConverter(OpenApiSchemaValidator validator, IOpenApiConfiguration configuration)
        {
            this.validator = validator;
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        public bool CanConvert(OpenApiSchema schema, bool ignoreFormat = false)
        {
            return schema.Type == "string" && schema.Format == "date";
        }

        /// <inheritdoc/>
        public object ConvertFrom(string content, OpenApiSchema schema)
        {
            JToken token = content;
            var result = (DateTimeOffset)token;

            this.validator.ValidateAndThrow(result, schema);

            return result;
        }

        /// <inheritdoc/>
        public string ConvertTo(object instance, OpenApiSchema schema)
        {
            string result = JsonConvert.SerializeObject(instance, this.configuration.Formatting, this.configuration.SerializerSettings);

            this.validator.ValidateAndThrow(result, schema);

            return result;
        }
    }
}