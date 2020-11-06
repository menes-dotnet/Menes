// <copyright file="JsonSchemaBuilder.Validation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// Builds the validation method for the type.
        /// </summary>
        /// <param name="namedElement">The element for which to build the validation method.</param>
        /// <returns>The content for the Validate() member.</returns>
        private async Task<string> BuildValidate(LocatedElement namedElement)
        {
            var memberBuilder = new StringBuilder();

            memberBuilder.AppendLine("/// <summary>");
            memberBuilder.AppendLine("/// Builds the validation annotations for the type.");
            memberBuilder.AppendLine("/// </summary>");
            memberBuilder.AppendLine("public Menes.ValidatationResult Validate(in Menes.ValidationResult validationResult)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("  Menes.ValidationResult result = validationResult;");

            try
            {
                switch (namedElement.JsonElement.ValueKind)
                {
                    case JsonValueKind.True:
                        this.BuildTrueValidation(memberBuilder);
                        break;
                    case JsonValueKind.False:
                        this.BuildFalseValidation(memberBuilder);
                        break;
                    case JsonValueKind.Object:
                        await this.BuildSchemaValidation(namedElement, memberBuilder).ConfigureAwait(false);
                        break;
                    default:
                        throw new InvalidOperationException("The schema is not valid.");
                }
            }
            finally
            {
                memberBuilder.AppendLine("}");
            }

            return memberBuilder.ToString();
        }

        private Task BuildSchemaValidation(in LocatedElement namedElement, StringBuilder memberBuilder)
        {
            bool pushedKeyword = false;

            try
            {
                if (namedElement.JsonElement.TryGetProperty("$schema", out JsonElement dollarschema))
                {
                    ValidateDollarSchema(dollarschema);
                }

                if (namedElement.JsonElement.TryGetProperty("$id", out JsonElement dollarid))
                {
                    ValidateDollarId(dollarid);

                    string dollaridValue = dollarid.GetString();
                    this.absoluteKeywordLocationStack.Push(dollaridValue);
                    pushedKeyword = true;
                    this.ids.Add(dollaridValue, namedElement);
                }
            }
            finally
            {
                if (pushedKeyword)
                {
                    this.absoluteKeywordLocationStack.Pop();
                }
            }

            return Task.CompletedTask;
        }

        private void BuildFalseValidation(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("  if (Menes.ValidationContext.Level >= Menes.ValidationLevel.Detailed)");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result = result.AddError(valid: false, keywordLocation: {this.WriteKeywordLocation()}, instanceLocation: this.instanceLocation, Error: \"core 4.3.2.Boolean JSON Schemas - false\");");
            memberBuilder.AppendLine("  }");
            memberBuilder.AppendLine("  else if (Menes.ValidationContext.Level == Menes.ValidationLevel.Basic)");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result.AddError(valid: false, keywordLocation: {this.WriteKeywordLocation()}, instanceLocation: this.instanceLocation, Error: \"core 4.3.2.Boolean JSON Schemas - false\");");
            memberBuilder.AppendLine("  }");
            memberBuilder.AppendLine("  else");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result.Valid = false;");
            memberBuilder.AppendLine("  }");
        }

        private void BuildTrueValidation(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("  if (Menes.ValidationContext.Level == Menes.ValidationLevel.Verbose)");
            memberBuilder.AppendLine("  {");
            memberBuilder.AppendLine($"      result = result.AddError(valid: true, keywordLocation: {this.WriteKeywordLocation()}, instanceLocation: this.instanceLocation, Error: \"core 4.3.2.Boolean JSON Schemas - true\");");
            memberBuilder.AppendLine("  }");
        }

        private string WriteKeywordLocation()
        {
            return Formatting.FormatLiteralOrNull(this.keywordLocationStack.Peek(), true);
        }
    }
}
