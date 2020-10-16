// <copyright file="SchemaParser.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System.Text.Json;
    using System.Threading.Tasks;

    /// <summary>
    /// Parse json schema.
    /// </summary>
    public static class SchemaParser
    {
        /// <summary>
        /// Loads schema via a <see cref="JsonRef"/>.
        /// </summary>
        /// <param name="reference">The json reference at which to load the schema.</param>
        /// <param name="resolver">The <see cref="IDocumentResolver"/> to load the document in the reference.</param>
        /// <returns>A <see cref="ValueTask{TResult}"/> which produces the <see cref="Schema"/>.</returns>
        public static async ValueTask<(JsonDocument, Schema)> LoadSchema(JsonRef reference, IDocumentResolver resolver)
        {
            (JsonDocument document, Schema.SchemaOrReference schema) = await reference.Resolve(resolver).ConfigureAwait(false);
            return (document, schema.AsSchema());
        }
    }
}
