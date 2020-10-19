﻿// <copyright file="SchemaVisitor.Type.cs" company="Endjin Limited">
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
        /// <param name="typeToUpdate">The type value to visit.</param>
        /// <returns>A tuple of <c>True</c> if the schema was updated, and the updated <see cref="Schema.TypeEnum"/>.</returns>
        protected virtual ValueTask<(bool, Schema.TypeEnum?)> VisitType(Schema.TypeEnum? typeToUpdate)
        {
            return new ValueTask<(bool, Schema.TypeEnum?)>((false, typeToUpdate));
        }
    }
}