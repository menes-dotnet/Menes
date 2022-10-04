// <copyright file="ResourceBuilder.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Immutable;
using System.Text.Json;
using Corvus.Json;

namespace Menes.Hal;

/// <summary>
/// Builds a <see cref="Resource"/>.
/// </summary>
public struct ResourceBuilder
{
    private readonly ImmutableDictionary<JsonPropertyName, JsonAny>.Builder resources = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
    private readonly ImmutableDictionary<JsonPropertyName, JsonAny>.Builder links = ImmutableDictionary.CreateBuilder<JsonPropertyName, JsonAny>();
    private readonly JsonAny baseElement;
    private readonly Link self;

    private ResourceBuilder(JsonAny baseElement, Link self)
        : this()
    {
        this.baseElement = baseElement;
        this.self = self;
    }

    /// <summary>
    /// Create a type which can build a HAL resource from a base JSON object.
    /// </summary>
    /// <typeparam name="TCreated">The type of the base element from which to build the resource.</typeparam>
    /// <param name="baseElement">The base element from which to construct the resource. All its properties will be included in the resulting resource, but should it already have <c>_links</c> and/or <c>_embedded</c> properties, these will be replaced with the ones created by this builder.</param>
    /// <param name="self">The <c>self</c> link for this resource. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target resource, otherwise it must conform to the link schema in the HAL specification.</param>
    /// <returns>An instance of a <see cref="ResourceBuilder"/> for the given base element.</returns>
    public static ResourceBuilder Create<TCreated>(in TCreated baseElement, in JsonAny self)
        where TCreated : struct, IJsonObject<TCreated>
    {
        return new ResourceBuilder(
            baseElement.AsAny,
            MakeLink(self));

        static Link MakeLink(JsonAny self)
        {
            Link result = self.ValueKind == JsonValueKind.String ? Link.Create(self) : self.As<Link>();
            if (!result.IsValid())
            {
                throw new ArgumentException("The self link must be either a string, or a valid Link according to the schema in the HAL specification.");
            }

            return result;
        }
    }

    /// <summary>
    /// Construct an instance of the resource from the builder.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource to create. This should conform with the HAL resource schema.</typeparam>
    /// <returns>An instance of the resource with the appropriate links and embedded resources.</returns>
    public TResource ToResource<TResource>()
            where TResource : struct, IJsonObject<TResource>
    {
        this.links.Add(LinksProperty.SelfJsonPropertyName, this.self);
        JsonAny resource =
            this.baseElement
                .SetProperty(Resource.LinksJsonPropertyName, JsonAny.From(this.links.ToImmutable()));

        if (this.resources.Count > 0)
        {
            resource =
                resource.SetProperty(Resource.EmbeddedJsonPropertyName, JsonAny.From(this.resources.ToImmutable()));
        }
        else
        {
            resource = resource.RemoveProperty(Resource.EmbeddedJsonPropertyName);
        }

        return resource.As<TResource>();
    }

    /// <summary>
    /// Add a link to the resource.
    /// </summary>
    /// <param name="name">The name of the link.</param>
    /// <param name="link">The link to add. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    public void AddLink(string name, in JsonAny link)
    {
        this.MergeLink(
            name,
            MakeLink(link),
            false);
    }

    /// <summary>
    /// Add a link to the resource.
    /// </summary>
    /// <param name="name">The name of the link.</param>
    /// <param name="link1">The first link to add. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    /// <param name="link2">The second link to add. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    public void AddLinks(string name, in JsonAny link1, in JsonAny link2)
    {
        this.MergeLink(
            name,
            MakeLink(link1),
            MakeLink(link2));
    }

    /// <summary>
    /// Add a link to the resource.
    /// </summary>
    /// <param name="name">The name of the link.</param>
    /// <param name="link1">The first link to add. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    /// <param name="link2">The second link to add. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    /// <param name="link3">The third link to add. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    public void AddLinks(string name, in JsonAny link1, in JsonAny link2, in JsonAny link3)
    {
        this.MergeLink(
            name,
            MakeLink(link1),
            MakeLink(link2),
            MakeLink(link3));
    }

