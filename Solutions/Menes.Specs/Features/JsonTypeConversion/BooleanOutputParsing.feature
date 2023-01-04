@perScenarioContainer

Feature: Boolean Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify boolean values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Body with valid values for simple types
    Given I have constructed the OpenAPI specification with a response body of type 'boolean', and format ''
    When I try to build a response body from the value '<Value>' of type 'System.Boolean'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value | ExpectedResult |
        | true  | true           |
        | false | false          |
