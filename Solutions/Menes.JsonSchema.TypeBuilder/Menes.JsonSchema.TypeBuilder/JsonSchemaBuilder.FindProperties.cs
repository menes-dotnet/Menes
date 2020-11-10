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
            // 1. Accumulated from an 'allOf' (dealt with elsewhere)
            // 1. Declared in the 'properties' element
            // 1. Declared in the 'required' element but not specified in the properties element, or accumulated from the 'allOf' element
            // No doubt I'll think of some more later.
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                await this.AddProperties(schema, typeDeclaration).ConfigureAwait(false);
                this.AddRequiredProperties(schema, typeDeclaration);
            }
        }

        /// <summary>
        /// Enumerate the required properties list to update the corresponding property declaration, or
        /// to add it if it was not declared previously.
        /// </summary>
        private void AddRequiredProperties(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.TryGetProperty("required", out JsonElement required))
            {
                foreach (JsonElement jsonPropertyName in required.EnumerateArray())
                {
                    string name = jsonPropertyName.GetString();
                    this.PushPropertyToAbsoluteKeywordLocationStack(name);

                    this.CreateOrUpdateRequiredPropertyDeclarationFor(typeDeclaration, name);

                    this.absoluteKeywordLocationStack.Pop();
                }
            }
        }

        /// <summary>
        /// Enumerate the "properties" value, and add or update <see cref="PropertyDeclaration"/> instances
        /// for each that we find.
        /// </summary>
        private async Task AddProperties(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.TryGetProperty("properties", out JsonElement properties))
            {
                this.PushPropertyToAbsoluteKeywordLocationStack("properties");

                foreach (JsonProperty property in properties.EnumerateObject())
                {
                    this.PushPropertyToAbsoluteKeywordLocationStack(property);

                    await this.CreateOrUpdatePropertyDeclarationFor(typeDeclaration, property).ConfigureAwait(false);

                    this.absoluteKeywordLocationStack.Pop();
                }

                this.absoluteKeywordLocationStack.Pop();
            }
        }

        private void CreateOrUpdateRequiredPropertyDeclarationFor(TypeDeclaration typeDeclaration, string jsonPropertyName)
        {
            if (typeDeclaration.TryGetPropertyDeclaration(jsonPropertyName, out PropertyDeclaration? declaration))
            {
                declaration.IsRequired = true;
            }
            else
            {
                var propertyDeclaration = new PropertyDeclaration();
                this.SetPropertyName(typeDeclaration, jsonPropertyName, propertyDeclaration);
                propertyDeclaration.TypeDeclaration = new TypeDeclaration
                {
                    DotnetTypeName = "Menes.JsonAny",
                };
                typeDeclaration.AddPropertyDeclaration(propertyDeclaration);
            }
        }

        private async Task CreateOrUpdatePropertyDeclarationFor(TypeDeclaration typeDeclaration, JsonProperty property)
        {
            string jsonPropertyName = property.Name;

            JsonReference location = this.absoluteKeywordLocationStack.Peek();
            if (this.TryGetResolvedElement(location, out LocatedElement propertyTypeElement))
            {
                TypeDeclaration newTypeDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                if (typeDeclaration.TryGetPropertyDeclaration(jsonPropertyName, out PropertyDeclaration? propertyDeclaration))
                {
                    propertyDeclaration.TypeDeclaration!.Merge(newTypeDeclaration);
                }
                else
                {
                    var newPropertyDeclaration = new PropertyDeclaration
                    {
                        TypeDeclaration = newTypeDeclaration,
                    };
                    this.SetPropertyName(typeDeclaration, jsonPropertyName, newPropertyDeclaration);
                    typeDeclaration.AddPropertyDeclaration(newPropertyDeclaration);
                }
            }
            else
            {
                throw new InvalidOperationException($"Unable to find element for property type at location: '{location}'");
            }
        }
    }
}