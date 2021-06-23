﻿// <copyright file="StringBuilderPool.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Json.UriTemplates
{
    using System.Text;
    using Microsoft.Extensions.ObjectPool;

    /// <summary>
    /// A <see cref="StringBuilder"/> provider.
    /// </summary>
    internal static class StringBuilderPool
    {
        /// <summary>
        /// Gets a shared <see cref="StringBuilder"/> pool.
        /// </summary>
        public static readonly DefaultObjectPool<StringBuilder> Shared = new (new StringBuilderPooledObjectPolicy());
    }
}
