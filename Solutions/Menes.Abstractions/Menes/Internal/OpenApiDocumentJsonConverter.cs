// <copyright file="OpenApiDocumentJsonConverter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Internal
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using Microsoft.OpenApi;
    using Microsoft.OpenApi.Extensions;
    using Microsoft.OpenApi.Models;

    /// <summary>
    ///     Converts OpenApiDocuments to JSON using <see cref="OpenApiSerializableExtensions.SerializeAsJson{T}(T,Stream,OpenApiSpecVersion)"/>
    ///     extension method.
    /// </summary>
    public class OpenApiDocumentJsonConverter : JsonConverter<OpenApiDocument>
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return typeof(OpenApiDocument) == objectType;
        }

        /// <inheritdoc />
        public override OpenApiDocument? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, OpenApiDocument value, JsonSerializerOptions options)
        {
            using var stream = new MemoryStream();
            value.SerializeAsJson(stream, OpenApiSpecVersion.OpenApi3_0);
            stream.Seek(0, SeekOrigin.Begin);
            ReadOnlySpan<byte> buffer = stream.GetBuffer();

            Utf8JsonReader r = new(buffer[0..((int)stream.Length)]);
            using var doc = JsonDocument.ParseValue(ref r);
            doc.WriteTo(writer);
        }
    }
}