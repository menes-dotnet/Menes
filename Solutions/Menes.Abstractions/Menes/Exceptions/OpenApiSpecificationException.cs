// <copyright file="OpenApiSpecificationException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Exceptions
{
    using System;

    /// <summary>
    /// An exception indicating that an OpenApi specification is misconfigured in some way, and therefore invalid.
    /// </summary>
    public class OpenApiSpecificationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiSpecificationException"/> class.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        public OpenApiSpecificationException(string message)
            : base(message)
        {
        }
    }
}
