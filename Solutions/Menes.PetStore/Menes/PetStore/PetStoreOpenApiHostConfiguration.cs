// <copyright file="PetStoreOpenApiHostConfiguration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.PetStore
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Common API host configuration.
    /// </summary>
    public static class PetStoreOpenApiHostConfiguration
    {
        /// <summary>
        /// Callback that can be passed to DI registration methods that provide a
        /// <see cref="IOpenApiHostConfiguration"/>-based callback.
        /// </summary>
        /// <param name="hostConfig">The open API host configuration object.</param>
        public static void LoadDocuments(IOpenApiHostConfiguration hostConfig)
        {
            hostConfig.Documents.RegisterOpenApiServiceWithEmbeddedDefinition(
                typeof(PetStoreService).Assembly,
                "Menes.PetStore.PetStore.yaml");

            hostConfig.Documents.AddSwaggerEndpoint();
        }
    }
}