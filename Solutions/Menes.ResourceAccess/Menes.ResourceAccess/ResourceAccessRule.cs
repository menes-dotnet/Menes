// <copyright file="ResourceAccessRule.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Corvus.Globbing;

namespace Menes.ResourceAccess;

/// <summary>
/// Struct representing a rule for resource access permissions. The rule is defined by a resource, an access type,
/// and a permission.
/// </summary>
/// <example>
/// <para>
/// To define a rule allowing access of type 'read' to all your 'book' resources, use the following:
/// </para>
/// <code>
/// var rule = new ResourceAccessRule("read", "books/**", Permission.Allow);
/// </code>
/// <para>
/// To define a rule denying access of type 'edit' to your 'Home page' resource, use the following:
/// </para>
/// <code>
/// var rule = new ResourceAccessRule("edit", "page/home", Permission.Deny);
/// </code>
/// </example>
/// <param name="AccessType">The type of resource usage to which this rule applies. This will be application specific and can be either a specific value ("GET") or a globbing pattern ("[GS]ET").</param>
/// <param name="Uri">The unique identifier for the resource. The Uri should be relative, and can either be
/// an actual value (e.g. "page/home") or a globbing pattern (e.g. "books/**").
/// </param>
/// <param name="Permission">Determines whether permission should be allowed or denied to the resource (deny takes precedence).</param>
/// <remarks>
/// <para>
/// The <paramref name="Uri"/> and <paramref name="AccessType"/> both support globbing: use '/' to separate segments, use '*' for wildcard in segment,
/// use '**' for arbitrary segment depth, use '..' for parent segment.
/// </para>
/// <para>
/// Note that the URI for the resource does not have to be the URI at which the resource is to be found. It could, for
/// example, be the URI for a unique tag for all resources of some type to support tag-based permissions.
/// </para>
/// </remarks>
public readonly record struct ResourceAccessRule(string AccessType, string Uri, Permission Permission)
{
    /// <summary>
    /// Determines whether this permission rule is a match for the target resource name and access type.
    /// Uses globbing to match to pattern.
    /// </summary>
    /// <param name="resourceUri">The URI of the target resource.</param>
    /// <param name="accessType">The access type of the target resource.</param>
    /// <returns><c>True</c> if a match.</returns>
    public bool IsMatch(in ReadOnlySpan<char> resourceUri, in ReadOnlySpan<char> accessType)
    {
        return Glob.Match(this.Uri, resourceUri) && Glob.Match(this.AccessType, accessType);
    }
}