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
            var targetType = Type.GetType(typeName);
            object data = properties.CreateInstance(() => Activator.CreateInstance(targetType));
            this.scenarioContext.Set(data, objectName);
        }
    }
}