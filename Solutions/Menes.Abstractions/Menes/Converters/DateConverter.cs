// <copyright file="DateConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using System;

    using Menes.Validation;

    using Microsoft.OpenApi.Models;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// An OpenAPI converter for dates.
    /// </summary>
    public class DateConverter : IOpenApiConverter
    {
        private readonly OpenApiSchemaValidator validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateConverter"/> class.
        /// </summary>
        /// <param name="validator">The <see cref="OpenApiSchemaValidator"/>.</param>
        public DateConverter(OpenApiSchemaValidator validator)
        {
            this.validator = validator;
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
            var result = new DateTimeOffset(DateTime.SpecifyKind((DateTime)token, DateTimeKind.Utc));

            this.validator.ValidateAndThrow(token, schema);

            return result;
        }

        /// <inheritdoc/>
        public string ConvertTo(object instance, OpenApiSchema schema)
        {
            string result = instance switch
            {
                DateTimeOffset dt => $"\"{dt:yyyy-MM-dd}\"",
                DateTime dt => $"\"{dt:yyyy-MM-dd}\"",
                DateOnly dt => $"\"{dt:yyyy-MM-dd}\"",
                _ => throw new ArgumentException($"Unsupported source type {instance.GetType().FullName}"),
            };

            this.validator.ValidateAndThrow(JToken.Parse(result), schema);

            return result;
        }
    }
}