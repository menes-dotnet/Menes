﻿// <copyright file="SchemaVisitor.Items.cs" company="Endjin Limited">
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
        /// <param name="itemsToUpdate">The items value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonAny"/>.</returns>
        protected virtual ValueTask<(bool, JsonSchema.SchemaOrReference?)> VisitItems(JsonSchema.SchemaOrReference? itemsToUpdate)
        {
            return this.VisitSchemaOrReference(itemsToUpdate);
        }
    }
}