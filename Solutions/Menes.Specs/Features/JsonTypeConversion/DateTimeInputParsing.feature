@perScenarioContainer

Feature: DateTime Input Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify date-time-formatted string parameters within the OpenAPI specification and have corresponding input parameters deserialized and validated

Scenario Outline: Body with valid values for simple types
    Given I have constructed the OpenAPI specification with a request body of type 'string', and format 'date-time'
    When I try to parse the value '<Value>' as the request body
    Then the parameter body should be <ExpectedResult> of type System.String

    Examples:
        | Value                  | ExpectedResult       |
        | "2017-07-21T17:32:28Z" | 2017-07-21T17:32:28Z |
        | "2017-07-21T17:32:28"  | 2017-07-21T17:32:28  |
        | "2017-07-21"           | 2017-07-21           |
        | "20170721"             | 20170721             |
        | "2017-07"              | 2017-07              |
        | "2017"                 | 2017                 |

Scenario Outline: Parameters with valid values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiDateTime', type 'string', and format 'date-time'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiDateTime'
    Then the parameter openApiDateTime should be <ExpectedResult> of type System.String

    Examples:
        | ParameterLocation | Value      | ExpectedResult       |
        | path              | 2017-07-21 | 2017-07-21 |
        | query             | 2017-07-21 | 2017-07-21 |
        | cookie            | 2017-07-21 | 2017-07-21 |
        | header            | 2017-07-21 | 2017-07-21 |

Scenario Outline: Parameters with valid default values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiDateTime', type 'string', format 'date-time' and default value '<DefaultValue>'
    When I try to parse the default value
    Then the parameter openApiDateTime should be <ExpectedResult> of type System.String

    Examples:
        | ParameterLocation | DefaultValue                | ExpectedResult            |
        | query             | "2017-07-21T17:32:28+00:00" | 2017-07-21T17:32:28+00:00 |
        | cookie            | "2017-07-21T17:32:28+00:00" | 2017-07-21T17:32:28+00:00 |
        | header            | "2017-07-21T17:32:28+00:00" | 2017-07-21T17:32:28+00:00 |

Scenario Outline: Incorrect body values
    Given I have constructed the OpenAPI specification with a request body of type 'string', and format 'date'
    When I try to parse the value '<Value>' as the request body and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | Value                          |
    | "This is certainly not a date" |
    | thisisnotevenvalidjson         |
    | true                           |
    | false                          |
    | null                           |
    | 42                             |
    | 9223372036854775808            |
    | 9223372036854775808123123123   |
    | "20170721T173228Z"             |
    | "2017-07-21T17:32:28Z"         |

Scenario Outline: Incorrect parameter values
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiDateTime', type 'string', and format 'date'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiDateTime' and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | ParameterLocation | Value                        |
    | query             | This is certainly not a date |
    | query             | true                         |
    | query             | false                        |
    | query             | null                         |
    | query             | 42                           |
    | query             | 9223372036854775808          |
    | query             | 9223372036854775808123123123 |
    | query             | 20170721T173228Z             |
    | query             | 2017-07-21T17:32:28Z         |
    | header            | This is certainly not a date |
    | cookie            | This+is+certainly+not+a+date |
    | path              | This+is+certainly+not+a+date |

Scenario Outline: Incorrect parameter defaults
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiDateTime', type 'string', format 'date' and default value '<DefaultValue>'
    When I try to parse the default value and expect an error
    Then an 'OpenApiSpecificationException' should be thrown

    Examples:
    # Not doing path, because it doesn't really make sense to provide a default - we're only going to match
    # the path template if all parts are present. (E.g., if the path is /pets/{petId}, we don't expect /pets/
    # to match.
    | ParameterLocation | DefaultValue                   |
    | query             | "This is certainly not a date" |
    | query             | thisisnotevenvalidjson         |
    | query             | true                           |
    | query             | false                          |
    | query             | 42                             |
    | query             | 9223372036854775808            |
    | query             | 9223372036854775808123123123   |
    | query             | "20170721T173228Z"             |
    # I'm not convinced this next one should work, but Microsoft.OpenApi parses it happily, and discards
    # the time portion, leaving just the 2017-07-21 date.
    #| query             | "2017-07-21T17:32:28Z"         |
    | query             | "42"                           |
    | header            | "This is certainly not a date" |
    | cookie            | "This is certainly not a date" |