// <copyright file="Permission.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ResourceAccess;

/// <summary>
/// List of permission states for a <see cref="ResourceAccessRule"/>.
/// </summary>
/// <remarks>
/// <see cref="Deny"/> takes precedence over <see cref="Allow"/> when multiple
/// permissions are applied to the same resource.
/// </remarks>
public enum Permission
{
    /// <summary>
    /// Explicitly deny permission to the resource.
    /// </summary>
    Deny,

    /// <summary>
    /// Explicitly allow permission to the resource.
    /// </summary>
    Allow,
}