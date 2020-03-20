// <copyright file="OpenApiGeneratorServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Linq;
    using Menes;
    using Menes.Internal;

    /// <summary>
    /// Extensions for a <see cref="IServiceCollection"/>.
    /// </summary>
    public static class OpenApiGeneratorServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services required to support the open api document visitors.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <param name="configureTypeVisitorFactory">An action to allow you to add additional visitors to the type visitor factory.</param>
        /// <param name="configureOperationVisitorFactory">An action to allow you to add additional visitors to the operation visitor factory.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddServiceGeneratorVisitors(this IServiceCollection services, Action<TypeVisitorFactory>? configureTypeVisitorFactory = null, Action<OperationVisitorFactory>? configureOperationVisitorFactory = null)
        {
            if (!services.Any(s => s.ImplementationType == typeof(TypeVisitorFactory)))
            {
                services.AddSingleton(_ =>
                {
                    var result = TypeVisitorFactory.CreateDefaultInstance();
                    configureTypeVisitorFactory?.Invoke(result);
                    return result;
                });
            }

            if (!services.Any(s => s.ImplementationType == typeof(OperationVisitorFactory)))
            {
                services.AddSingleton(s =>
                {
                    var result = new OperationVisitorFactory(s.GetRequiredService<TypeVisitorFactory>());
                    configureOperationVisitorFactory?.Invoke(result);
                    return result;
                });
            }

            if (!services.Any(s => s.ImplementationType == typeof(ServiceBuilder)))
            {
                services.AddSingleton<ServiceBuilder>();
            }

            return services;
        }
    }
}
