@perScenarioContainer

Feature: Date Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify date values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Body with valid values
    Given I have constructed the OpenAPI specification with a response body of type 'string', and format 'date'
    When I try to build a response from the value '<Value>' of type 'System.DateTimeOffset'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value                | ExpectedResult |
        | 2017-07-21T00:00:00Z | "2017-07-21"   |

Scenario: Header with valid values
    Given I have constructed the OpenAPI specification with a response header called 'X-Test' of type 'string', and format 'date'
    When I try to build a response from an OpenAPI result with these values
        | Name   | Type                  | Value                |
        | X-Test | System.DateTimeOffset | 2017-07-21T00:00:00Z |
    Then the response header called 'X-Test' should be '2017-07-21'
