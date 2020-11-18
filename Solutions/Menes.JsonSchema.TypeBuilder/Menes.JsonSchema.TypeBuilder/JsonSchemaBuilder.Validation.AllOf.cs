﻿// <copyright file="JsonSchemaBuilder.Validation.AllOf.cs" company="Endjin Limited">
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
                memberBuilder.AppendLine("result = ValidateAllOf(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
            }
        }

        private void BuildAllOfValidationLocalFunction(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.AllOf is List<TypeDeclaration>)
            {
                this.PushPropertyToAbsoluteKeywordLocationStack("allOf");

                memberBuilder.AppendLine("Menes.ValidatationResult ValidateAllOf(Menes.ValidationResult validationResult, Menes.ValidationLevel level = Menes.ValidationLevel.Flag, System.Collections.Generic.HashSet<string>? evaluatedProperties = null, System.Collections.Generic.Stack<string>? absoluteKeywordLocation = null, System.Collections.Generic.Stack<string>? instanceLocation = null)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("  Menes.ValidationResult result = validationResult;");

                int allOfIndex = 0;
                foreach (TypeDeclaration allOfType in typeDeclaration.AllOf)
                {
                    this.PushArrayIndexToAbsoluteKeywordLocationStack(allOfIndex);

                    this.BuildPushAbsoluteKeywordLocation(memberBuilder);

                    memberBuilder.AppendLine($"var allOf{allOfIndex} = this.{this.GetAsMethodNameFor(allOfType)}();");

                    if (typeDeclaration.UnevaluatedProperties is not null)
                    {
                        memberBuilder.AppendLine($"result = allOf{allOfIndex}.Validate(result, level, localEvaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"result = allOf{allOfIndex}.Validate(result, level, absoluteKeywordLocation: absoluteKeywordLocation, instanceLocation: instanceLocation);");
                    }

                    memberBuilder.AppendLine("if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    return result;");
                    memberBuilder.AppendLine("}");

                    ++allOfIndex;

                    this.BuildPopAbsoluteKeywordLocation(memberBuilder);
                    this.absoluteKeywordLocationStack.Pop();
                }

                memberBuilder.AppendLine("    return result;");
                memberBuilder.AppendLine("}");

                this.absoluteKeywordLocationStack.Pop();
            }
        }
    }
}