// <copyright file="OpenApiAccessCheckerExtensionsSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Corvus.Testing.SpecFlow;
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
        private readonly ScenarioContext scenarioContext;
        private List<(string Uri, string Method)> checksToDeny = new();

        public OpenApiAccessCheckerExtensionsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("I have a HalDocument called '(.*)'")]
        public void GivenIHaveAHalDocumentCalled(string halDocumentName)
        {
            IHalDocumentFactory halDocumentFactory = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IHalDocumentFactory>();

            this.scenarioContext.Set(halDocumentFactory.CreateHalDocument(), halDocumentName);
        }

        [Given("the HalDocument called '(.*)' has internal links")]
        public void GivenTheHalDocumentCalledHasInternalLinks(string halDocumentName, Table openApiWebLinkTable)
        {
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);

            openApiWebLinkTable.Rows.ForEach(
                row => doc.AddLink(
                    row["Rel"],
                    new OpenApiWebLink(
                        row["OperationId"],
                        row["Href"],
                        Enum.Parse<OperationType>(row["OperationType"], true))));
        }

        [Given("the HalDocument called '(.*)' has embedded resources")]
        public void GivenTheHalDocumentCalledHasEmbeddedResources(string halDocumentName, Table embeddedResourceTable)
        {
            IHalDocumentFactory halDocumentFactory =
                ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IHalDocumentFactory>();

            IEnumerable<(string Rel, object Object)> embeddedResources =
                embeddedResourceTable.CreateSet<(string Rel, object Object)>();
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);
            embeddedResources.ForEach(x => doc.AddEmbeddedResource(x.Rel, CreateHalDocument(x, halDocumentFactory)));
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
            mock.Setup(x => x.CheckAccessPoliciesAsync(It.IsAny<IOpenApiContext>(), It.IsAny<AccessCheckOperationDescriptor[]>())).Returns((IOpenApiContext _, AccessCheckOperationDescriptor[] descriptors) => this.MockCheckAccessPoliciesAsync(descriptors));

            // Normally this would be invoked as an extension method on mock.Object,
            // but it's invoked as a static method here as otherwise it looks like we're
            // running our test against a mock, which is misleading.
#pragma warning disable RCS1196 // Call extension method as instance method.
            return OpenApiAccessCheckerExtensions.RemoveForbiddenLinksAsync(mock.Object, doc, new SimpleOpenApiContext(), Enum.Parse<HalDocumentLinkRemovalOptions>(optionsTable.Rows[0][0]));
#pragma warning restore RCS1196 // Call extension method as instance method.
        }

        [Then("the HalDocument called '(.*)' should contain only the following link relations")]
        public void ThenTheHalDocumentCalledShouldContainOnlyTheFollowingLinkRelations(string halDocumentName, Table expectedLinkRelationsTable)
        {
            string[] expectedLinkRelations = expectedLinkRelationsTable.Rows.Select(x => x[0]).ToArray();
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);

            expectedLinkRelations.ForEach(expected => Assert.IsTrue(doc.GetLinksForRelation(expected).Any()));

            (string, WebLink)[] unexpectedLinkRelations = doc.GetLinkRelations().Where(actualRel => !expectedLinkRelations.Any(rel => actualRel == rel)).SelectMany(rel => doc.GetLinksForRelation(rel).Select(d => (rel, d))).ToArray();

            Assert.IsEmpty(unexpectedLinkRelations, $"HalDocument called \"{halDocumentName}\" contains unexpected link relations: {string.Join(", ", unexpectedLinkRelations.Select(l => l.Item1))}");
        }

        [Then("the HalDocument called '(.*)' should contain only the following embedded resources")]
        public void ThenTheHalDocumentCalledShouldContainOnlyTheFollowingEmbeddedResources(string halDocumentName, Table expectedEmbeddedResourcesTable)
        {
            string[] expectedEmbeddedResources = expectedEmbeddedResourcesTable.Rows.Select(x => x[0]).ToArray();
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);

            IEnumerable<string> relations = doc.GetEmbeddedResourceRelations().ToList();
            expectedEmbeddedResources.ForEach(expected => Assert.IsTrue(relations.Any(r => r == expected)));

            string[] unexpectedEmbeddedResources = relations.Where(r => !expectedEmbeddedResources.Any(rel => r == rel)).ToArray();

            Assert.IsEmpty(unexpectedEmbeddedResources, $"HalDocument called \"{halDocumentName}\" contains unexpected embedded resources: {string.Join(", ", unexpectedEmbeddedResources)}");
        }

        [Then("the HalDocument called '(.*)' should contain no embedded resources")]
        public void ThenTheHalDocumentCalledShouldContainNoEmbeddedResources(string halDocumentName)
        {
            HalDocument doc = this.scenarioContext.Get<HalDocument>(halDocumentName);
            Assert.IsEmpty(doc.EmbeddedResources);
        }

        private static HalDocument CreateHalDocument((string Rel, object Object) x, IHalDocumentFactory halDocumentFactory)
        {
            if (x.Object is HalDocument hal)
            {
                return hal;
            }

            HalDocument doc = halDocumentFactory.CreateHalDocumentFrom(x.Object ?? new object());
            doc.AddLink(x.Rel, new WebLink("/some/link"));
            return doc;
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