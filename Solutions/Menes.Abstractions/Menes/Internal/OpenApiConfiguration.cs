// <copyright file="OpenApiConfiguration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using Corvus.Extensions.Json;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;

    /// <summary>
    /// Standard implementation of <see cref="IOpenApiConfiguration"/>.
    /// </summary>
    public class OpenApiConfiguration : IOpenApiConfiguration
    {
        private Dictionary<string, Type> discriminators;

        /// <summary>
        /// Initializes a new instance of the <see cref="IOpenApiConfiguration"/> class.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> for the current context.</param>
        public OpenApiConfiguration(IServiceProvider serviceProvider)
        {
            if (serviceProvider is null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            this.SerializerSettings = serviceProvider.GetService<IJsonSerializerSettingsProvider>()?.Instance ?? JsonConvert.DefaultSettings?.Invoke();
        }

        /// <inheritdoc/>
        public Formatting Formatting { get; set; }

        /// <inheritdoc/>
        public JsonSerializerSettings SerializerSettings { get; set; }

        /// <inheritdoc/>
        public Dictionary<string, Type> DiscriminatedTypes
        {
            get
            {
                return this.discriminators ?? (this.discriminators = new Dictionary<string, Type>());
            }

            set
            {
                this.discriminators = value;
            }
        }

        /// <inheritdoc/>
        public bool EnableNonExactParameterMatching { get; set; } = true;

        /// <inheritdoc/>
        public ResponseWhenUnauthenticated AccessPolicyUnauthenticatedResponse { get; set; } = ResponseWhenUnauthenticated.Unauthorized;
    }
}