﻿// <copyright file="DateConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using System;

    using Menes.Validation;

    using Microsoft.OpenApi.Models;

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
            var result = new DateTimeOffset(DateTime.SpecifyKind(DateTime.Parse(content), DateTimeKind.Utc));

            this.validator.ValidateAndThrow(content, schema);

            return result;
        }

        /// <inheritdoc/>
        public string ConvertTo(object instance, OpenApiSchema schema)
        {
            string result = instance switch
            {
                DateTimeOffset dt => dt.ToString("yyyy-MM-dd"),
                DateTime dt => dt.ToString("yyyy-MM-dd"),
                DateOnly dt => dt.ToString("yyyy-MM-dd"),
                _ => throw new ArgumentException($"Unsupported source type {instance.GetType().FullName}"),
            };

            this.validator.ValidateAndThrow(result, schema);

            return $"\"{result}\"";
        }
    }
}