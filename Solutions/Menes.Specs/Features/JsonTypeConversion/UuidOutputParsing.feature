@perScenarioContainer

Feature: Uuid Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify uuid-formatted string values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Valid values for simple types
    Given I have constructed the OpenAPI specification with a response body of type 'string', and format 'uuid'
    When I try to build a response body from the value '<Value>' of type 'System.Uri'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value                                | ExpectedResult                         |
        | 9b7d63fb-1689-4697-9571-00d10b873d78 | "9b7d63fb-1689-4697-9571-00d10b873d78" |
