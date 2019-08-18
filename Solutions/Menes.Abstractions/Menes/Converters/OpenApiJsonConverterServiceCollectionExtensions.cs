// <copyright file="OpenApiJsonConverterServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using Menes.Converters;
    using Menes.Validation;

    /// <summary>
    /// An installer for OpenApi Converters.
    /// </summary>
    public static class OpenApiJsonConverterServiceCollectionExtensions
    {
        /// <summary>
        /// Add openAPI converters to the service collection.
        /// </summary>
        /// <param name="services">The service collection to which to add the converters.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddOpenApiJsonConverters(this IServiceCollection services)
        {
            services.AddSingleton<OpenApiSchemaValidator>();
            services.AddSingleton<IOpenApiConverter, BooleanConverter>();
            services.AddSingleton<IOpenApiConverter, ByteArrayConverter>();
            services.AddSingleton<IOpenApiConverter, DateConverter>();
            services.AddSingleton<IOpenApiConverter, DoubleConverter>();
            services.AddSingleton<IOpenApiConverter, FloatConverter>();
            services.AddSingleton<IOpenApiConverter, Integer32Converter>();
            services.AddSingleton<IOpenApiConverter, Integer64Converter>();
            services.AddSingleton<IOpenApiConverter, ObjectConverter>();
            services.AddSingleton<IOpenApiConverter, PasswordConverter>();
            services.AddSingleton<IOpenApiConverter, StringConverter>();
            services.AddSingleton<IOpenApiConverter, UriConverter>();
            services.AddSingleton<IOpenApiConverter, UuidConverter>();

            return services;
        }
    }
}