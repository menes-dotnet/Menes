// <copyright file="HalDocument.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Links
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Base class for documents that wish to follow the HAL specification (http://stateless.co/hal_specification.html).
    /// </summary>
    public class HalDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HalDocument"/> class.
        /// </summary>
        public HalDocument()
        {
            this.Links = new HalWebLinkCollection();
            this.EmbeddedResources = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets a collection of links to other resources.
        /// </summary>
        [JsonProperty("_links")]
        public virtual HalWebLinkCollection Links { get; }

        /// <summary>
        /// Gets a collection of other resources.
        /// </summary>
        [JsonProperty("_embedded")]
        public virtual IDictionary<string, object> EmbeddedResources { get; }

        /// <summary>
        /// Gets the current value of the embedded resource with the given key.
        /// </summary>
        /// <typeparam name="T">The type of the embedded resource.</typeparam>
        /// <param name="key">The key of the embedded resource.</param>
        /// <param name="defaultValueProvider">A function that can be used to create a default value for the embedded resource if it's not present in the dictionary.</param>
        /// <returns>The resource, or null if it hasn't been set.</returns>
        public T GetEmbeddedResource<T>(string key, Func<T> defaultValueProvider = null)
        {
            if (this.EmbeddedResources.TryGetValue(key, out object result))
            {
                return (T)result;
            }

            T newValue = defaultValueProvider == null ? default : defaultValueProvider();
            this.SetEmbeddedResource(key, newValue);

            return newValue;
        }

        /// <summary>
        /// Adds or updates the given resource in the collection of embedded resources.
        /// </summary>
        /// <typeparam name="T">The type of the resource.</typeparam>
        /// <param name="key">They key of the resource.</param>
        /// <param name="resource">The resource to add.</param>
        public void SetEmbeddedResource<T>(string key, T resource)
        {
            this.EmbeddedResources[key] = resource;
        }
    }
}
