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
                memberBuilder.AppendLine("result = ValidateAllOf(this, result, level, composedEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");
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

                memberBuilder.AppendLine($"Menes.ValidationResult ValidateAllOf(in {typeDeclaration.FullyQualifiedDotNetTypeName} that, Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("  Menes.ValidationResult result = validationResult;");
                memberBuilder.AppendLine("System.Collections.Generic.HashSet<string> localEvaluatedProperties = new System.Collections.Generic.HashSet<string>();");

                int allOfIndex = 0;
                foreach (TypeDeclaration allOfType in typeDeclaration.AllOf)
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(allOfIndex);

                    this.BuildPushAbsoluteKeywordLocation(memberBuilder, allOfIndex);

                    memberBuilder.AppendLine($"var allOf{allOfIndex} = that.{this.GetAsMethodNameFor(allOfType)}();");
                    memberBuilder.AppendLine("localEvaluatedProperties.Clear();");

                    memberBuilder.AppendLine($"result = allOf{allOfIndex}.Validate(result, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");

                    memberBuilder.AppendLine("if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    return result;");
                    memberBuilder.AppendLine("}");

                    // Merge the evaluated items back into the outer result set, which is the
                    // "composedEvaluatedProperties" collection.
                    memberBuilder.AppendLine("foreach (var item in localEvaluatedProperties)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    evaluatedProperties.Add(item);");
                    memberBuilder.AppendLine("}");

                    this.BuildPopAbsoluteKeywordLocation(memberBuilder, allOfIndex);
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
