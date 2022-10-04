// <copyright file="ResourceAccessRuleSet.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections;
using System.Collections.Immutable;

namespace Menes.ResourceAccess;

/// <summary>
/// A set of resource access rules.
/// </summary>
public readonly struct ResourceAccessRuleSet : IEnumerable, IEnumerable<ResourceAccessRule>, IResourceAccessRuleSet
{
    private readonly ImmutableList<ResourceAccessRule> rules;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceAccessRuleSet"/> class.
    /// </summary>
    /// <param name="rules">The rules from which to construct rule set.</param>
    public ResourceAccessRuleSet(in ImmutableList<ResourceAccessRule> rules)
    {
        this.rules = rules;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ResourceAccessRuleSet"/> class.
    /// </summary>
    /// <param name="rules">The rules from which to construct rule set.</param>
    /// <returns>A new resource access rule set.</returns>
    public static ResourceAccessRuleSet Create(params ResourceAccessRule[] rules)
    {
        return new ResourceAccessRuleSet(ImmutableList.Create(rules));
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ResourceAccessRuleSet"/> class.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable of resource access rules.</typeparam>
    /// <param name="rules">The rules from which to construct rule set.</param>
    /// <returns>A new resource access rule set.</returns>
    public static ResourceAccessRuleSet CreateRange<T>(in T rules)
        where T : IEnumerable<ResourceAccessRule>
    {
        return new ResourceAccessRuleSet(ImmutableList.CreateRange(rules));
    }

    /// <inheritdoc/>
    public bool Allows(in ReadOnlySpan<char> resourceUri, in ReadOnlySpan<char> accessType)
    {
        return ResourceAccessHelper.Allows(this, resourceUri, accessType);
    }

    /// <summary>
    /// Gets the enumerator for this collection.
    /// </summary>
    /// <returns>An instance of an enumerator for this collection.</returns>
    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    /// <inheritdoc/>
    IEnumerator<ResourceAccessRule> IEnumerable<ResourceAccessRule>.GetEnumerator() => this.GetEnumerator();

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    /// <summary>
    /// An enumerator for a resource access rule set.
    /// </summary>
    public struct Enumerator : IEnumerable, IEnumerator, IEnumerable<ResourceAccessRule>, IEnumerator<ResourceAccessRule>
    {
        private ImmutableList<ResourceAccessRule>.Enumerator enumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumerator"/> struct.
        /// </summary>
        /// <param name="ruleSet">The rule set to enumerator.</param>
        internal Enumerator(ResourceAccessRuleSet ruleSet)
        {
            this.enumerator = ruleSet.rules.GetEnumerator();
        }

        /// <summary>
        /// Gets the current item in the enumeration.
        /// </summary>
        public ResourceAccessRule Current => this.enumerator.Current;

        /// <inheritdoc/>
        object IEnumerator.Current => this.Current;

        /// <inheritdoc/>
        public void Dispose()
        {
            this.enumerator.Dispose();
        }

        /// <summary>
        /// Gets a new instance of this enumerator.
        /// </summary>
        /// <returns>The reset instance of the enumerator.</returns>
        public Enumerator GetEnumerator()
        {
            Enumerator result = this;
            result.Reset();
            return result;
        }

        /// <inheritdoc/>
        IEnumerator<ResourceAccessRule> IEnumerable<ResourceAccessRule>.GetEnumerator() => this.GetEnumerator();

        /// <inheritdoc/>
        public bool MoveNext()
        {
            return this.enumerator.MoveNext();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <inheritdoc/>
        public void Reset()
        {
            this.enumerator.Reset();
        }
    }
}