// <copyright file="JsonSchemaBuilder.BuildCode.cs" company="Endjin Limited">
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
        /// Build the code for a type.
        /// </summary>
        private void BuildCode(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine($"public readonly struct {typeDeclaration.DotnetTypeName}");
            memberBuilder.AppendLine("{");
            this.BuildValidate(typeDeclaration, memberBuilder);
            memberBuilder.AppendLine("}");
        }
    }
}
