@perScenarioContainer

Feature: DateTime Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify date-time values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Valid values for simple types
    Given I have constructed the OpenAPI specification with a response body of type 'string', and format 'date-time'
    When I try to build a response from the value '<Value>' of type 'System.String'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value                | ExpectedResult         |
        | 2017-07-21T00:00:00Z | "2017-07-21T00:00:00Z" |

Scenario: Header with valid values
    Given I have constructed the OpenAPI specification with a response header called 'X-Test' of type 'string', and format 'date-time'
    When I try to build a response from an OpenAPI result with these values
        | Name   | Type          | Value                |
        | X-Test | System.String | 2017-07-21T00:00:00Z |
    Then the response header called 'X-Test' should be '2017-07-21T00:00:00Z'
