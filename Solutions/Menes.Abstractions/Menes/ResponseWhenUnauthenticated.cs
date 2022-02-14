// <copyright file="ResponseWhenUnauthenticated.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    /// <summary>
    /// The response to generate when an access control policy reports that access is not allowed
    /// due to the client being unauthenticated.
    /// </summary>
    public enum ResponseWhenUnauthenticated
    {
        /// <summary>
        /// Produce a 401 Unauthorized response.
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        /// Produce a 403 Forbidden response.
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// Produce a 500 Server Error response.
        /// </summary>
        ServerError = 500,
    }
}