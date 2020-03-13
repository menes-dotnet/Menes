// <copyright file="LinkCollectionExtensionsSteps.cs" company="Endjin">
// Copyright (c) Endjin. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using Menes.Links;
    using Microsoft.OpenApi.Models;
    using Moq;
    using TechTalk.SpecFlow;

    [Binding]
    public class LinkCollectionExtensionsSteps
    {
        private readonly ScenarioContext scenarioContext;
        private readonly Mock<IOpenApiWebLinkResolver> resolver = new Mock<IOpenApiWebLinkResolver>();
        private readonly Mock<ILinkCollection> linkCollection = new Mock<ILinkCollection>();

        public LinkCollectionExtensionsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("my link resolver returns a link called '(.*)' when resolving by owner and relation")]
        public void GivenMyLinkResolverReturnsALinkCalledWhenResolvingByOwnerAndRelation(string linkName)
        {
            var link = new OpenApiWebLink("op", "l", OperationType.Get);
            this.resolver
                .Setup(r => r.ResolveByOwnerAndRelationType(It.IsAny<object>(), It.IsAny<string>(), It.IsAny<(string, object?)[]>()))
                .Returns(link);
            this.scenarioContext.Set(link, linkName);
        }

        [Given("my link resolver returns a link called '(.*)' when resolving by owner, relation, and context")]
        public void GivenMyLinkResolverReturnsALinkCalledWhenResolvingByOwnerRelationAndContext(string linkName)
        {
            var link = new OpenApiWebLink("op", "l", OperationType.Get);
            this.resolver
                .Setup(r => r.ResolveByOwnerAndRelationTypeAndContext(It.IsAny<object>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<(string, object?)[]>()))
                .Returns(link);
            this.scenarioContext.Set(link, linkName);
        }

        [Given("my link resolver returns a link called '(.*)' when resolving by operation id and relation")]
        public void GivenMyLinkResolverReturnsALinkCalledWhenResolvingByOperationIdAndRelation(string linkName)
        {
            var link = new OpenApiWebLink("op", "l", OperationType.Get);
            this.resolver
                .Setup(r => r.ResolveByOperationIdAndRelationType(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<(string, object?)[]>()))
                .Returns(link);
            this.scenarioContext.Set(link, linkName);
        }

        [When("I resolve and add a relation for the owner '(.*)' and the relation '(.*)'")]
        public void WhenIResolveAndAddARelationForTheOwnerAndTheRelation(string objectName, string relation)
        {
            object target = this.scenarioContext.Get<object>(objectName);
            this.linkCollection.Object.ResolveAndAddByOwnerAndRelationType(this.resolver.Object, target, relation);
        }

        [When("I resolve and add a relation for the owner '(.*)', the relation '(.*)', and the context '(.*)'")]
        public void WhenIResolveAndAddARelationForTheOwnerTheRelationAndTheContext(string objectName, string relation, string context)
        {
            object target = this.scenarioContext.Get<object>(objectName);
            this.linkCollection.Object.ResolveAndAddByOwnerAndRelationTypeAndContext(this.resolver.Object, target, relation, context);
        }

        [When("I resolve and add a relation for the operation '(.*)' and the relation '(.*)'")]
        public void WhenIResolveAndAddARelationForTheOperationAndTheRelation(string operationId, string relation)
        {
            this.linkCollection.Object.ResolveAndAddByOperationIdAndRelationType(this.resolver.Object, operationId, relation);
        }

        [Then("the link resolver should have been asked to resolve for the owner '(.*)' and the relation '(.*)'")]
        public void ThenTheLinkResolverShouldHaveBeenAskedToResolveForTheOwnerAndTheRelation(string objectName, string relation)
        {
            object target = this.scenarioContext.Get<object>(objectName);
            this.resolver
                .Verify(r => r.ResolveByOwnerAndRelationType(target, relation, It.IsAny<(string, object?)[]>()));
        }

        [Then("the link resolver should have been asked to resolve for the owner '(.*)', the relation '(.*)', and the context '(.*)'")]
        public void ThenTheLinkResolverShouldHaveBeenAskedToResolveForTheOwnerTheRelationAndTheContext(string objectName, string relation, string context)
        {
            object target = this.scenarioContext.Get<object>(objectName);
            this.resolver
                .Verify(r => r.ResolveByOwnerAndRelationTypeAndContext(target, relation, context, It.IsAny<(string, object?)[]>()));
        }

        [Then("the link resolver should have been asked to resolve for the operation '(.*)' and the relation '(.*)'")]
        public void ThenTheLinkResolverShouldHaveBeenAskedToResolveForTheOperationAndTheRelation(string operationId, string relation)
        {
            this.resolver
                .Verify(r => r.ResolveByOperationIdAndRelationType(operationId, relation, It.IsAny<(string, object?)[]>()));
        }

        [Then("the link '(.*)' should have been added to the link collection with relation '(.*)'")]
        public void ThenTheLinkShouldHaveBeenAddedToTheLinkCollectionWithRelation(string linkName, string relation)
        {
            OpenApiWebLink link = this.scenarioContext.Get<OpenApiWebLink>(linkName);
            this.linkCollection.Verify(c => c.AddLink(relation, link));
        }
    }
}