    /// <summary>
    /// Add a link to the resource.
    /// </summary>
    /// <param name="name">The name of the link.</param>
    /// <param name="link1">The first link to add. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    /// <param name="link2">The second link to add. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    /// <param name="link3">The third link to add. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    /// <param name="link4">The fourth link to add. If this is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    public void AddLinks(string name, in JsonAny link1, in JsonAny link2, in JsonAny link3, in JsonAny link4)
    {
        this.MergeLink(
            name,
            MakeLink(link1),
            MakeLink(link2),
            MakeLink(link3),
            MakeLink(link4));
    }

    /// <summary>
    /// Add a link to the resource.
    /// </summary>
    /// <param name="name">The name of the link.</param>
    /// <param name="links">The links to add. If an object in the array is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    public void AddLinks(string name, params JsonAny[] links)
    {
        this.MergeLinkRange(
            name,
            links.Select(l => MakeLink(l)));
    }

    /// <summary>
    /// Add a link to the resource.
    /// </summary>
    /// <typeparam name="TLink">The type of the link.</typeparam>
    /// <param name="name">The name of the link.</param>
    /// <param name="links">The links to add. If an object in the array is a <see cref="JsonString"/>, it will be treated as either a URI [RFC3986] or URI Template [RFC6570] of the target, otherwise it must conform to the link schema in the HAL specification.</param>
    public void AddLinkRange<TLink>(string name, IEnumerable<TLink> links)
        where TLink : struct, IJsonValue
    {
        this.MergeLinkRange(
            name,
            links.Select(l => MakeLink(l)));
    }

    /// <summary>
    /// Embed a resource in this resource.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource to embed.</typeparam>
    /// <param name="name">The name under which to embed the resource.</param>
    /// <param name="resource">The resource to embed. This must comply with the HAL reource schema, including a single self link.</param>
    /// <param name="forceArray">If true, then the resource/link will always be added as an array of links. Otherwise, the first named items
    /// will be added as a naked element, and second or subsequent items with same name will convert the property to an array.</param>
    /// <exception cref="ArgumentException">Thrown if the resource to embed does not have a self link.</exception>
    /// <remarks>
    /// <para>
    /// This will embed the resource, and add its self link to the links collection.
    /// </para>
    /// </remarks>
    public void EmbedResource<TResource>(string name, TResource resource, bool forceArray = false)
        where TResource : struct, IJsonObject<TResource>
    {
        JsonAny selfLink = MakeSelfLink(resource);

        this.MergeLink(name, selfLink, forceArray);
        this.MergeResource(name, resource, forceArray);
    }

    /// <summary>
    /// Embed a resource in this resource.
    /// </summary>
    /// <typeparam name="TResource1">The type of the first resource to embed.</typeparam>
    /// <typeparam name="TResource2">The type of the second resource to embed.</typeparam>
    /// <param name="name">The name under which to embed the resource.</param>
    /// <param name="resource1">The first resource to embed. This must comply with the HAL reource schema, including a single self link.</param>
    /// <param name="resource2">The second resource to embed. This must comply with the HAL reource schema, including a single self link.</param>
    /// <exception cref="ArgumentException">Thrown if the resource to embed does not have a self link.</exception>
    /// <remarks>
    /// <para>
    /// This will embed the resource, and add its self link to the links collection.
    /// </para>
    /// </remarks>
    public void EmbedResource<TResource1, TResource2>(string name, TResource1 resource1, TResource2 resource2)
        where TResource1 : struct, IJsonObject<TResource1>
        where TResource2 : struct, IJsonObject<TResource2>
    {
        Link selfLink1 = MakeSelfLink(resource1);
        Link selfLink2 = MakeSelfLink(resource2);

        this.MergeLink(name, selfLink1, selfLink2);
        this.MergeResource(name, resource1, resource2);
    }

    /// <summary>
    /// Embed a resource in this resource.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource to embed.</typeparam>
    /// <param name="name">The name under which to embed the resource.</param>
    /// <param name="resources">The resources to embed. They must comply with the HAL reource schema, including a single self link.</param>
    /// <exception cref="ArgumentException">Thrown if the resource to embed does not have a self link.</exception>
    /// <remarks>
    /// <para>
    /// This will embed the resource, and add its self link to the links collection.
    /// </para>
    /// </remarks>
    public void EmbedResource<TResource>(string name, params TResource[] resources)
        where TResource : struct, IJsonObject<TResource>
    {
        foreach (TResource resource in resources)
        {
            Link selfLink = MakeSelfLink(resource);
        }

        this.MergeLinkRange(name, resources.Select(r => MakeSelfLink(r)));
        this.MergeResource(name, resources);
    }

