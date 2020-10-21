﻿// <copyright file="SchemaVisitor.Properties.cs" company="Endjin Limited">
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
        /// <param name="propertiesToUpdate">The properties value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema.SchemaOrReference"/>.</returns>
        protected virtual ValueTask<(bool, JsonSchema.SchemaProperties?)> VisitProperties(JsonSchema.SchemaProperties? propertiesToUpdate)
        {
            return this.VisitSchemaProperties(propertiesToUpdate);
        }
    }
}