// <copyright file="OpenApiWebLinkResolverSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CS1591 // Elements should be documented

namespace Menes.Specs.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Menes.Internal;
    using Menes.Links;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    [Binding]
    public class OpenApiWebLinkResolverSteps
    {
        private readonly ScenarioContext scenarioContext;

        public OpenApiWebLinkResolverSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Given("I have initialised the OpenApiDocument provider from test YAML file '(.*)'")]
        public void GivenIHaveInitialisedTheOpenApiDocumentProviderFromTestYAMLFile(string embeddedResourceName)
        {
            OpenApiDocument document = OpenApiServiceDefinitions.ReadOpenApiServiceFromEmbeddedDefinitionWithDiagnostics(
                Assembly.GetExecutingAssembly(), embeddedResourceName, out OpenApiDiagnostic diagnostic);

            Assert.IsEmpty(diagnostic.Errors);

            var documentProvider = new OpenApiDocumentProvider(new LoggerFactory().CreateLogger<OpenApiDocumentProvider>());
            documentProvider.Add(document);

            this.scenarioContext.Set<IOpenApiDocumentProvider>(documentProvider);
        }

        [Given("I have mapped link relations by type")]
        public void GivenIHaveMappedLinkRelationsByType(Table table)
        {
            var mapper = new OpenApiLinkOperationMapper();
            MethodInfo genericMapMethod = typeof(OpenApiLinkOperationMapper).GetMethod(nameof(IOpenApiLinkOperationMap.MapByContentTypeAndRelationTypeAndOperationId), new[] { typeof(string), typeof(string) }) ?? throw new InvalidOperationException($"Unable to get method info for {nameof(IOpenApiLinkOperationMap.MapByContentTypeAndRelationTypeAndOperationId)}");
            IEnumerable<(string RelationName, string TargetType, string OperationId)> mappings = table.CreateSet<(string RelationName, string TargetType, string OperationId)>();

            foreach ((string relationName, string targetTypeName, string operationId) in mappings)
            {
                Type targetType = Type.GetType(targetTypeName) ?? throw new InvalidOperationException($"Unable to get type info for {targetTypeName}");
                MethodInfo mapMethod = genericMapMethod.MakeGenericMethod(targetType);
                mapMethod.Invoke(mapper, new[] { relationName, operationId });
            }

            this.scenarioContext.Set<IOpenApiLinkOperationMapper>(mapper);
        }

        [Given("I have mapped link relations by content type")]
        public void GivenIHaveMappedLinkRelationsByContentType(Table table)
        {
            var mapper = new OpenApiLinkOperationMapper();
            IEnumerable<(string RelationName, string ContentType, string OperationId)> mappings = table.CreateSet<(string RelationName, string TargetType, string OperationId)>();

            foreach ((string relationName, string contentType, string operationId) in mappings)
            {
                mapper.MapByContentTypeAndRelationTypeAndOperationId(contentType, relationName, operationId);
            }

            this.scenarioContext.Set<IOpenApiLinkOperationMapper>(mapper);
        }

        [When("I resolve the link relation '(.*)' for object '(.*)' with parameters")]
        public void WhenIResolveTheLinkRelationForObjectWithParameters(string relationName, string objectName, Table parameterTable)
        {
            object target = this.scenarioContext.Get<object>(objectName);
            (string Key, string? Value)[] parameters = parameterTable.CreateSet<(string Key, string? Value)>().ToArray();

            var resolver = new OpenApiWebLinkResolver(this.scenarioContext.Get<IOpenApiDocumentProvider>(), this.scenarioContext.Get<IOpenApiLinkOperationMapper>());
            OpenApiWebLink result = resolver.ResolveByOwnerAndRelationType(target, relationName, parameters.Select(x => (x.Key, (object?)x.Value)).ToArray());

            this.scenarioContext.Set(result);
        }

        [Then("the resulting link matches")]
        public void ThenTheResultingLinkMatches(Table expectedResultTable)
        {
            OpenApiWebLink expectedResult = expectedResultTable.CreateInstance(() => new OpenApiWebLink(string.Empty, string.Empty, OperationType.Get));
            OpenApiWebLink actualResult = this.scenarioContext.Get<OpenApiWebLink>();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
