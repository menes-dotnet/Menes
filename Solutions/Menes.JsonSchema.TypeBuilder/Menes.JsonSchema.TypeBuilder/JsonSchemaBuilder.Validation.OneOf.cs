// <copyright file="JsonSchemaBuilder.Validation.OneOf.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Collections.Generic;
    using System.Text;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private void BuildOneOfValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.OneOf is List<TypeDeclaration>)
            {
                memberBuilder.AppendLine("result = ValidateOneOf(result, level, evaluatedProperties);");
            }
        }

        private void BuildOneOfValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.OneOf is List<TypeDeclaration>)
            {
                this.PushPropertyToAbsoluteKeywordLocationStack("oneOf");

                memberBuilder.AppendLine("Menes.ValidatationResult ValidateOneOf(in Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("  Menes.ValidationResult result = validationResult;");

                memberBuilder.Append("int oneOfCount = 0;");
                int oneOfIndex = 0;
                foreach (TypeDeclaration oneOfType in typeDeclaration.OneOf)
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(oneOfIndex);
                    memberBuilder.AppendLine($"var oneOf{oneOfIndex} = this.{this.GetAsMethodNameFor(oneOfType)}();");

                    if (typeDeclaration.UnevaluatedProperties is not null)
                    {
                        memberBuilder.AppendLine($"var oneOfResult{oneOfIndex} = oneOf{oneOfIndex}.Validate(result, level, localEvaluatedProperties);");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"var oneOfResult{oneOfIndex} = oneOf{oneOfIndex}.Validate(result, level);");
                    }

                    memberBuilder.AppendLine($"if (oneOfResult{oneOfIndex}.Valid)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    oneOfCount++;");

                    // We can short circuit if we are at "flag" level as soon as we find a valid result.
                    memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag && oneOfCount > 1)");
                    memberBuilder.AppendLine("{");
                    this.WriteError("9.2.1.3. oneOf - multiple schema matched", memberBuilder);
                    memberBuilder.AppendLine("}");
                    memberBuilder.AppendLine("}");

                    ++oneOfIndex;
                    this.absoluteKeywordLocationStack.Pop();
                }

                memberBuilder.AppendLine("if (oneOfCount == 0)");
                memberBuilder.AppendLine("{");
                this.WriteError("9.2.1.2. oneOf - no schema matched", memberBuilder);
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else if (oneOfCount > 1)");
                memberBuilder.AppendLine("{");
                this.WriteError("9.2.1.2. oneOf - multiple schema matched", memberBuilder);
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                this.WriteSuccess("9.2.1.2. oneOf", memberBuilder);
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine("    return result;");
                memberBuilder.AppendLine("}");

                this.absoluteKeywordLocationStack.Pop();
            }
        }
    }
}
