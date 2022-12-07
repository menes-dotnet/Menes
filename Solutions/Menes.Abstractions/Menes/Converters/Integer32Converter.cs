// <copyright file="Integer32Converter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using System.Text.Json;

    using Menes.Validation;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An OpenAPI converter for int64 integers.
    /// </summary>
    public class Integer32Converter : IOpenApiConverter
    {
        private readonly OpenApiSchemaValidator validator;
        private readonly IOpenApiConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Integer32Converter"/> class.
        /// </summary>
        /// <param name="validator">The <see cref="OpenApiSchemaValidator"/>.</param>
        /// <param name="configuration">The OpenAPI host configuration.</param>
        public Integer32Converter(OpenApiSchemaValidator validator, IOpenApiConfiguration configuration)
        {
            this.validator = validator;
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        public bool CanConvert(OpenApiSchema schema, bool ignoreFormat = false)
        {
            return schema.Type == "integer" && (ignoreFormat || schema.Format == "int32");
        }

        /// <inheritdoc/>
        public object ConvertFrom(string content, OpenApiSchema schema)
        {
            int result = int.Parse(content);

            this.validator.ValidateAndThrow(content, schema);

            return result;
        }

        /// <inheritdoc/>
        public string ConvertTo(object instance, OpenApiSchema schema)
        {
            string result = JsonSerializer.Serialize(instance, typeof(int), this.configuration.SerializerOptions);

            this.validator.ValidateAndThrow(result, schema);

            return result;
        }
    }
}