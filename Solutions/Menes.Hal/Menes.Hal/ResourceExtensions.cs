// <copyright file="ResourceExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Corvus.Json;
using Corvus.Json.Visitor;
using Menes.ResourceAccess;

namespace Menes.Hal;

/// <summary>
/// Extensions for working with HAL specification resources.
/// </summary>
public static class ResourceExtensions
{
    /// <summary>
    /// Determines if the instance given conforms to the HAL resource specificiation.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource instance.</typeparam>
    /// <param name="resource">The resource instance to validate.</param>
    /// <returns><c>True</c> if the instance is a valid resource, according to the HAL specification, otherwise false.</returns>
    public static bool IsValidResource<TResource>(this TResource resource)
        where TResource : struct, IJsonValue<TResource>
    {
        return resource.As<Resource>().IsValid();
    }

    /// <summary>
    /// Filters the resources and links in the given resource, based on the resource access rule set.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource.</typeparam>
    /// <typeparam name="TResourceAccessRuleSet">The type of the resource access rule set.</typeparam>
    /// <param name="resource">The resource to filter.</param>
    /// <param name="ruleSet">The resource access rule set.</param>
    /// <param name="accessType">The access type for the rules.</param>
    /// <param name="result">The resulting reousrce after transformation.</param>
    /// <returns><c>True</c> if the result was modified.</returns>
    public static bool FilterResourcesAndLinks<TResource, TResourceAccessRuleSet>(this TResource resource, in TResourceAccessRuleSet ruleSet, string accessType, out TResource result)
        where TResource : struct, IJsonValue<TResource>
        where TResourceAccessRuleSet : struct, IResourceAccessRuleSet
    {
        FilteringResourceVisitor<TResourceAccessRuleSet> visitor = new(ruleSet, accessType);
        if (resource.FilterResourcesAndLinksCore(visitor, out JsonAny transformed))
        {
            result = transformed.As<TResource>();
            return true;
        }

        result = resource;
        return false;
    }

    /// <summary>
    /// Filters the resources and links in the given resource, based on the resource access rule set.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource.</typeparam>
    /// <typeparam name="TResourceAccessRuleSet">The type of the resource access rule set.</typeparam>
    /// <param name="resource">The resource to filter.</param>
    /// <param name="visitor">The current visitor.</param>
    /// <param name="result">The resulting reousrce after transformation.</param>
    /// <returns><c>True</c> if the result was modified.</returns>
    private static bool FilterResourcesAndLinksCore<TResource, TResourceAccessRuleSet>(this TResource resource, in FilteringResourceVisitor<TResourceAccessRuleSet> visitor, out JsonAny result)
        where TResource : struct, IJsonValue<TResource>
        where TResourceAccessRuleSet : struct, IResourceAccessRuleSet
    {
        JsonAny nodeToVisit = resource.AsAny;
        VisitResult visitResult = new(nodeToVisit, Transformed.No, Walk.Continue);
        visitor.Accept(nodeToVisit, ref visitResult);
        if (visitResult.IsTransformed)
        {
            result = visitResult.Output;
            return true;
        }

        result = nodeToVisit;
        return false;
    }

