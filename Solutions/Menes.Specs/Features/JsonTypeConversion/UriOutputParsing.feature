@perScenarioContainer

Feature: Uri Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify uri-formatted string values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Body with valid values
    Given I have constructed the OpenAPI specification with a response body of type 'string', and format 'uri'
    When I try to build a response from the value '<Value>' of type 'System.Uri'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value              | ExpectedResult       |
        | https://myuri.com/ | "https://myuri.com/" |
        | relativeuri        | "relativeuri"        |

Scenario Outline: Header with valid values
    Given I have constructed the OpenAPI specification with a response header called 'X-Test' of type 'string', and format 'uri'
    When I try to build a response from an OpenAPI result with these values
        | Name   | Type          | Value   |
        | X-Test | System.Uri | <Value> |
    Then the response header called 'X-Test' should be '<ExpectedResult>'

    Examples:
        | Value              | ExpectedResult     |
        | https://myuri.com/ | https://myuri.com/ |
        | relativeuri        | relativeuri        |
