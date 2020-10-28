// <copyright file="SchemaVisitor.Format.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.Schema
{
    using System.Threading.Tasks;

    /// <summary>
    /// A visitor for JsonSchema.
    /// </summary>
    public partial class SchemaVisitor
    {
        /// <summary>
        /// Visit a schema node.
        /// </summary>
        /// <param name="formatToUpdate">The format value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonString"/>.</returns>
        protected virtual Task<(bool, JsonString?)> VisitFormat(JsonString? formatToUpdate)
        {
            return Task.FromResult<(bool, JsonString?)>((false, formatToUpdate));
        }
    }
}
