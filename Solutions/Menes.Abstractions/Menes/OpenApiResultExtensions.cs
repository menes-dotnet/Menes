// <copyright file="OpenApiResultExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
namespace Menes
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods for <see cref="OpenApiResult"/>.
    /// </summary>
    public static class OpenApiResultExtensions
    {
        /// <summary>
        /// Gets information to log.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <returns>Information to log.</returns>
        public static string GetLoggingInformation(this OpenApiResult openApiResult)
        {
            return $"OpenApi Result with status code {openApiResult.StatusCode} and parameters {string.Join(", ", openApiResult.Results.Select(m => m.Key))}";
        }

        /// <summary>
        /// Adds the given values to the audit data.
        /// </summary>
        /// <param name="openApiResult">The <see cref="OpenApiResult"/>.</param>
        /// <param name="values">The values to add.</param>
        public static void AddAuditData(this OpenApiResult openApiResult, params (string, object)[] values)
        {
            if (values?.Length > 0)
            {
                openApiResult.AuditData = openApiResult.AuditData ?? new Dictionary<string, object>();
                openApiResult.AuditData.AddRange(values.Select(x => new KeyValuePair<string, object>(x.Item1, x.Item2)));
            }
        }
    }
}
