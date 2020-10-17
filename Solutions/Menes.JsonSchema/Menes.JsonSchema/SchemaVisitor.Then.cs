// <copyright file="SchemaVisitor.Then.cs" company="Endjin Limited">
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
        /// <param name="thenToUpdate">The then value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="Schema.SchemaOrReference"/>.</returns>
        protected virtual ValueTask<(bool, Schema.SchemaOrReference?)> VisitThen(Schema.SchemaOrReference? thenToUpdate)
        {
            return this.VisitSchemaOrReference(thenToUpdate);
        }
    }
}
