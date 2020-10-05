// <copyright file="ReferenceOf.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// A boxing reference to a value.
    /// </summary>
    /// <typeparam name="TValue">The value.</typeparam>
    /// <remarks>
    /// This is used when a value is set on a complex JSON object, to avoid a recursive reference. It boxes the instance.
    /// </remarks>
    public class ReferenceOf<TValue>
        where TValue : struct, IJsonValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceOf{TValue}"/> class.
        /// </summary>
        /// <param name="value">The value from which to construct the reference.</param>
        public ReferenceOf(TValue value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public TValue Value { get; }
    }
}
