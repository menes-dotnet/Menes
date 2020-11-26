// <copyright file="JsonSchemaBuilder.BuildCode.Validation.Schema.cs" company="Endjin Limited">
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
        /// Build the validation code for schema validation and add it to the body of the validation member.
        /// </summary>
        private void BuildSchemaValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;");

            this.BuildTypeValidations(typeDeclaration, memberBuilder);

            this.BuildConstValidation(typeDeclaration, memberBuilder);

            this.BuildNumericValidations(typeDeclaration, memberBuilder);

            this.BuildStringValidations(typeDeclaration, memberBuilder);

            if (typeDeclaration.AllOf is not null || typeDeclaration.AnyOf is not null || typeDeclaration.OneOf is not null)
            {
                this.BuildAllOfValidation(typeDeclaration, memberBuilder);
                this.BuildOneOfValidation(typeDeclaration, memberBuilder);
                this.BuildAnyOfValidation(typeDeclaration, memberBuilder);
            }

            this.BuildPropertyValidations(typeDeclaration, memberBuilder);
            this.BuildEnumeratedPropertyValidations(typeDeclaration, memberBuilder);

            this.BuildArrayValidation(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine("return result;");

            this.BuildValidationLocalFunctions(typeDeclaration, memberBuilder);
        }

        private void BuildConstValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Const is not JsonElement value)
            {
                return;
            }

            if (value.ValueKind == JsonValueKind.Number)
            {
                memberBuilder.AppendLine("if (!this.IsNumber)");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if ((double)this != (double)_MenesConstValue)");
                memberBuilder.AppendLine("    {");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    else");
                memberBuilder.AppendLine("    {");
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
            }
            else if (value.ValueKind == JsonValueKind.Null)
            {
                memberBuilder.AppendLine("if (!this.IsNull)");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.3. const - does not match null value", memberBuilder);
                memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        return result;");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("}");
            }
            else if (value.ValueKind == JsonValueKind.False || value.ValueKind == JsonValueKind.True)
            {
                memberBuilder.AppendLine("if (!this.IsBoolean)");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if ((bool)this != (bool)_MenesConstValue)");
                memberBuilder.AppendLine("    {");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    else");
                memberBuilder.AppendLine("    {");
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
            }
            else if (value.ValueKind == JsonValueKind.String)
            {
                memberBuilder.AppendLine("if (!this.IsString)");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if (!System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), _MenesConstValue.AsSpan()))");
                memberBuilder.AppendLine("    {");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    else");
                memberBuilder.AppendLine("    {");
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
            }
            else if (value.ValueKind == JsonValueKind.Array)
            {
                throw new NotImplementedException();
            }
            else if (value.ValueKind == JsonValueKind.Object)
            {
                throw new NotImplementedException();
            }
        }

        private void BuildTypeValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                bool isFirst = true;
                memberBuilder.Append($"if (");
                foreach (string type in typeDeclaration.Type)
                {
                    switch (type)
                    {
                        case "array":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsArray");
                            break;
                        case "object":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsObject");
                            break;
                        case "number":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsNumber");
                            break;
                        case "string":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsString");
                            break;
                        case "integer":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsInteger");
                            break;
                        case "null":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsNull");
                            break;
                        case "boolean":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsBoolean");
                            break;
                    }
                }

                memberBuilder.AppendLine(")");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.1.  type - item must be one of {string.Join(",", typeDeclaration.Type)}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
            }

            static bool AppendOperator(StringBuilder memberBuilder, bool isFirst)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    memberBuilder.Append(" && ");
                }

                return isFirst;
            }
        }

        private void BuildNumericValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsNumericType)
            {
                memberBuilder.AppendLine("if (this.IsNumber)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    var number = (double)this.As<Menes.JsonNumber>();");
                if (typeDeclaration.MultipleOf is double mo)
                {
                    memberBuilder.AppendLine($"    if (System.Math.Abs(System.Math.IEEERemainder((double)number, (double){mo})) > 1.0E-18)");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.2.1.  multipleOf - item must be a multiple of {mo}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.Maximum is double ma)
                {
                    memberBuilder.AppendLine($"    if (number > (double){ma})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.2.2.  maximum - item must be less than or equal to {ma}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.ExclusiveMaximum is double ema)
                {
                    memberBuilder.AppendLine($"    if (number >= (double){ema})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.2.3.  exclusiveMaximum - item must be less then {ema}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.Minimum is double mi)
                {
                    memberBuilder.AppendLine($"    if (number < (double){mi})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.2.4.  minimum - item must be greater than or equal to {mi}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.ExclusiveMinimum is double emi)
                {
                    memberBuilder.AppendLine($"    if (number <= (double){emi})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.2.3.  exclusiveMinimum - item must be greater then {emi}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                memberBuilder.AppendLine("}");
            }
        }

        private void BuildStringValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsStringType)
            {
                memberBuilder.AppendLine("if (this.IsString)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    var value = (string)this.As<Menes.JsonString>();");

                if (typeDeclaration.MaxLength is int maxl)
                {
                    memberBuilder.AppendLine($"    if (value.Length > {maxl})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.3.1.  maxLength - value must have length less than or equal to {maxl}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.MinLength is int minl)
                {
                    memberBuilder.AppendLine($"    if (value.Length < {minl})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.3.2.  minimum - value must have length greater than or equal to {minl}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.Pattern is string pattern)
                {
                    memberBuilder.AppendLine($"    if (!_MenesPatternExpression.IsMatch(value))");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.3.3.  pattern - value must match the regular expression {pattern}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                memberBuilder.AppendLine("}");
            }
        }

        private void BuildEnumeratedPropertyValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectTypeDeclaration)
            {
                return;
            }

            memberBuilder.AppendLine("if (this.IsObject)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    foreach (var property in this.EnumerateObject())");
            memberBuilder.AppendLine("    {");

            if (typeDeclaration.PatternProperties is not null)
            {
                int patternIndex = 0;

                foreach (PatternProperty patternProperty in typeDeclaration.PatternProperties)
                {
                    memberBuilder.AppendLine($"    if (_MenesPatternExpression{patternIndex}.IsMatch(property.Name))");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        evaluatedProperties?.Add(property.Name);");
                    memberBuilder.AppendLine($"        result = property.Value<{patternProperty.Schema.FullyQualifiedDotNetTypeName}>().Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                    patternIndex++;
                }
            }

            if (typeDeclaration.AllowsAdditionalProperties && typeDeclaration.AdditionalProperties is not null)
            {
                memberBuilder.AppendLine($"    if (!evaluatedProperties?.Contains(property.Name) ?? true)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine($"        result = property.Value<{typeDeclaration.AdditionalProperties.FullyQualifiedDotNetTypeName}>().Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
            }
            else if (!typeDeclaration.AllowsAdditionalProperties)
            {
                memberBuilder.AppendLine($"    if (!evaluatedProperties?.Contains(property.Name) ?? true)");
                memberBuilder.AppendLine("    {");
                this.WriteError("9.3.2.3. additionalProperties - additional properties are not permitted.", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
            }

            memberBuilder.AppendLine("    }");
            memberBuilder.AppendLine("}");
        }

        private void BuildPropertyValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectTypeDeclaration)
            {
                return;
            }

            if (typeDeclaration.Properties is not null)
            {
                int index = 0;
                memberBuilder.AppendLine("if (this.IsObject)");
                memberBuilder.AppendLine("{");

                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    // Don't evaluate non-local properties here (e.g. those that are merged in from allOf)
                    if (!property.IsLocal)
                    {
                        index++;
                        continue;
                    }

                    this.PushPropertyToAbsoluteKeywordLocationStack(property.JsonPropertyName!);
                    this.BuildPushAbsoluteKeywordLocation(memberBuilder, index);
                    memberBuilder.AppendLine($"    evaluatedProperties?.Add({Formatting.FormatLiteralOrNull(property.JsonPropertyName, true)});");
                    memberBuilder.AppendLine($"    if (this.TryGetProperty<{property.TypeDeclaration!.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}JsonPropertyName.Span, out {property.TypeDeclaration!.FullyQualifiedDotNetTypeName} value{index}))");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine($"        result = value{index}.Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    else");
                    memberBuilder.AppendLine("    {");

                    if (property.IsRequired)
                    {
                        this.WriteError("6.5.3. required - required property not present.", memberBuilder);
                        memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag)");
                        memberBuilder.AppendLine("        {");
                        memberBuilder.AppendLine("            return result;");
                        memberBuilder.AppendLine("        }");
                    }
                    else
                    {
                        this.WriteSuccess(memberBuilder);
                    }

                    memberBuilder.AppendLine("    }");

                    this.BuildPopAbsoluteKeywordLocation(memberBuilder, index);
                    this.absoluteKeywordLocationStack.Pop();
                    index++;
                }

                memberBuilder.AppendLine("}");
            }
        }

        private void BuildValidationLocalFunctions(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            this.BuildAllOfValidationLocalFunction(typeDeclaration, memberBuilder);
            this.BuildAnyOfValidationLocalFunction(typeDeclaration, memberBuilder);
            this.BuildOneOfValidationLocalFunction(typeDeclaration, memberBuilder);
        }
    }
}
