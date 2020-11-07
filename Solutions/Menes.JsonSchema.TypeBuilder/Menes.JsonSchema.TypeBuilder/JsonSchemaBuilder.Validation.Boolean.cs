// <copyright file="JsonSchemaBuilder.Validation.Boolean.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private void BuildFalseValidation(StringBuilder memberBuilder)
        {
            this.WriteError("core 4.3.2.Boolean JSON Schemas - false", memberBuilder);
        }

        private void BuildTrueValidation(StringBuilder memberBuilder)
        {
            this.WriteSuccess("core 4.3.2.Boolean JSON Schemas - true", memberBuilder);
        }
    }
}
