// <copyright file="MenesResponse.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.OpenApi.CodeGeneration;

/// <summary>
/// An operation response.
/// </summary>
public class MenesResponse
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MenesResponse"/> class.
    /// </summary>
    /// <param name="statusCode">The response status code.</param>
    /// <param name="dotnetTypeName">The dotnet type name for the response instance.</param>
    /// <param name="hasBody">True if the response has a body, otherwise false.</param>
    /// <param name="isBodyRequired">True if the response has a required body, otherwise false.</param>
    /// <param name="bodyIsNotJson">True is the body is not JSON.</param>
    /// <param name="bodyIsFormUrlEncoded">True if the body is Form URL encoded.</param>
    /// <param name="bodyIsMultipart">True if the body is Multipart form encoded.</param>
    public MenesResponse(string statusCode, string dotnetTypeName, bool hasBody, bool isBodyRequired, bool bodyIsNotJson, bool bodyIsFormUrlEncoded, bool bodyIsMultipart)
    {
        this.StatusCode = statusCode;
        this.DotnetTypeName = dotnetTypeName;
        this.HasBody = hasBody;
        this.IsBodyRequired = isBodyRequired;
        this.BodyIsNotJson = bodyIsNotJson;
        this.BodyIsFormUrlEncoded = bodyIsFormUrlEncoded;
        this.BodyIsMultipart = bodyIsMultipart;
    }

    /// <summary>
    /// Gets the response status code as a string.
    /// </summary>
    public string StatusCode { get; }

    /// <summary>
    /// Gets the dotnet type name for the response.
    /// </summary>
    public string DotnetTypeName { get; }

    /// <summary>
    /// Gets a value indicating whether the response has a body.
    /// </summary>
    public bool HasBody { get; }

    /// <summary>
    /// Gets a value indicating whether the response body is required.
    /// </summary>
    public bool IsBodyRequired { get; }

    /// <summary>
    /// Gets a value indicating whether the response body is not JSON.
    /// </summary>
    /// <remaks>
    /// <c>True</c> if the body is NOT represented as JSON.
    /// </remaks>
    public bool BodyIsNotJson { get; }

    /// <summary>
    /// Gets a value indicating whether the body is Form Url encoded.
    /// </summary>
    public bool BodyIsFormUrlEncoded { get; }

    /// <summary>
    /// Gets a value indicating whether th body is multipart form encoded.
    /// </summary>
    public bool BodyIsMultipart { get; }
}