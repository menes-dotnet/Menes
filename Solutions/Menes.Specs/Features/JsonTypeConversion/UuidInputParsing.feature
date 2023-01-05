@perScenarioContainer

Feature: Uuid Input Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify uuid-formatted string parameters within the OpenAPI specification and have corresponding input parameters deserialized and validated

Scenario Outline: Body with valid values for simple types
    Given I have constructed the OpenAPI specification with a request body of type 'string', and format 'uuid'
    When I try to parse the value '<Value>' as the request body
    Then the parameter body should be <ExpectedResult> of type System.Guid

    Examples:
        | Value                                  | ExpectedResult                       |
        | "9b7d63fb-1689-4697-9571-00d10b873d78" | 9b7d63fb-1689-4697-9571-00d10b873d78 |

Scenario Outline: Parameters with valid values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiString', type 'string', and format 'uuid'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiString'
    Then the parameter openApiString should be <ExpectedResult> of type System.Guid

    Examples:
        | ParameterLocation | Value                                | ExpectedResult                       |
        | path              | 9b7d63fb-1689-4697-9571-00d10b873d78 | 9b7d63fb-1689-4697-9571-00d10b873d78 |
        | query             | 9b7d63fb-1689-4697-9571-00d10b873d78 | 9b7d63fb-1689-4697-9571-00d10b873d78 |
        | cookie            | 9b7d63fb-1689-4697-9571-00d10b873d78 | 9b7d63fb-1689-4697-9571-00d10b873d78 |
        | header            | 9b7d63fb-1689-4697-9571-00d10b873d78 | 9b7d63fb-1689-4697-9571-00d10b873d78 |

Scenario Outline: Parameters with valid default values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiString', type 'string', format 'uuid' and default value '<DefaultValue>'
    When I try to parse the default value
    Then the parameter openApiString should be <ExpectedResult> of type System.Guid

    Examples:
        | ParameterLocation | DefaultValue                           | ExpectedResult                       |
        | query             | "9b7d63fb-1689-4697-9571-00d10b873d78" | 9b7d63fb-1689-4697-9571-00d10b873d78 |
        | cookie            | "9b7d63fb-1689-4697-9571-00d10b873d78" | 9b7d63fb-1689-4697-9571-00d10b873d78 |
        | header            | "9b7d63fb-1689-4697-9571-00d10b873d78" | 9b7d63fb-1689-4697-9571-00d10b873d78 |

Scenario Outline: Incorrect body values
    Given I have constructed the OpenAPI specification with a request body of type 'string', and format 'uuid'
    When I try to parse the value '<Value>' as the request body and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | Value                          |
    | "This is certainly not a guid" |
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
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiString', type 'string', and format 'uuid'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiString' and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | ParameterLocation | Value                        |
    | query             | This is certainly not a guid |
    | query             | true                         |
    | query             | false                        |
    | query             | null                         |
    | query             | 42                           |
    | query             | 9223372036854775808          |
    | query             | 9223372036854775808123123123 |
    | query             | 20170721T173228Z             |
    | query             | 2017-07-21T17:32:28Z         |
    | header            | This is certainly not a guid |
    | cookie            | This+is+certainly+not+a+guid |
    | path              | This+is+certainly+not+a+guid |

Scenario Outline: Incorrect parameter defaults
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiString', type 'string', format 'uuid' and default value '<DefaultValue>'
    When I try to parse the default value and expect an error
    Then an 'OpenApiSpecificationException' should be thrown

    Examples:
    # Not doing path, because it doesn't really make sense to provide a default - we're only going to match
    # the path template if all parts are present. (E.g., if the path is /pets/{petId}, we don't expect /pets/
    # to match.
    | ParameterLocation | DefaultValue                   |
    | query             | "This is certainly not a guid" |
    | query             | thisisnotevenvalidjson         |
    | query             | true                           |
    | query             | false                          |
    | query             | 42                             |
    | query             | 9223372036854775808            |
    | query             | 9223372036854775808123123123   |
    | query             | "20170721T173228Z"             |
    | query             | "2017-07-21T17:32:28Z"         |
    | query             | "42"                           |
    | header            | "This is certainly not a date" |
    | cookie            | "This is certainly not a date" |