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
                var seenItems = new HashSet<string>();

                for (int i = 0; i < typeDeclaration.AnyOf.Count; ++i)
                {
                    TypeDeclaration anyOf = typeDeclaration.AnyOf[i];

                    if (seenItems.Contains(anyOf.FullyQualifiedDotNetTypeName!))
                    {
                        continue;
                    }

                    seenItems.Add(anyOf.FullyQualifiedDotNetTypeName!);
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
                memberBuilder.AppendLine("result = ValidateAnyOf(this, result, level);");
            }
        }

        private void BuildAnyOfValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AnyOf is List<TypeDeclaration>)
            {
                memberBuilder.AppendLine($"Menes.ValidationContext ValidateAnyOf(in {typeDeclaration.FullyQualifiedDotNetTypeName} that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)");
                memberBuilder.AppendLine("{");

                this.PushPropertyToAbsoluteKeywordLocationStack("anyOf");

                memberBuilder.AppendLine("Menes.ValidationContext result = validationContext;");

                int anyOfIndex = 0;
                foreach (TypeDeclaration anyOfType in typeDeclaration.AnyOf)
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(anyOfIndex);

                    memberBuilder.AppendLine($"var anyOf{anyOfIndex} = that.{this.GetAsMethodNameFor(anyOfType)}();");

                    memberBuilder.AppendLine($"Menes.ValidationContext anyOfResult{anyOfIndex};");

                    memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    anyOfResult{anyOfIndex} = anyOf{anyOfIndex}.Validate(validationContext.CreateChildContext(), level);");
                    memberBuilder.AppendLine("}");
                    memberBuilder.AppendLine("else");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    anyOfResult{anyOfIndex} = anyOf{anyOfIndex}.Validate(validationContext.CreateChildContext({Formatting.FormatLiteralOrNull(this.absoluteKeywordLocationStack.Peek(), true)}), level);");
                    memberBuilder.AppendLine("}");

                    memberBuilder.AppendLine($"if (anyOfResult{anyOfIndex}.IsValid)");
                    memberBuilder.AppendLine("{");

                    // Merge the evaluated items back into the outer result set
                    memberBuilder.AppendLine($"result = result.MergeChildContext(anyOfResult{anyOfIndex}, false);");

                    memberBuilder.AppendLine("}");

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

                    memberBuilder.Append($"!anyOfResult{i}.IsValid");
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
