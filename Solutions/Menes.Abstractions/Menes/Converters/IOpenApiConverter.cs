// <copyright file="IOpenApiConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Converters
{
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Implemented by types that can convert a value to/from an OpenAPI schema value.
    /// </summary>
    public interface IOpenApiConverter
    {
        /// <summary>
        /// Determine if the converter can handle a particular schema.
        /// </summary>
        /// <param name="schema">The schema to handle.</param>
        /// <param name="ignoreFormat">Whether it can convert if the format is ignored.</param>
        /// <returns>True if this converter can handle the schema.</returns>
        bool CanConvert(OpenApiSchema schema, bool ignoreFormat = false);

        /// <summary>
        /// Convert from the specified content to an object of the required type.
        /// </summary>
        /// <param name="content">The content to convert.</param>
        /// <param name="schema">The schema of the content to convert.</param>
        /// <returns>An instance of the converted object.</returns>
        object ConvertFrom(string content, OpenApiSchema schema);

        /// <summary>
        /// Convert to a string representation from an object of the specified type.
        /// </summary>
        /// <param name="instance">The instance to convert.</param>
        /// <param name="schema">The schema of the content to convert.</param>
        /// <returns>A string representation of the converted object for the output document.</returns>
        string ConvertTo(object instance, OpenApiSchema schema);
    }
}