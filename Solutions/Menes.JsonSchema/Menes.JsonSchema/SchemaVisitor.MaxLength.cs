// <copyright file="SchemaVisitor.MaxLength.cs" company="Endjin Limited">
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
        /// <param name="maxLengthToUpdate">The maxLength value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="Schema.NonNegativeInteger"/>.</returns>
        protected virtual ValueTask<(bool, Schema.NonNegativeInteger?)> VisitMaxLength(Schema.NonNegativeInteger? maxLengthToUpdate)
        {
            return new ValueTask<(bool, Schema.NonNegativeInteger?)>((false, maxLengthToUpdate));
        }
    }
}
