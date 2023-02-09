// <copyright file="ExternalServicesSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps;

using System;
using System.Collections.Generic;

using Menes.Specs.Fakes;

using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

/// <summary>
/// Steps for testing <see cref="IOpenApiExternalServices"/>.
/// </summary>
[Binding]
public class ExternalServicesSteps
{
    private readonly ConfigurationSteps configuration;
    private readonly ServiceCollection services = new();
    private IOpenApiExternalServices? externalServices;
    private Uri? resolvedUrl;

    public ExternalServicesSteps(ConfigurationSteps configuration)
    {
        this.configuration = configuration;

        this.services.AddLogging();
    }

    [Given("I have registered an external service with an embedded definition, passing an IConfiguration directly, and a base URL configuration key of '([^']*)'")]
    public void GivenIHaveRegisteredAnExternalServiceWithAnEmbeddedDefinitionPassingAnIConfigurationAndAConfigurationKey(
        string configurationKey)
    {
        if (this.externalServices is not null)
        {
            throw new InvalidOperationException("External service registration is already complete");
        }

        this.services.AddExternalServices(
            this.configuration.ConfigurationRoot,
            externalServices => externalServices.AddExternalServiceWithEmbeddedDefinition<ExternalOpenApiService>(configurationKey));
    }

    [When("I resolve an external service URL for the operation '([^']*)' with these parameters")]
    public void WhenIResolveAnExternalServiceUrlForTheOperationWithTheseParameters(
        string operationId, Table table)
    {
        List<(string Name, object? Value)> parameters = new();
        foreach ((string name, string type, string valueText) in table.CreateSet<(string Name, string Type, string Value)>())
        {
            object value = Convert.ChangeType(valueText, Type.GetType(type) ?? throw new InvalidOperationException($"Unrecognized type {type}"));
            parameters.Add((name, value));
        }

        this.externalServices ??= this.services.BuildServiceProvider().GetRequiredService<IOpenApiExternalServices>();

        this.resolvedUrl = this.externalServices.ResolveUrl<ExternalOpenApiService>(operationId, parameters.ToArray());
    }

    [Then("the resolved external service URL is '([^']*)'")]
    public void ThenTheResolvedExternalServiceURLIs(Uri expectedUrl)
    {
        Assert.AreEqual(expectedUrl, this.resolvedUrl);
    }
}