// <copyright file="JsonSchemaBuilder.Validation.cs" company="Endjin Limited">
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
        /// Builds the validation method for the type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration for which to build the validation method.</param>
        /// <param name="memberBuilder">The output builder.</param>
        private void BuildValidateMethod(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            this.absoluteKeywordLocationStack.Push(typeDeclaration.TypeSchema.AbsoluteKeywordLocation);

            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public Menes.ValidatationResult Validate(in Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null)");
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
                        throw new InvalidOperationException("The schema is not valid. Expected to find [true, false, {}].");
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
            memberBuilder.AppendLine("  if (level >= Menes.ValidationLevel.Detailed)");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result = result.AddResult(valid: false, absoluteKeywordLocation: {this.WriteAbsoluteKeywordLocation()}, instanceLocation: this.instanceLocation, error: \"{message}\");");
            memberBuilder.AppendLine("  }");
            memberBuilder.AppendLine("  else if (level == Menes.ValidationLevel.Basic)");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result.AddResult(valid: false, absoluteKeywordLocation: {this.WriteAbsoluteKeywordLocation()}, instanceLocation: this.instanceLocation, error: \"{message}\");");
            memberBuilder.AppendLine("  }");
            memberBuilder.AppendLine("  else");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result = result.SetValid(false);");
            memberBuilder.AppendLine("  }");
        }

        /// <summary>
        /// Write a success message to the validation result.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="memberBuilder">The string builder to which to write the success.</param>
        private void WriteSuccess(string message, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("  if (level == Menes.ValidationLevel.Verbose)");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result = result.AddResult(valid: true, absoluteKeywordLocation: {this.WriteAbsoluteKeywordLocation()}, instanceLocation: this.instanceLocation, error: \"{message}\");");
            memberBuilder.AppendLine("  }");
        }
    }
}
