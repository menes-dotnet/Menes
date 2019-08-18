// <copyright file="HalDocumentJsonConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.Reflection;
    using Menes.Links;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// A type converter for serializing a <see cref="HalDocument{T}"/> as a standard
    /// HAL document, with the properties of the <see cref="HalDocument{T}.Data"/> property
    /// lifted up to appear as direct children of the document.
    /// </summary>
    public class HalDocumentJsonConverter : JsonConverter
    {
        private static readonly Type HalDocumentGenericTypeDefinition = typeof(HalDocument<>);

        /// <inheritdoc/>
        public override bool CanRead => false;

        /// <inheritdoc/>
        public override bool CanWrite => true;

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && objectType.GetGenericTypeDefinition() == HalDocumentGenericTypeDefinition;
        }

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type valueType = value.GetType();

            // Get the internal HalDocument property and serialize it to a JObject.
            // Note that the use of HalDocument<WebLink> is only so we can use nameof to get the property name -
            // you can't reference the property as HalDocument<>.HalDocumentInternal.
            PropertyInfo halDocumentProperty = valueType.GetProperty(nameof(HalDocument<WebLink>.HalDocumentInternal), BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Instance);
            object halDocumentValue = halDocumentProperty.GetValue(value);
            var halDocument = JObject.FromObject(halDocumentValue, serializer);

            // Get the data property and serialize that to a separate JObject.
            PropertyInfo dataProperty = valueType.GetProperty(nameof(HalDocument<WebLink>.Data), BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            object dataValue = dataProperty.GetValue(value);
            var dataDocument = JObject.FromObject(dataValue, serializer);

            halDocument.Merge(dataDocument, new JsonMergeSettings { MergeNullValueHandling = MergeNullValueHandling.Ignore });

            serializer.Serialize(writer, halDocument);
        }
    }
}
