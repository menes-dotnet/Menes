// <copyright file="OpenApiExceptionServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using Menes.ExceptionMappers;

    /// <summary>
    /// An installer for OpenApi exception mappers.
    /// </summary>
    public static class OpenApiExceptionServiceCollectionExtensions
    {
        /// <summary>
        /// Add openAPI exception mappers to the service collection.
        /// </summary>
        /// <param name="services">The service collection to which to add the mappers.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddOpenApiExceptionMappers(this IServiceCollection services)
        {
            services.AddSingleton<IExceptionMapper, ProblemDetailsExceptionMapper>();
            services.AddSingleton<IExceptionMapper, DefaultExceptionMapper>();

            return services;
        }
    }
}