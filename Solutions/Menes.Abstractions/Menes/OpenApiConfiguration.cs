// <copyright file="OpenApiConfiguration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Configuration for an OpenAPI server.
    /// </summary>
    /// <remarks>
    /// <para>
    /// You can customize the configuration for an Open API request host using this type. You can obtain it from the container and alter the values
    /// at runtime, but most hosts will provide a configuration mechanism as part of their container bootstrapping process.
    /// </para>
    /// </remarks>
    public class OpenApiConfiguration
    {
        private static JsonSerializerSettings jsonSerializerSettings;

        private Dictionary<string, Type> discriminators;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenApiConfiguration"/> class.
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

        /// <summary>
        /// Gets or sets the JSON <see cref="Formatting"/>.
        /// </summary>
        public Formatting Formatting { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="JsonSerializerSettings"/>.
        /// </summary>
        public JsonSerializerSettings DefaultSerializerSettings { get; set; }

        /// <summary>
        /// Gets or sets the discriminator to type mappings. These allow you to define descriminator values
        /// to type mappings for use in serialization.
        /// </summary>
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
        public bool EnableNonExactParameterMatching { get; set; } = true;

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
        public ResponseWhenUnauthenticated AccessPolicyUnauthenticatedResponse { get; set; } = ResponseWhenUnauthenticated.Unauthorized;

        private static JsonSerializerSettings CreateJsonSerializerSettings(IServiceProvider serviceProvider)
        {
            if (jsonSerializerSettings == null)
            {
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