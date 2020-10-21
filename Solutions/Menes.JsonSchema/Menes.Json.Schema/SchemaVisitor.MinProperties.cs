// <copyright file="SchemaVisitor.MinProperties.cs" company="Endjin Limited">
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
        /// <param name="minPropertiesToUpdate">The minProperties value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="JsonSchema.NonNegativeInteger"/>.</returns>
        protected virtual ValueTask<(bool, JsonSchema.NonNegativeInteger?)> VisitMinProperties(JsonSchema.NonNegativeInteger? minPropertiesToUpdate)
        {
            return new ValueTask<(bool, JsonSchema.NonNegativeInteger?)>((false, minPropertiesToUpdate));
        }
    }
}
