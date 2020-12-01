﻿// <copyright file="JsonSchemaBuilder.CreateDeclarations.cs" company="Endjin Limited">
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
        private async Task<TypeDeclaration> CreateTypeDeclarations(LocatedElement schema, string? fallbackRootName = null)
        {
            // We create the type declaration and immediately add it to the built declarations
            // collection so that we will be able to bomb out if we have already started building
            // this when we see a recursive definition.
            if (this.builtDeclarationsByLocation.TryGetValue(schema.AbsoluteKeywordLocation, out TypeDeclaration? prebuilt))
            {
                return prebuilt;
            }

            var typeDeclaration = new TypeDeclaration(schema);
            this.builtDeclarationsByLocation.Add(schema.AbsoluteKeywordLocation, typeDeclaration);

            // Update the stack with the current absolute keyword location.
            this.absoluteKeywordLocationStack.Push(schema.AbsoluteKeywordLocation);

            try
            {
                await this.SetNameAndParent(schema, typeDeclaration, fallbackRootName).ConfigureAwait(false);
                this.SetBooleanSchema(schema, typeDeclaration);

                if (!typeDeclaration.IsBooleanSchema)
                {
                    await this.AddRef(schema, typeDeclaration).ConfigureAwait(false);
                    this.AddTypeFormatAndEncoding(schema, typeDeclaration);
                    await this.AddAdditionalProperties(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddAllOf(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddAnyOf(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddOneOf(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddNot(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddIfThenElse(schema, typeDeclaration).ConfigureAwait(false);
                    this.AddConstAndEnumValidations(schema, typeDeclaration);
                    this.AddStringValidations(schema, typeDeclaration);
                    this.AddNumericValidations(schema, typeDeclaration);
                    await this.AddObjectValidations(schema, typeDeclaration).ConfigureAwait(false);
                    await this.AddArrayValidations(schema, typeDeclaration).ConfigureAwait(false);
                    await this.FindProperties(schema, typeDeclaration).ConfigureAwait(false);
                }

                if (typeDeclaration.IsEmpty && !typeDeclaration.IsBooleanSchema)
                {
                    return TypeDeclarations.AnyTypeDeclaration;
                }

                return typeDeclaration;
            }
            finally
            {
                this.absoluteKeywordLocationStack.Pop();
            }
        }

        /// <summary>
        /// Adds the const and enum validations.
        /// </summary>
        private void AddConstAndEnumValidations(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("const", out JsonElement constPropertyValue))
                {
                    typeDeclaration.Const = constPropertyValue;
                    if (typeDeclaration.Type is null)
                    {
                        this.SetTypeFromElementValueKind(typeDeclaration, constPropertyValue, default);
                    }
                }

                if (schema.JsonElement.TryGetProperty("enum", out JsonElement enumPropertyValue))
                {
                    ValidateArray(enumPropertyValue);
                    var result = new List<JsonElement>();
                    JsonElement? currentElement = null;
                    bool allMatchingValueKinds = true;

                    foreach (JsonElement enumValue in enumPropertyValue.EnumerateArray())
                    {
                        if (currentElement is null)
                        {
                            currentElement = enumValue;
                        }

                        if (currentElement?.ValueKind != enumValue.ValueKind)
                        {
                            allMatchingValueKinds = false;
                        }

                        result.Add(enumValue);
                    }

                    if (allMatchingValueKinds && currentElement is JsonElement element)
                    {
                        if (typeDeclaration.Type is null)
                        {
                            this.SetTypeFromElementValueKind(typeDeclaration, element, default);
                        }
                    }

                    typeDeclaration.Enum = result;
                }
            }
        }

        /// <summary>
        /// Adds the string-based validations pattern, maxLength and minLength.
        /// </summary>
        private void AddStringValidations(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("pattern", out JsonElement pattern))
                {
                    ValidateString(pattern);
                    typeDeclaration.Pattern = pattern.GetString();
                }

                if (schema.JsonElement.TryGetProperty("maxLength", out JsonElement maxLength))
                {
                    ValidateNumber(maxLength);
                    typeDeclaration.MaxLength = maxLength.GetInt32();
                }

                if (schema.JsonElement.TryGetProperty("minLength", out JsonElement minLength))
                {
                    ValidateNumber(minLength);
                    typeDeclaration.MinLength = minLength.GetInt32();
                }
            }
        }

        /// <summary>
        /// Adds the numeric-based validations.
        /// </summary>
        private void AddNumericValidations(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("multipleOf", out JsonElement multipleOf))
                {
                    ValidateNumber(multipleOf);
                    typeDeclaration.MultipleOf = multipleOf.GetDouble();
                }

                if (schema.JsonElement.TryGetProperty("maximum", out JsonElement maximum))
                {
                    ValidateNumber(maximum);
                    typeDeclaration.Maximum = maximum.GetDouble();
                }

                if (schema.JsonElement.TryGetProperty("exclusiveMaximum", out JsonElement exclusiveMaximum))
                {
                    ValidateNumber(exclusiveMaximum);
                    typeDeclaration.ExclusiveMaximum = exclusiveMaximum.GetDouble();
                }

                if (schema.JsonElement.TryGetProperty("minimum", out JsonElement minimum))
                {
                    ValidateNumber(minimum);
                    typeDeclaration.Minimum = minimum.GetDouble();
                }

                if (schema.JsonElement.TryGetProperty("exclusiveMinimum", out JsonElement exclusiveMinimum))
                {
                    ValidateNumber(exclusiveMinimum);
                    typeDeclaration.ExclusiveMinimum = exclusiveMinimum.GetDouble();
                }
            }
        }

        /// <summary>
        /// Adds the object-based validations, except "properties".
        /// </summary>
        private async Task AddObjectValidations(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("maxProperties", out JsonElement maxProperties))
                {
                    ValidateNumber(maxProperties);
                    typeDeclaration.MaxProperties = maxProperties.GetInt32();
                }

                if (schema.JsonElement.TryGetProperty("minProperties", out JsonElement minProperties))
                {
                    ValidateNumber(minProperties);
                    typeDeclaration.MinProperties = minProperties.GetInt32();
                }

                if (schema.JsonElement.TryGetProperty("patternProperties", out JsonElement patternProperties))
                {
                    ValidateObject(patternProperties);
                    this.PushPropertyToAbsoluteKeywordLocationStack("patternProperties");

                    foreach (JsonProperty property in patternProperties.EnumerateObject())
                    {
                        this.PushPropertyToAbsoluteKeywordLocationStack(property);

                        await this.CreateOrUpdatePatternPropertyDeclarationFor(typeDeclaration, property).ConfigureAwait(false);

                        this.absoluteKeywordLocationStack.Pop();
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }

                if (schema.JsonElement.TryGetProperty("dependentSchemas", out JsonElement dependentSchemas))
                {
                    ValidateObject(dependentSchemas);
                    this.PushPropertyToAbsoluteKeywordLocationStack("dependentSchemas");

                    foreach (JsonProperty property in dependentSchemas.EnumerateObject())
                    {
                        this.PushPropertyToAbsoluteKeywordLocationStack(property);

                        await this.CreateOrUpdateDependentSchemaDeclarationFor(typeDeclaration, property).ConfigureAwait(false);

                        this.absoluteKeywordLocationStack.Pop();
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }

                if (schema.JsonElement.TryGetProperty("dependentRequired", out JsonElement dependentRequired))
                {
                    ValidateObject(dependentRequired);

                    foreach (JsonProperty property in dependentRequired.EnumerateObject())
                    {
                        string key = property.Name;
                        ValidateArray(property.Value);
                        foreach (JsonElement required in property.Value.EnumerateArray())
                        {
                            ValidateString(required);
                            string? dr = required.GetString();

                            // We know we are not null if we passed ValidateString().
                            typeDeclaration.AddDependentRequired(key, dr!);
                        }
                    }
                }

                if (schema.JsonElement.TryGetProperty("propertyNames", out JsonElement propertyNames))
                {
                    ValidateSchema(propertyNames);
                    this.PushPropertyToAbsoluteKeywordLocationStack("propertyNames");
                    JsonReference location = this.GetLocationForSchemaElement(propertyNames);
                    if (this.TryGetResolvedElement(location, false, out LocatedElement propertyTypeElement))
                    {
                        TypeDeclaration propertyNamesDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                        typeDeclaration.PropertyNames = propertyNamesDeclaration;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for propertyNames type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }

                if (schema.JsonElement.TryGetProperty("unevaluatedProperties", out JsonElement unevaluatedProperties))
                {
                    ValidateSchema(unevaluatedProperties);
                    this.PushPropertyToAbsoluteKeywordLocationStack("unevaluatedProperties");
                    JsonReference location = this.GetLocationForSchemaElement(unevaluatedProperties);
                    if (this.TryGetResolvedElement(location, false, out LocatedElement propertyTypeElement))
                    {
                        TypeDeclaration unevaluatedPropertiesDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                        typeDeclaration.UnevaluatedProperties = unevaluatedPropertiesDeclaration;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for unevaluatedProperties type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }
            }
        }

        private async Task CreateOrUpdatePatternPropertyDeclarationFor(TypeDeclaration typeDeclaration, JsonProperty property)
        {
            string jsonPropertyName = property.Name;

            JsonReference location = this.GetLocationForSchemaElement(property.Value);
            if (this.TryGetResolvedElement(location, false, out LocatedElement propertyTypeElement))
            {
                TypeDeclaration newTypeDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                var newPatternPropertyDeclaration = new PatternProperty(jsonPropertyName, newTypeDeclaration);
                typeDeclaration.AddPatternProperty(newPatternPropertyDeclaration);
            }
            else
            {
                throw new InvalidOperationException($"Unable to find element for pattern property type at location: '{location}'");
            }
        }

        private async Task CreateOrUpdateDependentSchemaDeclarationFor(TypeDeclaration typeDeclaration, JsonProperty property)
        {
            string jsonPropertyName = property.Name;

            JsonReference location = this.GetLocationForSchemaElement(property.Value);
            if (this.TryGetResolvedElement(location, false, out LocatedElement propertyTypeElement))
            {
                TypeDeclaration newTypeDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                var newDependentSchemaDeclaration = new DependentSchema(jsonPropertyName, newTypeDeclaration);
                typeDeclaration.AddDependentSchema(newDependentSchemaDeclaration);
            }
            else
            {
                throw new InvalidOperationException($"Unable to find element for pattern dependent schema type at location: '{location}'");
            }
        }

        /// <summary>
        /// Add the array-based validations.
        /// </summary>
        private async Task AddArrayValidations(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("maxItems", out JsonElement maxItems))
                {
                    ValidateNumber(maxItems);
                    typeDeclaration.MaxItems = maxItems.GetInt32();
                }

                if (schema.JsonElement.TryGetProperty("minItems", out JsonElement minItems))
                {
                    ValidateNumber(minItems);
                    typeDeclaration.MinItems = minItems.GetInt32();
                }

                if (schema.JsonElement.TryGetProperty("uniqueItems", out JsonElement uniqueItems))
                {
                    ValidateBoolean(uniqueItems);
                    typeDeclaration.UniqueItems = uniqueItems.GetBoolean();
                }

                if (schema.JsonElement.TryGetProperty("maxContains", out JsonElement maxContains))
                {
                    ValidateNumber(maxContains);
                    typeDeclaration.MaxContains = maxContains.GetInt32();
                }

                if (schema.JsonElement.TryGetProperty("minContains", out JsonElement minContains))
                {
                    ValidateNumber(minContains);
                    typeDeclaration.MinContains = minContains.GetInt32();
                }

                if (schema.JsonElement.TryGetProperty("additionalItems", out JsonElement additionalItems))
                {
                    ValidateSchema(additionalItems);
                    this.PushPropertyToAbsoluteKeywordLocationStack("additionalItems");
                    JsonReference location = this.GetLocationForSchemaElement(additionalItems);
                    if (this.TryGetResolvedElement(location, false, out LocatedElement propertyTypeElement))
                    {
                        TypeDeclaration additionalItemsDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                        typeDeclaration.AdditionalItems = additionalItemsDeclaration;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for additionalItems type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }

                if (schema.JsonElement.TryGetProperty("unevaluatedItems", out JsonElement unevaluatedItems))
                {
                    ValidateSchema(unevaluatedItems);
                    this.PushPropertyToAbsoluteKeywordLocationStack("unevaluatedItems");
                    JsonReference location = this.GetLocationForSchemaElement(unevaluatedItems);
                    if (this.TryGetResolvedElement(location, false, out LocatedElement propertyTypeElement))
                    {
                        TypeDeclaration unevaluatedItemsDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                        typeDeclaration.UnevaluatedItems = unevaluatedItemsDeclaration;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for unevaluatedItems type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }

                if (schema.JsonElement.TryGetProperty("items", out JsonElement items))
                {
                    ValidateSchemaOrArray(items);
                    this.PushPropertyToAbsoluteKeywordLocationStack("items");

                    JsonReference location = this.GetLocationForSchemaElement(items);
                    if (items.ValueKind == JsonValueKind.Object || items.ValueKind == JsonValueKind.True || items.ValueKind == JsonValueKind.False)
                    {
                        typeDeclaration.IsItemsArray = false;
                        if (this.TryGetResolvedElement(location, false, out LocatedElement propertyTypeElement))
                        {
                            TypeDeclaration itemsDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                            typeDeclaration.AddItem(itemsDeclaration);
                            typeDeclaration.AddArrayConversionOperator(new ArrayConversionOperatorDeclaration { TargetItemType = itemsDeclaration });
                        }
                        else
                        {
                            throw new InvalidOperationException($"Unable to find element for items type at location: '{location}'");
                        }
                    }
                    else if (items.ValueKind == JsonValueKind.Array)
                    {
                        int index = 0;
                        foreach (JsonElement itemSchema in items.EnumerateArray())
                        {
                            this.PushArrayIndexToAbsoluteKeywordLocationStack(index);
                            JsonReference childLocation = this.GetLocationForSchemaElement(itemSchema);
                            if (this.TryGetResolvedElement(childLocation, false, out LocatedElement childElement))
                            {
                                ValidateSchema(itemSchema);
                                TypeDeclaration itemsDeclaration = await this.CreateTypeDeclarations(childElement).ConfigureAwait(false);
                                typeDeclaration.AddItem(itemsDeclaration);
                            }
                            else
                            {
                                throw new InvalidOperationException($"Unable to find element for items type at location: '{childLocation}'");
                            }

                            ++index;
                            this.absoluteKeywordLocationStack.Pop();
                        }

                        typeDeclaration.IsItemsArray = true;
                        typeDeclaration.AddArrayConversionOperator(new ArrayConversionOperatorDeclaration { TargetItemType = TypeDeclarations.AnyTypeDeclaration });
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }

                if (schema.JsonElement.TryGetProperty("contains", out JsonElement contains))
                {
                    ValidateSchema(contains);
                    this.PushPropertyToAbsoluteKeywordLocationStack("contains");
                    JsonReference location = this.GetLocationForSchemaElement(contains);
                    if (this.TryGetResolvedElement(location, false, out LocatedElement propertyTypeElement))
                    {
                        TypeDeclaration containsDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                        typeDeclaration.Contains = containsDeclaration;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for contains type at location: '{location}'");
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
                typeDeclaration.IsBooleanTrueSchema = true;
            }
            else if (schema.JsonElement.ValueKind == JsonValueKind.False)
            {
                typeDeclaration.IsBooleanFalseSchema = true;
            }
        }

        /// <summary>
        /// Adds the type array to the declaration.
        /// </summary>
        private void AddTypeFormatAndEncoding(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("contentMediaType", out JsonElement contentMediaType))
                {
                    typeDeclaration.ContentMediaType = contentMediaType.GetString();
                }

                if (schema.JsonElement.TryGetProperty("contentEncoding", out JsonElement contentEncoding))
                {
                    typeDeclaration.ContentEncoding = contentEncoding.GetString();
                }

                if (typeDeclaration.ContentMediaType is string cmt && cmt == "application/json")
                {
                    if (typeDeclaration.ContentEncoding is string ce && ce == "base64")
                    {
                        typeDeclaration.Reference = TypeDeclarations.ClrBase64StringTypeDeclaration;
                    }
                    else
                    {
                        typeDeclaration.Reference = TypeDeclarations.ClrBase64StringTypeDeclaration;
                    }
                }

                if (typeDeclaration.ContentMediaType is null && typeDeclaration.ContentEncoding is string ce2 && ce2 == "base64")
                {
                    typeDeclaration.Reference = TypeDeclarations.ClrBase64StringTypeDeclaration;
                }

                if (schema.JsonElement.TryGetProperty("format", out JsonElement format))
                {
                    ValidateString(format);
                    typeDeclaration.Format = format.GetString();
                }

                if (schema.JsonElement.TryGetProperty("type", out JsonElement type))
                {
                    ValidateStringOrArray(type);

                    if (type.ValueKind == JsonValueKind.Array)
                    {
                        var typeList = new List<string>();
                        foreach (JsonElement element in type.EnumerateArray())
                        {
                            string typeString = ValidateTypeString(element);
                            typeList.Add(typeString);
                            this.AddConversionOperatorsFor(typeString, format, typeDeclaration);
                        }

                        typeDeclaration.Type = typeList;
                    }
                    else
                    {
                        this.SetType(typeDeclaration, type, format);
                    }
                }
            }
        }

        private void SetType(TypeDeclaration typeDeclaration, JsonElement type, JsonElement format)
        {
            var typeList = new List<string>();
            string typeString = ValidateTypeString(type);
            typeList.Add(typeString);
            typeDeclaration.Type = typeList;
            this.AddConversionOperatorsFor(typeString, format, typeDeclaration);
        }

        private void SetTypeFromElementValueKind(TypeDeclaration typeDeclaration, JsonElement type, JsonElement format)
        {
            var typeList = new List<string>();
            string typeString = GetTypeStringForValueKind(type);
            typeList.Add(typeString);
            typeDeclaration.Type = typeList;
            this.AddConversionOperatorsFor(typeString, format, typeDeclaration);
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
        private async Task SetNameAndParent(LocatedElement schema, TypeDeclaration typeDeclaration, string? fallbackRootName)
        {
            await this.SetParent(schema, typeDeclaration).ConfigureAwait(false);
            this.SetTypeName(schema, typeDeclaration, fallbackRootName);
            this.AddToParent(typeDeclaration);
        }

        private void AddToParent(TypeDeclaration typeDeclaration)
        {
            typeDeclaration.Parent?.AddEmbeddedTypeDeclaration(typeDeclaration);
        }

        private async Task SetParent(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.AbsoluteParentKeywordLocation is JsonReference reference)
            {
                if (!this.builtDeclarationsByLocation.TryGetValue(reference, out TypeDeclaration parent))
                {
                    if (this.TryGetResolvedElement(reference, false, out LocatedElement parentElement))
                    {
                        parent = await this.CreateTypeDeclarations(parentElement).ConfigureAwait(false);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for parent at location: '{reference}'");
                    }
                }

                // Don't set a self-referential parent.
                if (parent != typeDeclaration && !parent.IsBuiltInType)
                {
                    typeDeclaration.Parent = parent;
                }

                return;
            }
        }
    }
}