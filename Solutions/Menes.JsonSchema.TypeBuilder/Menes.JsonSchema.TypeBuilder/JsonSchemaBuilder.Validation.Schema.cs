// <copyright file="JsonSchemaBuilder.Validation.Schema.cs" company="Endjin Limited">
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
        /// <summary>
        /// Build the validation code for schema validation and add it to the body of the validation member.
        /// </summary>
        private void BuildSchemaValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("Menes.ValidationResult result = validationResult;");

            AddLocalEvaluatedProperties(typeDeclaration, memberBuilder);

            this.BuildAllOfValidation(typeDeclaration, memberBuilder);
            this.BuildOneOfValidation(typeDeclaration, memberBuilder);
            this.BuildAnyOfValidation(typeDeclaration, memberBuilder);

            MergeLocalEvaluatedProperties(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine("return result;");

            this.BuildValidationLocalFunctions(typeDeclaration, memberBuilder);
        }

        private void BuildValidationLocalFunctions(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            this.BuildAllOfValidationLocalFunction(typeDeclaration, memberBuilder);
            this.BuildAnyOfValidationLocalFunction(typeDeclaration, memberBuilder);
            this.BuildOneOfValidationLocalFunction(typeDeclaration, memberBuilder);
        }
    }
}
