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
                memberBuilder.AppendLine("result = ValidateOneOf(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
            }
        }

        private void BuildOneOfValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.OneOf is List<TypeDeclaration>)
            {
                this.PushPropertyToAbsoluteKeywordLocationStack("oneOf");

                memberBuilder.AppendLine("Menes.ValidatationResult ValidateOneOf(in Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("  Menes.ValidationResult result = validationResult;");

                memberBuilder.AppendLine("int oneOfCount = 0;");
                int oneOfIndex = 0;
                foreach (TypeDeclaration oneOfType in typeDeclaration.OneOf)
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(oneOfIndex);
                    this.BuildPushAbsoluteKeywordLocation(memberBuilder);

                    memberBuilder.AppendLine($"var oneOf{oneOfIndex} = this.{this.GetAsMethodNameFor(oneOfType)}();");

                    if (typeDeclaration.UnevaluatedProperties is not null)
                    {
                        memberBuilder.AppendLine($"var oneOfResult{oneOfIndex} = oneOf{oneOfIndex}.Validate(result, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"var oneOfResult{oneOfIndex} = oneOf{oneOfIndex}.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);");
                    }

                    memberBuilder.AppendLine($"if (oneOfResult{oneOfIndex}.Valid)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    oneOfCount++;");

                    // We can short circuit if we are at "flag" level if we have found multiple valid items
                    // (there's no point checking on the first one, because we can't possibly have already
                    // validated 2!)
                    if (oneOfIndex > 0)
                    {
                        memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag && oneOfCount > 1)");
                        memberBuilder.AppendLine("{");
                        this.WriteError("9.2.1.3. oneOf - multiple schema matched", memberBuilder);
                        memberBuilder.AppendLine("}");
                    }

                    memberBuilder.AppendLine("}");

                    ++oneOfIndex;
                    this.BuildPopAbsoluteKeywordLocation(memberBuilder);
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
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine("    return result;");
                memberBuilder.AppendLine("}");

                this.absoluteKeywordLocationStack.Pop();
            }
        }
    }
}
