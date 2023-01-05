@perScenarioContainer

Feature: Oubject Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify objects as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario: Object with properties of simple types
    Given I have constructed the OpenAPI specification with a response body of type object, containing properties in the structure '{ "id": { "type": "integer" }, "name": {"type": "string"} }'
    When I try to build a response body from the value '{"id":123,"name":"Ed"}' of type 'ObjectWithIdAndName'
    Then the response body should be '{"id":123,"name":"Ed"}'
