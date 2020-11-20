// <copyright file="JsonSchemaBuilder.BuildCode.Validation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
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
            try
            {
                switch (typeDeclaration.TypeSchema.JsonElement.ValueKind)
                {
                    case JsonValueKind.True:
                        this.BuildTrueValidation(memberBuilder);
                        break;
                    case JsonValueKind.False:
                        this.BuildFalseValidation(memberBuilder);
                        break;
                    case JsonValueKind.Object:
                        this.BuildSchemaValidation(typeDeclaration, memberBuilder);
                        break;
                    default:
                        throw new InvalidOperationException($"The schema is not valid. Expected to find [true, false, {{}}] but was {typeDeclaration.TypeSchema.JsonElement.ValueKind}.");
                }
            }
            finally
            {
                memberBuilder.AppendLine("}");
                this.absoluteKeywordLocationStack.Pop();
            }
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
