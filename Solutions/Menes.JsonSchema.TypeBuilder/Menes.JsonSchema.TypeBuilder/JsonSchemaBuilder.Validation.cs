// <copyright file="JsonSchemaBuilder.Validation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
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
        /// <returns>The content for the Validate() member.</returns>
        private async Task BuildValidate(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("/// <inheritdoc />");
            memberBuilder.AppendLine("public Menes.ValidatationResult Validate(in Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("  Menes.ValidationResult result = validationResult;");

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
                        await this.BuildSchemaValidation(typeDeclaration, memberBuilder).ConfigureAwait(false);
                        break;
                    default:
                        throw new InvalidOperationException("The schema is not valid. Expected to find [true, false, {}].");
                }
            }
            finally
            {
                memberBuilder.AppendLine("}");
            }
        }

        private string WriteKeywordLocation()
        {
            return Formatting.FormatLiteralOrNull(this.keywordLocationStack.Peek(), true);
        }

        /// <summary>
        /// Write an error message to the validation result.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="memberBuilder">The string builder to which to write the error.</param>
        private void WriteError(string message, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("  if (Menes.ValidationContext.Level >= Menes.ValidationLevel.Detailed)");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result = result.AddError(valid: false, keywordLocation: {this.WriteKeywordLocation()}, instanceLocation: this.instanceLocation, Error: \"{message}\");");
            memberBuilder.AppendLine("  }");
            memberBuilder.AppendLine("  else if (Menes.ValidationContext.Level == Menes.ValidationLevel.Basic)");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result.AddError(valid: false, keywordLocation: {this.WriteKeywordLocation()}, instanceLocation: this.instanceLocation, Error: \"{message}\");");
            memberBuilder.AppendLine("  }");
            memberBuilder.AppendLine("  else");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result.Valid = false;");
            memberBuilder.AppendLine("  }");
        }

        /// <summary>
        /// Write a success message to the validation result.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="memberBuilder">The string builder to which to write the success.</param>
        private void WriteSuccess(string message, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("  if (Menes.ValidationContext.Level == Menes.ValidationLevel.Verbose)");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result = result.AddError(valid: true, keywordLocation: {this.WriteKeywordLocation()}, instanceLocation: this.instanceLocation, Error: \"{message}\");");
            memberBuilder.AppendLine("  }");
        }
    }
}
