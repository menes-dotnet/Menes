// <copyright file="ResourceAccessCompoundRuleSet.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections;
using System.Collections.Immutable;

namespace Menes.ResourceAccess;

/// <summary>
/// A compound set of resource access rules.
/// </summary>
public readonly struct ResourceAccessCompoundRuleSet : IEnumerable, IEnumerable<ResourceAccessRule>, IResourceAccessRuleSet
{
    private readonly ImmutableList<ResourceAccessRuleSet> ruleSets;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResourceAccessRuleSet"/> class.
    /// </summary>
    /// <param name="ruleSets">The set of rule sets from which to construct the compound rule set.</param>
    public ResourceAccessCompoundRuleSet(in ImmutableList<ResourceAccessRuleSet> ruleSets)
    {
        this.ruleSets = ruleSets;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ResourceAccessRuleSet"/> class.
    /// </summary>
    /// <param name="ruleSets">The set of rule sets from which to construct the compound rule set.</param>
    /// <returns>A new compound resource access rule set.</returns>
    public static ResourceAccessCompoundRuleSet Create(params ResourceAccessRuleSet[] ruleSets)
    {
        return new ResourceAccessCompoundRuleSet(ImmutableList.Create(ruleSets));
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ResourceAccessCompoundRuleSet"/> class.
    /// </summary>
    /// <typeparam name="T">The type of the enumerable of resource access rule sets.</typeparam>
    /// <param name="ruleSets">The set of rule sets from which to construct the compound rule set.</param>
    /// <returns>A new resource access rule set.</returns>
    public static ResourceAccessCompoundRuleSet CreateRange<T>(in T ruleSets)
        where T : IEnumerable<ResourceAccessRuleSet>
    {
        return new ResourceAccessCompoundRuleSet(ImmutableList.CreateRange(ruleSets));
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
    IEnumerator<ResourceAccessRule> IEnumerable<ResourceAccessRule>.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// An enumerator for a resource access rule set.
    /// </summary>
    public struct Enumerator : IEnumerable, IEnumerator, IEnumerable<ResourceAccessRule>, IEnumerator<ResourceAccessRule>
    {
        private readonly ResourceAccessCompoundRuleSet ruleSet;

        private int currentIndex = -1;
        private ResourceAccessRuleSet.Enumerator? currentEnumerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Enumerator"/> struct.
        /// </summary>
        /// <param name="ruleSet">The rule set to enumerator.</param>
        internal Enumerator(in ResourceAccessCompoundRuleSet ruleSet)
            : this()
        {
            this.ruleSet = ruleSet;
        }

        /// <summary>
        /// Gets the current item in the enumeration.
        /// </summary>
        public ResourceAccessRule Current => this.currentEnumerator?.Current ?? default;

        /// <inheritdoc/>
        object IEnumerator.Current => this.Current;

        /// <inheritdoc/>
        public void Dispose()
        {
            this.currentEnumerator?.Dispose();
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
            if (this.currentEnumerator.HasValue && this.currentEnumerator.Value.MoveNext())
            {
                return true;
            }

            while (this.currentIndex < this.ruleSet.ruleSets.Count)
            {
                if (this.currentEnumerator.HasValue)
                {
                    this.currentEnumerator.Value.Dispose();
                }

                this.currentEnumerator = this.ruleSet.ruleSets[this.currentIndex++].GetEnumerator();
                if (this.currentEnumerator.Value.MoveNext())
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <inheritdoc/>
        public void Reset()
        {
            this.currentIndex = -1;
            if (this.currentEnumerator.HasValue)
            {
                this.currentEnumerator.Value.Dispose();
                this.currentEnumerator = null;
            }
        }
    }
}