@perScenarioContainer

Feature: String Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify string values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated

Scenario Outline: Body with valid values
    Given I have constructed the OpenAPI specification with a response body of type 'string', and format ''
    When I try to build a response body from the value '<Value>' of type 'System.String'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value     | ExpectedResult |
        | Foo       | "Foo"          |
        | /1234/abc | "/1234/abc"    |
        |           | ""             |

Scenario Outline: Header with valid values
    Given I have constructed the OpenAPI specification with a response header called 'X-Test' of type 'string', and format ''
    When I try to build a response with a header called 'X-Test' from the value '<Value>' of type 'System.String'
    Then the response should container a header called 'X-Test' with value  '<ExpectedResult>'

    Examples:
        | Value     | ExpectedResult |
        | Foo       | Foo            |
        | /1234/abc | /1234/abc      |
        | "Foo"     | "Foo"          |