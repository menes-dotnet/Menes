// <copyright file="OpenApiGeneratorServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Linq;
    using Menes.Internal;

    /// <summary>
    /// Extensions for a <see cref="IServiceCollection"/>.
    /// </summary>
    public static class OpenApiGeneratorServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services required to support OpenApi auditing.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <param name="configure">An action to allow you to add additional visitors to the factory.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddTypeVisitors(this IServiceCollection services, Action<TypeVisitorFactory>? configure = null)
        {
            if (!services.Any(s => s.ImplementationType == typeof(TypeVisitorFactory)))
            {
                services.AddSingleton(_ =>
                {
                    var result = TypeVisitorFactory.CreateDefaultInstance();
                    configure?.Invoke(result);
                    return result;
                });
            }

            return services;
        }
    }
}
