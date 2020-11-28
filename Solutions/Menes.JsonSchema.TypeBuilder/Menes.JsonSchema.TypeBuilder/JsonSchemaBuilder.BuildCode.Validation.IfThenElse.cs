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
                memberBuilder.AppendLine("result = ValidateIfThenElse(this, result, level, composedEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");
            }
        }

        private void BuildIfThenElseValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IfThenElse is IfThenElse ifThenElse)
            {
                memberBuilder.AppendLine($"Menes.ValidationResult ValidateIfThenElse(in {typeDeclaration.FullyQualifiedDotNetTypeName} that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)");
                memberBuilder.AppendLine("{");

                this.PushPropertyToAbsoluteKeywordLocationStack("if");
                this.BuildPushAbsoluteKeywordLocation(memberBuilder, 1);

                memberBuilder.AppendLine("System.Collections.Generic.HashSet<string> localEvaluatedProperties = new System.Collections.Generic.HashSet<string>();");

                memberBuilder.AppendLine("localEvaluatedProperties.Clear();");

                memberBuilder.AppendLine($"var ifValue = that.{this.GetAsMethodNameFor(ifThenElse.If)}();");

                memberBuilder.AppendLine($"var ifResult = ifValue.Validate(null, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");

                this.BuildPopAbsoluteKeywordLocation(memberBuilder, 1);
                this.absoluteKeywordLocationStack.Pop();

                if (ifThenElse.Then is TypeDeclaration thenType)
                {
                    memberBuilder.AppendLine("if (ifResult.Valid)");
                    memberBuilder.AppendLine("{");

                    // Merge back the local evaluated properties
                    memberBuilder.AppendLine("    foreach (var item in localEvaluatedProperties)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        evaluatedProperties.Add(item);");
                    memberBuilder.AppendLine("    }");

                    memberBuilder.AppendLine("localEvaluatedProperties.Clear();");

                    this.PushPropertyToAbsoluteKeywordLocationStack("then");
                    this.BuildPushAbsoluteKeywordLocation(memberBuilder, 2);
                    memberBuilder.AppendLine($"    var thenValue = that.{this.GetAsMethodNameFor(thenType)}();");
                    memberBuilder.AppendLine("    var thenResult = thenValue.Validate(null, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                    memberBuilder.AppendLine("    if (!thenResult.Valid)");
                    memberBuilder.AppendLine("    {");
                    this.WriteError("9.2.2.2. then", memberBuilder);
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    else");
                    memberBuilder.AppendLine("    {");

                    // Merge back the local evaluated properties
                    memberBuilder.AppendLine("    foreach (var item in localEvaluatedProperties)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        evaluatedProperties.Add(item);");
                    memberBuilder.AppendLine("    }");
                    this.WriteSuccess(memberBuilder);
                    memberBuilder.AppendLine("    }");
                    this.BuildPopAbsoluteKeywordLocation(memberBuilder, 2);
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
                        memberBuilder.AppendLine("if (!ifResult.Valid)");
                    }

                    memberBuilder.AppendLine("{");
                    this.PushPropertyToAbsoluteKeywordLocationStack("else");
                    this.BuildPushAbsoluteKeywordLocation(memberBuilder, 3);
                    memberBuilder.AppendLine($"    var elseValue = that.{this.GetAsMethodNameFor(elseType)}();");
                    memberBuilder.AppendLine("localEvaluatedProperties.Clear();");
                    memberBuilder.AppendLine("    var elseResult = elseValue.Validate(null, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                    memberBuilder.AppendLine("    if (!elseResult.Valid)");
                    memberBuilder.AppendLine("    {");
                    this.WriteError("9.2.2.3. else", memberBuilder);
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    else");
                    memberBuilder.AppendLine("    {");
                    this.WriteSuccess(memberBuilder);

                    // Merge back the local evaluated properties
                    memberBuilder.AppendLine("    foreach (var item in localEvaluatedProperties)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        evaluatedProperties.Add(item);");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    }");
                    this.BuildPopAbsoluteKeywordLocation(memberBuilder, 3);
                    this.absoluteKeywordLocationStack.Pop();
                    memberBuilder.AppendLine("}");
                }

                memberBuilder.AppendLine("    return result;");
                memberBuilder.AppendLine("}");
            }
        }
    }
}
