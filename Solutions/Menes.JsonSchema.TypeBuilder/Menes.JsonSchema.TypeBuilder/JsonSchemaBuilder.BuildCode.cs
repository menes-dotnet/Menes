// <copyright file="JsonSchemaBuilder.BuildCode.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
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
            memberBuilder.AppendLine($"public readonly struct {typeDeclaration.DotnetTypeName} : Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            // Private readonly fields
            this.BuildJsonElementBackingField(memberBuilder);
            this.BuildAdditionalPropertiesBackingField(typeDeclaration, memberBuilder);
            this.BuildTypeBackingFields(typeDeclaration, memberBuilder);
            this.BuildPropertyBackingFields(typeDeclaration, memberBuilder);

            // Public properties
            this.BuildUndefinedAndNullProperties(memberBuilder);
            this.BuildJsonElementProperties(memberBuilder);
            this.BuildProperties(typeDeclaration, memberBuilder);

            // Public methods
            this.BuildValidateMethod(typeDeclaration, memberBuilder);
            this.BuildWriteToMethod(typeDeclaration, memberBuilder);
            this.BuildIsAndAsMethods(typeDeclaration, memberBuilder);

            // Private methods
            this.BuildJsonPropertyGetMethods(typeDeclaration, memberBuilder);
            this.BuildAllBackingFieldsAreNullMethod(typeDeclaration, memberBuilder);

            // Embedded types
            this.BuildEmbeddedTypes(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("}");
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
            memberBuilder.AppendLine("    T item = this.As<T>();");
            memberBuilder.AppendLine("    return item.Validate(Menes.ValidationResult.ValidResult, Menes.ValidationLevel.Flag).Valid;");
            memberBuilder.AppendLine("}");
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
            memberBuilder.AppendLine("private TPropertyValue GetPropertyFromJsonElement<TPropertyValue>(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName)");
            memberBuilder.AppendLine("    where TPropertyValue : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return this.GetOptionalPropertyFromJsonElement<TPropertyValue>(parentDocument, propertyName) ?? throw new System.InvalidOperationException($\"The required property {propertyName.ToString()} was not found.\");");
            memberBuilder.AppendLine("}");
            memberBuilder.AppendLine("private TPropertyValue? GetOptionalPropertyFromJsonElement<TPropertyValue>(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName)");
            memberBuilder.AppendLine("    where TPropertyValue : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?");
            memberBuilder.AppendLine("         (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)");
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
                            memberBuilder.AppendLine($"public {property.TypeDeclaration.FullyQualifiedDotNetTypeName} {property.DotnetPropertyName} => this.HasJsonElement ? this.GetPropertyFromJsonElement<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}ByteArray) : this.{property.DotnetFieldName}.Value!;");
                        }
                        else
                        {
                            memberBuilder.AppendLine($"public {property.TypeDeclaration.FullyQualifiedDotNetTypeName}? {property.DotnetPropertyName} => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}ByteArray) : this.{property.DotnetFieldName};");
                        }
                    }
                    else
                    {
                        if (property.IsRequired)
                        {
                            memberBuilder.AppendLine($"public {property.TypeDeclaration.FullyQualifiedDotNetTypeName} {property.DotnetPropertyName} => this.HasJsonElement ? this.GetPropertyFromJsonElement<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}ByteArray) : this.{property.DotnetFieldName}.Value<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>();");
                        }
                        else
                        {
                            memberBuilder.AppendLine($"public {property.TypeDeclaration.FullyQualifiedDotNetTypeName}? {property.DotnetPropertyName} => this.HasJsonElement ? this.GetOptionalPropertyFromJsonElement<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}ByteArray) : this.{property.DotnetFieldName}.Value<{property.TypeDeclaration.FullyQualifiedDotNetTypeName}>();");
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
            this.BuildWriteAnyOfBackingValues(typeDeclaration, memberBuilder);
            this.BuildWriteOneOfBackingValues(typeDeclaration, memberBuilder);
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
                        memberBuilder.AppendLine($"    if (this._menes{typeAsPascalCase}TypeBacking is not null)");
                        memberBuilder.AppendLine("    {");
                        memberBuilder.AppendLine($"        this._menes{typeAsPascalCase}TypeBacking.WriteTo(writer);");
                        memberBuilder.AppendLine("    }");
                    }
                }
            }
        }

        private void BuildWriteAnyOfBackingValues(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AnyOf is not null)
            {
                for (int i = 0; i < typeDeclaration.AnyOf.Count; ++i)
                {
                    memberBuilder.AppendLine($"    if (this._menesAnyOf{i}Backing is not null)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine($"        this._menesAnyOf{i}Backing.WriteTo(writer);");
                    memberBuilder.AppendLine("    }");
                }
            }
        }

        private void BuildWriteOneOfBackingValues(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.OneOf is not null)
            {
                for (int i = 0; i < typeDeclaration.OneOf.Count; ++i)
                {
                    memberBuilder.AppendLine($"    if (this._menesOneOf{i}Backing is not null)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine($"        this._menesOneOf{i}Backing.WriteTo(writer);");
                    memberBuilder.AppendLine("    }");
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
                    memberBuilder.AppendLine($"        writer.WritePropertyName(\"{property.JsonPropertyName}\");");
                    memberBuilder.AppendLine($"        {property.DotnetFieldName}.WriteTo(writer);");
                    memberBuilder.AppendLine("    }");
                }
            }

            if (typeDeclaration.AllowsAdditionalProperties)
            {
                memberBuilder.AppendLine($"    foreach (var kvp in this._menesAdditionalPropertiesBacking)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        writer.WritePropertyName(kvp.Key);");
                memberBuilder.AppendLine("        kvp.Value.WriteTo(writer);");
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
                string additionalPropertyTypeName = typeDeclaration.AdditionalProperties?.FullyQualifiedDotNetTypeName ?? TypeDeclarations.AnyTypeDeclaration.FullyQualifiedDotNetTypeName!;
                memberBuilder.AppendLine($"private readonly System.Collections.Immutable.ImmutableDictionary<string, {additionalPropertyTypeName}> _menesAdditionalPropertiesBacking;");
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
                        memberBuilder.AppendLine($"if (this.{property.DotnetFieldName} is not null)");
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
                memberBuilder.AppendLine("if (this._menesAdditionalPropertiesBacking is not null)");
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
