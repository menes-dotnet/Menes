// <copyright file="SchemaVisitor.UniqueItems.cs" company="Endjin Limited">
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
        /// <param name="uniqueItemsToUpdate">The uniqueItems value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonBoolean"/>.</returns>
        protected virtual Task<(bool, JsonBoolean?)> VisitUniqueItems(JsonBoolean? uniqueItemsToUpdate)
        {
            return Task.FromResult<(bool, JsonBoolean?)>((false, uniqueItemsToUpdate));
        }
    }
}
