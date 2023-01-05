// <copyright file="OpenApiParameterParsingSteps.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.Specs.Steps
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using Corvus.Testing.SpecFlow;

    using Menes.Internal;
    using Menes.Specs.Fakes;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using Microsoft.OpenApi.Readers;

    using Newtonsoft.Json;

    using NUnit.Framework;

    using TechTalk.SpecFlow;

    [Binding]
    public class OpenApiParameterParsingSteps
    {
        private readonly ScenarioContext scenarioContext;
        private IPathMatcher? matcher;
        private IDictionary<string, object>? parameters;
        private Exception? exception;
        private string? responseBody;

        public OpenApiParameterParsingSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        private IPathMatcher Matcher => this.matcher ?? throw new InvalidOperationException("Matcher not set - test must first create a fake OpenAPI spec");

        [Given("I have constructed the OpenAPI specification with a request body of type '([^']*)', and format '([^']*)'")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithARequestBodyOfTypeAndFormat(
            string bodyType, string bodyFormat)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "post": {
                            "summary": "Create a pet",
                            "operationId": "createPets",
                            "requestBody": {
                                "required": true,
                                "content": {
                                    "application/json": {
                                        "schema": {
                                            "type": "{{bodyType}}",
                                            "format": "{{bodyFormat}}"
                                        }
                                    }
                                }
                            },
                            "responses": { "201": { "description": "Created" } }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a response body of type '([^']*)', and format '([^']*)'")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithAResponseBodyOfTypeAndFormat(
            string bodyType, string bodyFormat)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "get": {
                            "summary": "Get a pet",
                            "operationId": "getPet",
                            "responses": {
                                "201": {
                                    "description": "A pet",
                                    "content": {
                                        "application/json": {
                                            "schema": {
                                                "type": "{{bodyType}}",
                                                "format": "{{bodyFormat}}"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a response body of type object, containing properties in the structure '([^']*)'")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithAResponseBodyOfTypeObjectContainingPropertiesInTheStructure(
            string objectProperties)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "get": {
                            "summary": "Get a pet",
                            "operationId": "getPet",
                            "responses": {
                                "200": {
                                    "description": "A pet",
                                    "content": {
                                        "application/json": {
                                            "schema": {
                                               "type": "object",
                                               "properties": {{objectProperties}}
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a ([^ ]*) parameter with name '([^']*)', type '([^']*)', and format '([^']*)'")]
        public void GivenIConstructAnOpenApiSpecWithSimpleParameter(
            string parameterLocation,
            string parameterName,
            string parameterType,
            string parameterFormat)
        {
            //// Build OpenAPI spec object from scratch to mimic reality. Cutting corners by initializing an
            //// OpenApiDocument directly removes the ability for the the parameter type to be inferred. Something
            //// that this test is trying to cover.

            string path = parameterLocation == "path" ? $"/pets/{{{parameterName}}}" : "/pets";
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "{{path}}": {
                        "get": {
                            "summary": "List all pets",
                            "operationId": "listPets",
                            "parameters": [
                                {
                                    "name": "{{parameterName}}",
                                    "in": "{{parameterLocation}}",
                                    "schema": {
                                        "type": "{{parameterType}}",
                                        "format": "{{parameterFormat}}",
                                        }
                                    }
                                ],
                            "responses": {
                                "200": {
                                    "description": "OK"
                                }
                            }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a ([^ ]*) parameter with name '([^']*)', type '([^']*)', format '([^']*)' and default value '(.*)'")]
        public void GivenIConstructAnOpenApiSpecWithSimpleParameterWithDefault(
            string parameterLocation,
            string parameterName,
            string parameterType,
            string parameterFormat,
            string parameterDefaultValue)
        {
            //// Build OpenAPI spec object from scratch to mimic reality. Cutting corners by initializing an
            //// OpenApiDocument directly removes the ability for the the parameter type to be inferred. Something
            //// that this test is trying to cover.

            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"{parameterLocation}\", \"schema\": {{ \"type\": \"{parameterType}\", \"format\": \"{parameterFormat}\", \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a request body of type array, containing items of type '([^']*)'")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithARequestBodyOfTypeArrayContainingItemsOfType(string arrayItemType)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "post": {
                            "summary": "Create a pet",
                            "operationId": "createPets",
                            "requestBody": {
                                "required": true,
                                "content": {
                                    "application/json": {
                                        "schema": {
                                            "type": "array",
                                            "items": {
                                                type: "{{arrayItemType}}"
                                            }
                                        }
                                    }
                                }
                            },
                            "responses": { "201": { "description": "Created" } }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a request body of type array, containing items of type '([^']*)' and format '([^']*)'")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithARequestBodyOfTypeArrayContainingItemsOfTypeAndFormat(
            string arrayItemType, string arrayItemFormat)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "post": {
                            "summary": "Create a pet",
                            "operationId": "createPets",
                            "requestBody": {
                                "required": true,
                                "content": {
                                    "application/json": {
                                        "schema": {
                                            "type": "array",
                                            "items": {
                                                "type": "{{arrayItemType}}",
                                                "format": "{{arrayItemFormat}}"
                                            }
                                        }
                                    }
                                }
                            },
                            "responses": { "201": { "description": "Created" } }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '([^']*)', of type array, containing items of type '([^']*)'")]
        public void GivenIConstructAnArrayParameterWithSimpleItems(
            string parameterName,
            string arrayItemType)
        {
            string openApiSpec = $$"""
                {
                    "openapi": "3.0.1",
                    "info": { "title": "Swagger Petstore (Simple)", "version": "1.0.0" },
                    "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                    "paths": {
                        "/pets": {
                            "get": {
                                "summary": "List all pets",
                                "operationId": "listPets",
                                "parameters": [
                                    {
                                        "name": "{{parameterName}}",
                                        "in": "query",
                                        "schema": {
                                            "type": "array",
                                            "items": {
                                                type: "{{arrayItemType}}"
                                            }
                                        }
                                    }
                                ],
                                "responses": {
                                    "200": { "description": "OK" }
                                }
                            }
                        }
                    }                    
                }
                """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '([^']*)', of type array, containing items of type '([^']*)' and format '([^']*)'")]
        public void GivenIConstructAnArrayParameterWithSimpleItemsWithFormat(
            string parameterName,
            string arrayItemType,
            string arrayItemFormat)
        {
            string openApiSpec = $$"""
                {
                    "openapi": "3.0.1",
                    "info": { "title": "Swagger Petstore (Simple)", "version": "1.0.0" },
                    "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                    "paths": {
                        "/pets": {
                            "get": {
                                "summary": "List all pets",
                                "operationId": "listPets",
                                "parameters": [
                                    {
                                        "name": "{{parameterName}}",
                                        "in": "query",
                                        "schema": {
                                            "type": "array",
                                            "items": {
                                                "type": "{{arrayItemType}}",
                                                "format": "{{arrayItemFormat}}"
                                            }
                                        }
                                    }
                                ],
                                "responses": {
                                    "200": { "description": "OK" }
                                }
                            }
                        }
                    }                    
                }
                """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '([^']*)', of type array, containing items of type '([^']*)', and the default value for the parameter is '(.*)'")]
        public void GivenIConstructAnArrayParameterWithSimpleItemsWithDefault(
            string parameterName,
            string arrayItemType,
            string parameterDefaultValue)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"query\", \"schema\": {{ \"type\": \"array\", \"items\": {{ type: \"{arrayItemType}\" }}, \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '([^']*)', of type array, containing items of type '([^']*)' and format '([^']*)', and the default value for the parameter is '(.*)'")]
        public void GivenIConstructAnArrayParameterWithSimpleItemsWithFormatWithDefault(
            string parameterName,
            string arrayItemType,
            string arrayItemFormat,
            string parameterDefaultValue)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"query\", \"schema\": {{ \"type\": \"array\", \"items\": {{ \"type\": \"{arrayItemType}\", \"format\": \"{arrayItemFormat}\" }}, \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a request body of type array, containing items which are arrays themselves with item type '([^']*)'")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithARequestBodyOfTypeArrayContainingItemsWhichAreArraysThemselvesWithItemType(
            string nestedArrayItemType)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "post": {
                            "summary": "Create a pet",
                            "operationId": "createPets",
                            "requestBody": {
                                "required": true,
                                "content": {
                                    "application/json": {
                                        "schema": {
                                           "type": "array",
                                            "items": {
                                                "type": "array",
                                                "items": {
                                                    "type": "{{nestedArrayItemType}}"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            "responses": { "201": { "description": "Created" } }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a request body of type array, containing items which are arrays themselves with item type '([^']*)' and format '([^']*)'")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithARequestBodyOfTypeArrayContainingItemsWhichAreArraysThemselvesWithItemTypeAndFormat(
            string nestedArrayItemType,
            string nestedArrayItemFormat)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "post": {
                            "summary": "Create a pet",
                            "operationId": "createPets",
                            "requestBody": {
                                "required": true,
                                "content": {
                                    "application/json": {
                                        "schema": {
                                           "type": "array",
                                            "items": {
                                                "type": "array",
                                                "items": {
                                                    "type": "{{nestedArrayItemType}}",
                                                    "format": "{{nestedArrayItemFormat}}"
                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            "responses": { "201": { "description": "Created" } }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '([^']*)', of type array, containing items which are arrays themselves with item type '([^']*)'")]
        public void GivenIConstructAnArrayParameterWithArrayItems(
            string parameterName,
            string nestedArrayItemType)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": { "title": "Swagger Petstore (Simple)", "version": "1.0.0" },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "get": {
                            "summary": "List all pets",
                            "operationId": "listPets",
                            "parameters": [
                                {
                                    "name": "{{parameterName}}",
                                    "in": "query",
                                    "schema": {
                                        "type": "array",
                                        "items": {
                                            "type": "array",
                                            "items": {
                                                "type": "{{nestedArrayItemType}}"
                                            }
                                        }
                                    }
                                }
                            ],
                            "responses": {
                                "200": { "description": "OK" }
                            }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '([^']*)', of type array, containing items which are arrays themselves with item type '([^']*)' and format '([^']*)'")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithAParameterWithNameOfTypeArrayContainingItemsWhichAreArraysThemselvesWithItemTypeAndFormat(
            string parameterName,
            string nestedArrayItemType,
            string nestedArrayItemFormat)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": { "title": "Swagger Petstore (Simple)", "version": "1.0.0" },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "get": {
                            "summary": "List all pets",
                            "operationId": "listPets",
                            "parameters": [
                                {
                                    "name": "{{parameterName}}",
                                    "in": "query",
                                    "schema": {
                                        "type": "array",
                                        "items": {
                                            "type": "array",
                                            "items": {
                                                "type": "{{nestedArrayItemType}}",
                                                "format": "{{nestedArrayItemFormat}}"
                                            }
                                        }
                                    }
                                }
                            ],
                            "responses": {
                                "200": { "description": "OK" }
                            }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '([^']*)', of type array, containing items which are arrays themselves with item type '([^']*)', and the default value for the parameter is '([^']*)'")]
        public void GivenIConstructAnArrayParameterWithArrayItemsWithDefault(
            string parameterName,
            string nestedArrayItemType,
            string parameterDefaultValue)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"query\", \"schema\": {{ \"type\": \"array\", \"items\": {{ \"type\": \"array\", \"items\": {{ \"type\": \"{nestedArrayItemType}\" }} }}, \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '([^']*)', of type array, containing items which are arrays themselves with item type '([^']*)' and format '([^']*)', and the default value for the parameter is '([^']*)'")]
        public void GivenIConstructAnArrayParameterWithArrayItemsWithFormatWithDefault(
            string parameterName,
            string nestedArrayItemType,
            string nestedArrayItemFormat,
            string parameterDefaultValue)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"query\", \"schema\": {{ \"type\": \"array\", \"items\": {{ \"type\": \"array\", \"items\": {{ \"type\": \"{nestedArrayItemType}\", \"format\": \"{nestedArrayItemFormat}\" }} }}, \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a request body of type array, containing items which are objects which has the property structure '([^']*)'")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithARequestBodyOfTypeArrayContainingItemsWhichAreObjectsWhichHasThePropertyStructure(
            string objectProperties)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "post": {
                            "summary": "Create a pet",
                            "operationId": "createPets",
                            "requestBody": {
                                "required": true,
                                "content": {
                                    "application/json": {
                                        "schema": {
                                           "type": "array",
                                            "items": {
                                                "type": "object",
                                                "properties": {{objectProperties}}
                                            }
                                        }
                                    }
                                }
                            },
                            "responses": { "201": { "description": "Created" } }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '([^']*)', of type array, containing items which are objects which has the property structure '([^']*)'")]
        public void GivenIConstructAnArrayParameterWithObjectItems(
            string parameterName,
            string objectProperties)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": { "title": "Swagger Petstore (Simple)", "version": "1.0.0" },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "get": {
                            "summary": "List all pets",
                            "operationId": "listPets",
                            "parameters": [
                                {
                                    "name": "{{parameterName}}",
                                    "in": "query",
                                    "schema": {
                                        "type": "array",
                                        "items": {
                                            "type": "object",
                                            "properties": {{objectProperties}}
                                        }
                                    }
                                }
                            ],
                            "responses": { "200": { "description": "OK" } }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '(.*)', of type array, containing items which are objects which has the property structure '(.*)', and the default value for the parameter is '(.*)'")]
        public void GivenIConstructAnArrayParameterWithObjectItemsWithDefault(
            string parameterName,
            string objectProperties,
            string parameterDefaultValue)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"query\", \"schema\": {{ \"type\": \"array\", \"items\": {{ \"type\": \"object\", \"properties\": {objectProperties} }}, \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '([^']*)'")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithARequestBodyOfTypeObjectContainingPropertiesInTheStructure(
            string objectProperties)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "post": {
                            "summary": "Create a pet",
                            "operationId": "createPets",
                            "requestBody": {
                                "required": true,
                                "content": {
                                    "application/json": {
                                        "schema": {
                                           "type": "object",
                                           "properties": {{objectProperties}}
                                        }
                                    }
                                }
                            },
                            "responses": { "201": { "description": "Created" } }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '([^']*)' with '([^']*)' as the discriminator")]
        public void GivenIHaveConstructedTheOpenAPISpecificationWithARequestBodyOfTypeObjectContainingPropertiesInTheStructureWithDiscriminator(
            string objectProperties,
            string discriminator)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": {
                    "title": "Swagger Petstore (Simple)",
                    "version": "1.0.0"
                },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "post": {
                            "summary": "Create a pet",
                            "operationId": "createPets",
                            "requestBody": {
                                "required": true,
                                "content": {
                                    "application/json": {
                                        "schema": {
                                           "type": "object",
                                           "properties": {{objectProperties}},
                                           "discriminator": { "propertyName": "{{discriminator}}" }
                                        }
                                    }
                                }
                            },
                            "responses": { "201": { "description": "Created" } }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '([^']*)', of type object, containing properties in the structure '([^']*)'")]
        public void GivenIConstructAnObjectParameterWithSimpleProperties(
            string parameterName,
            string objectProperties)
        {
            string openApiSpec = $$"""
            {
                "openapi": "3.0.1",
                "info": { "title": "Swagger Petstore (Simple)", "version": "1.0.0" },
                "servers": [ { "url": "http://petstore.swagger.io/api" } ],
                "paths": {
                    "/pets": {
                        "get": {
                            "summary": "List all pets",
                            "operationId": "listPets",
                            "parameters": [
                                {
                                    "name": "{{parameterName}}",
                                    "in": "query",
                                    "schema": {
                                        "type": "object",
                                        "properties": {{objectProperties}}
                                    }
                                }
                            ],
                            "responses": { "200": { "description": "OK" } }
                        }
                    }
                }
            }
            """;

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a parameter with name '(.*)', of type object, containing properties in the structure '(.*)', and the default value for the parameter is '(.*)'")]
        public void GivenIConstructAnObjectParameterWithSimplePropertiesWithDefault(
            string parameterName,
            string objectProperties,
            string parameterDefaultValue)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"query\", \"schema\": {{ \"type\": \"object\", \"properties\": {objectProperties}, \"default\": {parameterDefaultValue} }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [Given("I have constructed the OpenAPI specification with a (.*) parameter with name (.*), type (.*), format (.*) and a null default value")]
        public void GivenIConstructAParameterWithANullDefaultValue(
            string parameterLocation,
            string parameterName,
            string parameterType,
            string parameterFormat)
        {
            string openApiSpec = $"{{ \"openapi\": \"3.0.1\", \"info\": {{ \"title\": \"Swagger Petstore (Simple)\", \"version\": \"1.0.0\" }}, \"servers\": [ {{ \"url\": \"http://petstore.swagger.io/api\" }} ], \"paths\": {{ \"/pets\": {{ \"get\": {{ \"summary\": \"List all pets\", \"operationId\": \"listPets\", \"parameters\": [ {{ \"name\": \"{parameterName}\", \"in\": \"{parameterLocation}\", \"schema\": {{ \"type\": \"{parameterType}\", \"format\": \"{parameterFormat}\", \"default\": null, \"nullable\": true }} }} ], \"responses\": {{ \"200\": {{ \"description\": \"OK\" }} }} }} }} }} }}";

            this.InitializeDocumentProviderAndPathMatcher(openApiSpec);
        }

        [When("I try to parse the default value")]
        public async Task WhenITryToParseTheDefaultValueAsync()
        {
            IOpenApiParameterBuilder<HttpRequest> builder = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IOpenApiParameterBuilder<HttpRequest>>();

            this.Matcher.FindOperationPathTemplate("/pets", "GET", out OpenApiOperationPathTemplate? operationPathTemplate);

            var context = new DefaultHttpContext();

            this.parameters = await builder.BuildParametersAsync(context.Request, operationPathTemplate!).ConfigureAwait(false);
        }

        [When("I try to parse the default value and expect an error")]
        public async Task WhenITryToParseTheDefaultValueAndExpectAnErrorAsync()
        {
            try
            {
                await this.WhenITryToParseTheDefaultValueAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [When("I try to parse the value '(.*)' as the request body")]
        public async Task WhenITryToParseTheValueAsTheRequestBody(string body)
        {
            IOpenApiParameterBuilder<HttpRequest> builder = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IOpenApiParameterBuilder<HttpRequest>>();

            this.Matcher.FindOperationPathTemplate("/pets", "POST", out OpenApiOperationPathTemplate? operationPathTemplate);

            var context = new DefaultHttpContext();
            context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
            context.Request.Headers.ContentType = "application/json";

            this.parameters = await builder.BuildParametersAsync(context.Request, operationPathTemplate!).ConfigureAwait(false);
        }

        [When("I try to parse the value '(.*?)' as the request body and expect an error")]
        public async Task WhenITryToParseTheValueAsTheRequestBodyAndExpectAnError(string body)
        {
            try
            {
                await this.WhenITryToParseTheValueAsTheRequestBody(body).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [When("I try to parse the path value '(.*?)' as the parameter '([^']*)'")]
        public async Task WhenITryToParseThePathValue(string value, string unusedParameterName)
        {
            _ = unusedParameterName;

            IOpenApiParameterBuilder<HttpRequest> builder = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IOpenApiParameterBuilder<HttpRequest>>();

            string path = $"/pets/{value}";
            this.Matcher.FindOperationPathTemplate(path, "GET", out OpenApiOperationPathTemplate? operationPathTemplate);

            DefaultHttpContext context = new();
            context.Request.Path = path;

            this.parameters = await builder.BuildParametersAsync(context.Request, operationPathTemplate!).ConfigureAwait(false);
        }

        [When("I try to parse the path value '(.*?)' as the parameter '([^']*)' and expect an error")]
        public async Task WhenITryToParseThePathValueAndExpectAnErrorAsync(string value, string unusedParameterName)
        {
            try
            {
                await this.WhenITryToParseThePathValue(value, unusedParameterName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [When("I try to parse the query value '(.*?)' as the parameter '([^']*)'")]
        public async Task WhenITryToParseTheQueryValue(
            string value,
            string parameterName)
        {
            IOpenApiParameterBuilder<HttpRequest> builder = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IOpenApiParameterBuilder<HttpRequest>>();

            this.Matcher.FindOperationPathTemplate("/pets", "GET", out OpenApiOperationPathTemplate? operationPathTemplate);

            var context = new DefaultHttpContext();
            context.Request.Query = new QueryCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
                {
                    { parameterName, value },
                });

            this.parameters = await builder.BuildParametersAsync(context.Request, operationPathTemplate!).ConfigureAwait(false);
        }

        [When("I try to parse the query value '([^']*)' as the parameter '([^']*)' and expect an error")]
        public async Task WhenITryToParseTheQueryValueAndExpectAnErrorAsync(
            string value,
            string parameterName)
        {
            try
            {
                await this.WhenITryToParseTheQueryValue(value, parameterName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [When("I try to parse the header value '([^']*)' as the parameter '([^']*)'")]
        public async Task WhenITryToParseTheHeaderValue(
            string value,
            string parameterName)
        {
            IOpenApiParameterBuilder<HttpRequest> builder = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IOpenApiParameterBuilder<HttpRequest>>();

            this.Matcher.FindOperationPathTemplate("/pets", "GET", out OpenApiOperationPathTemplate? operationPathTemplate);

            var context = new DefaultHttpContext();
            context.Request.Headers.Add(parameterName, value);

            this.parameters = await builder.BuildParametersAsync(context.Request, operationPathTemplate!).ConfigureAwait(false);
        }

        [When("I try to parse the header value '([^']*)' as the parameter '([^']*)' and expect an error")]
        public async Task WhenITryToParseTheHeaderValueAndExpectAnErrorAsync(
            string value,
            string parameterName)
        {
            try
            {
                await this.WhenITryToParseTheHeaderValue(value, parameterName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [When("I try to parse the cookie value '([^']*)' as the parameter '([^']*)'")]
        public async Task WhenITryToParseTheCookieValue(
            string value,
            string parameterName)
        {
            IOpenApiParameterBuilder<HttpRequest> builder = ContainerBindings.GetServiceProvider(this.scenarioContext).GetRequiredService<IOpenApiParameterBuilder<HttpRequest>>();

            this.Matcher.FindOperationPathTemplate("/pets", "GET", out OpenApiOperationPathTemplate? operationPathTemplate);

            var context = new DefaultHttpContext();
            context.Request.Cookies = new FakeCookieCollection()
                {
                    { parameterName, value },
                };

            this.parameters = await builder.BuildParametersAsync(context.Request, operationPathTemplate!).ConfigureAwait(false);
        }

        [When("I try to parse the cookie value '([^']*)' as the parameter '([^']*)' and expect an error")]
        public async Task WhenITryToParseTheCookieValueAndExpectAnErrorAsync(
            string value,
            string parameterName)
        {
            try
            {
                await this.WhenITryToParseTheCookieValue(value, parameterName).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.exception = ex;
            }
        }

        [When("I try to build a response body from the value '([^']*)' of type '([^']*)'")]
        public void WhenITryToBuildAResponseBodyFromTheValueOfTypeSystem_Boolean(
            string valueAsString, string valueType)
        {
            object value = GetResultFromStringAndType(valueAsString, valueType);

            IEnumerable<IResponseOutputBuilder<IHttpResponseResult>> builders = ContainerBindings.GetServiceProvider(this.scenarioContext).
                GetServices<IResponseOutputBuilder<IHttpResponseResult>>();

            this.Matcher.FindOperationPathTemplate("/pets", "GET", out OpenApiOperationPathTemplate? operationPathTemplate);
            OpenApiOperation operation = operationPathTemplate!.Operation;

            IHttpResponseResult? result = null;
            foreach (IResponseOutputBuilder<IHttpResponseResult> builder in builders)
            {
                if (builder.CanBuildOutput(value, operation))
                {
                    result = builder.BuildOutput(value, operation);
                    break;
                }
            }

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();
            result!.ExecuteResultAsync(context.Response);
            context.Response.Body.Position = 0;
            using StreamReader sr = new(context.Response.Body);
            this.responseBody = sr.ReadToEnd();
        }

        [Then("the response body should be '([^']*)'")]
        public void ThenTheResponseBodyShouldBeTrue(string expectedBody)
        {
            Assert.AreEqual(expectedBody, this.responseBody);
        }

        [Then("the parameter (.*?) should be (.*?) of type (.*)")]
        public void ThenTheParameterShouldBe(string parameterName, string expectedResultAsString, string expectedType)
        {
            object expectedResult = GetResultFromStringAndType(expectedResultAsString, expectedType);

            Assert.AreEqual(expectedResult, this.parameters![parameterName]);
            Assert.AreEqual(expectedResult.GetType(), this.parameters![parameterName]!.GetType());
        }

        [Then("the parameter (.*?) should be of type '([^']*)'")]
        public void ThenTheParameterBodyShouldBeOfType(string parameterName, string expectedType)
        {
            Assert.AreEqual(expectedType, this.parameters![parameterName].GetType().Name);
        }

        [Then("an '(.*)' should be thrown")]
        public void ThenAnShouldBeThrown(string exceptionType)
        {
            Assert.IsNotNull(this.exception);

            Assert.AreEqual(exceptionType, this.exception!.GetType().Name);
        }

        private static object GetResultFromStringAndType(string expectedResultAsString, string expectedType)
        {
            return expectedType switch
            {
                "ByteArrayFromBase64String" => Convert.FromBase64String(expectedResultAsString),
                "System.DateTimeOffset" => DateTimeOffset.Parse(expectedResultAsString),
                "System.Guid" => Guid.Parse(expectedResultAsString),
                "System.Uri" => new Uri(expectedResultAsString, UriKind.RelativeOrAbsolute),
                "ObjectWithIdAndName" => JsonConvert.DeserializeObject<ObjectWithIdAndName>(expectedResultAsString)!,
                _ => Convert.ChangeType(expectedResultAsString, Type.GetType(expectedType)!),
            };
        }

        private void InitializeDocumentProviderAndPathMatcher(string openApiSpec)
        {
            OpenApiDocument document = new OpenApiStringReader().Read(openApiSpec, out OpenApiDiagnostic _);

            var documentProvider = new OpenApiDocumentProvider(new LoggerFactory().CreateLogger<OpenApiDocumentProvider>());
            documentProvider.Add(document);

            this.scenarioContext.Set<IOpenApiDocumentProvider>(documentProvider);

            this.matcher = new PathMatcher(documentProvider);
        }

        private class FakeCookieCollection : IRequestCookieCollection
        {
            private readonly Dictionary<string, string> cookies = new();

            public int Count => this.cookies.Count;

            public ICollection<string> Keys => this.cookies.Keys;

            public string? this[string key] => this.TryGetValue(key, out string? cookie) ? cookie : null;

            public void Add(string key, string value)
            {
                this.cookies.Add(key, value);
            }

            public bool ContainsKey(string key) => this.cookies.ContainsKey(key);

            public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => this.cookies.GetEnumerator();

            public bool TryGetValue(string key, [MaybeNullWhen(false)] out string? value) => this.cookies.TryGetValue(key, out value);

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}