    private readonly struct FilteringResourceVisitor<TResourceAccessRuleSet>
        where TResourceAccessRuleSet : struct, IResourceAccessRuleSet
    {
        public FilteringResourceVisitor(TResourceAccessRuleSet ruleSet, string accessType)
        {
            this.RuleSet = ruleSet;
            this.AccessType = accessType;
        }

        public TResourceAccessRuleSet RuleSet { get; }

        public string AccessType { get; }

        public void Accept(JsonAny nodeToVisit, ref VisitResult result)
        {
            // Check to see we are an object with a _links property.
            if (nodeToVisit.ValueKind == JsonValueKind.Object || nodeToVisit.HasProperty(Resource.LinksJsonPropertyName))
            {
                Resource resource = nodeToVisit.As<Resource>();
                if (!this.RuleSet.Allows(resource.Links.Self.Href, this.AccessType))
                {
                    result.Walk = Walk.RemoveAndContinue;
                    result.Transformed = Transformed.Yes;
                    result.Output = Resource.Undefined;
                    return;
                }

                bool modifiedLinks = this.FilterLinks(resource, out ImmutableDictionary<JsonPropertyName, JsonAny>.Builder? linksBuilder);
                bool modifiedEmbeddedResources = this.FilterEmbeddedResources(resource, out ImmutableDictionary<JsonPropertyName, JsonAny>.Builder? embeddedResourcesBuilder);

                if (modifiedLinks || modifiedEmbeddedResources)
                {
                    ImmutableDictionary<JsonPropertyName, JsonAny>.Builder resourcePropertyDictionary = resource.AsImmutableDictionaryBuilder();
                    if (modifiedLinks)
                    {
                        resourcePropertyDictionary[Resource.LinksJsonPropertyName] = linksBuilder!.ToImmutable();
                    }

                    if (modifiedEmbeddedResources)
                    {
                        resourcePropertyDictionary[Resource.EmbeddedJsonPropertyName] = embeddedResourcesBuilder!.ToImmutable();
                    }

                    result.Walk = Walk.TerminateAtThisNodeAndKeepChanges;
                    result.Transformed = Transformed.Yes;
                    result.Output = resourcePropertyDictionary.ToImmutable();
                }
                else
                {
                    result.Walk = Walk.TerminateAtThisNodeAndKeepChanges;
                    result.Transformed = Transformed.No;
                    result.Output = nodeToVisit;
                }
            }
            else
            {
                // We are not allowed to visit something that isn't a HAL resource.
                result.Transformed = Transformed.No;
                result.Walk = Walk.TerminateAtThisNodeAndAbandonAllChanges;
                result.Output = nodeToVisit;
            }
        }

        private bool FilterEmbeddedResources(in Resource resource, [NotNullWhen(true)] out ImmutableDictionary<JsonPropertyName, JsonAny>.Builder? embeddedResourcesBuilder)
        {
            bool modifiedEmbeddedResources = false;

            ImmutableDictionary<JsonPropertyName, JsonAny>.Builder workingBuilder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();

            foreach (JsonObjectProperty property in resource.Embedded.EnumerateObject())
            {
                EmbeddedResourceProperty embeddedProperty = property.ValueAs<EmbeddedResourceProperty>();
                if (embeddedProperty.TryGetAsResource(out Resource embedded))
                {
                    if (embedded.FilterResourcesAndLinksCore(this, out JsonAny transformed))
                    {
                        modifiedEmbeddedResources = true;
                        if (transformed.ValueKind != JsonValueKind.Undefined)
                        {
                            // Don't add the property back to the builder as it was previously a single link
                            workingBuilder.Add(property.Name, transformed);
                        }
                    }
                    else
                    {
                        workingBuilder.Add(property.Name, property.Value);
                    }
                }
                else
                {
                    bool modifiedArray = false;

                    // It's an array of embeddedResources
                    ResourceCollection embeddedResourceArray = embeddedProperty.AsResourceCollection;
                    ImmutableList<JsonAny>.Builder embeddedResourceArrayBuilder = embeddedResourceArray.AsImmutableListBuilder();
                    int indexInBuilder = 0;

                    foreach (Resource embeddedResourceInArray in embeddedResourceArray.EnumerateArray())
                    {
                        if (embedded.FilterResourcesAndLinksCore(this, out JsonAny transformed))
                        {
                            modifiedEmbeddedResources = true;
                            modifiedArray = true;
                            if (transformed.ValueKind == JsonValueKind.Undefined)
                            {
                                // We removed it.
                                embeddedResourceArrayBuilder.RemoveAt(indexInBuilder);
                            }
                            else
                            {
                                // We modified it.
                                embeddedResourceArrayBuilder[indexInBuilder] = transformed;
                                ++indexInBuilder;
                            }
                        }
                        else
                        {
                            ++indexInBuilder;
                        }
                    }

                    if (modifiedArray)
                    {
                        if (embeddedResourceArrayBuilder.Count > 0)
                        {
                            workingBuilder.Add(property.Name, embeddedResourceArrayBuilder.ToImmutable());
                        }
                    }
                    else
                    {
                        workingBuilder.Add(property.Name, embeddedResourceArray);
                    }
                }
            }

            if (modifiedEmbeddedResources)
            {
                embeddedResourcesBuilder = workingBuilder;
                return true;
            }

            embeddedResourcesBuilder = null;
            return false;
        }

        private bool FilterLinks(in Resource resource, [NotNullWhen(true)] out ImmutableDictionary<JsonPropertyName, JsonAny>.Builder? linksBuilder)
        {
            bool modifiedLinks = false;

            ImmutableDictionary<JsonPropertyName, JsonAny>.Builder workingBuilder = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();

            // This is a HAL resource
            // Look through the links and decide if we are going to keep them or strip them.
            // Strip the embedded resources that correspond with those links
            // Iterate throught the embedded resources that are left
            foreach (JsonObjectProperty property in resource.Links.EnumerateObject())
            {
                LinkProperty linkProperty = property.ValueAs<LinkProperty>();
                if (linkProperty.TryGetAsLink(out Link link))
                {
                    if (!this.RuleSet.Allows(link.Href, this.AccessType))
                    {
                        // Don't add the property back to the builder as it was previously a single link
                        modifiedLinks = true;
                    }
                    else
                    {
                        workingBuilder.Add(property.Name, property.Value);
                    }
                }
                else
                {
                    bool modifiedArray = false;

                    // It's an array of links
                    LinkCollection linkArray = linkProperty.AsLinkCollection;
                    ImmutableList<JsonAny>.Builder linkArrayBuilder = linkArray.AsImmutableListBuilder();
                    int indexInBuilder = 0;
                    foreach (Link linkInArray in linkArray.EnumerateArray())
                    {
                        if (!this.RuleSet.Allows(linkInArray.Href, this.AccessType))
                        {
                            linkArrayBuilder.RemoveAt(indexInBuilder);
                            modifiedLinks = true;
                            modifiedArray = true;
                        }
                        else
                        {
                            ++indexInBuilder;
                        }
                    }

                    if (modifiedArray)
                    {
                        if (linkArrayBuilder.Count > 0)
                        {
                            workingBuilder.Add(property.Name, linkArrayBuilder.ToImmutable());
                        }
                    }
                    else
                    {
                        workingBuilder.Add(property.Name, linkArray);
                    }
                }
            }

            if (modifiedLinks)
            {
                linksBuilder = workingBuilder;
                return true;
            }

            linksBuilder = null;
            return false;
        }
    }
}