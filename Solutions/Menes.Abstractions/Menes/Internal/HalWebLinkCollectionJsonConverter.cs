// <copyright file="HalWebLinkCollectionJsonConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Menes.Links;
    using Newtonsoft.Json;

    /// <summary>
    /// A type converter for serializing a collection of OpenApi links to a form that matches the links section
    /// of the HAL specification (http://stateless.co/hal_specification.html).
    /// </summary>
    public class HalWebLinkCollectionJsonConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanRead => false;

        /// <inheritdoc/>
        public override bool CanWrite => true;

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType) => objectType == typeof(HalWebLinkCollection);

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var result = new Dictionary<string, object>();
            var links = (WebLinkCollection)value;

            foreach (IGrouping<string, WebLink> current in links.GroupBy(x => x.Rel))
            {
                string rel = current.First().Rel;

                if (current.Count() == 1)
                {
                    result.Add(rel, this.BuildHalLink(current.First()));
                }
                else
                {
                    result.Add(rel, this.BuildHalLink(current));
                }
            }

            serializer.Serialize(writer, result);
        }

        private object[] BuildHalLink(IEnumerable<WebLink> current)
        {
            return current.Select(this.BuildHalLink).ToArray();
        }

        private object BuildHalLink(WebLink webLink)
        {
            return new { webLink.Href };
        }
    }
}
