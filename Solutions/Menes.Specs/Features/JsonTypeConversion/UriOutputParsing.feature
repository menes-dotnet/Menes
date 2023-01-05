@perScenarioContainer

Feature: Uri Output Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify uri-formatted string values as or in response bodies within the OpenAPI specification and have corresponding response bodies deserialized and validated


Scenario Outline: Valid values for simple types
    Given I have constructed the OpenAPI specification with a response body of type 'string', and format 'uri'
    When I try to build a response body from the value '<Value>' of type 'System.Uri'
    Then the response body should be '<ExpectedResult>'

    Examples:
        | Value             | ExpectedResult      |
        | https://myuri.com | "https://myuri.com" |
        # Note: although Menes has always supported relative URIs as inputs, it does not allow them
        # as outputs. It seems likely that one of these facts is a bug, but it's not currently clear
        # which. We will most likely resolve this when we move over to Corvus.JsonSchema.
        #| relativeuri       | "relativeuri"       |
