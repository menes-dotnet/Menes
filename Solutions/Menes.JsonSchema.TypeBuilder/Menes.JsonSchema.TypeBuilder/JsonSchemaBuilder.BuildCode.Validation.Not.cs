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
                memberBuilder.AppendLine("result = ValidateNot(this, result, level);");
            }
        }

        private void BuildNotValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Not is TypeDeclaration notType)
            {
                memberBuilder.AppendLine($"Menes.ValidationContext ValidateNot(in {typeDeclaration.FullyQualifiedDotNetTypeName} that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)");
                memberBuilder.AppendLine("{");

                memberBuilder.AppendLine($"Menes.ValidationContext result = validationContext;");

                this.PushPropertyToAbsoluteKeywordLocationStack("not");

                memberBuilder.AppendLine($"var notValue = that.{this.GetAsMethodNameFor(notType)}();");
                memberBuilder.AppendLine($"Menes.ValidationContext notResult;");

                memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine($"    notResult = notValue.Validate(validationContext.CreateChildContext(), level);");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine($"    notResult = notValue.Validate(validationContext.CreateChildContext({Formatting.FormatLiteralOrNull(this.absoluteKeywordLocationStack.Peek(), true)}), level);");
                memberBuilder.AppendLine("}");

                if (typeDeclaration.UnevaluatedProperties is null)
                {
                    // We can short circuit if we are at "flag" level as soon as we find a valid result, but
                    // only if we are not evaluating all the unevaluated properties.
                    memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag && !notResult.IsValid)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    return result;");
                    memberBuilder.AppendLine("}");
                }

                //// Not should *not* merge back from the child context.

                memberBuilder.AppendLine("if (notResult.IsValid)");
                memberBuilder.AppendLine("{");
                this.WriteError("9.2.1.4. not", memberBuilder);
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
