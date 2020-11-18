﻿// <copyright file="JsonSchemaBuilder.Validation.Boolean.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System.Text;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private void BuildFalseValidation(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;");
            this.WriteError("core 4.3.2.Boolean JSON Schemas - false", memberBuilder);
            memberBuilder.AppendLine("return result;");
        }

        private void BuildTrueValidation(StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;");
            this.WriteSuccess(memberBuilder);
            memberBuilder.AppendLine("return result;");
        }
    }
}