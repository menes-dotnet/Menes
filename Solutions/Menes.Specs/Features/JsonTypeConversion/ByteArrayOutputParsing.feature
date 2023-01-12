@perScenarioContainer

Feature: Byte Array Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify byte-formatted string values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Body with valid values
    Given I have constructed the OpenAPI specification with a response body of type 'string', and format 'byte'
    When I try to build a response from the value '<Value>' of type 'ByteArrayFromBase64String'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value                | ExpectedResult         |
        | U3dhZ2dlciByb2Nrcw== | "U3dhZ2dlciByb2Nrcw==" |
        |                      | ""                     |

Scenario Outline: Header with valid values
    Given I have constructed the OpenAPI specification with a response header called 'X-Test' of type 'string', and format 'byte'
    When I try to build a response from an OpenAPI result with these values
        | Name   | Type                      | Value   |
        | X-Test | ByteArrayFromBase64String | <Value> |
    Then the response header called 'X-Test' should be '<ExpectedResult>'

    Examples:
        | Value                | ExpectedResult       |
        | U3dhZ2dlciByb2Nrcw== | U3dhZ2dlciByb2Nrcw== |
        |                      |                      |
