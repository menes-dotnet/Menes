// <copyright file="IOpenApiExternalServices.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;

    /// <summary>
    /// Provides the ability to resolve URLs to external services.
    /// </summary>
    public interface IOpenApiExternalServices
    {
        /// <summary>
        /// Enables URLs to be resolved for a service that embeds its Open API service definition
        /// as a resource, using the <see cref="EmbeddedOpenApiDefinitionAttribute"/>.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <param name="baseUrlConfigurationKey">
        /// The configuration key under which this service's base URL is stored.
        /// </param>
        /// <remarks>
        /// <para>
        /// External URLs need to be absolute. Since this requires a hostname, and hostnames are
        /// specific to deployments, we need to be able to determine the hostname from
        /// configuration.
        /// </para>
        /// </remarks>
        void AddExternalServiceWithEmbeddedDefinition<TService>(string baseUrlConfigurationKey)
            where TService : IOpenApiService;

        /// <summary>
        /// Resolves a URL for the specified service type.
        /// </summary>
        /// <typeparam name="TService">The service type.</typeparam>
        /// <param name="operationId">The Open API operation for which a URL is required.</param>
        /// <param name="parameters">The parameters required to expand the URL template.</param>
        /// <returns>The URL.</returns>
        Uri ResolveUrl<TService>(
            string operationId,
            params (string Name, object? Value)[] parameters);
    }
}
