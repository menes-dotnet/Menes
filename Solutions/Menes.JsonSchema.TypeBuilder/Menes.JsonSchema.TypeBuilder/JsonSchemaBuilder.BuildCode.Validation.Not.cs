// <copyright file="JsonSchemaBuilder.BuildCode.Validation.Not.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Text;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private void BuildNotAsMethods(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Not is TypeDeclaration not)
            {
                memberBuilder.AppendLine($"public readonly {not.FullyQualifiedDotNetTypeName} {this.GetAsMethodNameFor(not)}()");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine($"    return this.As<{not.FullyQualifiedDotNetTypeName}>();");
                memberBuilder.AppendLine("}");
            }
        }

        private void BuildNotValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Not is not null)
            {
                memberBuilder.AppendLine("result = ValidateNot(this, result, level, composedEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");
            }
        }

        private void BuildNotValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Not is TypeDeclaration notType)
            {
                memberBuilder.AppendLine($"Menes.ValidationResult ValidateNot(in {typeDeclaration.FullyQualifiedDotNetTypeName} that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)");
                memberBuilder.AppendLine("{");

                this.PushPropertyToAbsoluteKeywordLocationStack("not");

                memberBuilder.AppendLine("System.Collections.Generic.HashSet<string> localEvaluatedProperties = new System.Collections.Generic.HashSet<string>();");

                this.BuildPushAbsoluteKeywordLocation(memberBuilder, 1);

                memberBuilder.AppendLine("localEvaluatedProperties.Clear();");

                memberBuilder.AppendLine($"Menes.ValidationResult notResult;");

                memberBuilder.AppendLine($"var not = that.{this.GetAsMethodNameFor(notType)}();");

                if (typeDeclaration.UnevaluatedProperties is not null)
                {
                    memberBuilder.AppendLine($"notResult = not.Validate(null, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                }
                else
                {
                    memberBuilder.AppendLine($"notResult = not.Validate(null, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");

                    // We can short circuit if we are at "flag" level as soon as we find a valid result, but
                    // only if we are not evaluating all the unevaluated properties.
                    memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag && !notResult.Valid)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    return result;");
                    memberBuilder.AppendLine("}");
                }

                // Merge the evaluated items back into the outer result set, which is the
                // "composedEvaluatedProperties" collection.
                memberBuilder.AppendLine("foreach (var item in localEvaluatedProperties)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    evaluatedProperties.Add(item);");
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine("if (notResult.Valid)");
                memberBuilder.AppendLine("{");
                this.WriteError("9.2.1.4. not", memberBuilder);
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine("    return result;");
                memberBuilder.AppendLine("}");

                this.BuildPopAbsoluteKeywordLocation(memberBuilder, 1);
                this.absoluteKeywordLocationStack.Pop();
            }
        }
    }
}
