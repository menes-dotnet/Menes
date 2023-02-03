// <copyright file="ConfigurationSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps;

using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;

using TechTalk.SpecFlow;

/// <summary>
/// Steps for working with <see cref="IConfiguration"/>.
/// </summary>
[Binding]
public class ConfigurationSteps
{
    private readonly Dictionary<string, string?> settings = new();
    private IConfigurationRoot? builtConfiguration = null;

    public IConfigurationRoot ConfigurationRoot => this.builtConfiguration ??=
        new ConfigurationBuilder().AddInMemoryCollection(this.settings).Build();

    [Given("my configuration contains the setting '([^']*)' with the value '([^']*)'")]
    public void GivenMyConfigurationContainsTheSettingWithTheValue(string settingName, string settingValue)
    {
        if (this.builtConfiguration is not null)
        {
            throw new InvalidOperationException("The IConfigurationRoot has already been created (because some other test step asked for it) so it is too late to add more configuration settings");
        }

        this.settings.Add(settingName, settingValue);
    }
}