    /// <summary>
    /// Embed a resource in this resource.
    /// </summary>
    /// <typeparam name="TResource">The type of the resource to embed.</typeparam>
    /// <param name="name">The name under which to embed the resource.</param>
    /// <param name="resources">The resources to embed. They must comply with the HAL reource schema, including a single self link.</param>
    /// <exception cref="ArgumentException">Thrown if the resource to embed does not have a self link.</exception>
    /// <remarks>
    /// <para>
    /// This will embed the resource, and add its self link to the links collection.
    /// </para>
    /// </remarks>
    public void EmbedResourceRange<TResource>(string name, IEnumerable<TResource> resources)
        where TResource : struct, IJsonObject<TResource>
    {
        this.MergeLinkRange(name, resources.Select(resource => MakeSelfLink(resource)));
        this.MergeResourceRange(name, resources.Select(resource => resource.AsAny));
    }

    private static JsonAny MakeLink<TLink>(in TLink link)
        where TLink : struct, IJsonValue
    {
        return link.ValueKind == JsonValueKind.String ? Link.Create(link.AsString) : link.AsAny;
    }

    private static JsonAny MakeSelfLink<TResource>(TResource resource)
        where TResource : struct, IJsonObject<TResource>
    {
        Link selfLink = resource.As<Resource>().Links.Self;

        if (selfLink.IsNullOrUndefined())
        {
            throw new ArgumentException("No self link found for resource.", nameof(resource));
        }

        return selfLink;
    }

    private readonly void MergeResource<TResource>(string name, TResource resource, bool forceArray)
        where TResource : struct, IJsonObject<TResource>
    {
        if (this.resources.TryGetValue(name, out JsonAny er))
        {
            EmbeddedResourceProperty embeddedResource = er.As<EmbeddedResourceProperty>();
            if (embeddedResource.IsResource)
            {
                this.resources[name] = JsonArray.FromItems(embeddedResource, resource.AsAny);
            }
            else
            {
                this.resources[name] = embeddedResource.AsArray.Add(resource.AsAny);
            }
        }
        else
        {
            if (!forceArray)
            {
                this.resources[name] = resource.AsAny;
            }
            else
            {
                this.resources[name] = JsonArray.FromItems(resource.AsAny);
            }
        }
    }

    private readonly void MergeResource<TResource1, TResource2>(string name, TResource1 resource1, TResource2 resource2)
        where TResource1 : struct, IJsonObject<TResource1>
        where TResource2 : struct, IJsonObject<TResource2>
    {
        if (this.resources.TryGetValue(name, out JsonAny er))
        {
            EmbeddedResourceProperty embeddedResource = er.As<EmbeddedResourceProperty>();
            if (embeddedResource.IsResource)
            {
                this.resources[name] = JsonArray.FromItems(embeddedResource, resource1.AsAny, resource2.AsAny);
            }
            else
            {
                this.resources[name] = embeddedResource.AsArray.Add(resource1.AsAny, resource2.AsAny);
            }
        }
        else
        {
            this.resources[name] = JsonArray.FromItems(resource1.AsAny, resource2.AsAny);
        }
    }

    private readonly void MergeResource<TResource>(string name, params TResource[] resources)
    where TResource : struct, IJsonObject<TResource>
    {
        if (this.resources.TryGetValue(name, out JsonAny er))
        {
            EmbeddedResourceProperty embeddedResource = er.As<EmbeddedResourceProperty>();
            if (embeddedResource.IsResource)
            {
                ImmutableArray<JsonAny>.Builder array = ImmutableArray.CreateBuilder<JsonAny>();
                array.Add(embeddedResource);
                array.AddRange(resources.Select(resource => resource.AsAny));
                this.resources[name] = JsonArray.From(array.ToImmutable());
            }
            else
            {
                this.resources[name] = embeddedResource.AsArray.AddRange(resources);
            }
        }
        else
        {
            this.resources[name] = JsonArray.FromRange(resources);
        }
    }

