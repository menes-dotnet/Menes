// <copyright file="OpenApiResponsesExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.OpenApi.Models;

    /// <summary>
    /// The open api responses extensions.
    /// </summary>
    public static class OpenApiResponsesExtensions
    {
        /// <summary>
        /// Tries to find a suitable response for a given status code.
        /// </summary>
        /// <param name="responses">
        /// The list of responses.
        /// </param>
        /// <param name="statusCode">
        /// The status code. If null, the method will look for a default response.
        /// </param>
        /// <param name="response">
        /// The response.
        /// </param>
        /// <returns>
        /// True if a match was found, false if not.
        /// </returns>
        public static bool TryGetResponseForStatusCode(this OpenApiResponses responses, int? statusCode, [NotNullWhen(true)] out OpenApiResponse? response)
        {
            if (statusCode.HasValue)
            {
                if (responses.TryGetValue(statusCode.ToString(), out response))
                {
                    return true;
                }
            }

            return responses.TryGetValue("default", out response);
        }
    }
}