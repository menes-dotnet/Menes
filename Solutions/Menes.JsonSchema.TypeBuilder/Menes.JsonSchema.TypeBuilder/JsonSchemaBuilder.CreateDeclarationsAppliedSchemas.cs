// <copyright file="JsonSchemaBuilder.CreateDeclarationsAppliedSchemas.cs" company="Endjin Limited">
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

                    // Cannot be null if we passed ValidateDollarRef();
                    string? dref = dollarref.GetString();
                    JsonReference location = this.GetAbsoluteKeywordLocation(JsonReference.FromEncodedJsonString(dref!).Value);
                    if (this.TryGetResolvedElement(location, out LocatedElement dollarRefTypeElement))
                    {
                        TypeDeclaration dollarrefTypeDeclaration = await this.CreateTypeDeclarations(dollarRefTypeElement).ConfigureAwait(false);
                        typeDeclaration.Reference = dollarrefTypeDeclaration;
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

                    // Cannot be null if we passed ValidateDollarRef();
                    string? drref = dollarrecursiveRef.GetString();
                    JsonReference location = this.GetAbsoluteKeywordLocation(JsonReference.FromEncodedJsonString(drref!).Value);
                    if (this.TryGetResolvedElement(location, out LocatedElement dollarrecursiveRefTypeElement))
                    {
                        TypeDeclaration dollarrecursiveRefTypeDeclaration = await this.CreateTypeDeclarations(dollarrecursiveRefTypeElement).ConfigureAwait(false);
                        typeDeclaration.Reference = dollarrecursiveRefTypeDeclaration;
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
                    ValidateSchema(not);
                    this.PushPropertyToAbsoluteKeywordLocationStack("not");
                    JsonReference location = this.GetLocationForSchemaElement(not);
                    if (this.TryGetResolvedElement(location, out LocatedElement propertyTypeElement))
                    {
                        TypeDeclaration notDeclaration = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                        typeDeclaration.Not = notDeclaration;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for not type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }
            }
        }

        private async Task AddIfThenElse(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            if (schema.JsonElement.ValueKind == JsonValueKind.Object)
            {
                TypeDeclaration? ifType = null;
                TypeDeclaration? thenType = null;
                TypeDeclaration? elseType = null;

                if (schema.JsonElement.TryGetProperty("if", out JsonElement @if))
                {
                    ValidateSchema(@if);
                    this.PushPropertyToAbsoluteKeywordLocationStack("if");
                    JsonReference location = this.GetLocationForSchemaElement(@if);
                    if (this.TryGetResolvedElement(location, out LocatedElement propertyTypeElement))
                    {
                        ifType = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for if type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }

                if (schema.JsonElement.TryGetProperty("then", out JsonElement then))
                {
                    ValidateSchema(then);

                    this.PushPropertyToAbsoluteKeywordLocationStack("then");
                    JsonReference location = this.GetLocationForSchemaElement(then);
                    if (this.TryGetResolvedElement(location, out LocatedElement propertyTypeElement))
                    {
                        thenType = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for if type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }

                if (schema.JsonElement.TryGetProperty("else", out JsonElement @else))
                {
                    ValidateSchema(@else);
                    this.PushPropertyToAbsoluteKeywordLocationStack("else");
                    JsonReference location = this.GetLocationForSchemaElement(@else);
                    if (this.TryGetResolvedElement(location, out LocatedElement propertyTypeElement))
                    {
                        elseType = await this.CreateTypeDeclarations(propertyTypeElement).ConfigureAwait(false);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to find element for if type at location: '{location}'");
                    }

                    this.absoluteKeywordLocationStack.Pop();
                }

                if (ifType is not null && (thenType is not null || elseType is not null))
                {
                    typeDeclaration.IfThenElse = new IfThenElse(ifType, thenType, elseType);
                }
            }
        }

        private Task AddAllOf(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            return this.AddAllAnyOneCore(
                schema,
                typeDeclaration,
                "allOf",
                e => ValidateAllOf(e),
                (parent, aot) =>
                {
                    parent.AddAllOfType(aot);
                });
        }

        private Task AddAnyOf(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            return this.AddAllAnyOneCore(
                schema,
                typeDeclaration,
                "anyOf",
                e => ValidateAnyOf(e),
                (parent, aot) =>
                {
                    parent.AddAnyOfType(aot);
                });
        }

        private Task AddOneOf(LocatedElement schema, TypeDeclaration typeDeclaration)
        {
            return this.AddAllAnyOneCore(
                schema,
                typeDeclaration,
                "oneOf",
                e => ValidateOneOf(e),
                (parent, oot) =>
                {
                    parent.AddOneOfType(oot);
                });
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
                        JsonReference location = this.GetLocationForSchemaElement(element);
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