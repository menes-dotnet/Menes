// <copyright file="ExternalOpenApiService.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Fakes;

/// <summary>
/// A class representing an OpenApi service for use by the IOpenApiExternalServices tests.
/// </summary>
/// <remarks>
/// The tests never hit any of the endpoints for this service. The class's only purpose in the
/// test is to enable the code under test to locate the OpenAPI YAML. So the only thing we need
/// here is the <see cref="EmbeddedOpenApiDefinitionAttribute"/>.
/// </remarks>
[EmbeddedOpenApiDefinition("Menes.Specs.Fakes.ExternalOpenApiService.yaml")]
public class ExternalOpenApiService : IOpenApiService
{
}