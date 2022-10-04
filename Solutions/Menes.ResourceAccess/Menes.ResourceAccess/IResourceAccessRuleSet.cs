// <copyright file="IResourceAccessRuleSet.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ResourceAccess;

/// <summary>
/// An interface implemented by resource access rule sets.
/// </summary>
public interface IResourceAccessRuleSet
{
    /// <summary>
    /// Evaluates the ruleset to determine if the given <paramref name="accessType"/> is allowed for the specified <paramref name="resourceUri"/>.
    /// </summary>
    /// <param name="resourceUri">The URI of the resource against which to evaluate the rules.</param>
    /// <param name="accessType">The access type against which to evaluate the rules.</param>
    /// <returns><c>True</c> if the rule set allows the given URI.</returns>
    bool Allows(in ReadOnlySpan<char> resourceUri, in ReadOnlySpan<char> accessType);
}