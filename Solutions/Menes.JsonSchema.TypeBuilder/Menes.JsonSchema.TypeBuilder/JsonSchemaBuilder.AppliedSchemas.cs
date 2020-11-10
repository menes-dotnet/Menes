// <copyright file="JsonSchemaBuilder.AppliedSchemas.cs" company="Endjin Limited">
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
        private async Task AddRef(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("$ref", out JsonElement dollarref))
                {
                    this.PushPropertyToAbsoluteKeywordLocationStack("$ref");

                    ValidateDollarRef(dollarref);

                    JsonReference location = this.GetAbsoluteKeywordLocation(JsonReference.FromEncodedJsonString(dollarref.GetString()).Value);
                    if (this.TryGetResolvedElement(location, out LocatedElement dollarRefTypeElement))
                    {
                        TypeDeclaration dollarrefTypeDeclaration = await this.CreateTypeDeclarations(dollarRefTypeElement).ConfigureAwait(false);
                        typeDeclaration.Merge(dollarrefTypeDeclaration);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for $ref type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }
                else if (schema.JsonElement.TryGetProperty("$recursiveRef", out JsonElement dollarrecursiveRef))
                {
                    this.PushPropertyToAbsoluteKeywordLocationStack("$recursiveRef");

                    ValidateDollarRef(dollarrecursiveRef);

                    JsonReference location = this.GetAbsoluteKeywordLocation(JsonReference.FromEncodedJsonString(dollarrecursiveRef.GetString()).Value);
                    if (this.TryGetResolvedElement(location, out LocatedElement dollarrecursiveRefTypeElement))
                    {
                        TypeDeclaration dollarrecursiveRefTypeDeclaration = await this.CreateTypeDeclarations(dollarrecursiveRefTypeElement).ConfigureAwait(false);
                        typeDeclaration.Merge(dollarrecursiveRefTypeDeclaration);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for $recursiveRef type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }
            }
        }

        private async Task AddNot(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty("not", out JsonElement not))
                {
                    this.PushPropertyToAbsoluteKeywordLocationStack("not");
                    JsonReference location = this.absoluteKeywordLocationStack.Peek();
                    if (this.TryGetResolvedElement(location, out LocatedElement propertyTypeElement))
                    {
                        TypeDeclaration notDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                        typeDeclaration.NotType = notDeclaration;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for not type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }
            }
        }

        private Task AddAllOf(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            return this.AddAllAnyOneCore(schema, typeDeclaration, "allOf", e => ValidateAllOf(e), (parent, aot) => parent.AddAllOfType(aot));
        }

        private Task AddAnyOf(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            return this.AddAllAnyOneCore(schema, typeDeclaration, "anyOf", e => ValidateAnyOf(e), (parent, aot) => parent.AddAnyOfType(aot));
        }

        private Task AddOneOf(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            return this.AddAllAnyOneCore(schema, typeDeclaration, "oneOf", e => ValidateOneOf(e), (parent, oot) => parent.AddOneOfType(oot));
        }

        private async Task AddAllAnyOneCore(LocatedElement schema, TypeDeclaration typeDeclaration, string propertyName, Action<JsonElement> validate, Action<TypeDeclaration, TypeDeclaration> add)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                if (schema.JsonElement.TryGetProperty(propertyName, out JsonElement subschema))
                {
                    this.PushPropertyToAbsoluteKeywordLocationStack(propertyName);

                    validate(subschema);

                    int index = 0;
                    foreach (JsonElement element in subschema.EnumerateArray())
                    {
                        this.PushArrayIndexToAbsoluteKeywordLocationStack(index);
                        JsonReference location = this.absoluteKeywordLocationStack.Peek();
                        if (this.TryGetResolvedElement(location, out LocatedElement allOfTypeElement))
                        {
                            TypeDeclaration allOfTypeDeclaration = await this.CreateTypeDeclarations(allOfTypeElement).ConfigureAwait(false);
                            add(typeDeclaration, allOfTypeDeclaration);
                        }
                        else
                        {
                            throw new InvalidOperationException($"Unable to find element for {propertyName} type at location: '{location}'");
                        }

                        ++index;
                        this.absoluteKeywordLocationStack.Pop();
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }
            }
        }
    }
}