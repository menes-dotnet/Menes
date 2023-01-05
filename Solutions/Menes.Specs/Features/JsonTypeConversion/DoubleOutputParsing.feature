@perScenarioContainer

Feature: Double Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify double values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Valid values for simple types
    Given I have constructed the OpenAPI specification with a response body of type 'number', and format 'double'
    When I try to build a response body from the value '<Value>' of type 'System.Double'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value       | ExpectedResult |
        | 0           | 0.0            |
        | 1234        | 1234.0         |
        | -1234       | -1234.0        |
        | 1234.5      | 1234.5         |
        | -1234.567   | -1234.567      |
        | -1234.5678987 | -1234.5678987  |