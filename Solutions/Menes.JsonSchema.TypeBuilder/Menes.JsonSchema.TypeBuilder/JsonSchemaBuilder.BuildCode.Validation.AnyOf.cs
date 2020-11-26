// <copyright file="JsonSchemaBuilder.BuildCode.Validation.AnyOf.cs" company="Endjin Limited">
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
        private void BuildAnyOfAsMethods(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AnyOf is not null)
            {
                for (int i = 0; i < typeDeclaration.AnyOf.Count; ++i)
                {
                    TypeDeclaration anyOf = typeDeclaration.AnyOf[i];
                    memberBuilder.AppendLine($"public readonly {anyOf.FullyQualifiedDotNetTypeName} {this.GetAsMethodNameFor(anyOf)}()");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    return this.As<{anyOf.FullyQualifiedDotNetTypeName}>();");
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildAnyOfValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AnyOf is List<TypeDeclaration>)
            {
                memberBuilder.AppendLine("result = ValidateAnyOf(this, result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
            }
        }

        private void BuildAnyOfValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AnyOf is List<TypeDeclaration>)
            {
                memberBuilder.AppendLine($"Menes.ValidationResult ValidateAnyOf(in {typeDeclaration.FullyQualifiedDotNetTypeName} that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)");
                memberBuilder.AppendLine("{");

                this.PushPropertyToAbsoluteKeywordLocationStack("anyOf");

                // If we don't have to evaluate everything, we can short-circuit anyOf
                if (typeDeclaration.IsConcreteAnyOf && typeDeclaration.UnevaluatedProperties is null)
                {
                    int currentIndex = 0;
                    memberBuilder.AppendLine("int foundIndex = -1;");
                    memberBuilder.AppendLine("Menes.ValidationResult? preResult = null;");
                    memberBuilder.AppendLine("if (level == Menes.ValidationLevel.Flag)");
                    memberBuilder.AppendLine("{");
                    foreach (TypeDeclaration type in typeDeclaration.AnyOf)
                    {
                        string backingName = Formatting.ToPascalCaseWithReservedWords(type.FullyQualifiedDotNetTypeName!).ToString();
                        memberBuilder.AppendLine($"if (that._menes{backingName}AnyOfBacking is {type.FullyQualifiedDotNetTypeName} anyOfBacking{currentIndex})");
                        memberBuilder.AppendLine("{");
                        memberBuilder.AppendLine($"    foundIndex = {currentIndex};");
                        memberBuilder.AppendLine($"    preResult = anyOfBacking{currentIndex}.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);");
                        memberBuilder.AppendLine("    if (preResult.Valid)");
                        memberBuilder.AppendLine("    {");
                        memberBuilder.AppendLine("        return result;");
                        memberBuilder.AppendLine("    }");
                        memberBuilder.AppendLine("}");
                        currentIndex++;
                    }

                    memberBuilder.AppendLine("}");
                }

                int anyOfIndex = 0;
                foreach (TypeDeclaration anyOfType in typeDeclaration.AnyOf)
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(anyOfIndex);
                    this.BuildPushAbsoluteKeywordLocation(memberBuilder, anyOfIndex);

                    memberBuilder.AppendLine($"Menes.ValidationResult anyOfResult{anyOfIndex};");

                    // If we don't have to evaluate everything, we can short-circuit anyOf
                    if (typeDeclaration.IsConcreteAnyOf && typeDeclaration.UnevaluatedProperties is null)
                    {
                        memberBuilder.AppendLine($"if (foundIndex == {anyOfIndex})");
                        memberBuilder.AppendLine("{");
                        memberBuilder.AppendLine($"    anyOfResult{anyOfIndex} = preResult;");
                        memberBuilder.AppendLine("}");
                        memberBuilder.AppendLine("else");
                        memberBuilder.AppendLine("{");
                    }

                    memberBuilder.AppendLine($"var anyOf{anyOfIndex} = that.{this.GetAsMethodNameFor(anyOfType)}();");

                    if (typeDeclaration.UnevaluatedProperties is not null)
                    {
                        memberBuilder.AppendLine($"anyOfResult{anyOfIndex} = anyOf{anyOfIndex}.Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"anyOfResult{anyOfIndex} = anyOf{anyOfIndex}.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);");

                        // We can short circuit if we are at "flag" level as soon as we find a valid result, but
                        // only if we are not evaluating all the unevaluated properties.
                        memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag && anyOfResult{anyOfIndex}.Valid)");
                        memberBuilder.AppendLine("{");
                        memberBuilder.AppendLine("    return result;");
                        memberBuilder.AppendLine("}");
                    }

                    if (typeDeclaration.IsConcreteAnyOf && typeDeclaration.UnevaluatedProperties is null)
                    {
                        memberBuilder.AppendLine("}");
                    }

                    this.BuildPopAbsoluteKeywordLocation(memberBuilder, anyOfIndex);
                    this.absoluteKeywordLocationStack.Pop();
                    ++anyOfIndex;
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
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine("    return result;");
                memberBuilder.AppendLine("}");

                this.absoluteKeywordLocationStack.Pop();
            }
        }
    }
}
