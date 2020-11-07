// <copyright file="JsonSchemaBuilder.Validation.Schema.cs" company="Endjin Limited">
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
        private Task BuildSchemaValidation(in LocatedElement namedElement, StringBuilder memberBuilder)
        {
            bool pushedKeyword = false;

            try
            {
                if (namedElement.JsonElement.TryGetProperty("$schema", out JsonElement dollarschema))
                {
                    ValidateDollarSchema(dollarschema);
                }

                if (namedElement.JsonElement.TryGetProperty("$id", out JsonElement dollarid))
                {
                    ValidateDollarId(dollarid);

                    string dollaridValue = dollarid.GetString();
                    this.absoluteKeywordLocationStack.Push(dollaridValue);
                    pushedKeyword = true;
                    this.ids.Add(dollaridValue, namedElement);
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
