// <copyright file="OpenApiUnauthorizedException.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Exceptions
{
    using System;

    /// <summary>
    /// An exception which, when thrown from an <see cref="IOpenApiService"/> operation method,
    /// indicates that an HTTP 401 Unauthorized response should be returned.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This indicates that authorization information of the required form is either missing (e.g.,
    /// an Authorization header is required, and not present, or a client certificate for TLS is
    /// required and not present), or is invalid (e.g., the Authorization header is present but
    /// is of the wrong kind - perhaps a Bearer is expected, but basic auth has been used;
    /// maybe the right kind of header is present, but it is malformed in some way; or a JWT of the
    /// expected form has been supplied but is not from a trusted issuer; or a JWT has been
    /// supplied that would have been entirely acceptable, except it has expired).
    /// </para>
    /// <para>
    /// In all cases, the implication of this exception is that the service does not have enough
    /// information to be confident of the identity of the client. So this is not a case of "you
    /// are not allowed to do that". (That's what <see cref="OpenApiForbiddenException"/> is for.)
    /// This is a case of "we don't know whether you're allowed to do that because we don't know
    /// who you are" meaning that the client needs to provide suitable credentials.
    /// </para>
    /// <para>
    /// In cases where the hosting infrastructure is performing authentication (e.g., an Azure
    /// Function or Web App is using Azure Easy Auth) it will be unusual to throw this, because
    /// the checks that lead to a 401 will be performed by that infrastructure. It is only if there
    /// are further application-specific checks that need to be performed to establish whether
    /// credentials have been supplied in an acceptable form that this will be thrown. Since the
    /// hosting environment typically filters out malformed credentials, applications will more
    /// normally want to use policy-based responses such as a 403 Forbidden, for which they should
    /// throw an <see cref="OpenApiForbiddenException"/>.
    /// </para>
    /// </remarks>
    public class OpenApiUnauthorizedException : Exception
    {
        /// <summary>Creates an <see cref="OpenApiUnauthorizedException"/> with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <remarks>
        /// <para>
        /// This exception does not use the <see cref="OpenApiProblemDetailsExtensions"/> extension
        /// methods to populate the exception data with problem details, because explaining to
        /// attackers exactly why you didn't like their token makes their lives easier. We take
        /// a description of what is wrong with the credentials to enable problems to be logged,
        /// and it may be appropriate for these messages to be visible to an administrator or to
        /// support personnel, but it should not be included in the response to the client.
        /// </para>
        /// </remarks>
        public OpenApiUnauthorizedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Standard constructor for any derived exceptions.
        /// </summary>
        protected OpenApiUnauthorizedException()
        {
        }

        /// <summary>
        /// Standard constructor for any derived exceptions.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        protected OpenApiUnauthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}