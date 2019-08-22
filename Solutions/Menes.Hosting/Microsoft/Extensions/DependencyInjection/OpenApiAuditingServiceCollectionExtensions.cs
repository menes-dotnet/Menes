// <copyright file="OpenApiAuditingServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using Endjin.Auditing.Internal;
    using Menes.Auditing;
    using Menes.Auditing.Internal;

    /// <summary>
    /// Extensions for a <see cref="IServiceCollection"/>.
    /// </summary>
    public static class OpenApiAuditingServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services required to support OpenApi auditing.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddOpenApiAuditing(this IServiceCollection services)
        {
            services.AddSingleton<IAuditLogBuilder, OpenApiResultAuditLogBuilder>();
            services.AddSingleton<IAuditLogBuilder, PocoAuditLogBuilder>();
            return services;
        }

        /// <summary>
        /// Adds an audit sink for OpenApi auditing.
        /// </summary>
        /// <typeparam name="TSink">The type of sink to add.</typeparam>
        /// <param name="services">The service collection to add to.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddAuditLogSink<TSink>(this IServiceCollection services)
            where TSink : class, IAuditLogSink
        {
            services.AddSingleton<IAuditLogSink, TSink>();

            return services;
        }
    }
}
