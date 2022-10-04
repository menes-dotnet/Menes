// <copyright file="MenesParameter.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Menes.OpenApiSchema.V31;

namespace Menes.OpenApi.CodeGeneration;

/// <summary>
/// A parameter for an operation.
/// </summary>
public class MenesParameter
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MenesParameter"/> class.
    /// </summary>
    /// <param name="name">The parameter name.</param>
    /// <param name="location">The absolute location in the source document of the parameter value.</param>
    /// <param name="parameterValue">The OpenAPI parameter definition.</param>
    public MenesParameter(string name, string location, Document.Parameter parameterValue)
    {
        this.Name = name;
        this.Location = location;
        this.ParameterValue = parameterValue;
    }

    /// <summary>
    /// Gets the name of the parameter.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the location for the parameter value (for reference resolution).
    /// </summary>
    public string Location { get; }

    /// <summary>
    /// Gets the OpenAPI parameter definition.
    /// </summary>
    public Document.Parameter ParameterValue { get; }
}