// <copyright file="JsonSchemaBuilder.FindProperties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// We find all the different ways that properties might be declared against this
        /// schema.
        /// </summary>
        /// <param name="schema">The schema to inspect.</param>
        /// <param name="typeDeclaration">The type declaration of the schema.</param>
        private async Task FindProperties(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            // We can find properties in the following ways:
            // 1. Accumulated from an 'allOf'
            // 1. Declared in the 'properties' element
            // 1. Declared in the 'required' element but not specified in the properties element, or accumulated from the 'allOf' element
            // No doubt I'll think of some more later.
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("properties", out JsonElement properties))
                {
                    this.PushPropertyToAbsoluteKeywordLocationStack("properties");

                    foreach (JsonProperty property in properties.EnumerateObject())
                    {
                        this.PushPropertyToAbsoluteKeywordLocationStack(property);

                        await this.CreatePropertyDeclarationFor(typeDeclaration, property).ConfigureAwait(false);

                        this.absoluteKeywordLocationStack.Pop();
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }
            }
        }

        private async Task CreatePropertyDeclarationFor(TypeDeclaration typeDeclaration, JsonProperty property)
        {
            var propertyDeclaration = new PropertyDeclaration
            {
                JsonPropertyName = property.Name,
                DotnetPropertyName = Formatting.ToPascalCaseWithReservedWords(property.Name).ToString(),
            };

            JsonReference location = this.absoluteKeywordLocationStack.Peek();
            if (this.locatedElementsByLocation.TryGetValue(location, out LocatedElement propertyTypeElement))
            {
                propertyDeclaration.TypeDeclaration = await this.BuildTypeDeclaration(propertyTypeElement).ConfigureAwait(false);
            }
            else
            {
                throw new InvalidOperationException($"Unable to find element for property type at location: '{location}'");
            }

            typeDeclaration.AddPropertyDeclaration(propertyDeclaration);
        }
    }
}