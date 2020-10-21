// <copyright file="SchemaVisitor.Required.cs" company="Endjin Limited">
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
        /// <param name="requiredToUpdate">The required value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema.ValidatedArrayOfJsonString"/>.</returns>
        protected virtual ValueTask<(bool, JsonSchema.ValidatedArrayOfJsonString?)> VisitRequired(JsonSchema.ValidatedArrayOfJsonString? requiredToUpdate)
        {
            return new ValueTask<(bool, JsonSchema.ValidatedArrayOfJsonString?)>((false, requiredToUpdate));
        }
    }
}
