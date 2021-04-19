Feature: OpenApiSandbox
	In order to develop the OpenApi-based service generator
	As a developer
	I want to play with the code

Scenario: Run the OpenApi walker
	Given the input OpenApi document "test.json"
	When I build the service
