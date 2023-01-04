@perScenarioContainer

Feature: Integer64 Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify integer64 values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Valid values for simple types
    Given I have constructed the OpenAPI specification with a response body of type 'integer', and format 'int64'
    When I try to build a response body from the value '<Value>' of type 'System.Int64'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value                | ExpectedResult       |
        | 0                    | 0                    |
        | 1234                 | 1234                 |
        | -1234                | -1234                |
        | 2147483647           | 2147483647           |
        | -2147483648          | -2147483648          |
        | 9223372036854775807  | 9223372036854775807  |
        | -9223372036854775808 | -9223372036854775808 |
