// <copyright file="OpenApiAccessCheckerExtensionsSteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CS1591 // Elements should be documented

namespace Menes.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Corvus.SpecFlow.Extensions;
    using Menes.Hal;
    using Menes.Links;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Moq;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    [Binding]
    public class OpenApiAccessCheckerExtensionsSteps
    {
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;
        private List<(string Uri, string Method)> checksToDeny = new List<(string Uri, string Method)>();

        public OpenApiAccessCheckerExtensionsSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
        }

        [Given("I have a HalDocument called '(.*)'")]
        public void GivenIHaveAHalDocumentCalled(string halDocumentName)
        {
            IHalDocumentFactory halDocumentFactory = ContainerBindings.GetServiceProvider(this.featureContext).GetService<IHalDocumentFactory>();

            this.scenarioContext.Set(halDocumentFactory.CreateHalDocument(), halDocumentName);
        }

        [Given("the HalDocument called '(.*)' has internal links")]
        public void GivenTheHalDocumentCalledHasInternalLinks(string halDocumentName, Table openApiWebLinkTable)
        {
            IEnumerable<OpenApiWebLink> links = openApiWebLinkTable.CreateSet(() => new OpenApiWebLink(string.Empty, string.Empty, string.Empty, OperationType.Get));
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);
            links.ForEach(doc.AddLink);
        }

        [Given("the HalDocument called '(.*)' has embedded resources")]
        public void GivenTheHalDocumentCalledHasEmbeddedResources(string halDocumentName, Table embeddedResourceTable)
        {
            IHalDocumentFactory halDocumentFactory = ContainerBindings.GetServiceProvider(this.featureContext).GetService<IHalDocumentFactory>();

            IEnumerable<(string Rel, object Object)> embeddedResources = embeddedResourceTable.CreateSet<(string Rel, object Object)>();
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);
            embeddedResources.ForEach(x => doc.AddEmbeddedResource(x.Rel, halDocumentFactory.CreateHalDocumentFrom(x.Object ?? new object())));
        }

        [Given("the current user does not have permission to")]
        public void GivenTheCurrentUserDoesNotHavePermissionTo(Table table)
        {
            this.checksToDeny = table.CreateSet<(string Url, string Method)>().ToList();
        }

        [When("I ask the access checker to remove forbidden links from the HalDocument called '(.*)' with the following options")]
        public Task WhenIRequestAnAccessCheckOnTheHalDocumentCalledWithTheFollowingOptions(string halDocumentName, Table optionsTable)
        {
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);
            var mock = new Mock<IOpenApiAccessChecker>();
            mock.Setup(x => x.CheckAccessPoliciesAsync(It.IsAny<IOpenApiContext>(), It.IsAny<AccessCheckOperationDescriptor[]>())).Returns((IOpenApiContext context, AccessCheckOperationDescriptor[] descriptors) => this.MockCheckAccessPoliciesAsync(descriptors));

            // Normally this would be invoked as an extension method on mock.Object,
            // but it's invoked as a static method here as otherwise it looks like we're
            // running our test against a mock, which is misleading.
            return OpenApiAccessCheckerExtensions.RemoveForbiddenLinksAsync(mock.Object, doc, new SimpleOpenApiContext(), Enum.Parse<HalDocumentLinkRemovalOptions>(optionsTable.Rows[0][0]));
        }

        [Then("the HalDocument called '(.*)' should contain only the following link relations")]
        public void ThenTheHalDocumentCalledShouldContainOnlyTheFollowingLinkRelations(string halDocumentName, Table expectedLinkRelationsTable)
        {
            string[] expectedLinkRelations = expectedLinkRelationsTable.Rows.Select(x => x[0]).ToArray();
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);

            expectedLinkRelations.ForEach(expected => doc.Links.Any(l => l.Rel == expected));

            WebLink[] unexpectedLinkRelations = doc.Links.Where(link => !expectedLinkRelations.Any(rel => link.Rel == rel)).ToArray();

            Assert.IsEmpty(unexpectedLinkRelations, $"HalDocument called \"{halDocumentName}\" contains unexpected link relations: {string.Join(", ", unexpectedLinkRelations.Select(l => l.Rel))}");
        }

        [Then("the HalDocument called '(.*)' should contain only the following embedded resources")]
        public void ThenTheHalDocumentCalledShouldContainOnlyTheFollowingEmbeddedResources(string halDocumentName, Table expectedEmbeddedResourcesTable)
        {
            string[] expectedEmbeddedResources = expectedEmbeddedResourcesTable.Rows.Select(x => x[0]).ToArray();
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);

            IEnumerable<string> relations = doc.GetEmbeddedResourceRelations().ToList();
            expectedEmbeddedResources.ForEach(expected => relations.Any(r => r == expected));

            string[] unexpectedEmbeddedResources = relations.Where(r => !expectedEmbeddedResources.Any(rel => r == rel)).ToArray();

            Assert.IsEmpty(unexpectedEmbeddedResources, $"HalDocument called \"{halDocumentName}\" contains unexpected embedded resources: {string.Join(", ", unexpectedEmbeddedResources)}");
        }

        [Then("the HalDocument called '(.*)' should contain no embedded resources")]
        public void ThenTheHalDocumentCalledShouldContainNoEmbeddedResources(string halDocumentName)
        {
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);
            Assert.IsEmpty(doc.EmbeddedResources);
        }

        private Task<IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult>> MockCheckAccessPoliciesAsync(AccessCheckOperationDescriptor[] operationDescriptors)
        {
            IDictionary<AccessCheckOperationDescriptor, AccessControlPolicyResult> result = operationDescriptors.ToDictionary(
                check => check,
                check => new AccessControlPolicyResult(this.checksToDeny.Any(denial => denial.Method == check.Method && denial.Uri == check.Path) ? AccessControlPolicyResultType.NotAllowed : AccessControlPolicyResultType.Allowed));

            return Task.FromResult(result);
        }
    }
}
