// <copyright file="OpenApiHostingServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Linq;
    using Menes;
    using Menes.Auditing;
    using Menes.Auditing.AuditLogSinks.Development;
    using Menes.Exceptions;
    using Menes.Hal;
    using Menes.Hal.Internal;
    using Menes.Internal;
    using Menes.Links;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// Extensions for a <see cref="IServiceCollection"/>.
    /// </summary>
    public static class OpenApiHostingServiceCollectionExtensions
    {
        /// <summary>
        /// Configure Open API hosting using an <see cref="IOpenApiHost"/>.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="services">The services collection to configure.</param>
        /// <param name="configureHost">A function used to configure the host.</param>
        /// <param name="configureEnvironment">A function used to optionally configure the hosting environment.</param>
        /// <returns>The configured <see cref="IServiceCollection"/>.</returns>
        /// <remarks>
        /// <para>
        /// See <see cref="IOpenApiService"/> for details on using the Open API hosting environment.
        /// </para>
        /// <para>
        /// To host in functions, you should provide a function entry point with a catch-all for your base URI, and any operation types you need to support (GET, POST etc.)
        /// </para>
        /// <para>
        /// <code>
        /// [FunctionName("openapihostroot")]
        /// public static Task&lt;IActionResult&gt; RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "{*path}")]HttpRequest req, ExecutionContext context, ILogger log)
        /// {
        ///     Initialize(context);
        ///
        ///     var host = ServiceRoot.ServiceProvider.GetRequiredService&lt;OpenApiHttpRequestHost&gt;();
        ///     return host.HandleRequest(req);
        /// }
        /// </code>
        /// </para>
        /// <para>
        /// Initialization is handled using this method, during Functions container initialization.
        /// </para>
        /// <para>
        /// <code>
        /// private static void Initialize(ExecutionContext context)
        /// {
        ///     Functions.InitializeContainer(context, services =&gt;
        ///     {
        ///         services.AddOpenApiHttpHosting(host =&gt;
        ///         {
        ///             using (var stream = File.OpenRead(".\\yaml\\petstore.yaml"))
        ///             {
        ///                 var openApiDocument = new OpenApiStreamReader().Read(stream, out var diagnostics);
        ///                 host.AddDocument(openApiDocument);
        ///             }
        ///         });
        ///
        ///         // We can add all the services here
        ///         services.AddSingleton&lt;IOpenApiService, PetStoreService&gt;();
        ///     });
        /// }
        /// </code>
        /// </para>
        /// <para>
        /// You can add as many <see cref="IOpenApiService"/> instances to the container as you have, but the framework will
        /// <i>only</i> expose those that are bound to Open API documents that you have added to the host. While you typically
        /// add documents on startup, you can add more at runtime to light up services that are registered in the container, but not
        /// actually bound to Open API documents.
        /// </para>
        /// <para>
        /// See <see cref="IOpenApiService"/> for more details on configuring the host using this mechanism.
        /// </para>
        /// </remarks>
        public static IServiceCollection AddOpenApiHosting<TRequest, TResponse>(this IServiceCollection services, Action<OpenApiHostConfiguration> configureHost, Action<IOpenApiConfiguration> configureEnvironment = null)
        {
            if (services.Any(s => typeof(IOpenApiHost<TRequest, TResponse>).IsAssignableFrom(s.ServiceType)))
            {
                return services;
            }

            services.AddJsonSerializerSettings();

            services.AddInstrumentation();

            services.AddOpenApiAuditing();
            services.AddAuditLogSink<ConsoleAuditLogSink>();

            services.AddSingleton<JsonConverter, OpenApiDocumentJsonConverter>();
            services.AddSingleton<JsonConverter, HalDocumentJsonConverter>();
            services.AddSingleton<IOpenApiDocumentProvider, OpenApiDocumentProvider>();
            services.AddSingleton<IHalDocumentFactory, HalDocumentFactory>();
            services.AddTransient<HalDocument>();
            services.AddSingleton<IOpenApiServiceOperationLocator, DefaultOperationLocator>();
            services.AddSingleton<IPathMatcher, PathMatcher>();
            services.AddSingleton<IOpenApiService, SwaggerService>();
            services.AddSingleton<IOpenApiLinkOperationMapper, OpenApiLinkOperationMapper>();
            services.AddSingleton<IOpenApiAccessChecker, OpenApiAccessChecker>();
            services.AddSingleton<IOpenApiExceptionMapper, OpenApiExceptionMapper>();
            services.AddSingleton<IOpenApiWebLinkResolver, OpenApiWebLinkResolver>();
            services.AddSingleton<IAuditContext, AuditContext>();
            services.AddSingleton<IOpenApiOperationInvoker<TRequest, TResponse>, OpenApiOperationInvoker<TRequest, TResponse>>();

            services.AddSingleton((Func<IServiceProvider, IOpenApiHost<TRequest, TResponse>>)(serviceProvider =>
            {
                var result = new OpenApiHost<TRequest, TResponse>(
                        serviceProvider.GetRequiredService<IPathMatcher>(),
                        serviceProvider.GetRequiredService<IOpenApiOperationInvoker<TRequest, TResponse>>(),
                        serviceProvider.GetRequiredService<IOpenApiResultBuilder<TResponse>>());

                IOpenApiExceptionMapper exceptionMapper = serviceProvider.GetRequiredService<IOpenApiExceptionMapper>();

                exceptionMapper.Map<OpenApiBadRequestException>(400);
                exceptionMapper.Map<OpenApiUnauthorizedException>(401);
                exceptionMapper.Map<OpenApiForbiddenException>(403);
                exceptionMapper.Map<OpenApiNotFoundException>(404);

                var hostConfiguration = new OpenApiHostConfiguration(serviceProvider.GetRequiredService<IOpenApiDocumentProvider>(), exceptionMapper, serviceProvider.GetRequiredService<IOpenApiLinkOperationMapper>());

                serviceProvider.GetServices<IHalDocumentMapper>().ForEach(mapper => mapper.ConfigureLinkMap(hostConfiguration.Links));
                configureHost?.Invoke(hostConfiguration);

                return result;
            }));

            services.AddSingleton<IOpenApiConfiguration>(serviceProvider =>
            {
                var config = new OpenApiConfiguration(serviceProvider);
                configureEnvironment?.Invoke(config);

                return config;
            });

            services.AddOpenApiJsonConverters();
            services.AddOpenApiExceptionMappers();

            return services;
        }

        /// <summary>
        /// Add an <see cref="IHalDocumentMapper"/> to the service collection.
        /// </summary>
        /// <typeparam name="TResource">The type of the resource mapped by the HAL document mapper.</typeparam>
        /// <typeparam name="TMapper">The type of the mapper.</typeparam>
        /// <param name="services">The service collection to which to add the mapper.</param>
        /// <returns>The service collection, configured with the HAL document mapper.</returns>
        public static IServiceCollection AddHalDocumentMapper<TResource, TMapper>(this IServiceCollection services)
            where TMapper : class, IHalDocumentMapper<TResource>
        {
            services.AddSingleton<TMapper>();
            services.AddSingleton<IHalDocumentMapper>(s => s.GetRequiredService<TMapper>());
            services.AddSingleton<IHalDocumentMapper<TResource>>(s => s.GetRequiredService<TMapper>());
            return services;
        }

        /// <summary>
        /// Add an <see cref="IHalDocumentMapper"/> to the service collection.
        /// </summary>
        /// <typeparam name="TResource">The type of the resource mapped by the HAL document mapper.</typeparam>
        /// <typeparam name="TContext">The type of the additional context required by the HAL document mapper.</typeparam>
        /// <typeparam name="TMapper">The type of the mapper.</typeparam>
        /// <param name="services">The service collection to which to add the mapper.</param>
        /// <returns>The service collection, configured with the HAL document mapper.</returns>
        public static IServiceCollection AddHalDocumentMapper<TResource, TContext, TMapper>(this IServiceCollection services)
            where TMapper : class, IHalDocumentMapper<TResource, TContext>
        {
            services.AddSingleton<TMapper>();
            services.AddSingleton<IHalDocumentMapper>(s => s.GetRequiredService<TMapper>());
            services.AddSingleton<IHalDocumentMapper<TResource, TContext>>(s => s.GetRequiredService<TMapper>());
            return services;
        }

        /// <summary>
        /// Adds the /swagger endpoint to your host.
        /// </summary>
        /// <param name="documents">
        /// The Open API document provider.
        /// </param>
        public static void AddSwaggerEndpoint(this IOpenApiDocuments documents)
        {
            documents.Add(SwaggerService.BuildSwaggerDocument());
        }

        /// <summary>
        /// Enables resolution of URLs to external services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configurationSectionName">
        /// The name of the configuration section in which external service base URLs are configured.
        /// </param>
        /// <param name="configure">A callback for registering external services.</param>
        /// <returns>The service collection, to enable chaining.</returns>
        public static IServiceCollection AddExternalServices(
            this IServiceCollection services,
            string configurationSectionName,
            Action<IOpenApiExternalServices> configure)
        {
            services.AddSingleton(sp =>
            {
                IConfigurationRoot configRoot = sp.GetRequiredService<IConfigurationRoot>();
                IOpenApiExternalServices result = new OpenApiExternalServices(
                    configRoot.GetSection(configurationSectionName),
                    sp.GetRequiredService<ILogger<OpenApiDocumentProvider>>());

                configure(result);

                return result;
            });

            return services;
        }
    }
}