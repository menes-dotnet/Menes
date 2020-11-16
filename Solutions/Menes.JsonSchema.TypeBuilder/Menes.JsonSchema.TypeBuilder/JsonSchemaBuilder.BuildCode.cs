// <copyright file="JsonSchemaBuilder.BuildCode.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
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

            // Public properties
            this.BuildUndefinedAndNullProperties(memberBuilder);
            this.BuildJsonElementProperties(memberBuilder);

            // Public methods
            this.BuildValidateMethod(typeDeclaration, memberBuilder);
            this.BuildWriteToMethod(typeDeclaration, memberBuilder);

            // Private methods
            this.BuildAllBackingFieldsAreNullMethod(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("}");
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

                        memberBuilder.AppendLine($"if _menes{typeAsPascalCase}TypeBacking is not null)");
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
                    memberBuilder.AppendLine($"    if (this.{property.DotnetFieldName} is not null)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine($"        writer.WritePropertyName(\"{property.JsonPropertyName}\");");
                    memberBuilder.AppendLine($"        this.{property.DotnetFieldName}.WriteTo(writer);");
                    memberBuilder.AppendLine("    }");
                }
            }

            if (typeDeclaration.AllowsAdditionalProperties)
            {
                memberBuilder.AppendLine($"    foreach (var kvp in this._menesBackingElement)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        writer.WritePropertyName(kvp.Key);");
                memberBuilder.AppendLine("        kvp.Value.WriteTo(writer);");
                memberBuilder.AppendLine("    }");
            }
        }

        private void BuildJsonElementBackingField(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("private readonly System.Text.Json.JsonElement _menesBackingElement;");
        }

        private void BuildAdditionalPropertiesBackingField(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllowsAdditionalProperties)
            {
                string additionalPropertyTypeName = typeDeclaration.AdditionalProperties?.FullyQualifiedDotNetTypeName ?? TypeDeclarations.AnyTypeDeclaration.FullyQualifiedDotNetTypeName!;
                memberBuilder.AppendLine($"private readonly System.Collections.Immutable.ImmutableDictionary<string, {additionalPropertyTypeName}> _menesBackingElement;");
            }
        }

        private void BuildAllBackingFieldsAreNullMethod(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("private bool AllBackingFieldsAreNull()");
            memberBuilder.AppendLine("{");

            this.BuildPropertiesAreNull(typeDeclaration, memberBuilder);

            this.BuildAdditionalPropertiesAreNull(typeDeclaration, memberBuilder);

            this.BuildTypeBackingFieldsAreNull(typeDeclaration, memberBuilder);

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
            memberBuilder.AppendLine("bool IsUndefined => this._menesBackingElement.ValueKind == System.Text.Json.JsonValueKind.Undefined && this.AllBackingFieldsAreNull();");

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("bool IsNull => this._menesBackingElement.ValueKind == System.Text.Json.JsonValueKind.Null || this.AllBackingFieldsAreNull();");
        }

        private void BuildJsonElementProperties(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("bool HasJsonElement => this._menesBackingElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;");

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("System.Text.Json.JsonElement JsonElement => this._menesBackingElement;");
        }
    }
}
