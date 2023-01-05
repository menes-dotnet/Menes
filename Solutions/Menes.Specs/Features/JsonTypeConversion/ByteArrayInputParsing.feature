@perScenarioContainer

Feature: Byte Array Input Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify byte-formatted string parameters within the OpenAPI specification and have corresponding input parameters deserialized and validated

Scenario Outline: Body with valid values for simple types
    Given I have constructed the OpenAPI specification with a request body of type 'string', and format 'byte'
    When I try to parse the value '<Value>' as the request body
    Then the parameter body should be <ExpectedResult> of type ByteArrayFromBase64String

    Examples:
        | Value                  | ExpectedResult       |
        | "U3dhZ2dlciByb2Nrcw==" | U3dhZ2dlciByb2Nrcw== |
        | ""                     |                      |

Scenario Outline: Parameters with valid values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiString', type 'string', and format 'byte'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiString'
    Then the parameter openApiString should be <ExpectedResult> of type ByteArrayFromBase64String

    Examples:
        | ParameterLocation | Value                | ExpectedResult       |
        | path              | U3dhZ2dlciByb2Nrcw== | U3dhZ2dlciByb2Nrcw== |
        | query             | U3dhZ2dlciByb2Nrcw== | U3dhZ2dlciByb2Nrcw== |
        | cookie            | U3dhZ2dlciByb2Nrcw== | U3dhZ2dlciByb2Nrcw== |
        | header            | U3dhZ2dlciByb2Nrcw== | U3dhZ2dlciByb2Nrcw== |

Scenario Outline: Parameters with valid default values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiString', type 'string', format 'byte' and default value '<DefaultValue>'
    When I try to parse the default value
    Then the parameter openApiString should be <ExpectedResult> of type ByteArrayFromBase64String

    Examples:
        | ParameterLocation | DefaultValue           | ExpectedResult       |
        | query             | "U3dhZ2dlciByb2Nrcw==" | U3dhZ2dlciByb2Nrcw== |
        | query             |                        |                      |
        | cookie            | "U3dhZ2dlciByb2Nrcw==" | U3dhZ2dlciByb2Nrcw== |
        | header            | "U3dhZ2dlciByb2Nrcw==" | U3dhZ2dlciByb2Nrcw== |

Scenario Outline: Incorrect body values
    Given I have constructed the OpenAPI specification with a request body of type 'string', and format 'byte'
    When I try to parse the value '<Value>' as the request body and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | Value                          |
    | "This is certainly not base64" |
    | "2017-07-21T17:32:28Z"         |
    | thisisnotevenvalidjson         |
    | false                          |
    | 42                             |
    | 9223372036854775808            |
    # Because our current code design doesn't enable validation to make a distinction between
    # quoted and unquoted text in request bodies, these values that shouldn't be handled as
    # valid (because they are non-string JSON values, and therefore cannot possibly be
    # base64-formatted string values) are in fact accepted. (Don't be misled by the fact
    # that they don't much look like base64. Lots of strings consisting of only alphanumeric
    # values are acceptable as base64 if their length happens to be a multiple of 4.)
    #| true                           |
    #| null                           |
    #| 9223372036854775808123123123   |

Scenario Outline: Incorrect parameter values
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiString', type 'string', and format 'byte'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiString' and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | ParameterLocation | Value                          |
    | query             | This is certainly not base64   |
    | query             | false                          |
    | query             | 42                             |
    | query             | 9223372036854775808            |
    | query             | 2017-07-21T17:32:28Z           |
    | header            | This is certainly not a date   |
    | cookie            | This%3Ais+certainly+not+a+date |
    | path              | This%3Ais+certainly+not+a+date |

Scenario Outline: Incorrect parameter defaults
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiString', type 'string', format 'byte' and default value '<DefaultValue>'
    When I try to parse the default value and expect an error
    Then an 'OpenApiSpecificationException' should be thrown

    Examples:
    | ParameterLocation | DefaultValue                   |
    | query             | "This:is certainly not base64" |
    | query             | thisisnotevenvalidjson         |
    | query             | false                          |
    | query             | 42                             |
    | query             | 9223372036854775808            |
    | query             | "2017-07-21T17:32:28Z"         |
    | query             | "42"                           |
    | header            | "This is certainly not a date" |
    | cookie            | "This is certainly not a date" |