// <copyright file="JsonSchemaBuilder.BuildCode.Validation.AllOf.cs" company="Endjin Limited">
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
                memberBuilder.AppendLine("result = ValidateAllOf(this, result, level);");
            }
        }

        private void BuildAllOfAsMethods(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllOf is not null)
            {
                var seenItems = new HashSet<string>();

                for (int i = 0; i < typeDeclaration.AllOf.Count; ++i)
                {
                    TypeDeclaration allOf = typeDeclaration.AllOf[i];

                    if (seenItems.Contains(allOf.FullyQualifiedDotNetTypeName!))
                    {
                        continue;
                    }

                    seenItems.Add(allOf.FullyQualifiedDotNetTypeName!);
                    memberBuilder.AppendLine($"public readonly {allOf.FullyQualifiedDotNetTypeName} {this.GetAsMethodNameFor(allOf)}()");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    return this.As<{allOf.FullyQualifiedDotNetTypeName}>();");
                    memberBuilder.AppendLine("}");
                }
            }
        }

        private void BuildAllOfValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllOf is List<TypeDeclaration>)
            {
                this.PushPropertyToAbsoluteKeywordLocationStack("allOf");

                memberBuilder.AppendLine($"Menes.ValidationContext ValidateAllOf(in {typeDeclaration.FullyQualifiedDotNetTypeName} that, in Menes.ValidationContext validationContext, Menes.ValidationLevel level = Menes.ValidationLevel.Flag)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("  Menes.ValidationContext result = validationContext;");

                int allOfIndex = 0;
                foreach (TypeDeclaration allOfType in typeDeclaration.AllOf)
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(allOfIndex);

                    memberBuilder.AppendLine($"var allOf{allOfIndex} = that.{this.GetAsMethodNameFor(allOfType)}();");
                    memberBuilder.AppendLine($"var allOfResult{allOfIndex} = level == Menes.ValidationLevel.Flag ? allOf{allOfIndex}.Validate(validationContext.CreateChildContext({Formatting.FormatLiteralOrNull(this.absoluteKeywordLocationStack.Peek(), true)}), level) : allOf{allOfIndex}.Validate(validationContext.CreateChildContext(), level);");

                    memberBuilder.AppendLine($"if (level == Menes.ValidationLevel.Flag && !allOfResult{allOfIndex}.IsValid)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine($"    result = result.MergeChildContext(allOfResult{allOfIndex}, true);");
                    memberBuilder.AppendLine("    return result;");
                    memberBuilder.AppendLine("}");

                    memberBuilder.AppendLine($"    result = result.MergeChildContext(allOfResult{allOfIndex}, true);");

                    this.absoluteKeywordLocationStack.Pop();
                    ++allOfIndex;
                }

                memberBuilder.AppendLine("    return result;");
                memberBuilder.AppendLine("}");

                this.absoluteKeywordLocationStack.Pop();
            }
        }
    }
}