    private readonly void MergeResourceRange(string name, IEnumerable<JsonAny> resources)
    {
        if (this.resources.TryGetValue(name, out JsonAny er))
        {
            EmbeddedResourceProperty embeddedResource = er.As<EmbeddedResourceProperty>();
            if (embeddedResource.IsResource)
            {
                ImmutableArray<JsonAny>.Builder array = ImmutableArray.CreateBuilder<JsonAny>();
                array.Add(embeddedResource);
                array.AddRange(resources);
                this.resources[name] = JsonArray.From(array.ToImmutable());
            }
            else
            {
                this.resources[name] = embeddedResource.AsArray.AddRange(resources);
            }
        }
        else
        {
            this.resources[name] = JsonArray.FromRange(resources);
        }
    }

    private readonly void MergeLink(string name, JsonAny link, bool forceArray)
    {
        if (this.links.TryGetValue(name, out JsonAny el))
        {
            LinkProperty embeddedLink = el.As<LinkProperty>();
            if (embeddedLink.IsLink)
            {
                this.links[name] = JsonArray.FromItems(embeddedLink, link);
            }
            else
            {
                this.links[name] = embeddedLink.AsArray.Add(link);
            }
        }
        else
        {
            if (!forceArray)
            {
                this.links[name] = link;
            }
            else
            {
                this.links[name] = JsonArray.FromItems(link);
            }
        }
    }

    private readonly void MergeLink(string name, JsonAny link1, JsonAny link2)
    {
        if (this.links.TryGetValue(name, out JsonAny el))
        {
            LinkProperty embeddedLink = el.As<LinkProperty>();
            if (embeddedLink.IsLink)
            {
                this.links[name] = JsonArray.FromItems(embeddedLink, link1, link2);
            }
            else
            {
                this.links[name] = embeddedLink.AsArray.Add(link1, link2);
            }
        }
        else
        {
            this.links[name] = JsonArray.FromItems(link1, link2);
        }
    }

    private readonly void MergeLink(string name, JsonAny link1, JsonAny link2, JsonAny link3)
    {
        if (this.links.TryGetValue(name, out JsonAny el))
        {
            LinkProperty embeddedLink = el.As<LinkProperty>();
            if (embeddedLink.IsLink)
            {
                this.links[name] = JsonArray.FromItems(embeddedLink, link1, link2, link3);
            }
            else
            {
                this.links[name] = embeddedLink.AsArray.Add(link1, link2, link3);
            }
        }
        else
        {
            this.links[name] = JsonArray.FromItems(link1, link2, link3);
        }
    }

    private readonly void MergeLink(string name, JsonAny link1, JsonAny link2, JsonAny link3, JsonAny link4)
    {
        if (this.links.TryGetValue(name, out JsonAny el))
        {
            LinkProperty embeddedLink = el.As<LinkProperty>();
            if (embeddedLink.IsLink)
            {
                this.links[name] = JsonArray.FromItems(embeddedLink, link1, link2, link3, link4);
            }
            else
            {
                this.links[name] = embeddedLink.AsArray.Add(link1, link2, link3, link4);
            }
        }
        else
        {
            this.links[name] = JsonArray.FromItems(link1, link2, link3, link4);
        }
    }

    private readonly void MergeLinkRange(string name, IEnumerable<JsonAny> links)
    {
        if (this.links.TryGetValue(name, out JsonAny el))
        {
            LinkProperty embeddedLink = el.As<LinkProperty>();
            JsonArray result;

            if (embeddedLink.TryGetAsLink(out Link link))
            {
                ImmutableArray<JsonAny>.Builder array = ImmutableArray.CreateBuilder<JsonAny>();
                array.Add(link);
                array.AddRange(links);
                result = JsonArray.From(array.ToImmutable());
            }
            else
            {
                result = embeddedLink.AsLinkCollection.AddRange(links);
            }

            this.links[name] = result;
        }
        else
        {
            this.links[name] = JsonArray.FromRange(links);
        }
    }
}