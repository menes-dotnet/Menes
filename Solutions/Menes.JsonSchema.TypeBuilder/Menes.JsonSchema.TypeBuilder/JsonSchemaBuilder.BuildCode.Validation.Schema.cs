// <copyright file="JsonSchemaBuilder.BuildCode.Validation.Schema.cs" company="Endjin Limited">
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
        /// Build the validation code for schema validation and add it to the body of the validation member.
        /// </summary>
        private void BuildSchemaValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;");

            AddLocalEvaluatedProperties(typeDeclaration, memberBuilder);

            if (typeDeclaration.AllOf is not null || typeDeclaration.AnyOf is not null || typeDeclaration.OneOf is not null)
            {
                this.BuildAllOfValidation(typeDeclaration, memberBuilder);
                this.BuildOneOfValidation(typeDeclaration, memberBuilder);
                this.BuildAnyOfValidation(typeDeclaration, memberBuilder);
            }

            this.BuildPropertyValidations(typeDeclaration, memberBuilder);
            this.BuildEnumeratedPropertyValidations(typeDeclaration, memberBuilder);
            this.BuildArrayValidation(typeDeclaration, memberBuilder);

            MergeLocalEvaluatedProperties(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine("return result;");

            this.BuildValidationLocalFunctions(typeDeclaration, memberBuilder);
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

                // We need to know what we have already evaluated if we have pattern properties
                memberBuilder.AppendLine("evaluatedProperties = evaluatedProperties ?? new System.Collections.Generic.HashSet<string>();");

                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
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

        private void BuildTypeValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
        }

        private void BuildValidationLocalFunctions(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            this.BuildAllOfValidationLocalFunction(typeDeclaration, memberBuilder);
            this.BuildAnyOfValidationLocalFunction(typeDeclaration, memberBuilder);
            this.BuildOneOfValidationLocalFunction(typeDeclaration, memberBuilder);
        }
    }
}
