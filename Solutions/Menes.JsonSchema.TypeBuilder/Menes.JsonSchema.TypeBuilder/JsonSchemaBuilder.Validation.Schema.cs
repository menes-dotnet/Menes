// <copyright file="JsonSchemaBuilder.Validation.Schema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Menes.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        private Task BuildSchemaValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            bool pushedKeyword = false;

            try
            {
                if (typeDeclaration.TypeSchema.JsonElement.TryGetProperty("$schema", out JsonElement dollarschema))
                {
                    ValidateDollarSchema(dollarschema);
                }

                if (typeDeclaration.TypeSchema.JsonElement.TryGetProperty("$id", out JsonElement dollarid))
                {
                    ValidateDollarId(dollarid);

                    string dollaridValue = dollarid.GetString();
                    this.absoluteKeywordLocationStack.Push(JsonReference.FromEncodedJsonString(dollaridValue).Value);
                    pushedKeyword = true;
                    this.ids.Add(dollaridValue, typeDeclaration.TypeSchema);
                }
            }
            finally
            {
                if (pushedKeyword)
                {
                    this.absoluteKeywordLocationStack.Pop();
                }
            }

            return Task.CompletedTask;
        }
    }
}
