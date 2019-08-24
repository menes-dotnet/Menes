// <copyright file="OpenApiConfiguration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Corvus.ContentHandling.Json;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Standard implementation of <see cref="IOpenApiConfiguration"/>.
    /// </summary>
    public class OpenApiConfiguration : IOpenApiConfiguration
    {
        private static JsonSerializerSettings jsonSerializerSettings;

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

            this.DefaultSerializerSettings = CreateJsonSerializerSettings(serviceProvider);
        }

        /// <inheritdoc/>
        public Formatting Formatting { get; set; }

        /// <inheritdoc/>
        public JsonSerializerSettings DefaultSerializerSettings { get; set; }

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

        private static JsonSerializerSettings CreateJsonSerializerSettings(IServiceProvider serviceProvider)
        {
            if (jsonSerializerSettings == null)
            {
                // Use the content provider if available
                IDefaultJsonSerializerSettings provider = serviceProvider.GetService<IDefaultJsonSerializerSettings>();
                if (provider != null)
                {
                    jsonSerializerSettings = provider.Instance;
                }
                else
                {
                    // Otherwise fall back on compatible defaults.
                    jsonSerializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = StandardContractResolver.Instance,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        ReferenceLoopHandling = ReferenceLoopHandling.Error,
                        NullValueHandling = NullValueHandling.Include,
                        ObjectCreationHandling = ObjectCreationHandling.Auto,
                        PreserveReferencesHandling = PreserveReferencesHandling.None,
                        ConstructorHandling = ConstructorHandling.Default,
                        TypeNameHandling = TypeNameHandling.None,
                        MetadataPropertyHandling = MetadataPropertyHandling.Default,
                        Formatting = Formatting.None,
                        DateFormatHandling = DateFormatHandling.IsoDateFormat,
                        DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                        DateParseHandling = DateParseHandling.DateTimeOffset,
                        FloatParseHandling = FloatParseHandling.Double,
                        FloatFormatHandling = FloatFormatHandling.String,
                        StringEscapeHandling = StringEscapeHandling.Default,
                        CheckAdditionalContent = false,
                        DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK",
                        Converters = new List<JsonConverter>(serviceProvider.GetServices<JsonConverter>()),
                        ReferenceResolverProvider = null,
                        Context = default,
                        Culture = CultureInfo.InvariantCulture,
                        MaxDepth = 4096,
                        DefaultValueHandling = DefaultValueHandling.Include,
                    };
                }
            }

            return jsonSerializerSettings;
        }

        private class StandardContractResolver : CamelCasePropertyNamesContractResolver
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StandardContractResolver"/> class.
            /// </summary>
            public StandardContractResolver()
            {
                this.NamingStrategy.ProcessDictionaryKeys = false;
            }

            /// <summary>
            /// Gets a standard endjin contract resolver.
            /// </summary>
            public static StandardContractResolver Instance { get; } = new StandardContractResolver();
        }
    }
}