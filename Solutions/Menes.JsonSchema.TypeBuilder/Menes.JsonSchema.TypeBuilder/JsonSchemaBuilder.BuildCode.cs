// <copyright file="JsonSchemaBuilder.BuildCode.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Text;
    using System.Text.Json;
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

            memberBuilder.Append($"public readonly struct {typeDeclaration.DotnetTypeName} : ");
            this.BuildInterfaces(typeDeclaration, memberBuilder);
            this.BuildArrayInterfaces(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine();

            memberBuilder.AppendLine("{");

            // Public static readonly fields
            this.BuildNull(typeDeclaration, memberBuilder);

            // Private static readonly fields
            this.BuildPropertyNames(typeDeclaration, memberBuilder);

            // Private readonly fields
            this.BuildJsonElementBackingField(memberBuilder);
            this.BuildAdditionalPropertiesBackingField(typeDeclaration, memberBuilder);
            this.BuildTypeBackingFields(typeDeclaration, memberBuilder);
            this.BuildOneOfBackingFields(typeDeclaration, memberBuilder);
            this.BuildAnyOfBackingFields(typeDeclaration, memberBuilder);
            this.BuildArrayBackingField(typeDeclaration, memberBuilder);
            this.BuildPropertyBackingFields(typeDeclaration, memberBuilder);
            this.BuildPatternExpression(typeDeclaration, memberBuilder);
            this.BuildPatternPropertyExpressions(typeDeclaration, memberBuilder);
            this.BuildConstValue(typeDeclaration, memberBuilder);

            // Public and private constructors
            this.BuildConstructors(typeDeclaration, memberBuilder);

            // Conversion operators
            this.BuildConversionOperators(typeDeclaration, memberBuilder);
            this.BuildArrayConversionOperators(typeDeclaration, memberBuilder);

            // Public properties
            this.BuildUndefinedAndNullProperties(typeDeclaration, memberBuilder);
            this.BuildJsonElementProperties(memberBuilder);
            this.BuildProperties(typeDeclaration, memberBuilder);
            this.BuildPropertyCountProperty(typeDeclaration, memberBuilder);

            // Public methods
            this.BuildValidateMethod(typeDeclaration, memberBuilder);
            this.BuildWriteToMethod(typeDeclaration, memberBuilder);
            this.BuildIsAndAsMethods(typeDeclaration, memberBuilder);
            this.BuildEqualsMethod(typeDeclaration, memberBuilder);
            this.BuildTryGetProperty(typeDeclaration, memberBuilder);
            this.BuildPublicGetPropertyAtIndex(typeDeclaration, memberBuilder);
            this.BuildSetPropertyMethods(typeDeclaration, memberBuilder);
            this.BuildArrayEnumerators(typeDeclaration, memberBuilder);
            this.BuildArrayAccessors(typeDeclaration, memberBuilder);
            this.BuildArrayAdd(typeDeclaration, memberBuilder);
            this.BuildArrayInsert(typeDeclaration, memberBuilder);
            this.BuildArrayRemoveAt(typeDeclaration, memberBuilder);
            this.BuildArrayRemoveIf(typeDeclaration, memberBuilder);
            this.BuildObjectEnumerator(typeDeclaration, memberBuilder);
            this.BuildWithPropertyMethods(typeDeclaration, memberBuilder);

            // Private methods
            this.BuildJsonPropertyGetMethods(typeDeclaration, memberBuilder);
            this.BuildAllBackingFieldsAreNullMethod(typeDeclaration, memberBuilder);
            this.BuildPrivateGetPropertyAtIndex(typeDeclaration, memberBuilder);
            this.BuildWithAdditionalPropertyMethod(typeDeclaration, memberBuilder);

            // Embedded types
            this.BuildEmbeddedTypes(typeDeclaration, memberBuilder);
            this.BuildArrayEnumerator(typeDeclaration, memberBuilder);
            this.BuildPropertyEnumerator(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("}");
        }

        private void BuildConstValue(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Const is not JsonElement value)
            {
                return;
            }

            if (value.ValueKind == JsonValueKind.Number)
            {
                memberBuilder.AppendLine($"private static readonly Menes.JsonNumber _MenesConstValue = new Menes.JsonNumber((double){value.GetDouble()});");
            }
            else if (value.ValueKind == JsonValueKind.Null)
            {
                memberBuilder.AppendLine($"private static readonly Menes.JsonNull _MenesConstValue = Menes.JsonNull.Instance;");
            }
            else if (value.ValueKind == JsonValueKind.False)
            {
                memberBuilder.AppendLine($"private static readonly Menes.JsonBoolean _MenesConstValue = new Menes.JsonBoolean(false);");
            }
            else if (value.ValueKind == JsonValueKind.True)
            {
                memberBuilder.AppendLine($"private static readonly Menes.JsonBoolean _MenesConstValue = new Menes.JsonBoolean(true);");
            }
            else if (value.ValueKind == JsonValueKind.String)
            {
                memberBuilder.AppendLine($"private static readonly Menes.JsonString _MenesConstValue = new Menes.JsonString({Formatting.FormatLiteralOrNull(value.GetString(), true)});");
            }
            else if (value.ValueKind == JsonValueKind.Array || value.ValueKind == JsonValueKind.Object)
            {
                memberBuilder.AppendLine($"private static readonly Menes.JsonAny _MenesConstValue = new Menes.JsonAny({Formatting.FormatLiteralOrNull(value.GetRawText(), true)});");
            }
        }

        private void BuildPatternExpression(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Pattern is null)
            {
                return;
            }

            memberBuilder.AppendLine($"private static readonly System.Text.RegularExpressions.Regex _MenesPatternExpression = new System.Text.RegularExpressions.Regex({Formatting.FormatLiteralOrNull(typeDeclaration.Pattern, true)}, System.Text.RegularExpressions.RegexOptions.Compiled);");
        }

        private void BuildPatternPropertyExpressions(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.PatternProperties is null)
            {
                return;
            }

            int index = 0;
            foreach (PatternProperty patternProperty in typeDeclaration.PatternProperties)
            {
                memberBuilder.AppendLine($"private static readonly System.Text.RegularExpressions.Regex _MenesPatternExpression{index} = new System.Text.RegularExpressions.Regex({Formatting.FormatLiteralOrNull(patternProperty.Pattern, true)}, System.Text.RegularExpressions.RegexOptions.Compiled);");
                index++;
            }
        }

        private void BuildInterfaces(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsObjectTypeDeclaration)
            {
                memberBuilder.Append($"Menes.IJsonObject<{typeDeclaration.DotnetTypeName}>");
            }
            else
            {
                memberBuilder.Append("Menes.IJsonValue");
            }
        }

        private bool AppendParameterComma(bool isFirstParameter, StringBuilder memberBuilder)
        {
            if (isFirstParameter)
            {
                isFirstParameter = false;
            }
            else
            {
                memberBuilder.Append(", ");
            }

            return isFirstParameter;
        }

        private void BuildEqualsMethod(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("/// <inheritdoc/>");
            memberBuilder.AppendLine("public bool Equals<T>(T other)");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");

            if (typeDeclaration.IsConcreteType)
            {
                if (typeDeclaration.IsStringType)
                {
                    memberBuilder.AppendLine("    if (!other.IsString)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        return false;");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    return ((Menes.JsonString)this).Equals(other);");
                }

                if (typeDeclaration.IsBooleanType)
                {
                    memberBuilder.AppendLine("    if (!other.IsBoolean)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        return false;");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    return ((Menes.JsonBoolean)this).Equals(other);");
                }

                if (typeDeclaration.IsNumericType)
                {
                    memberBuilder.AppendLine("    if (!other.IsNumber)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        return false;");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    return ((Menes.JsonNumber)this).Equals(other);");
                }

                if (typeDeclaration.IsArrayTypeDeclaration)
                {
                    memberBuilder.AppendLine("    if (!other.IsArray)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        return false;");
                    memberBuilder.AppendLine("    }");

                    memberBuilder.AppendLine("MenesArrayEnumerator firstEnumerator = this.EnumerateArray();");
                    memberBuilder.AppendLine("Menes.JsonAny.MenesArrayEnumerator secondEnumerator = other.As<Menes.JsonAny>().EnumerateArray();");
                    memberBuilder.AppendLine("while (firstEnumerator.MoveNext())");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    if (!secondEnumerator.MoveNext())");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        // We've run out of items in the second enumerator.");
                    memberBuilder.AppendLine("        return false;");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    if (!firstEnumerator.Current.Equals(secondEnumerator.Current))");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        return false;");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("}");
                    memberBuilder.AppendLine("// If we have extra items in the second enumerator, return false.");
                    memberBuilder.AppendLine("return !secondEnumerator.MoveNext();");
                }

                if (typeDeclaration.IsObjectTypeDeclaration)
                {
                    memberBuilder.AppendLine("    if (!other.IsObject)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        return false;");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    var otherObject = Corvus.Extensions.CastTo<Menes.IJsonObject>.From(other);");
                    memberBuilder.AppendLine("MenesPropertyEnumerator firstEnumerator = this.EnumerateObject();");
                    memberBuilder.AppendLine("if (this.PropertyCount != otherObject.PropertyCount)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    return false;");
                    memberBuilder.AppendLine("}");
                    memberBuilder.AppendLine("while (firstEnumerator.MoveNext())");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    if (!otherObject.TryGetProperty<Menes.JsonAny>(firstEnumerator.Current.NameAsMemory.Span, out Menes.JsonAny otherProperty))");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        return false;");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    if (!firstEnumerator.Current.Value<Menes.JsonAny>().Equals(otherProperty))");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        return false;");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("}");
                    memberBuilder.AppendLine("return true;");
                }
            }
            else
            {
                memberBuilder.AppendLine("return false;");
            }

            memberBuilder.AppendLine("}");
        }

        private void BuildIsAndAsMethods(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public T As<T>()");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine($"if (typeof(T) == typeof({typeDeclaration.DotnetTypeName}))");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return Corvus.Extensions.CastTo<T>.From(this);");
            memberBuilder.AppendLine("}");

            if (typeDeclaration.IsConcreteOneOf)
            {
                foreach (TypeDeclaration oneOfType in typeDeclaration.OneOf!)
                {
                    memberBuilder.AppendLine($"if (typeof(T) == typeof({oneOfType.FullyQualifiedDotNetTypeName}) && this._menes{Formatting.ToPascalCaseWithReservedWords(oneOfType.FullyQualifiedDotNetTypeName!).ToString()}OneOfBacking is not null)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    return Corvus.Extensions.CastTo<T>.From(this._menes{Formatting.ToPascalCaseWithReservedWords(oneOfType.FullyQualifiedDotNetTypeName!).ToString()}OneOfBacking);");
                    memberBuilder.AppendLine("}");
                }
            }

            if (typeDeclaration.IsConcreteAnyOf)
            {
                foreach (TypeDeclaration anyOfType in typeDeclaration.AnyOf!)
                {
                    memberBuilder.AppendLine($"if (typeof(T) == typeof({anyOfType.FullyQualifiedDotNetTypeName}) && this._menes{Formatting.ToPascalCaseWithReservedWords(anyOfType.FullyQualifiedDotNetTypeName!).ToString()}AnyOfBacking is not null)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    return Corvus.Extensions.CastTo<T>.From(this._menes{Formatting.ToPascalCaseWithReservedWords(anyOfType.FullyQualifiedDotNetTypeName!).ToString()}AnyOfBacking);");
                    memberBuilder.AppendLine("}");
                }
            }

            memberBuilder.AppendLine($"    return Menes.JsonValue.As<{typeDeclaration.DotnetTypeName}, T>(this);");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public bool Is<T>()");
            memberBuilder.AppendLine("    where T : struct, Menes.IJsonValue");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine($"if (typeof(T) == typeof({typeDeclaration.FullyQualifiedDotNetTypeName}))");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return this.Validate().Valid;");
            memberBuilder.AppendLine("}");

            if (typeDeclaration.IsConcreteOneOf)
            {
                foreach (TypeDeclaration oneOfType in typeDeclaration.OneOf!)
                {
                    memberBuilder.AppendLine($"if (typeof(T) == typeof({oneOfType.FullyQualifiedDotNetTypeName}) && this._menes{Formatting.ToPascalCaseWithReservedWords(oneOfType.FullyQualifiedDotNetTypeName!).ToString()}OneOfBacking is not null)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    return this._menes{Formatting.ToPascalCaseWithReservedWords(oneOfType.FullyQualifiedDotNetTypeName!).ToString()}OneOfBacking.Value!.Validate().Valid;");
                    memberBuilder.AppendLine("}");
                }
            }

            if (typeDeclaration.IsConcreteAnyOf)
            {
                foreach (TypeDeclaration anyOfType in typeDeclaration.AnyOf!)
                {
                    memberBuilder.AppendLine($"if (typeof(T) == typeof({anyOfType.FullyQualifiedDotNetTypeName}) && this._menes{Formatting.ToPascalCaseWithReservedWords(anyOfType.FullyQualifiedDotNetTypeName!).ToString()}AnyOfBacking is not null)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    return this._menes{Formatting.ToPascalCaseWithReservedWords(anyOfType.FullyQualifiedDotNetTypeName!).ToString()}AnyOfBacking.Value!.Validate().Valid;");
                    memberBuilder.AppendLine("}");
                }
            }

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
            if (typeDeclaration.IsObjectTypeDeclaration)
            {
                memberBuilder.AppendLine("writer.WriteStartObject();");
                this.BuildWritePropertyBackingValues(typeDeclaration, memberBuilder);
                memberBuilder.AppendLine("writer.WriteEndObject();");
            }
            else if (typeDeclaration.IsArrayTypeDeclaration)
            {
                memberBuilder.AppendLine("writer.WriteStartArray();");
                memberBuilder.AppendLine("foreach (var item in this._menesArrayValueBacking)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    item.WriteTo(writer);");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("writer.WriteEndArray();");
            }
            else if (typeDeclaration.IsConcreteOneOf)
            {
                this.BuildWriteOneOfBackingValues(typeDeclaration, memberBuilder);
            }
            else if (typeDeclaration.IsConcreteAnyOf)
            {
                this.BuildWriteAnyOfBackingValues(typeDeclaration, memberBuilder);
            }
            else
            {
                this.BuildWriteTypeBackingValues(typeDeclaration, memberBuilder);
            }

            memberBuilder.AppendLine("}");
        }

        private void BuildAllBackingFieldsAreNullMethod(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("private bool AllBackingFieldsAreNull()");
            memberBuilder.AppendLine("{");

            this.BuildPropertiesAreNull(typeDeclaration, memberBuilder);

            this.BuildAdditionalPropertiesAreNull(typeDeclaration, memberBuilder);

            this.BuildTypeBackingFieldsAreNull(typeDeclaration, memberBuilder);
            this.BuildOneOfBackingFieldsAreNull(typeDeclaration, memberBuilder);
            this.BuildAnyOfBackingFieldsAreNull(typeDeclaration, memberBuilder);

            this.BuildArrayBackingFieldIsNull(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine("return true;");
            memberBuilder.AppendLine("}");
        }
    }
}
