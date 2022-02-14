// <copyright file="OpenApiServiceMismatchException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Exceptions
{
    using System;

    /// <summary>
    /// An exception indicating that an OpenApi service is misconfigured in some way, or that the
    /// service implementation is producing results that do not match the service definition.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This exception takes a fairly broad view of 'misconfiguration'. For example, if a service
    /// tries to produce, say, a 400 status code, but there's no corresponding response definition
    /// in YAML the YAML, we interpret that as misconfiguration. (It might equally be a coding
    /// error - perhaps the code just specified the wrong status code. So this really indicates
    /// that we've encountered a situation in which the service's runtime behaviour is inconsistent
    /// with the configuration.)
    /// </para>
    /// <para>
    /// Misconfiguration issues may not be immediately apparent. For example, if a service method
    /// returns an <see cref="OpenApiResult"/> with an HTTP status code for which the YAML defines
    /// no corresponding response and no default response in general it's not possible to determine
    /// through static analysis all of the ways that this could happen. So this exception is
    /// typically thrown when we hit a situation at runtime that indicates a configuration problem,
    /// rather than being thrown on startup.
    /// </para>
    /// </remarks>
    public class OpenApiServiceMismatchException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiServiceMismatchException"/> class.
        /// </summary>
        /// <param name="message">A description of the error.</param>
        public OpenApiServiceMismatchException(string message)
            : base(message)
        {
        }
    }
}