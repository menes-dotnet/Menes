// <copyright file="SchemaVisitor.ExclusiveMaximum.cs" company="Endjin Limited">
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
        /// <param name="exclusiveMaximumToUpdate">The exclusiveMaximum value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonNumber"/>.</returns>
        protected virtual Task<(bool, JsonNumber?)> VisitExclusiveMaximum(JsonNumber? exclusiveMaximumToUpdate)
        {
            return Task.FromResult<(bool, JsonNumber?)>((false, exclusiveMaximumToUpdate));
        }
    }
}
