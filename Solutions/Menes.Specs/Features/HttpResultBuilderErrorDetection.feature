@perScenarioContainer

Feature: HttpResultBuilderErrorDetection
	In order to discover that I've made a mistake
	As an OpenApi service developer
	I want to be told when my service is not providing an expected response

Scenario: Operation returns an OpenApiResult with no matching status code
	Given I have an OpenApiOperation
	And I have an OpenApiResult with a 201 response
	When I pass the OpenApiOperation and OpenApiResult to HttpRequestResultBuilder.BuildResult
	Then it should throw an OutputBuilderNotFoundException

Scenario: Operation returns an OpenApiResult with no matching media type
	Given I have an OpenApiOperation
	And I have an OpenApiResult with a 200 response
	When I pass the OpenApiOperation and OpenApiResult to HttpRequestResultBuilder.BuildResult
	Then it should throw an OutputBuilderNotFoundException

Scenario: Operation returns an OpenApiResult with matching media type and status code
	Given I have an OpenApiOperation
	And I have an OpenApiResult with a 200 response and an "application/hal+json" body
	When I pass the OpenApiOperation and OpenApiResult to HttpRequestResultBuilder.BuildResult
	Then it should not throw an OutputBuilderNotFoundException

Scenario: Operation returns an OpenApiResult with a mismatched media type
	Given I have an OpenApiOperation
	And I have an OpenApiResult with a 200 response and an "application/json" body
	When I pass the OpenApiOperation and OpenApiResult to HttpRequestResultBuilder.BuildResult
	Then it should throw an OutputBuilderNotFoundException