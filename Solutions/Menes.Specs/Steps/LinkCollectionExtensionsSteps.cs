// <copyright file="LinkCollectionExtensionsSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using Menes.Links;

    using Microsoft.OpenApi.Models;

    using NSubstitute;
    using Reqnroll;

    [Binding]
    public class LinkCollectionExtensionsSteps
    {
        private readonly ScenarioContext scenarioContext;
        private readonly IOpenApiWebLinkResolver resolver = Substitute.For<IOpenApiWebLinkResolver>();
        private readonly ILinkCollection linkCollection = Substitute.For<ILinkCollection>();

        public LinkCollectionExtensionsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("my link resolver returns a link called '(.*)' when resolving by owner and relation")]
        public void GivenMyLinkResolverReturnsALinkCalledWhenResolvingByOwnerAndRelation(string linkName)
        {
            var link = new OpenApiWebLink("op", "l", OperationType.Get);
            this.resolver
                .ResolveByOwnerAndRelationType(Arg.Any<object>(), Arg.Any<string>(), Arg.Any<(string, object?)[]>())
                .Returns(link);
            this.scenarioContext.Set(link, linkName);
        }

        [Given("my link resolver returns a link called '(.*)' when resolving by owner, relation, and context")]
        public void GivenMyLinkResolverReturnsALinkCalledWhenResolvingByOwnerRelationAndContext(string linkName)
        {
            var link = new OpenApiWebLink("op", "l", OperationType.Get);
            this.resolver
                .ResolveByOwnerAndRelationTypeAndContext(Arg.Any<object>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<(string, object?)[]>())
                .Returns(link);
            this.scenarioContext.Set(link, linkName);
        }

        [Given("my link resolver returns a link called '(.*)' when resolving by operation id and relation")]
        public void GivenMyLinkResolverReturnsALinkCalledWhenResolvingByOperationIdAndRelation(string linkName)
        {
            var link = new OpenApiWebLink("op", "l", OperationType.Get);
            this.resolver
                .ResolveByOperationIdAndRelationType(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<(string, object?)[]>())
                .Returns(link);
            this.scenarioContext.Set(link, linkName);
        }

        [When("I resolve and add a relation for the owner '(.*)' and the relation '(.*)'")]
        public void WhenIResolveAndAddARelationForTheOwnerAndTheRelation(string objectName, string relation)
        {
            object target = this.scenarioContext.Get<object>(objectName);
            this.linkCollection.ResolveAndAddByOwnerAndRelationType(this.resolver, target, relation);
        }

        [When("I resolve and add a relation for the owner '(.*)', the relation '(.*)', and the context '(.*)'")]
        public void WhenIResolveAndAddARelationForTheOwnerTheRelationAndTheContext(string objectName, string relation, string context)
        {
            object target = this.scenarioContext.Get<object>(objectName);
            this.linkCollection.ResolveAndAddByOwnerAndRelationTypeAndContext(this.resolver, target, relation, context);
        }

        [When("I resolve and add a relation for the operation '(.*)' and the relation '(.*)'")]
        public void WhenIResolveAndAddARelationForTheOperationAndTheRelation(string operationId, string relation)
        {
            this.linkCollection.ResolveAndAddByOperationIdAndRelationType(this.resolver, operationId, relation);
        }

        [Then("the link resolver should have been asked to resolve for the owner '(.*)' and the relation '(.*)'")]
        public void ThenTheLinkResolverShouldHaveBeenAskedToResolveForTheOwnerAndTheRelation(string objectName, string relation)
        {
            object target = this.scenarioContext.Get<object>(objectName);
            this.resolver
                .Received()
                .ResolveByOwnerAndRelationType(target, relation, Arg.Any<(string, object?)[]>());
        }

        [Then("the link resolver should have been asked to resolve for the owner '(.*)', the relation '(.*)', and the context '(.*)'")]
        public void ThenTheLinkResolverShouldHaveBeenAskedToResolveForTheOwnerTheRelationAndTheContext(string objectName, string relation, string context)
        {
            object target = this.scenarioContext.Get<object>(objectName);
            this.resolver
                .Received()
                .ResolveByOwnerAndRelationTypeAndContext(target, relation, context, Arg.Any<(string, object?)[]>());
        }

        [Then("the link resolver should have been asked to resolve for the operation '(.*)' and the relation '(.*)'")]
        public void ThenTheLinkResolverShouldHaveBeenAskedToResolveForTheOperationAndTheRelation(string operationId, string relation)
        {
            this.resolver
                .Received()
                .ResolveByOperationIdAndRelationType(operationId, relation, Arg.Any<(string, object?)[]>());
        }

        [Then("the link '(.*)' should have been added to the link collection with relation '(.*)'")]
        public void ThenTheLinkShouldHaveBeenAddedToTheLinkCollectionWithRelation(string linkName, string relation)
        {
            OpenApiWebLink link = this.scenarioContext.Get<OpenApiWebLink>(linkName);
            this.linkCollection.Received().AddLink(relation, link);
        }
    }
}