// <copyright file="JsonSchemaBuilder.BuildCode.Validation.EvaluatedProperties.cs" company="Endjin Limited">
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
        private static void MergeLocalEvaluatedProperties(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.UnevaluatedProperties is not null)
            {
                // Merge our evaluated properties into the parent set, if we had any.
                memberBuilder.AppendLine("if (evaluatedProperties is not null)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    foreach (string evaluatedProperty in localEvaluatedProperties)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        evaluatedProperties.Add(evaluatedProperty);");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
            }
        }

        private static void AddLocalEvaluatedProperties(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.UnevaluatedProperties is not null)
            {
                // We have an unevaluated properties validation, so we need to create the hashset
                // to record the locally evaluated properties.
                // We will copy those back in on the way out.
                memberBuilder.AppendLine("var localEvaluatedProperties = new System.Collections.Generic.HashSet<string>();");
            }
        }
    }
}
