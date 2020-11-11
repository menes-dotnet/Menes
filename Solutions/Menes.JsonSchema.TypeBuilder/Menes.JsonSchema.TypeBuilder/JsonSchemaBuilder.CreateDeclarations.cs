// <copyright file="JsonSchemaBuilder.CreateDeclarations.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Collections.Generic;
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
        /// Build a <see cref="TypeDeclaration"/> from a <see cref="LocatedElement"/> produced
        /// by calling <see cref="WalkTreeAndLocateElementsFrom(System.Text.Json.JsonElement)"/>.
        /// </summary>
        private async Task<TypeDeclaration> CreateTypeDeclarations(LocatedElement schema)
        {
            // We create the type declaration and immediately add it to the built declarations
            // collection so that we will be able to bomb out if we have already started building
            // this when we see a recursive definition.
            if (this.builtDeclarationsByLocation.TryGetValue(schema.AbsoluteKeywordLocation, out TypeDeclaration prebuilt))
            {
                return prebuilt;
            }

            var typeDeclaration = new TypeDeclaration(schema);
            this.builtDeclarationsByLocation.Add(schema.AbsoluteKeywordLocation, typeDeclaration);

            // Update the stack with the current absolute keyword location.
            this.absoluteKeywordLocationStack.Push(schema.AbsoluteKeywordLocation);

            try
            {
                await this.SetNameAndParent(schema, typeDeclaration).ConfigureAwait(false);
                this.SetBooleanSchema(schema, typeDeclaration);

                if (!typeDeclaration.IsBooleanSchema)
                {
                    await this.AddRef(schema, typeDeclaration).ConfigureAwait(false);
                    this.AddType(schema, typeDeclaration);
                    await this.AddAdditionalProperties(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddAllOf(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddAnyOf(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddOneOf(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddNot(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddIfThenElse(schema, typeDeclaration).ConfigureAwait(false);
                    await this.FindProperties(schema, typeDeclaration).ConfigureAwait(false);
                }

                return typeDeclaration;
            }
            finally
            {
                this.absoluteKeywordLocationStack.Pop();
            }
        }

        private async Task AddAdditionalProperties(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("additionalProperties", out JsonElement not))
                {
                    ValidateSchema(not);
                    this.PushPropertyToAbsoluteKeywordLocationStack("additionalProperties");
                    JsonReference location = this.absoluteKeywordLocationStack.Peek();
                    if (this.TryGetResolvedElement(location, out LocatedElement propertyTypeElement))
                    {
                        if (propertyTypeElement.JsonElement.ValueKind == JsonValueKind.Object)
                        {
                            TypeDeclaration additionalPropertiesDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                            typeDeclaration.AdditionalProperties = additionalPropertiesDeclaration;
                        }
                        else if (propertyTypeElement.JsonElement.ValueKind == JsonValueKind.False)
                        {
                            typeDeclaration.AdditionalProperties = CommonTypeDeclarations.NotTypeDeclaration;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for additionalProperties type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether this is a boolean schema.
        /// </summary>
        private void SetBooleanSchema(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.True)
            {
                typeDeclaration.IsBooleanTrueType = true;
            }
            else if (schema.JsonElement.ValueKind == JsonValueKind.False)
            {
                typeDeclaration.IsBooleanFalseType = true;
            }
        }

        /// <summary>
        /// Adds the type array to the declaration.
        /// </summary>
        private void AddType(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("type", out JsonElement type))
                {
                    ValidateStringOrArray(type);

                    this.PushPropertyToAbsoluteKeywordLocationStack("type");
                    if (type.ValueKind == JsonValueKind.Array)
                    {
                        var typeList = new List<string>();
                        foreach (JsonElement element in type.EnumerateArray())
                        {
                            string typeString = ValidateTypeString(element);
                            typeList.Add(typeString);
                        }

                        typeDeclaration.Type = typeList;
                    }
                    else
                    {
                        var typeList = new List<string>();
                        string typeString = ValidateTypeString(type);
                        typeList.Add(typeString);
                        typeDeclaration.Type = typeList;
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }
            }
        }

        /// <summary>
        /// <para>
        /// We set the name and the parent in a single operation as it has to be done in two stages.
        /// </para>
        /// <para>
        /// First, we find and set our own parent reference, if we have one.
        /// </para>
        /// <para>
        /// Then we build our name, based on the knowledge of the other members in our parent
        /// to avoid clashes.
        /// </para>
        /// <para>
        /// Then we add ourselves to our parent, in the knowledge that we will not fall foul
        /// of our parent's unique name validation constraints.
        /// </para>
        /// </summary>
        private async Task SetNameAndParent(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            await this.SetParent(schema, typeDeclaration).ConfigureAwait(false);
            this.SetTypeName(schema, typeDeclaration);
            this.AddToParent(typeDeclaration);
        }

        private void AddToParent(TypeDeclaration typeDeclaration)
        {
            typeDeclaration.Parent?.AddTypeDeclaration(typeDeclaration);
        }

        private async Task SetParent(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.AbsoluteParentKeywordLocation is JsonReference reference)
            {
                if (!this.builtDeclarationsByLocation.TryGetValue(reference, out TypeDeclaration parent))
                {
                    if (this.TryGetResolvedElement(reference, out LocatedElement parentElement))
                    {
                        parent = await this.CreateTypeDeclarations(parentElement).ConfigureAwait(false);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for parent at location: '{reference}'");
                    }
                }

                // Don't set a self-referential parent.
                if (parent != typeDeclaration)
                {
                    typeDeclaration.Parent = parent;
                }

                return;
            }
        }
    }
}