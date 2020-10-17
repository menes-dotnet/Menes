// <copyright file="SchemaVisitor.Required.cs" company="Endjin Limited">
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
        /// <param name="requiredToUpdate">The required value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="Schema.ValidatedArrayOfJsonString"/>.</returns>
        protected virtual ValueTask<(bool, Schema.ValidatedArrayOfJsonString?)> VisitRequired(Schema.ValidatedArrayOfJsonString? requiredToUpdate)
        {
            return new ValueTask<(bool, Schema.ValidatedArrayOfJsonString?)>((false, requiredToUpdate));
        }
    }
}
