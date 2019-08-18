// <copyright file="OpenApiSchemaExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Extension methods for <see cref="OpenApiSchema"/>.
    /// </summary>
    public static class OpenApiSchemaExtensions
    {
        /// <summary>
        /// Gets information to log.
        /// </summary>
        /// <param name="schema">The <see cref="OpenApiSchema"/>.</param>
        /// <returns>Information to log.</returns>
        public static string GetLoggingInformation(this OpenApiSchema schema)
        {
            if (schema.Reference != null)
            {
                return $"schema with reference Id {schema.Reference.Id}";
            }
            else if (schema.Type != null)
            {
                return $"schema with type {schema.Type}";
            }

            return "schema with no type or reference ID";
        }
    }
}
