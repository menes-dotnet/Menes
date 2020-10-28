// <copyright file="SchemaVisitor.MultipleOf.cs" company="Endjin Limited">
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
        /// <param name="multipleOfToUpdate">The multipleOf value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema.PositiveNumber"/>.</returns>
        protected virtual Task<(bool, JsonSchema.PositiveNumber?)> VisitMultipleOf(JsonSchema.PositiveNumber? multipleOfToUpdate)
        {
            return Task.FromResult<(bool, JsonSchema.PositiveNumber?)>((false, multipleOfToUpdate));
        }
    }
}
