// <copyright file="OpenApiProblemDetailsExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;

    /// <summary>
    /// Extension methods that decorate an exception with the content required for the standard ProblemDetails RFC7807.
    /// </summary>
    public static class OpenApiProblemDetailsExtensions
    {
        /// <summary>
        /// Adds a URI reference [RFC3986] that identifies the problem type. This specification encourages that, when
        /// dereferenced, it provide human-readable documentation for the problem type
        /// (e.g., using HTML [W3C.REC-html5-20141028]).  When this member is not present, its value is assumed to be
        /// "about:blank".
        /// </summary>
        /// <param name="ex">The exception to which to add the problem details type.</param>
        /// <param name="type">The problem details type.</param>
        /// <returns>The decorated exception.</returns>
        public static Exception AddProblemDetailsType(this Exception ex, string type)
        {
            ex.Data.Add("type", type ?? "about:blank");

            return ex;
        }

        /// <summary>
        /// Sets a short, human-readable summary of the problem type. It SHOULD NOT change from occurrence to occurrence
        /// of the problem, except for purposes of localization (e.g., using proactive content negotiation;
        /// see [RFC7231], Section 3.4).
        /// </summary>
        /// <param name="ex">The exception to which to add the problem details type.</param>
        /// <param name="title">The problem details title.</param>
        /// <returns>The decorated exception.</returns>
        public static Exception AddProblemDetailsTitle(this Exception ex, string title)
        {
            ex.Data.Add("title", title);

            return ex;
        }

        /// <summary>
        /// Sets a human-readable explanation specific to this occurrence of the problem.
        /// </summary>
        /// <param name="ex">The exception to which to add the problem details type.</param>
        /// <param name="detail">The problem details explanation.</param>
        /// <returns>The decorated exception.</returns>
        public static Exception AddProblemDetailsExplanation(this Exception ex, string detail)
        {
            ex.Data.Add("detail", detail);

            return ex;
        }

        /// <summary>
        /// Sets a URI reference that identifies the specific occurrence of the problem.It may or may not yield further information if dereferenced.
        /// </summary>
        /// <param name="ex">The exception to which to add the problem details type.</param>
        /// <param name="instance">The problem details instance URI.</param>
        /// <returns>The decorated exception.</returns>
        public static Exception AddProblemDetailsInstance(this Exception ex, string instance)
        {
            ex.Data.Add("instance", instance);

            return ex;
        }

        /// <summary>
        /// Sets an extension value for the problem details.
        /// </summary>
        /// <param name="ex">The exception to which to add the problem details type.</param>
        /// <param name="extensionName">The name of the problem details extension.</param>
        /// <param name="value">The value of the problem details extension which will be serialized to JSON in the result.</param>
        /// <returns>The decorated exception.</returns>
        public static Exception AddProblemDetailsExtension(this Exception ex, string extensionName, object value)
        {
            ex.Data.Add(extensionName, value);

            return ex;
        }
    }
}