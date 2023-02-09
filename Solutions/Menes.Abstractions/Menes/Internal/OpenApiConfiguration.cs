// <copyright file="OpenApiConfiguration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    /// <summary>
    /// Standard implementation of <see cref="IOpenApiConfiguration"/>.
    /// </summary>
    public class OpenApiConfiguration : IOpenApiConfiguration
    {
        private Dictionary<string, Type>? discriminators;

        /// <summary>
        /// Initializes a new instance of the <see cref="IOpenApiConfiguration"/> class.
        /// </summary>
        public OpenApiConfiguration()
        {
            this.SerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        }

        /// <inheritdoc/>
        public JsonSerializerOptions SerializerOptions { get; set; }

        /// <inheritdoc/>
        public Dictionary<string, Type> DiscriminatedTypes
        {
            get => this.discriminators ??= new Dictionary<string, Type>();
            set => this.discriminators = value;
        }

        /// <inheritdoc/>
        public bool EnableNonExactParameterMatching { get; set; } = true;

        /// <inheritdoc/>
        public ResponseWhenUnauthenticated AccessPolicyUnauthenticatedResponse { get; set; } = ResponseWhenUnauthenticated.Unauthorized;
    }
}