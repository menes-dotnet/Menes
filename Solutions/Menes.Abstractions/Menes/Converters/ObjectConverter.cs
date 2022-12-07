// <copyright file="ObjectConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using System;
    using System.Text.Json;

    using Menes.Validation;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// An OpenAPI converter for objects.
    /// </summary>
    public class ObjectConverter : IOpenApiConverter
    {
        private readonly IServiceProvider serviceProvider;
        private readonly OpenApiSchemaValidator validator;
        private readonly IOpenApiConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectConverter"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider that can supply type information.</param>
        /// <param name="validator">The <see cref="OpenApiSchemaValidator"/>.</param>
        /// <param name="configuration">The OpenAPI host configuration.</param>
        public ObjectConverter(IServiceProvider serviceProvider, OpenApiSchemaValidator validator, IOpenApiConfiguration configuration)
        {
            this.serviceProvider = serviceProvider;
            this.validator = validator;
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        public bool CanConvert(OpenApiSchema schema, bool ignoreFormat = false)
        {
            return schema.Type == "array" || schema.Type == null || schema.Type == "object";
        }

        /// <inheritdoc/>
        public object ConvertFrom(string content, OpenApiSchema schema)
        {
            this.validator.ValidateAndThrow(content, schema);

            // Use the discriminator to look up the type, if it is available
            string? discriminator = schema.Discriminator?.PropertyName;

            string? type;
            if (!string.IsNullOrEmpty(discriminator))
            {
                using var jdoc = JsonDocument.Parse(content);
                type = jdoc.RootElement.TryGetProperty(discriminator, out JsonElement discriminatorProperty) ? discriminatorProperty.GetString() : null;

                if (type == null)
                {
                    throw new InvalidOperationException($"The object does not contain the discriminator property {discriminator}");
                }
            }
            else
            {
                // If we had no discriminator, fall back on the format
                // This is where you know the "type" of the object, but you don't know what the actual schema is - it is an "any" from the point of view of the OpenAPI description
                type = schema.Format;
            }

            if (type == null)
            {
                // We have no means of discriminating the type, so we just return the value as a string
                // and leave it to it
                return content;
            }

            if (!this.configuration.DiscriminatedTypes.TryGetValue(type, out Type? targetType))
            {
                if (!this.serviceProvider.TryGetTypeFor(type, out targetType))
                {
                    // We have no immediately obvious way to discriminate the type, so fall back on the serializers.
                    return JsonSerializer.Deserialize<object>(content, this.configuration.SerializerOptions)!;
                }
            }

            return JsonSerializer.Deserialize(content, targetType, this.configuration.SerializerOptions)!;
        }

        /// <inheritdoc/>
        public string ConvertTo(object instance, OpenApiSchema schema)
        {
            string result = JsonSerializer.Serialize(instance, instance.GetType(), this.configuration.SerializerOptions);

            this.validator.ValidateAndThrow(result, schema);

            return result;
        }
    }
}