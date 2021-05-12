// <copyright file="AspNetOperationEntityPartial.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApi.SchemaModel
{
    /// <summary>
    /// The backing class for the generated AspNetOperationEntity.
    /// </summary>
    public partial class AspNetOperationEntityPartial
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetOperationEntityPartial"/> class.
        /// </summary>
        /// <param name="operation">The operation instance for generation.</param>
        public AspNetOperationEntityPartial(Operation operation)
        {
            this.Operation = operation;
        }

        /// <summary>
        /// Gets the operation for this partial.
        /// </summary>
        public Operation Operation { get; }
    }
}
