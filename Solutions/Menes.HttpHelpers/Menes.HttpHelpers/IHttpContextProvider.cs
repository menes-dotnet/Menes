// <copyright file="IHttpContextProvider.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;

namespace Menes.HttpHelpers;

/// <summary>
/// Implemented by Operation requests that can provide an ASPNET HttpContext.
/// </summary>
public interface IHttpContextProvider
{
    /// <summary>
    /// Gets the <see cref="HttpContext"/> for the request.
    /// </summary>
    HttpContext HttpContext { get; }
}