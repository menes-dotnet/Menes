@perScenarioContainer

Feature: Integer32 Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify integer32 values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Valid values for simple types
    Given I have constructed the OpenAPI specification with a response body of type 'integer', and format ''
    When I try to build a response body from the value '<Value>' of type 'System.Int32'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value       | ExpectedResult |
        | 0           | 0              |
        | 1234        | 1234           |
        | -1234       | -1234          |
        | 2147483647  | 2147483647     |
        | -2147483648 | -2147483648    |
