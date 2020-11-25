// <copyright file="JsonSchemaBuilder.BuildCode.Properties.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private void BuildNull(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine($"public static readonly {typeDeclaration.DotnetTypeName} Null = default({typeDeclaration.DotnetTypeName});");
        }

        private void BuildJsonElementBackingField(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("private readonly System.Text.Json.JsonElement _menesJsonElementBacking;");
        }

        private void BuildSetPropertyMethods(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectTypeDeclaration)
            {
                return;
            }

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} RemoveProperty(string propertyName)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return this.SetProperty(propertyName, Menes.JsonNull.Instance);");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} RemoveProperty(System.ReadOnlySpan<char> propertyName)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return this.SetProperty(propertyName, Menes.JsonNull.Instance);");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} RemoveProperty(System.ReadOnlySpan<byte> propertyName)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return this.SetProperty(propertyName, Menes.JsonNull.Instance);");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} SetProperty<T>(string name, T value)");
            memberBuilder.AppendLine($"where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    var propertyName = System.MemoryExtensions.AsSpan(name);");

            this.BuildSetProperty(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} SetProperty<T>(System.ReadOnlySpan<char> propertyName, T value)");
            memberBuilder.AppendLine($"where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            this.BuildSetProperty(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine($"public {typeDeclaration.DotnetTypeName} SetProperty<T>(System.ReadOnlySpan<byte> utf8Name, T value)");
            memberBuilder.AppendLine($"where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            memberBuilder.AppendLine("    System.Span<char> name = stackalloc char[utf8Name.Length];");
            memberBuilder.AppendLine("    int writtenCount = System.Text.Encoding.UTF8.GetChars(utf8Name, name);");
            memberBuilder.AppendLine("    var propertyName = name.Slice(0, writtenCount);");

            this.BuildSetProperty(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine("}");
        }

        private void BuildSetProperty(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is List<PropertyDeclaration> properties)
            {
                foreach (PropertyDeclaration property in properties)
                {
                    memberBuilder.AppendLine($"if (System.MemoryExtensions.SequenceEqual(propertyName, _Menes{property.DotnetPropertyName}JsonPropertyName.Span))");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    return this.With{property.DotnetPropertyName}(value.As<{property.TypeDeclaration!.FullyQualifiedDotNetTypeName}>());");
                    memberBuilder.AppendLine("}");
                }
            }

            if (typeDeclaration.AllowsAdditionalProperties)
            {
                TypeDeclaration additionalPropertyType = typeDeclaration.AdditionalProperties ?? TypeDeclarations.AnyTypeDeclaration;

                bool containsReference = additionalPropertyType.ContainsReferenceTo(typeDeclaration);
                if (!containsReference)
                {
                    memberBuilder.AppendLine($"var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty<{additionalPropertyType.FullyQualifiedDotNetTypeName}>>();");
                }
                else
                {
                    memberBuilder.AppendLine($"var arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.AdditionalProperty>();");
                }

                memberBuilder.AppendLine("bool added = false;");
                memberBuilder.AppendLine("foreach (var property in this._menesAdditionalPropertiesBacking)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if (!property.NameEquals(propertyName))");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        arrayBuilder.Add(property);");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    else");
                memberBuilder.AppendLine("    {");

                if (!containsReference)
                {
                    memberBuilder.AppendLine($"        arrayBuilder.Add(new Menes.AdditionalProperty<{additionalPropertyType.FullyQualifiedDotNetTypeName}>(propertyName, value.As<{additionalPropertyType.FullyQualifiedDotNetTypeName}>()));");
                }
                else
                {
                    memberBuilder.AppendLine($"        arrayBuilder.Add(new Menes.AdditionalProperty(propertyName, Menes.JsonValueBacking.From<{additionalPropertyType.FullyQualifiedDotNetTypeName}>(value.As<{additionalPropertyType.FullyQualifiedDotNetTypeName}>())));");
                }

                memberBuilder.AppendLine("        added = true;");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine("if (!added)");
                memberBuilder.AppendLine("{");

                if (!containsReference)
                {
                    memberBuilder.AppendLine($"        arrayBuilder.Add(new Menes.AdditionalProperty<{additionalPropertyType.FullyQualifiedDotNetTypeName}>(propertyName, value.As<{additionalPropertyType.FullyQualifiedDotNetTypeName}>()));");
                }
                else
                {
                    memberBuilder.AppendLine($"        arrayBuilder.Add(new Menes.AdditionalProperty(propertyName, Menes.JsonValueBacking.From<{additionalPropertyType.FullyQualifiedDotNetTypeName}>(value.As<{additionalPropertyType.FullyQualifiedDotNetTypeName}>())));");
                }

                memberBuilder.AppendLine("}");
            }

            memberBuilder.AppendLine("return this.WithAdditionalProperties(arrayBuilder.ToImmutable());");
        }

        private void BuildAdditionalPropertiesBackingField(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllowsAdditionalProperties)
            {
                TypeDeclaration additionalPropertyType = typeDeclaration.AdditionalProperties ?? TypeDeclarations.AnyTypeDeclaration;

                if (!additionalPropertyType.ContainsReferenceTo(typeDeclaration))
                {
                    memberBuilder.AppendLine($"private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty<{additionalPropertyType.FullyQualifiedDotNetTypeName}>> _menesAdditionalPropertiesBacking;");
                }
                else
                {
                    memberBuilder.AppendLine($"private readonly System.Collections.Immutable.ImmutableArray<Menes.AdditionalProperty> _menesAdditionalPropertiesBacking;");
                }
            }
        }

        private void BuildUndefinedAndNullProperties(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();");
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());");

            if (typeDeclaration.Type is List<string> type)
            {
                if (type.Count == 1)
                {
                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type[0] == "number" || type[0] == "integer")
                    {
                        memberBuilder.AppendLine("public bool IsNumber => true;");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsNumber => false;");
                    }

                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type[0] == "integer")
                    {
                        memberBuilder.AppendLine("public bool IsInteger => true;");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsInteger=> false;");
                    }

                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type[0] == "string")
                    {
                        memberBuilder.AppendLine("public bool IsString => true;");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsString => false;");
                    }

                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type[0] == "object")
                    {
                        memberBuilder.AppendLine("public bool IsObject => true;");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsObject => false;");
                    }

                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type[0] == "boolean")
                    {
                        memberBuilder.AppendLine("public bool IsBoolean => true;");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsBoolean => false;");
                    }

                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type[0] == "array")
                    {
                        memberBuilder.AppendLine("public bool IsArray => true;");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsArray => false;");
                    }
                }
                else
                {
                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type.Contains("number"))
                    {
                        memberBuilder.AppendLine("public bool IsNumber => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number) || (!this.HasJsonElement && this._menesNumberTypeBacking is not null);");
                    }
                    else if (type.Contains("integer"))
                    {
                        memberBuilder.AppendLine("public bool IsNumber => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number) || (!this.HasJsonElement && this._menesIntegerTypeBacking is not null);");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsNumber => false;");
                    }

                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type.Contains("integer"))
                    {
                        memberBuilder.AppendLine("public bool IsInteger => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number) || (!this.HasJsonElement && this._menesIntegerTypeBacking is not null);");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsInteger=> false;");
                    }

                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type.Contains("string"))
                    {
                        memberBuilder.AppendLine("public bool IsString => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String) || (!this.HasJsonElement && this._menesStringTypeBacking is not null);");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsString => false;");
                    }

                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type.Contains("object"))
                    {
                        memberBuilder.AppendLine("public bool IsObject => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object) || (!this.HasJsonElement && !this.AllBackingFieldsAreNull());");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsObject => false;");
                    }

                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type.Contains("boolean"))
                    {
                        memberBuilder.AppendLine("public bool IsBoolean => (this.HasJsonElement && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.True || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.False)) || (!this.HasJsonElement && _menesBooleanTypeBacking is not null);");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsBoolean => false;");
                    }

                    memberBuilder.AppendLine("/// <inheritdoc />");
                    if (type.Contains("array"))
                    {
                        memberBuilder.AppendLine("public bool IsArray => (this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Array) || (!this.HasJsonElement && this._menesArrayValueBacking.Length > 0);");
                    }
                    else
                    {
                        memberBuilder.AppendLine("public bool IsArray => false;");
                    }
                }
            }
            else
            {
                //// TODO: Determine if this is a oneOf/anyOf/allOf/any type and do something special for those cases

                memberBuilder.AppendLine("/// <inheritdoc />");
                memberBuilder.AppendLine("public bool IsNumber => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number;");
                memberBuilder.AppendLine("/// <inheritdoc />");
                memberBuilder.AppendLine("public bool IsInteger => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Number;");
                memberBuilder.AppendLine("/// <inheritdoc />");
                memberBuilder.AppendLine("public bool IsString => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.String;");
                memberBuilder.AppendLine("/// <inheritdoc />");
                memberBuilder.AppendLine("public bool IsObject => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object;");
                memberBuilder.AppendLine("/// <inheritdoc />");
                memberBuilder.AppendLine("public bool IsBoolean => this.HasJsonElement && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.True || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.False);");
                memberBuilder.AppendLine("/// <inheritdoc />");
                memberBuilder.AppendLine("public bool IsArray => this.HasJsonElement && this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Array;");
            }
        }

        private void BuildPropertyNames(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is null)
            {
                return;
            }

            foreach (PropertyDeclaration property in typeDeclaration.Properties)
            {
                memberBuilder.AppendLine($"private static readonly System.ReadOnlyMemory<char> _Menes{property.DotnetPropertyName}JsonPropertyName = System.MemoryExtensions.AsMemory(\"{property.DotnetFieldName}\");");
            }

            foreach (PropertyDeclaration property in typeDeclaration.Properties)
            {
                memberBuilder.AppendLine($"private static readonly System.ReadOnlyMemory<byte>  _Menes{property.DotnetPropertyName}Utf8JsonPropertyName = new byte[] {{ {string.Join(", ", System.Text.Encoding.UTF8.GetBytes(property.JsonPropertyName).Select(b => b.ToString()))} }};");
            }

            foreach (PropertyDeclaration property in typeDeclaration.Properties)
            {
                memberBuilder.AppendLine($"private static readonly  System.Text.Json.JsonEncodedText _Menes{property.DotnetPropertyName}EncodedJsonPropertyName = System.Text.Json.JsonEncodedText.Encode(_Menes{property.DotnetPropertyName}Utf8JsonPropertyName.Span);");
            }
        }

        private void BuildTryGetProperty(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectTypeDeclaration)
            {
                return;
            }

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool TryGetProperty<T>(System.ReadOnlySpan<char> propertyName, out T property)");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            this.BuildTryGetPropertyFromJsonElement(memberBuilder);

            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    memberBuilder.AppendLine($"    if (System.MemoryExtensions.SequenceEqual(propertyName, _Menes{property.DotnetPropertyName}JsonPropertyName.Span))");
                    memberBuilder.AppendLine("    {");
                    this.BuildPropertyResultAssignment(memberBuilder, property);
                    memberBuilder.AppendLine($"        return true;");
                    memberBuilder.AppendLine("    }");
                }
            }

            this.BuildTryGetPropertyFromAdditionalProperties(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("        property = default;");
            memberBuilder.AppendLine("        return false;");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool TryGetProperty<T>(string propertyName, out T property)");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            this.BuildTryGetPropertyFromJsonElement(memberBuilder);

            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    memberBuilder.AppendLine($"    if (System.MemoryExtensions.SequenceEqual(System.MemoryExtensions.AsSpan(propertyName), _Menes{property.DotnetPropertyName}JsonPropertyName.Span))");
                    memberBuilder.AppendLine("    {");
                    this.BuildPropertyResultAssignment(memberBuilder, property);
                    memberBuilder.AppendLine($"        return true;");
                    memberBuilder.AppendLine("    }");
                }
            }

            this.BuildTryGetPropertyFromAdditionalProperties(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("        property = default;");
            memberBuilder.AppendLine("        return false;");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool TryGetProperty<T>(System.ReadOnlySpan<byte> propertyName, out T property)");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            this.BuildTryGetPropertyFromJsonElement(memberBuilder);

            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    memberBuilder.AppendLine($"    if (System.MemoryExtensions.SequenceEqual(propertyName, _Menes{property.DotnetPropertyName}Utf8JsonPropertyName.Span))");
                    memberBuilder.AppendLine("    {");
                    this.BuildPropertyResultAssignment(memberBuilder, property);
                    memberBuilder.AppendLine($"        return true;");
                    memberBuilder.AppendLine("    }");
                }
            }

            this.BuildTryGetPropertyFromAdditionalProperties(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("        property = default;");
            memberBuilder.AppendLine("        return false;");
            memberBuilder.AppendLine("}");
        }

        private void BuildPropertyResultAssignment(StringBuilder memberBuilder, PropertyDeclaration property)
        {
            if (property.IsRequired)
            {
                memberBuilder.AppendLine($"        property = this.{property.DotnetPropertyName}.As<T>();");
            }
            else
            {
                memberBuilder.AppendLine($"        if (!(this.{property.DotnetPropertyName}?.As<T>() is T result))");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            property = default;");
                memberBuilder.AppendLine("            return false;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("        property = result;");
                memberBuilder.AppendLine("        return true;");
            }
        }

        private void BuildTryGetPropertyFromJsonElement(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("    if (this.HasJsonElement)");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        if (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement value))");
            memberBuilder.AppendLine("        {");
            memberBuilder.AppendLine("            property = Menes.JsonValue.As<T>(value);");
            memberBuilder.AppendLine("            return true;");
            memberBuilder.AppendLine("        }");
            memberBuilder.AppendLine("        property = default;");
            memberBuilder.AppendLine("        return false;");
            memberBuilder.AppendLine("    }");
        }

        private void BuildTryGetPropertyFromAdditionalProperties(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllowsAdditionalProperties)
            {
                TypeDeclaration additionalPropertiesType = typeDeclaration.AdditionalProperties ?? TypeDeclarations.AnyTypeDeclaration;

                memberBuilder.AppendLine("    foreach (var additionalProperty in this._menesAdditionalPropertiesBacking)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        if (additionalProperty.NameEquals(propertyName))");
                memberBuilder.AppendLine("        {");

                if (!additionalPropertiesType.ContainsReferenceTo(typeDeclaration))
                {
                    memberBuilder.AppendLine("            property = additionalProperty.Value.As<T>();");
                }
                else
                {
                    memberBuilder.AppendLine($"            property = additionalProperty.Value<{additionalPropertiesType.FullyQualifiedDotNetTypeName}>()?.As<T>() ?? default;");
                }

                memberBuilder.AppendLine("            return true;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
            }
        }

        private void BuildJsonPropertyGetMethods(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.AllowsAdditionalProperties && typeDeclaration.Properties is null)
            {
                return;
            }

            memberBuilder.AppendLine("private TPropertyValue GetPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)");
            memberBuilder.AppendLine("    where TPropertyValue : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return this.GetOptionalPropertyFromJsonElement<TPropertyValue>(propertyName) ?? default;");
            memberBuilder.AppendLine("}");
            memberBuilder.AppendLine("private TPropertyValue? GetOptionalPropertyFromJsonElement<TPropertyValue>(System.ReadOnlySpan<byte> propertyName)");
            memberBuilder.AppendLine("    where TPropertyValue : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            memberBuilder.AppendLine("         (this.JsonElement.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
            memberBuilder.AppendLine("             ? Menes.JsonValue.As<TPropertyValue>(property)");
            memberBuilder.AppendLine("             : null)");
            memberBuilder.AppendLine("         : null;");
            memberBuilder.AppendLine("}");
        }

        private void BuildProperties(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    if (property.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException("You must set the type declaration for all properties before generating code.");
                    }

                    if (!property.TypeDeclaration.ContainsReferenceTo(typeDeclaration))
                    {
                        if (property.IsRequired)
                        {
                            memberBuilder.AppendLine($"public {property.TypeDeclaration.FullyQualifiedDotNetTypeName} {property.DotnetPropertyName} => this.HasJsonElement ? this.GetPropertyFromJsonElement<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}Utf8JsonPropertyName.Span) : this.{property.DotnetFieldName} ?? {property.TypeDeclaration.FullyQualifiedDotNetTypeName}.Null;");
                        }
                        else
                        {
                            memberBuilder.AppendLine($"public {property.TypeDeclaration.FullyQualifiedDotNetTypeName}? {property.DotnetPropertyName} => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}Utf8JsonPropertyName.Span) : this.{property.DotnetFieldName};");
                        }
                    }
                    else
                    {
                        if (property.IsRequired)
                        {
                            memberBuilder.AppendLine($"public {property.TypeDeclaration.FullyQualifiedDotNetTypeName} {property.DotnetPropertyName} => this.HasJsonElement ? this.GetPropertyFromJsonElement<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}Utf8JsonPropertyName.Span) : this.{property.DotnetFieldName}.As<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>() ?? {property.TypeDeclaration.FullyQualifiedDotNetTypeName}.Null;");
                        }
                        else
                        {
                            memberBuilder.AppendLine($"public {property.TypeDeclaration.FullyQualifiedDotNetTypeName}? {property.DotnetPropertyName} => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}Utf8JsonPropertyName.Span) : this.{property.DotnetFieldName}.As<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>();");
                        }
                    }
                }
            }
        }

        private void BuildPropertyBackingFields(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    if (property.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException("You must set the type declaration for all properties before generating code.");
                    }

                    if (property.TypeDeclaration.ContainsReferenceTo(typeDeclaration))
                    {
                        memberBuilder.AppendLine($"private readonly Menes.JsonValueBacking {property.DotnetFieldName};");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"private readonly {property.TypeDeclaration.FullyQualifiedDotNetTypeName}? {property.DotnetFieldName};");
                    }
                }
            }
        }

        private void BuildPropertiesAreNull(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    if (property.TypeDeclaration!.ContainsReferenceTo(typeDeclaration))
                    {
                        memberBuilder.AppendLine($"if (!this.{property.DotnetFieldName}.IsNull)");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"if (this.{property.DotnetFieldName} is not null)");
                    }

                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    return false;");
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildAdditionalPropertiesAreNull(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllowsAdditionalProperties)
            {
                memberBuilder.AppendLine("if (this._menesAdditionalPropertiesBacking.Length > 0)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    return false;");
                memberBuilder.AppendLine("}");
            }
        }

        private void BuildWritePropertyBackingValues(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    if (!property.TypeDeclaration!.ContainsReferenceTo(typeDeclaration))
                    {
                        memberBuilder.AppendLine($"    if (this.{property.DotnetFieldName} is {property.TypeDeclaration!.FullyQualifiedDotNetTypeName} {property.DotnetFieldName})");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"    if (this.{property.DotnetFieldName} is Menes.JsonValueBacking {property.DotnetFieldName} && !{property.DotnetFieldName}.IsNull)");
                    }

                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine($"        writer.WritePropertyName(_Menes{property.DotnetPropertyName}EncodedJsonPropertyName);");
                    memberBuilder.AppendLine($"        {property.DotnetFieldName}.WriteTo(writer);");
                    memberBuilder.AppendLine("    }");
                }
            }

            if (typeDeclaration.AllowsAdditionalProperties)
            {
                memberBuilder.AppendLine("    foreach (var property in this._menesAdditionalPropertiesBacking)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        property.WriteTo(writer);");
                memberBuilder.AppendLine("    }");
            }
        }

        private void BuildJsonElementProperties(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool HasJsonElement => this._menesJsonElementBacking.ValueKind != System.Text.Json.JsonValueKind.Undefined;");
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public System.Text.Json.JsonElement JsonElement => this._menesJsonElementBacking;");
        }
    }
}
