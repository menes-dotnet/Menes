// <copyright file="JsonSchemaBuilder.Validation.AllOf.cs" company="Endjin Limited">
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
        private void BuildAllOfValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllOf is List<TypeDeclaration>)
            {
                memberBuilder.AppendLine("result = ValidateAllOf(result, level, evaluatedProperties);");
            }
        }

        private void BuildAllOfValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllOf is List<TypeDeclaration>)
            {
                this.PushPropertyToAbsoluteKeywordLocationStack("allOf");

                memberBuilder.AppendLine("Menes.ValidatationResult ValidateAllOf(in Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("  Menes.ValidationResult result = validationResult;");

                int allOfIndex = 0;
                foreach (TypeDeclaration allOfType in typeDeclaration.AllOf)
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(allOfIndex);
                    memberBuilder.AppendLine($"var allOf{allOfIndex} = this.{this.GetAsMethodNameFor(allOfType)}();");

                    if (typeDeclaration.UnevaluatedProperties is not null)
                    {
                        memberBuilder.AppendLine($"result = allOf{allOfIndex}.Validate(result, level, localEvaluatedProperties);");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"result = allOf{allOfIndex}.Validate(result, level);");
                    }

                    memberBuilder.AppendLine("if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    return result;");
                    memberBuilder.AppendLine("}");

                    ++allOfIndex;
                    this.absoluteKeywordLocationStack.Pop();
                }

                memberBuilder.AppendLine("    return result;");
                memberBuilder.AppendLine("}");

                this.absoluteKeywordLocationStack.Pop();
            }
        }
    }
}
