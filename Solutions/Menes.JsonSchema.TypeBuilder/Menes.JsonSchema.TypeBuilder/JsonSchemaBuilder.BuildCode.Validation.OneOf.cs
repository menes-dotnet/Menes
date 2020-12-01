// <copyright file="JsonSchemaBuilder.BuildCode.Validation.OneOf.cs" company="Endjin Limited">
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
        private void BuildOneOfAsMethods(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.OneOf is not null)
            {
                var seenItems = new HashSet<string>();

                for (int i = 0; i < typeDeclaration.OneOf.Count; ++i)
                {
                    TypeDeclaration oneOf = typeDeclaration.OneOf[i];

                    if (seenItems.Contains(oneOf.FullyQualifiedDotNetTypeName!))
                    {
                        continue;
                    }

                    seenItems.Add(oneOf.FullyQualifiedDotNetTypeName!);
                    memberBuilder.AppendLine($"public readonly {oneOf.FullyQualifiedDotNetTypeName} {this.GetAsMethodNameFor(oneOf)}()");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"        return this.As<{oneOf.FullyQualifiedDotNetTypeName}>();");
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildOneOfValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.OneOf is List<TypeDeclaration>)
            {
                memberBuilder.AppendLine("result = ValidateOneOf(this, result, level);");
            }
        }

        private void BuildOneOfValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.OneOf is List<TypeDeclaration>)
            {
                this.PushPropertyToAbsoluteKeywordLocationStack("oneOf");

                memberBuilder.AppendLine($"Menes.ValidationContext ValidateOneOf(in {typeDeclaration.FullyQualifiedDotNetTypeName} that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("  Menes.ValidationContext result = validationContext;");

                memberBuilder.AppendLine("int oneOfCount = 0;");
                int oneOfIndex = 0;
                foreach (TypeDeclaration oneOfType in typeDeclaration.OneOf)
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(oneOfIndex);

                    memberBuilder.AppendLine($"var oneOf{oneOfIndex} = that.{this.GetAsMethodNameFor(oneOfType)}();");

                    memberBuilder.AppendLine($"Menes.ValidationContext oneOfResult{oneOfIndex};");

                    memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    oneOfResult{oneOfIndex} = oneOf{oneOfIndex}.Validate(validationContext.CreateChildContext(), level);");
                    memberBuilder.AppendLine("}");
                    memberBuilder.AppendLine("else");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    oneOfResult{oneOfIndex} = oneOf{oneOfIndex}.Validate(validationContext.CreateChildContext({Formatting.FormatLiteralOrNull(this.absoluteKeywordLocationStack.Peek(), true)}), level);");
                    memberBuilder.AppendLine("}");

                    memberBuilder.AppendLine($"if (oneOfResult{oneOfIndex}.IsValid)");
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

                    // Merge the evaluated items back into the outer result set
                    memberBuilder.AppendLine($"result = result.MergeChildContext(oneOfResult{oneOfIndex}, false);");

                    this.absoluteKeywordLocationStack.Pop();
                    ++oneOfIndex;
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
