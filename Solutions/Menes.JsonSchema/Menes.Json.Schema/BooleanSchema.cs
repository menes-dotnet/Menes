// <copyright file="BooleanSchema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System.Text.Json;

    /// <summary>
    /// Represents the boolean schema <c>true</c> and <c>false</c> equivalent to <c>{}</c> and <c>not: {}</c> respectively.
    /// </summary>
    public static class BooleanSchema
    {
        /// <summary>
        /// Gets the 'True' schema.
        /// </summary>
        public static readonly JsonSchema True = new JsonSchema(BuildElement("true"));

        /// <summary>
        /// Gets the 'false' schema.
        /// </summary>
        public static readonly JsonSchema False = new JsonSchema(BuildElement("false"));

        private static JsonElement BuildElement(string value)
        {
            using var document = JsonDocument.Parse(value);
            return document.RootElement.Clone();
        }
    }
}
