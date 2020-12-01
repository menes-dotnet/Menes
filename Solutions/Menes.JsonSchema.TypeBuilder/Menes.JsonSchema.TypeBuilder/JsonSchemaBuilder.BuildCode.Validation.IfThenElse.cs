// <copyright file="JsonSchemaBuilder.BuildCode.Validation.IfThenElse.cs" company="Endjin Limited">
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
        private void BuildIfThenElseAsMethods(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IfThenElse is IfThenElse ifThenElse)
            {
                memberBuilder.AppendLine($"public readonly {ifThenElse.If.FullyQualifiedDotNetTypeName} {this.GetAsMethodNameFor(ifThenElse.If)}()");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine($"    return this.As<{ifThenElse.If.FullyQualifiedDotNetTypeName}>();");
                memberBuilder.AppendLine("}");

                if (ifThenElse.Then is TypeDeclaration thenType)
                {
                    memberBuilder.AppendLine($"public readonly {thenType.FullyQualifiedDotNetTypeName} {this.GetAsMethodNameFor(thenType)}()");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    return this.As<{thenType.FullyQualifiedDotNetTypeName}>();");
                    memberBuilder.AppendLine("}");
                }

                if (ifThenElse.Else is TypeDeclaration elseType)
                {
                    memberBuilder.AppendLine($"public readonly {elseType.FullyQualifiedDotNetTypeName} {this.GetAsMethodNameFor(elseType)}()");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    return this.As<{elseType.FullyQualifiedDotNetTypeName}>();");
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildIfThenElseValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IfThenElse is not null)
            {
                memberBuilder.AppendLine("result = ValidateIfThenElse(this, result, level);");
            }
        }

        private void BuildIfThenElseValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IfThenElse is IfThenElse ifThenElse)
            {
                memberBuilder.AppendLine($"Menes.ValidationContext ValidateIfThenElse(in {typeDeclaration.FullyQualifiedDotNetTypeName} that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level)");
                memberBuilder.AppendLine("{");

                this.PushPropertyToAbsoluteKeywordLocationStack("if");

                memberBuilder.AppendLine($"var ifValue = that.{this.GetAsMethodNameFor(ifThenElse.If)}();");
                memberBuilder.AppendLine($"Menes.ValidationContext ifResult;");

                memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine($"    ifResult = ifValue.Validate(validationContext.CreateChildContext(), level);");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine($"    ifResult = ifValue.Validate(validationContext.CreateChildContext({Formatting.FormatLiteralOrNull(this.absoluteKeywordLocationStack.Peek(), true)}), level);");
                memberBuilder.AppendLine("}");

                this.absoluteKeywordLocationStack.Pop();

                if (ifThenElse.Then is TypeDeclaration thenType)
                {
                    memberBuilder.AppendLine("if (ifResult.IsValid)");
                    memberBuilder.AppendLine("{");

                    // Merge back the local evaluated properties
                    memberBuilder.AppendLine($"result = result.MergeChildContext(ifResult, false);");

                    this.PushPropertyToAbsoluteKeywordLocationStack("then");
                    memberBuilder.AppendLine($"    var thenValue = that.{this.GetAsMethodNameFor(thenType)}();");
                    memberBuilder.AppendLine($"Menes.ValidationContext thenResult;");

                    memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    thenResult = thenValue.Validate(validationContext.CreateChildContext(), level);");
                    memberBuilder.AppendLine("}");
                    memberBuilder.AppendLine("else");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    thenResult = thenValue.Validate(validationContext.CreateChildContext({Formatting.FormatLiteralOrNull(this.absoluteKeywordLocationStack.Peek(), true)}), level);");
                    memberBuilder.AppendLine("}");
                    memberBuilder.AppendLine("    if (!thenResult.IsValid)");
                    memberBuilder.AppendLine("    {");
                    this.WriteError("9.2.2.2. then", memberBuilder);
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    else");
                    memberBuilder.AppendLine("    {");

                    // Merge back the local evaluated properties
                    memberBuilder.AppendLine($"result = result.MergeChildContext(thenResult, false);");
                    this.WriteSuccess(memberBuilder);
                    memberBuilder.AppendLine("    }");
                    this.absoluteKeywordLocationStack.Pop();
                    memberBuilder.AppendLine("}");
                }

                if (ifThenElse.Else is TypeDeclaration elseType)
                {
                    if (ifThenElse.Then is not null)
                    {
                        memberBuilder.AppendLine("else");
                    }
                    else
                    {
                        memberBuilder.AppendLine("if (!ifResult.IsValid)");
                    }

                    memberBuilder.AppendLine("{");
                    this.PushPropertyToAbsoluteKeywordLocationStack("else");
                    memberBuilder.AppendLine($"    var elseValue = that.{this.GetAsMethodNameFor(elseType)}();");
                    memberBuilder.AppendLine($"Menes.ValidationContext elseResult;");

                    memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    elseResult = elseValue.Validate(validationContext.CreateChildContext(), level);");
                    memberBuilder.AppendLine("}");
                    memberBuilder.AppendLine("else");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    elseResult = elseValue.Validate(validationContext.CreateChildContext({Formatting.FormatLiteralOrNull(this.absoluteKeywordLocationStack.Peek(), true)}), level);");
                    memberBuilder.AppendLine("}");

                    memberBuilder.AppendLine("    if (!elseResult.IsValid)");
                    memberBuilder.AppendLine("    {");
                    this.WriteError("9.2.2.3. else", memberBuilder);
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    else");
                    memberBuilder.AppendLine("    {");
                    this.WriteSuccess(memberBuilder);

                    // Merge back the local evaluated properties
                    memberBuilder.AppendLine($"result = result.MergeChildContext(elseResult, false);");
                    memberBuilder.AppendLine("    }");
                    this.absoluteKeywordLocationStack.Pop();
                    memberBuilder.AppendLine("}");
                }

                memberBuilder.AppendLine("    return result;");
                memberBuilder.AppendLine("}");
            }
        }
    }
}
