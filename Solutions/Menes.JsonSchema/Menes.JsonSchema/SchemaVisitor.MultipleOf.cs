// <copyright file="SchemaVisitor.MultipleOf.cs" company="Endjin Limited">
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
        /// <param name="multipleOfToUpdate">The multipleOf value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="Schema.PositiveNumber"/>.</returns>
        protected virtual ValueTask<(bool, Schema.PositiveNumber?)> VisitMultipleOf(Schema.PositiveNumber? multipleOfToUpdate)
        {
            return new ValueTask<(bool, Schema.PositiveNumber?)>((false, multipleOfToUpdate));
        }
    }
}
