// <copyright file="IOpenApiConfiguration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Configuration for an OpenAPI server.
    /// </summary>
    /// <remarks>
    /// <para>
    /// You can customize the configuration for an Open API request host using this type. You can obtain it from the container and alter the values
    /// at runtime, but most hosts will provide a configuration mechanism as part of their container bootstrapping process.
    /// </para>
    /// </remarks>
    public interface IOpenApiConfiguration
    {
        /// <summary>
        /// Gets or sets a value defining the behaviour when access control policy blocks an operation
        /// as a result of the client being unauthenticated.
        /// </summary>
        /// <remarks>
        /// The default behaviour is to produce a 401 Unauthorized, because this signals to the client that
        /// authentication is required. However, if your service is running in an environment in which you
        /// should never receive unauthenticated requests (e.g., because you have configured Azure
        /// EasyAuth always to require authentication) it would be more appropriate to set this to
        /// <see cref="ResponseWhenUnauthenticated.ServerError"/>, because the arrival of an
        /// unauthenticated request could only occur as a result of misconfiguration.
        /// </remarks>
        ResponseWhenUnauthenticated AccessPolicyUnauthenticatedResponse { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="JsonSerializerSettings"/>.
        /// </summary>
        JsonSerializerSettings DefaultSerializerSettings { get; set; }

        /// <summary>
        /// Gets or sets the discriminator to type mappings. These allow you to define descriminator values
        /// to type mappings for use in serialization.
        /// </summary>
        Dictionary<string, Type> DiscriminatedTypes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether parameter matching can ignore case and certain
        /// characters.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This enables matching of header values such as X-Tenant to a parameter named xtenant,
        /// or xTenant. (Alternatively, you can switch this off and use
        /// <see cref="OpenApiParameterAttribute"/> if you want to use precise matching even with
        /// OpenApi parameters whose names are not legal as C# identifiers.)
        /// </para>
        /// </remarks>
        bool EnableNonExactParameterMatching { get; set; }

        /// <summary>
        /// Gets or sets the JSON <see cref="Formatting"/>.
        /// </summary>
        Formatting Formatting { get; set; }
    }
}