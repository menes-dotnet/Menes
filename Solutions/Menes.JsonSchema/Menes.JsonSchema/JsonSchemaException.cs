// <copyright file="JsonSchemaException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema
{
    using System;

    /// <summary>
    /// An exception thrown when an operation on a JSON schema fails.
    /// </summary>
    public class JsonSchemaException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public JsonSchemaException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSchemaException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The original exception that caused this exception.</param>
        public JsonSchemaException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
