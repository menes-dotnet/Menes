// <copyright file="OpenApiExternalServices.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;

    /// <summary>
    /// Provides the ability to resolve URLs to external services.
    /// </summary>
    public class OpenApiExternalServices : IOpenApiExternalServices
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<OpenApiDocumentProvider> uriTemplateProviderLogger;

        private readonly Dictionary<Type, (OpenApiDocumentProvider Provider, string ConfigKey)> uriTemplateProviders
            = new Dictionary<Type, (OpenApiDocumentProvider Provider, string ConfigKey)>();

        /// <summary>
        /// Create a <see cref="OpenApiExternalServices"/>.
        /// </summary>
        /// <param name="configuration">
        /// Provides configuration settings used to determine the base URLs for external services.
        /// </param>
        /// <param name="uriTemplateProviderLogger">Logger for template provider instances.</param>
        public OpenApiExternalServices(
            IConfiguration configuration,
            ILogger<OpenApiDocumentProvider> uriTemplateProviderLogger)
        {
            this.configuration = configuration;
            this.uriTemplateProviderLogger = uriTemplateProviderLogger;
        }

        /// <inheritdoc />
        public void AddExternalServiceWithEmbeddedDefinition<TService>(string baseUrlConfigurationKey)
            where TService : IOpenApiService
        {
            // We cannot resolve the IOperationUriTemplateProvider from DI because it is a
            // singleton, and any service definitions we add to it will then be visible to the
            // service host, which will think it's responsible for serving them up. That would be
            // unhelpful, because by definition any services we deal with here are hosted
            // elsewhere.
            // We create a distinct template provider for each service to remove any need for
            // operation ids to be globally unique across all external services.
            var provider = new OpenApiDocumentProvider(this.uriTemplateProviderLogger);
            OpenApiDocument serviceDefinition = OpenApiServiceDefinitions.GetOpenApiServiceFromEmbeddedDefinition<TService>();
            provider.Add(serviceDefinition);

            this.uriTemplateProviders.Add(typeof(TService), (provider, baseUrlConfigurationKey));
        }

        /// <inheritdoc />
        public Uri ResolveUrl<TService>(string operationId, params (string Name, object Value)[] parameters)
        {
            Type serviceType = typeof(TService);
            if (!this.uriTemplateProviders.TryGetValue(serviceType, out (OpenApiDocumentProvider Provider, string ConfigKey) providerAndKey))
            {
                throw new ArgumentException($"Service of type '{serviceType.FullName}' registered");
            }

            ResolvedOperationRequestInfo relativeUrl = providerAndKey.Provider.GetResolvedOperationRequestInfo(operationId, parameters);

            string baseUrl = this.configuration[providerAndKey.ConfigKey];
            return new Uri(new Uri(baseUrl), relativeUrl.Uri);
        }
    }
}
