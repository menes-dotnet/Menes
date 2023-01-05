@perScenarioContainer

Feature: Date Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify date values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Valid values for simple types
    Given I have constructed the OpenAPI specification with a response body of type 'string', and format 'date'
    When I try to build a response body from the value '<Value>' of type 'System.DateTimeOffset'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value                | ExpectedResult |
        | 2017-07-21T00:00:00Z | "2017-07-21"   |
