// <copyright file="JsonSchemaBuilder.BuildCode.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Linq;
    using System.Text;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// Build the code for a type.
        /// </summary>
        private void BuildCode(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsBuiltInType || typeDeclaration.IsRef)
            {
                return;
            }

            memberBuilder.AppendLine($"public readonly struct {typeDeclaration.DotnetTypeName} : Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            // Public static readonly fields
            this.BuildNull(typeDeclaration, memberBuilder);

            // Private static readonly fields
            this.BuildPropertyNames(typeDeclaration, memberBuilder);

            // Private readonly fields
            this.BuildJsonElementBackingField(memberBuilder);
            this.BuildAdditionalPropertiesBackingField(typeDeclaration, memberBuilder);
            this.BuildTypeBackingFields(typeDeclaration, memberBuilder);
            this.BuildPropertyBackingFields(typeDeclaration, memberBuilder);

            // Conversion operators
            this.BuildConversionOperators(typeDeclaration, memberBuilder);

            // Public properties
            this.BuildUndefinedAndNullProperties(memberBuilder);
            this.BuildJsonElementProperties(memberBuilder);
            this.BuildProperties(typeDeclaration, memberBuilder);

            // Public methods
            this.BuildValidateMethod(typeDeclaration, memberBuilder);
            this.BuildWriteToMethod(typeDeclaration, memberBuilder);
            this.BuildIsAndAsMethods(typeDeclaration, memberBuilder);
            this.BuildTryGetProperty(typeDeclaration, memberBuilder);

            // Private methods
            this.BuildJsonPropertyGetMethods(typeDeclaration, memberBuilder);
            this.BuildAllBackingFieldsAreNullMethod(typeDeclaration, memberBuilder);

            // Embedded types
            this.BuildEmbeddedTypes(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("}");
        }

        private void BuildConversionOperators(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.ConversionOperators is null)
            {
                return;
            }

            foreach (ConversionOperatorDeclaration op in typeDeclaration.ConversionOperators)
            {
                if (op.TargetType is null)
                {
                    throw new InvalidOperationException("You must set the conversion operator target type before use.");
                }

                if (op.Direction.HasFlag(ConversionOperatorDeclaration.ConversionDirection.FromImplicit))
                {
                    memberBuilder.AppendLine($"public static implicit operator {op.TargetType.FullyQualifiedDotNetTypeName}({typeDeclaration.DotnetTypeName} value)");
                    memberBuilder.AppendLine("{");
                    this.BuildConversionOperator(op.Conversion, op.TargetType, memberBuilder);
                    memberBuilder.AppendLine("}");
                }

                if (op.Direction.HasFlag(ConversionOperatorDeclaration.ConversionDirection.FromExplicit))
                {
                    memberBuilder.AppendLine($"public static explicit operator {op.TargetType.FullyQualifiedDotNetTypeName}({typeDeclaration.DotnetTypeName} value)");
                    memberBuilder.AppendLine("{");
                    this.BuildConversionOperator(op.Conversion, op.TargetType, memberBuilder);
                    memberBuilder.AppendLine("}");
                }

                if (op.Direction.HasFlag(ConversionOperatorDeclaration.ConversionDirection.ToImplicit))
                {
                    memberBuilder.AppendLine($"public static implicit operator {typeDeclaration.DotnetTypeName}({op.TargetType.FullyQualifiedDotNetTypeName} value)");
                    memberBuilder.AppendLine("{");
                    this.BuildConversionOperator(op.Conversion, typeDeclaration, memberBuilder);
                    memberBuilder.AppendLine("}");
                }

                if (op.Direction.HasFlag(ConversionOperatorDeclaration.ConversionDirection.ToExplicit))
                {
                    memberBuilder.AppendLine($"public static explicit operator {typeDeclaration.DotnetTypeName}({op.TargetType.FullyQualifiedDotNetTypeName} value)");
                    memberBuilder.AppendLine("{");
                    this.BuildConversionOperator(op.Conversion, typeDeclaration, memberBuilder);
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildConversionOperator(ConversionOperatorDeclaration.ConversionType conversion, TypeDeclaration targetType, StringBuilder memberBuilder)
        {
            switch (conversion)
            {
                case ConversionOperatorDeclaration.ConversionType.Cast:
                    memberBuilder.AppendLine($"    return ({targetType.FullyQualifiedDotNetTypeName})value;");
                    break;
                case ConversionOperatorDeclaration.ConversionType.Constructor:
                    memberBuilder.AppendLine($"    return new {targetType.FullyQualifiedDotNetTypeName}(value);");
                    break;
                case ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom:
                    memberBuilder.AppendLine($"    return Menes.JsonValue.As<{targetType.FullyQualifiedDotNetTypeName}>(value);");
                    break;
            }
        }

        private void BuildNull(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine($"public static readonly {typeDeclaration.DotnetTypeName} Null = default({typeDeclaration.DotnetTypeName});");
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
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool TryGetProperty<T>(System.ReadOnlySpan<char> propertyName, out T property)");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            this.BuildTryGetPropertyFromJsonElement(memberBuilder);

            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    memberBuilder.AppendLine($"    if (propertyName.SequenceEqual(_Menes{property.DotnetPropertyName}JsonPropertyName.Span))");
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
                    memberBuilder.AppendLine($"    if (System.MemoryExtensions.AsSpan(propertyName).SequenceEqual(_Menes{property.DotnetPropertyName}JsonPropertyName.Span))");
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
                    memberBuilder.AppendLine($"    if (propertyName.SequenceEqual(_Menes{property.DotnetPropertyName}Utf8JsonPropertyName.Span))");
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

        private void BuildIsAndAsMethods(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public T As<T>()");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return Menes.JsonValue.As<T>(Menes.JsonValue.FlattenToJsonElementBacking(this).JsonElement);");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool Is<T>()");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine($"if (typeof(T) == typeof({typeDeclaration.FullyQualifiedDotNetTypeName}))");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return this.Validate().Valid;");
            memberBuilder.AppendLine("}");
            memberBuilder.AppendLine("    return this.As<T>().Validate().Valid;");
            memberBuilder.AppendLine("}");

            this.BuildAllOfAsMethods(typeDeclaration, memberBuilder);
            this.BuildAnyOfAsMethods(typeDeclaration, memberBuilder);
            this.BuildOneOfAsMethods(typeDeclaration, memberBuilder);
        }

        private void BuildEmbeddedTypes(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.EmbeddedTypes is null)
            {
                return;
            }

            foreach (TypeDeclaration t in typeDeclaration.EmbeddedTypes)
            {
                this.BuildCode(t, memberBuilder);
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
                            memberBuilder.AppendLine($"public {property.TypeDeclaration.FullyQualifiedDotNetTypeName} {property.DotnetPropertyName} => this.HasJsonElement ? this.GetPropertyFromJsonElement<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}Utf8JsonPropertyName.Span) : this.{property.DotnetFieldName}.Value<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>() ?? {property.TypeDeclaration.FullyQualifiedDotNetTypeName}.Null;");
                        }
                        else
                        {
                            memberBuilder.AppendLine($"public {property.TypeDeclaration.FullyQualifiedDotNetTypeName}? {property.DotnetPropertyName} => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}Utf8JsonPropertyName.Span) : this.{property.DotnetFieldName}.Value<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>();");
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

        private void BuildWriteToMethod(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public void WriteTo(System.Text.Json.Utf8JsonWriter writer)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    if (this.HasJsonElement)");
            memberBuilder.AppendLine("    {");
            memberBuilder.AppendLine("        this.JsonElement.WriteTo(writer);");
            memberBuilder.AppendLine("        return;");
            memberBuilder.AppendLine("    }");
            this.BuildWritePropertyBackingValues(typeDeclaration, memberBuilder);
            this.BuildWriteTypeBackingValues(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("}");
        }

        private void BuildTypeBackingFields(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array" && type != "null")
                    {
                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();
                        string typeName = TypeDeclarations.GetTypeNameFor(type);

                        memberBuilder.AppendLine($"private readonly {typeName}? _menes{typeAsPascalCase}TypeBacking;");
                    }
                }
            }
        }

        private void BuildTypeBackingFieldsAreNull(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array" && type != "null")
                    {
                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();

                        memberBuilder.AppendLine($"if (this._menes{typeAsPascalCase}TypeBacking is not null)");
                        memberBuilder.AppendLine("{");
                        memberBuilder.AppendLine("    return false;");
                        memberBuilder.AppendLine("}");
                    }
                }
            }
        }

        private void BuildWriteTypeBackingValues(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                foreach (string type in typeDeclaration.Type)
                {
                    if (type != "object" && type != "array")
                    {
                        string typeAsPascalCase = Formatting.ToPascalCaseWithReservedWords(type).ToString();
                        memberBuilder.AppendLine($"        this._menes{typeAsPascalCase}TypeBacking?.WriteTo(writer);");
                    }
                }
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
                        memberBuilder.AppendLine($"    if (this.{property.DotnetFieldName} is Menes.JsonValueBacking {property.DotnetFieldName})");
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

        private void BuildJsonElementBackingField(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("private readonly System.Text.Json.JsonElement _menesJsonElementBacking;");
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

        private void BuildAllBackingFieldsAreNullMethod(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("private bool AllBackingFieldsAreNull()");
            memberBuilder.AppendLine("{");

            this.BuildPropertiesAreNull(typeDeclaration, memberBuilder);

            this.BuildAdditionalPropertiesAreNull(typeDeclaration, memberBuilder);

            this.BuildTypeBackingFieldsAreNull(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine("return true;");
            memberBuilder.AppendLine("}");
        }

        private void BuildPropertiesAreNull(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Properties is not null)
            {
                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    if (!property.IsRequired)
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

        private void BuildUndefinedAndNullProperties(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool IsUndefined => !this.HasJsonElement && this.AllBackingFieldsAreNull();");
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool IsNull => this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null || (!this.HasJsonElement && this.AllBackingFieldsAreNull());");
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
