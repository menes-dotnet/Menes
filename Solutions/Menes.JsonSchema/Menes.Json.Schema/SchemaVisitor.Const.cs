// <copyright file="SchemaVisitor.Const.cs" company="Endjin Limited">
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
        /// <param name="constToUpdate">The const value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonAny"/>.</returns>
        protected virtual Task<(bool, JsonAny?)> VisitConst(JsonAny? constToUpdate)
        {
            return Task.FromResult<(bool, JsonAny?)>((false, constToUpdate));
        }
    }
}
