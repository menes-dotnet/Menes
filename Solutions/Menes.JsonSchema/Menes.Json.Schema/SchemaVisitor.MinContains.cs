// <copyright file="SchemaVisitor.MinContains.cs" company="Endjin Limited">
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
        /// <param name="minContainsToUpdate">The minContains value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema.NonNegativeInteger"/>.</returns>
        protected virtual ValueTask<(bool, JsonSchema.NonNegativeInteger?)> VisitMinContains(JsonSchema.NonNegativeInteger? minContainsToUpdate)
        {
            return new ValueTask<(bool, JsonSchema.NonNegativeInteger?)>((false, minContainsToUpdate));
        }
    }
}
