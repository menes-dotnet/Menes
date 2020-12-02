// <copyright file="JsonSchemaBuilder.BuildCode.Validation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Collections.Generic;
    using System.Text;
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
            memberBuilder.AppendLine("public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)");
            memberBuilder.AppendLine("{");

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
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.IsValid)");
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

            if (typeDeclaration.UniqueItems.HasValue && typeDeclaration.UniqueItems.Value)
            {
                memberBuilder.AppendLine("var innerEnumerator = this.EnumerateArray();");
                memberBuilder.AppendLine("var innerIndex = -1;");
                memberBuilder.AppendLine("while (innerIndex < arrayLength && innerEnumerator.MoveNext())");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    innerIndex++;");
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine("while (innerEnumerator.MoveNext())");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if (innerEnumerator.Current.Equals(arrayEnumerator.Current))");
                memberBuilder.AppendLine("    {");
                this.WriteError($"6.4.3.  uniqueItems - duplicate items were found.", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.IsValid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
                this.WriteSuccess(memberBuilder);
            }

            if (typeDeclaration.Contains is TypeDeclaration contains)
            {
                memberBuilder.AppendLine($"var containsResult = arrayEnumerator.Current.As<{contains.FullyQualifiedDotNetTypeName}>().Validate(result.CreateChildContext(), level);");
                memberBuilder.AppendLine("if (containsResult.IsValid)");
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
                    memberBuilder.AppendLine($"result = arrayEnumerator.Current.As<{items[0].FullyQualifiedDotNetTypeName}>().Validate(result, level);");
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.IsValid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("result = result.WithLocalItemIndex(arrayLength);");
                }
                else
                {
                    memberBuilder.AppendLine("switch(arrayLength)");
                    memberBuilder.AppendLine("{");

                    int caseIndex = 0;
                    foreach (TypeDeclaration item in items)
                    {
                        memberBuilder.AppendLine($"case {caseIndex}:");
                        memberBuilder.AppendLine($"   result = arrayEnumerator.Current.As<{items[caseIndex].FullyQualifiedDotNetTypeName}>().Validate(result, level);");
                        memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.IsValid)");
                        memberBuilder.AppendLine("    {");
                        memberBuilder.AppendLine("        return result;");
                        memberBuilder.AppendLine("    }");
                        memberBuilder.AppendLine("result = result.WithLocalItemIndex(arrayLength);");
                        memberBuilder.AppendLine("    break;");
                        caseIndex++;
                    }

                    memberBuilder.AppendLine("default:");
                    if (!typeDeclaration.AllowsAdditionalItems)
                    {
                        this.WriteError("9.3.1.2. additionalItems", memberBuilder);
                        memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.IsValid)");
                        memberBuilder.AppendLine("    {");
                        memberBuilder.AppendLine("        return result;");
                        memberBuilder.AppendLine("    }");
                    }
                    else if (typeDeclaration.AllowsAdditionalItems)
                    {
                        if (typeDeclaration.AdditionalItems is TypeDeclaration additionalItems)
                        {
                            memberBuilder.AppendLine($"   result = arrayEnumerator.Current.As<{additionalItems.FullyQualifiedDotNetTypeName}>().Validate(result, level);");
                            memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.IsValid)");
                            memberBuilder.AppendLine("    {");
                            memberBuilder.AppendLine("        return result;");
                            memberBuilder.AppendLine("    }");
                            memberBuilder.AppendLine("result = result.WithLocalItemIndex(arrayLength);");
                        }
                        else if (typeDeclaration.UnevaluatedItems is TypeDeclaration unevaluatedItems)
                        {
                            memberBuilder.AppendLine("if (!result.HasEvaluatedLocalOrAppliedItemIndex(arrayLength))");
                            memberBuilder.AppendLine("{");
                            memberBuilder.AppendLine($"   result = arrayEnumerator.Current.As<{unevaluatedItems.FullyQualifiedDotNetTypeName}>().Validate(result, level);");
                            memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.IsValid)");
                            memberBuilder.AppendLine("    {");
                            memberBuilder.AppendLine("        return result;");
                            memberBuilder.AppendLine("    }");
                            memberBuilder.AppendLine("result = result.WithLocalItemIndex(arrayLength);");
                            memberBuilder.AppendLine("}");
                        }
                    }

                    memberBuilder.AppendLine("break;");
                    memberBuilder.AppendLine("}");
                }
            }
            else if (typeDeclaration.UnevaluatedItems is TypeDeclaration unevaluatedItems)
            {
                memberBuilder.AppendLine("if (!result.HasEvaluatedLocalOrAppliedItemIndex(arrayLength))");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine($"   result = arrayEnumerator.Current.As<{unevaluatedItems.FullyQualifiedDotNetTypeName}>().Validate(result, level);");
                memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.IsValid)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        return result;");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("result = result.WithLocalItemIndex(arrayLength);");
                memberBuilder.AppendLine("}");
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
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.IsValid)");
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
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.IsValid)");
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
            memberBuilder.AppendLine($"    result = result.WithResult(isValid: false, message: {Formatting.FormatLiteralOrNull(message, true)});");
            memberBuilder.AppendLine("}");
            memberBuilder.AppendLine("else");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    result = result.WithResult(isValid: false);");
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
            memberBuilder.AppendLine("    result = result.WithResult(isValid: true);");
            memberBuilder.AppendLine("}");
        }
    }
}
