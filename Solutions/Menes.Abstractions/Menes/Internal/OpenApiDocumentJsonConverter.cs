// <copyright file="OpenApiDocumentJsonConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.IO;

    using Microsoft.OpenApi;
    using Microsoft.OpenApi.Extensions;
    using Microsoft.OpenApi.Models;

    using Newtonsoft.Json;

    /// <summary>
    ///     Converts OpenApiDocuments to JSON using <see cref="OpenApiSerializableExtensions.SerializeAsJson{T}(T,Stream,OpenApiSpecVersion)"/>
    ///     extension method.
    /// </summary>
    public class OpenApiDocumentJsonConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanRead => false;

        /// <inheritdoc />
        public override bool CanWrite => true;

        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return typeof(OpenApiDocument) == objectType;
        }

        /// <inheritdoc />
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var document = (OpenApiDocument)value;

            using var stream = new MemoryStream();
            document.SerializeAsJson(stream, OpenApiSpecVersion.OpenApi2_0);
            stream.Seek(0, SeekOrigin.Begin);

            using var reader = new StreamReader(stream);
            string json = reader.ReadToEnd();
            writer.WriteRaw(json);
        }
    }
}