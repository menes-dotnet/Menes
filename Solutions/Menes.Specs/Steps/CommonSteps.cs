// <copyright file="OpenApiWebLinkResolverSteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext scenarioContext;

        public CommonSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("I have an object called '(.*)' of type '(.*)'")]
        public void GivenIHaveAnObjectCalledOfType(string objectName, string typeName, Table properties)
        {
            Type targetType = Type.GetType(typeName) ?? throw new InvalidOperationException($"Unable to get type info for {typeName}");
            object data = properties.CreateInstance(() => Activator.CreateInstance(targetType)) ?? throw new InvalidOperationException($"Unable to create instance of {typeName}");
            this.scenarioContext.Set(data, objectName);
        }
    }
}