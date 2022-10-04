// <copyright file="MenesOperation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System.Collections.Immutable;
using System.Text;
using Corvus.Json.UriTemplates;

using InEntity = Menes.OpenApiSchema.V31.Document.Parameter.InEntity;

namespace Menes.OpenApi.CodeGeneration;

/// <summary>
/// An Open API operation for generation.
/// </summary>
public class MenesOperation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MenesOperation"/> class.
    /// </summary>
    /// <param name="id">The service-unique ID for the operation.</param>
    /// <param name="verb">The HTTP verb associated with the operation.</param>
    /// <param name="path">The path for the operation.</param>
    /// <param name="dotnetTypeName">The dotnet name for the operation.</param>
    /// <param name="requestBodyMediaTypes">The request body media types.</param>
    /// <param name="responses">The operation response.</param>
    /// <param name="parameters">The operation parameters.</param>
    /// <param name="summary">Summary documentation for the property.</param>
    public MenesOperation(string id, string verb, string path, string dotnetTypeName, ImmutableArray<MenesRequestBodyMediaType>? requestBodyMediaTypes, ImmutableArray<MenesResponse> responses, ImmutableDictionary<string, MenesParameter> parameters, string? summary)
    {
        this.Id = id;
        this.Verb = verb;
        this.Path = path;
        this.DotnetTypeName = dotnetTypeName;
        this.RequestBodyMediaTypes = requestBodyMediaTypes ?? default;
        this.Responses = responses;
        this.Parameters = parameters;
        this.Summary = summary;
    }

    /// <summary>
    /// Gets a value indicating whether this operation has a request body parameter.
    /// </summary>
    public bool HasRequestBodyParameter => !this.RequestBodyMediaTypes.IsDefault;

    /// <summary>
    /// Gets the service-unique ID for the operation.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the HTTP verb associated with the operation.
    /// </summary>
    public string Verb { get; }

    /// <summary>
    /// Gets the path for the operation.
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// Gets the dotnet name for the operation.
    /// </summary>
    public string DotnetTypeName { get; }

    /// <summary>
    /// Gets the dotnet name for the operation result.
    /// </summary>
    public string ResultDotnetTypeName => this.DotnetTypeName + "Result";

    /// <summary>
    /// Gets a value indicating whether this operation has responses.
    /// </summary>
    public bool HasResponses => !this.Responses.IsDefault;

    /// <summary>
    /// Gets the request body media types.
    /// </summary>
    public ImmutableArray<MenesRequestBodyMediaType> RequestBodyMediaTypes { get; }

    /// <summary>
    /// Gets the responses for the operation.
    /// </summary>
    public ImmutableArray<MenesResponse> Responses { get; }

    /// <summary>
    /// Gets the parameters for the operation.
    /// </summary>
    public ImmutableDictionary<string, MenesParameter> Parameters { get; }

    /// <summary>
    /// Gets the summary documentation for the operation.
    /// </summary>
    public string? Summary { get; }

    /// <summary>
    /// Gets the path template for the operation.
    /// </summary>
    /// <returns>A URI template for the given path.</returns>
    /// <remarks>
    /// This is the path transformed into a URI template for parameter extraction
    /// and URI matching.
    /// </remarks>
    public UriTemplate BuildPathTemplate()
    {
        var builder = new StringBuilder(this.Path);
        foreach (KeyValuePair<string, MenesParameter> parameter in this.Parameters)
        {
            if (parameter.Key == InEntity.EnumValues.Query)
            {
                if (parameter.Value.ParameterValue.Explode)
                {
                    builder.Replace($"{{{parameter.Key}}}", $"{{?{parameter.Key}*}}");
                }
                else
                {
                    builder.Replace($"{{{parameter.Key}}}", $"{{?{parameter.Key}}}");
                }
            }
            else if (parameter.Value.ParameterValue.In == InEntity.EnumValues.Path)
            {
                if (parameter.Value.ParameterValue.Explode)
                {
                    if (parameter.Value.ParameterValue.Style == "matrix")
                    {
                        builder.Replace($"{{{parameter.Key}}}", $"{{;{parameter.Key}*}}");
                    }
                    else if (parameter.Value.ParameterValue.Style == "label")
                    {
                        builder.Replace($"{{{parameter.Key}}}", $"{{.{parameter.Key}*}}");
                    }
                    else
                    {
                        // For all other cases, we just need the simple replacement
                        builder.Replace($"{{{parameter.Key}}}", $"{{{parameter.Key}*}}");
                    }
                }
                else
                {
                    if (parameter.Value.ParameterValue.Style == "matrix")
                    {
                        builder.Replace($"{{{parameter.Key}}}", $"{{;{parameter.Key}}}");
                    }
                    else if (parameter.Value.ParameterValue.Style == "label")
                    {
                        builder.Replace($"{{{parameter.Key}}}", $"{{.{parameter.Key}}}");
                    }

                    // For all other cases, we just need the simple replacement (non-exploded, which is exactly what we already have.)
                }
            }
        }

        return new UriTemplate(builder.ToString());
    }
}