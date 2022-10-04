// <copyright file="ResourceAccessHelper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.ResourceAccess;

/// <summary>
/// Extension methods for resource access.
/// </summary>
internal static class ResourceAccessHelper
{
    /// <summary>
    /// Evaluates a set of <paramref name="ruleSet"/> to determine if the given <paramref name="accessType"/> is allowed for the specified <paramref name="resourceUri"/>.
    /// </summary>
    /// <typeparam name="T">The type of the set of resource access rules.</typeparam>
    /// <param name="ruleSet">The set of rules to evaluate.</param>
    /// <param name="resourceUri">The URI of the resource against which to evaluate the rules.</param>
    /// <param name="accessType">The access type against which to evaluate the rules.</param>
    /// <returns><c>True</c> if the rule set allows the given URI.</returns>
    internal static bool Allows<T>(in T ruleSet, in ReadOnlySpan<char> resourceUri, in ReadOnlySpan<char> accessType)
        where T : struct, IEnumerable<ResourceAccessRule>
    {
        bool hasAtLeastOneAllow = false;

        foreach (ResourceAccessRule rule in ruleSet)
        {
            if (rule.IsMatch(resourceUri, accessType))
            {
                if (rule.Permission == Permission.Deny)
                {
                    // Jump straight out if we have a 'deny' match
                    return false;
                }
                else
                {
                    hasAtLeastOneAllow = true;
                }
            }
        }

        return hasAtLeastOneAllow;
    }
}