// <copyright file="OpenApiAzureFunctionsWorkerHostingServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection;

using System;

using Menes;
using Menes.Hosting.AzureFunctionsWorker;
using Menes.Internal;

using Microsoft.Azure.Functions.Worker.Http;

/// <summary>
/// Extensions to register open api request hosting for <see cref="HttpRequestData"/> and <see cref="HttpResponseData"/>.
/// </summary>
public static class OpenApiAzureFunctionsWorkerHostingServiceCollectionExtensions
{
    /// <summary>
    /// Adds <see cref="HttpRequestData"/> / <see cref="HttpResponseData"/> middleware-based hosting.
    /// </summary>
    /// <typeparam name="TContext">The type of the OpenApi context.</typeparam>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configureHost">A function to configure the host.</param>
    /// <param name="configureEnvironment">A function to configure the environment.</param>
    /// <returns>The configured service collection.</returns>
    public static IServiceCollection AddOpenApiAzureFunctionsWorkerHosting<TContext>(
        this IServiceCollection services,
        Action<IOpenApiHostConfiguration>? configureHost,
        Action<IOpenApiConfiguration>? configureEnvironment = null)
        where TContext : class, IOpenApiContext, new()
    {
        services.AddSingleton<IResponseOutputBuilder<IHttpResponseDataResult>, PocoHttpResponseDataOutputBuilder>();
        services.AddSingleton<IResponseOutputBuilder<IHttpResponseDataResult>, OpenApiResultHttpResponseDataOutputBuilder>();
        services.AddSingleton<IOpenApiResultBuilder<IHttpResponseDataResult>, OpenApiHttpResponseDataResultBuilder>();

        services.AddSingleton<IOpenApiContextBuilder<HttpRequestData>, OpenApiContextBuilder<HttpRequestData, TContext>>();
        services.AddSingleton<IOpenApiParameterBuilder<HttpRequestData>, HttpRequestDataParameterBuilder>();

        services.AddOpenApiHosting<HttpRequestData, HttpResponseData>(
            configureHost,
            configureEnvironment);

        return services;
    }
}