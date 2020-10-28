// <copyright file="SchemaVisitor.Type.cs" company="Endjin Limited">
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
        /// <param name="typeToUpdate">The type value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema.TypeEnum"/>.</returns>
        protected virtual Task<(bool, JsonSchema.TypeEnum?)> VisitType(JsonSchema.TypeEnum? typeToUpdate)
        {
            return Task.FromResult<(bool, JsonSchema.TypeEnum?)>((false, typeToUpdate));
        }
    }
}
