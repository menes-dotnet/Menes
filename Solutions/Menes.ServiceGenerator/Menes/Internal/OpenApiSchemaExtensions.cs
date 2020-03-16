// <copyright file="OpenApiSchemaExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Extensions for the <see cref="OpenApiSchema"/> type.
    /// </summary>
    public static class OpenApiSchemaExtensions
    {
        /// <summary>
        /// Gets the type name for a schema definition.
        /// </summary>
        /// <param name="typeSchema">The <see cref="OpenApiSchema"/> for which to generate a type name.</param>
        /// <param name="fallbackName">The fallback name if one cannot be derived.</param>
        /// <returns>The name for the OpenApi schema definition.</returns>
        /// <remarks>
        /// <para>This will attempt to use a PascalCased version of the type's <see cref="OpenApiReference.Id"/> if present. Otherwise it will use the <paramref name="fallbackName"/>.</para>
        /// </remarks>
        public static string GetTypeName(this OpenApiSchema typeSchema, string fallbackName)
        {
            string typeName = fallbackName;
            if (!string.IsNullOrEmpty(typeSchema.Reference?.Id))
            {
                typeName = NamingHelpers.ConvertCaseString(typeSchema.Reference!.Id, NamingHelpers.Case.PascalCase);
            }

            return typeName;
        }

        /// <summary>
        /// Determines if a schema is of an object type.
        /// </summary>
        /// <param name="typeSchema">The type schema to check.</param>
        /// <returns>True if the <see cref="OpenApiSchema.Type"/> is null or <c>"object"</c>.</returns>
        public static bool IsObjectType(this OpenApiSchema typeSchema)
        {
            return typeSchema.Type is null || typeSchema.Type == "object";
        }
    }
}
