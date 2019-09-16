@setupContainer

Feature: OpenApiMisconfigurationDetection
	In order to discover that I've made a mistake
	As an OpenApi service developer
	I want to be told when my configuration is wrong

Scenario: Operation returns POCO when multiple success responses have been defined
	Given I have an OpenApiOperation with multiple 2xx responses
	When I pass the OpenApiOperation to OpenApiActionResult.CanConstructFrom
	Then it should throw an OpenApiServiceMismatchException

Scenario: Operation returns POCO when one success responses and a default response have been defined
	Given I have an OpenApiOperation with a 200 response and a default response
	When I pass the OpenApiOperation to OpenApiActionResult.CanConstructFrom
	Then it should throw an OpenApiServiceMismatchException

Scenario: Operation throws an exception for which no mapping exists
    Given I have an OpenApiOperation with a 200 response
    When I ask the OpenApiExceptionHandler for a response for an unmapped exception
    Then it should throw an OpenApiServiceMismatchException

Scenario: OpenApiDocument defines object lists an undefined property as required
	Given I have an OpenApiOperation with an argument type that lists an undefined property as required
	When I add the OpenApiDocument containing the OpenApiOperation to a OpenApiDocumentProvider
	Then it should throw an OpenApiServiceMismatchException