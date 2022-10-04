// <copyright file="MenesResponseHeader.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApi.CodeGeneration;

/// <summary>
/// Represents an HTTP header.
/// </summary>
public class MenesResponseHeader
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MenesResponseHeader"/> class.
    /// </summary>
    /// <param name="name">The name of the header.</param>
    /// <param name="schemaReference">The $ref to the schema for the header.</param>
    /// <param name="isRequired">If true, the header is required.</param>
    /// <param name="contentMediaType">The content media type for the header, if specified.</param>
    public MenesResponseHeader(string name, string schemaReference, bool isRequired, string? contentMediaType)
    {
        this.Name = name;
        this.SchemaReference = schemaReference;
        this.IsRequired = isRequired;
        this.ContentMediaType = contentMediaType;
    }

    /// <summary>
    /// Gets the name of the header.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the content media type for the header, if specified.
    /// </summary>
    public string? ContentMediaType { get; }

    /// <summary>
    /// Gets a value indicating whether the header is required.
    /// </summary>
    public bool IsRequired { get; }

    /// <summary>
    /// Gets the schema reference for the header.
    /// </summary>
    public string SchemaReference { get; }
}