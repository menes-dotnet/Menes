// <copyright file="SchemaVisitor.MaxLength.cs" company="Endjin Limited">
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
        /// <param name="maxLengthToUpdate">The maxLength value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema.NonNegativeInteger"/>.</returns>
        protected virtual Task<(bool, JsonSchema.NonNegativeInteger?)> VisitMaxLength(JsonSchema.NonNegativeInteger? maxLengthToUpdate)
        {
            return Task.FromResult<(bool, JsonSchema.NonNegativeInteger?)>((false, maxLengthToUpdate));
        }
    }
}
