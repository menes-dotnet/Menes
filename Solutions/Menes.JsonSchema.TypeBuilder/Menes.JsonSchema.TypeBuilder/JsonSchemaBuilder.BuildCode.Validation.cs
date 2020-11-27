// <copyright file="JsonSchemaBuilder.BuildCode.Validation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json;
    using Menes.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// Builds the validation method for the type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration for which to build the validation method.</param>
        /// <param name="memberBuilder">The output builder.</param>
        private void BuildValidateMethod(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            this.absoluteKeywordLocationStack.Push(typeDeclaration.TypeSchema.AbsoluteKeywordLocation);

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public Menes.ValidationResult Validate(Menes.ValidationResult? validationResult = null, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)");
            memberBuilder.AppendLine("{");

            memberBuilder.AppendLine("evaluatedProperties = evaluatedProperties ?? new System.Collections.Generic.HashSet<string>();");
            memberBuilder.AppendLine("var composedEvaluatedProperties = new System.Collections.Generic.HashSet<string>();");

            try
            {
                this.BuildSchemaValidation(typeDeclaration, memberBuilder);
            }
            finally
            {
                memberBuilder.AppendLine("}");
                this.absoluteKeywordLocationStack.Pop();
            }
        }

        private void BuildArrayValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsArrayType)
            {
                return;
            }

            if (typeDeclaration.IsConcreteArray)
            {
                memberBuilder.AppendLine("if (!this.IsArray)");
                memberBuilder.AppendLine("{");
                this.WriteError("6.1.1. type - expected an array type.", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
            }

            memberBuilder.AppendLine("if (this.IsArray)");
            memberBuilder.AppendLine("{");

            memberBuilder.AppendLine("int arrayLength = 0;");

            if (typeDeclaration.Contains is not null)
            {
                memberBuilder.AppendLine("int containsCount = 0;");
            }

            memberBuilder.AppendLine("var arrayEnumerator = this.EnumerateArray();");
            memberBuilder.AppendLine("while (arrayEnumerator.MoveNext())");
            memberBuilder.AppendLine("{");

            if (typeDeclaration.Contains is TypeDeclaration contains)
            {
                memberBuilder.AppendLine($"var containsResult = arrayEnumerator.Current.As<{contains.FullyQualifiedDotNetTypeName}>().Validate(null, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                memberBuilder.AppendLine("if (containsResult.Valid)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    containsCount++;");

                if (typeDeclaration.MaxContains is int maxContains)
                {
                    memberBuilder.AppendLine($"        if (level == Menes.ValidationLevel.Flag && containsCount > {maxContains})");
                    memberBuilder.AppendLine("        {");
                    this.WriteError($"6.4.4.  maxContains - exceeded maximum of {maxContains}", memberBuilder);
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                }

                memberBuilder.AppendLine("}");
            }

            if (typeDeclaration.Items is List<TypeDeclaration> items)
            {
                if (!typeDeclaration.IsItemsArray)
                {
                    memberBuilder.AppendLine($"result = arrayEnumerator.Current.As<{items[0].FullyQualifiedDotNetTypeName}>().Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                }
                else
                {
                    memberBuilder.AppendLine("switch(arrayLength)");
                    memberBuilder.AppendLine("{");

                    int caseIndex = 0;
                    foreach (TypeDeclaration item in items)
                    {
                        memberBuilder.AppendLine($"case {caseIndex}:");
                        memberBuilder.AppendLine($"   result = arrayEnumerator.Current.As<{items[caseIndex].FullyQualifiedDotNetTypeName}>().Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                        memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                        memberBuilder.AppendLine("    {");
                        memberBuilder.AppendLine("        return result;");
                        memberBuilder.AppendLine("    }");
                        memberBuilder.AppendLine("    break;");
                        caseIndex++;
                    }

                    memberBuilder.AppendLine("default:");
                    if (!typeDeclaration.AllowsAdditionalItems)
                    {
                        this.WriteError("9.3.1.2. additionalItems", memberBuilder);
                        memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                        memberBuilder.AppendLine("    {");
                        memberBuilder.AppendLine("        return result;");
                        memberBuilder.AppendLine("    }");
                    }
                    else if (typeDeclaration.AdditionalItems is TypeDeclaration additionalItems)
                    {
                        memberBuilder.AppendLine($"   result = arrayEnumerator.Current.As<{additionalItems.FullyQualifiedDotNetTypeName}>().Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                        memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                        memberBuilder.AppendLine("    {");
                        memberBuilder.AppendLine("        return result;");
                        memberBuilder.AppendLine("    }");
                    }
                    else if (typeDeclaration.UnevaluatedItems is TypeDeclaration unevaluatedItems)
                    {
                        memberBuilder.AppendLine($"   result = arrayEnumerator.Current.As<{unevaluatedItems.FullyQualifiedDotNetTypeName}>().Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                        memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                        memberBuilder.AppendLine("    {");
                        memberBuilder.AppendLine("        return result;");
                        memberBuilder.AppendLine("    }");
                    }

                    memberBuilder.AppendLine("break;");
                    memberBuilder.AppendLine("}");
                }
            }
            else if (typeDeclaration.UnevaluatedItems is TypeDeclaration unevaluatedItems)
            {
                memberBuilder.AppendLine($"   result = arrayEnumerator.Current.As<{unevaluatedItems.FullyQualifiedDotNetTypeName}>().Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        return result;");
                memberBuilder.AppendLine("    }");
            }

            memberBuilder.AppendLine("   arrayLength++;");
            memberBuilder.AppendLine("}");

            if (typeDeclaration.Contains is not null)
            {
                if (typeDeclaration.MaxContains is int maxContains2)
                {
                    memberBuilder.AppendLine($"        if (containsCount > {maxContains2})");
                    memberBuilder.AppendLine("        {");
                    this.WriteError($"6.4.4.  maxContains - greater than maximum of {maxContains2}", memberBuilder);
                    memberBuilder.AppendLine("        }");
                }

                if (typeDeclaration.MinContains is int minContains)
                {
                    memberBuilder.AppendLine($"        if (containsCount < {minContains})");
                    memberBuilder.AppendLine("        {");
                    this.WriteError($"6.4.5.  minContains - less than minimum of {minContains}", memberBuilder);
                    memberBuilder.AppendLine("        }");
                }

                if (typeDeclaration.MinContains is null)
                {
                    memberBuilder.AppendLine($"        if (containsCount == 0)");
                    memberBuilder.AppendLine("        {");
                    this.WriteError($"9.3.1.4.  contains - no items found", memberBuilder);
                    memberBuilder.AppendLine("        }");
                }
            }

            if (typeDeclaration.MinItems is int minItems)
            {
                memberBuilder.AppendLine($"if (arrayLength < {minItems})");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.4.2.  minItems - expected a minimum of {minItems} items", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
            }

            if (typeDeclaration.MaxItems is int maxItems)
            {
                memberBuilder.AppendLine($"if (arrayLength > {maxItems})");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.4.2.  minItems - expected a maximum of {maxItems} items", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
            }

            memberBuilder.AppendLine("}");
        }

        private string WriteAbsoluteKeywordLocation()
        {
            return Formatting.FormatLiteralOrNull(this.absoluteKeywordLocationStack.Peek(), true);
        }

        /// <summary>
        /// Write an error message to the validation result.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="memberBuilder">The string builder to which to write the error.</param>
        private void WriteError(string message, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("if (level >= Menes.ValidationLevel.Basic)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    string? il = null;");
            memberBuilder.AppendLine("    string? akl = null;");
            memberBuilder.AppendLine("    instanceLocation?.TryPeek(out il);");
            memberBuilder.AppendLine("    absoluteKeywordLocation?.TryPeek(out akl);");
            memberBuilder.AppendLine($"    result.AddResult(valid: false, message: {Formatting.FormatLiteralOrNull(message, true)}, instanceLocation: il, absoluteKeywordLocation: akl);");
            memberBuilder.AppendLine("}");
            memberBuilder.AppendLine("else");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    result.SetValid(false);");
            memberBuilder.AppendLine("}");
        }

        /// <summary>
        /// Write a success message to the validation result.
        /// </summary>
        /// <param name="memberBuilder">The string builder to which to write the success.</param>
        private void WriteSuccess(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("if (level == Menes.ValidationLevel.Verbose)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    string? il = null;");
            memberBuilder.AppendLine("    string? akl = null;");
            memberBuilder.AppendLine("    instanceLocation?.TryPeek(out il);");
            memberBuilder.AppendLine("    absoluteKeywordLocation?.TryPeek(out akl);");
            memberBuilder.AppendLine("    result.AddResult(valid: true, instanceLocation: il, absoluteKeywordLocation: akl);");
            memberBuilder.AppendLine("}");
        }

        private void BuildPopAbsoluteKeywordLocation(StringBuilder memberBuilder, int index)
        {
            memberBuilder.AppendLine($"if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPop{index})");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine($"    aklPop{index}.Pop();");
            memberBuilder.AppendLine("}");
        }

        private void BuildPushAbsoluteKeywordLocation(JsonReference jsonReference, StringBuilder memberBuilder, int index)
        {
            memberBuilder.AppendLine($"if (absoluteKeywordLocation is System.Collections.Generic.Stack<string> aklPush{index})");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine($"    aklPush{index}.Push({Formatting.FormatLiteralOrNull(jsonReference, true)});");
            memberBuilder.AppendLine("}");
        }

        private void BuildPushAbsoluteKeywordLocation(StringBuilder memberBuilder, int index)
        {
            this.BuildPushAbsoluteKeywordLocation(this.absoluteKeywordLocationStack.Peek(), memberBuilder, index);
        }
    }
}
