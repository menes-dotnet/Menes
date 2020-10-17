// <copyright file="SchemaVisitor.ExclusiveMaximum.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
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
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonInteger"/>.</returns>
        protected virtual ValueTask<(bool, JsonNumber?)> VisitExclusiveMaximum(JsonNumber? exclusiveMaximumToUpdate)
        {
            return new ValueTask<(bool, JsonNumber?)>((false, exclusiveMaximumToUpdate));
        }
    }
}
