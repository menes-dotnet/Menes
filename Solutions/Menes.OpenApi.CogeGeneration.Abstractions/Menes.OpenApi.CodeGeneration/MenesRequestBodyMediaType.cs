// <copyright file="MenesRequestBodyMediaType.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApi.CodeGeneration;

/// <summary>
/// A media type declaration in a request body.
/// </summary>
public class MenesRequestBodyMediaType
{
    private readonly string mediaType;

    /// <summary>
    /// Initializes a new instance of the <see cref="MenesRequestBodyMediaType"/> class.
    /// </summary>
    /// <param name="mediaType">The name of the media type.</param>
    /// <param name="dotnetName">The pascal-cased dotnet name for this media type.</param>
    /// <param name="requestBodyFullyQualifiedDotnetTypeName">The fully-qualified dotnet type name for the request body type.</param>
    public MenesRequestBodyMediaType(string mediaType, string dotnetName, string requestBodyFullyQualifiedDotnetTypeName)
    {
        this.mediaType = mediaType;
        this.DotnetName = dotnetName;
        this.RequestBodyFullyQualifiedDotnetTypeName = requestBodyFullyQualifiedDotnetTypeName;
    }

    /// <summary>
    /// Gets the pascal-cased dotnet name for this request body media type.
    /// </summary>
    public string DotnetName { get; }

    /// <summary>
    /// Gets the fully qualified dotnet type name for the request body type corresponding
    /// to this media type.
    /// </summary>
    public string RequestBodyFullyQualifiedDotnetTypeName { get; }

    /// <summary>
    /// Gets a value indicating whether this media type is multipart/form-data or application/x-www-form-urlencoded.
    /// </summary>
    public bool IsMultipartOrFormUrlEncoded
    {
        get
        {
            return this.IsMultipart || this.IsFormUrlEncoded;
        }
    }

    /// <summary>
    /// Gets a value indicating whether this media type is multipart/form-data or application/x-www-form-urlencoded.
    /// </summary>
    public bool IsMultipart
    {
        get
        {
            return this.mediaType.Equals("multipart/form-data", StringComparison.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// Gets a value indicating whether this media type is multipart/form-data or application/x-www-form-urlencoded.
    /// </summary>
    public bool IsFormUrlEncoded
    {
        get
        {
            return this.mediaType.Equals("application/x-www-form-urlencoded", StringComparison.OrdinalIgnoreCase);
        }
    }
}