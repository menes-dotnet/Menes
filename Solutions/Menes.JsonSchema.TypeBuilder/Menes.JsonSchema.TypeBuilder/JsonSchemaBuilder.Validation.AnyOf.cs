// <copyright file="JsonSchemaBuilder.Validation.AnyOf.cs" company="Endjin Limited">
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
        private void BuildAnyOfValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AnyOf is List<TypeDeclaration>)
            {
                memberBuilder.AppendLine("result = ValidateAnyOf(result, level, evaluatedProperties);");
            }
        }

        private void BuildAnyOfValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AnyOf is List<TypeDeclaration>)
            {
                memberBuilder.AppendLine("Menes.ValidatationResult ValidateAnyOf(in Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null)");
                memberBuilder.AppendLine("{");

                this.PushPropertyToAbsoluteKeywordLocationStack("anyOf");

                int anyOfIndex = 0;
                foreach (TypeDeclaration anyOfType in typeDeclaration.AnyOf)
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(anyOfIndex);
                    memberBuilder.AppendLine($"var anyOf{anyOfIndex} = this.{this.GetAsMethodNameFor(anyOfType)}();");

                    if (typeDeclaration.UnevaluatedProperties is not null)
                    {
                        memberBuilder.AppendLine($"var anyOfResult{anyOfIndex} = anyOf{anyOfIndex}.Validate(result, level, localEvaluatedProperties);");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"var anyOfResult{anyOfIndex} = anyOf{anyOfIndex}.Validate(result, level);");
                    }

                    // We can short circuit if we are at "flag" level as soon as we find a valid result.
                    memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag && anyOfResult{anyOfIndex}.Valid)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    return result;");
                    memberBuilder.AppendLine("}");

                    ++anyOfIndex;
                    this.absoluteKeywordLocationStack.Pop();
                }

                memberBuilder.Append("if (");
                for (int i = 0; i < typeDeclaration.AnyOf.Count; i++)
                {
                    if (i > 0)
                    {
                        memberBuilder.Append(" && ");
                    }

                    memberBuilder.Append($"!anyOfResult{i}.Valid");
                }

                memberBuilder.AppendLine(")");
                memberBuilder.AppendLine("{");
                this.WriteError("9.2.1.2. anyOf", memberBuilder);
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                this.WriteSuccess("9.2.1.2. anyOf", memberBuilder);
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine("    return result;");
                memberBuilder.AppendLine("}");

                this.absoluteKeywordLocationStack.Pop();
            }
        }
    }
}
