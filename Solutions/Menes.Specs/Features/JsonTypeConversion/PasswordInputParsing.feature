@perScenarioContainer

Feature: Password Input Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify password-formatted string parameters within the OpenAPI specification and have corresponding input parameters deserialized and validated

Scenario Outline: Body with valid values for simple types
    Given I have constructed the OpenAPI specification with a request body of type 'string', and format 'password'
    When I try to parse the value '<Value>' as the request body
    Then the parameter body should be <ExpectedResult> of type System.String

    Examples:
        | Value                     | ExpectedResult          |
        | "myVErySeCurePAsSworD123" | myVErySeCurePAsSworD123 |

Scenario Outline: Parameters with valid values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiPassword', type 'string', and format 'password'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiPassword'
    Then the parameter openApiPassword should be <ExpectedResult> of type System.String

    Examples:
        | ParameterLocation | Value                                | ExpectedResult                       |
        | path              | myVErySeCurePAsSworD123 | myVErySeCurePAsSworD123 |
        | query             | myVErySeCurePAsSworD123 | myVErySeCurePAsSworD123 |
        | cookie            | myVErySeCurePAsSworD123 | myVErySeCurePAsSworD123 |
        | header            | myVErySeCurePAsSworD123 | myVErySeCurePAsSworD123 |

Scenario Outline: Parameters with valid default values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiPassword', type 'string', format 'password' and default value '<DefaultValue>'
    When I try to parse the default value
    Then the parameter openApiPassword should be <ExpectedResult> of type System.String

    Examples:
        | ParameterLocation | DefaultValue              | ExpectedResult          |
        | query             | "myVErySeCurePAsSworD123" | myVErySeCurePAsSworD123 |
        | cookie            | "myVErySeCurePAsSworD123" | myVErySeCurePAsSworD123 |
        | header            | "myVErySeCurePAsSworD123" | myVErySeCurePAsSworD123 |

#Scenario Outline: Incorrect body values
#    Given I have constructed the OpenAPI specification with a request body of type 'string', and format 'password'
#    When I try to parse the value '<Value>' as the request body and expect an error
#    Then an 'OpenApiBadRequestException' should be thrown
#
#    Examples:
#    # In principle, values that aren't quoted strings (e.g., true, false, numbers, objects)
#    # should all fail because the request body is JSON, and only a string can contain a
#    # password. However, IOpenApiConverter requires incoming strings values to have the quotes
#    # removed, meaning that it can't tell the difference between "true" (which is a valid
#    # relative password) and true (which shouldn't be). When we move to Corvus.JsonSchema, we
#    # may be able to fix this, but for, any input body will be accepted as a password.
#    | Value                          |
#    | thisisnotevenvalidjson         |
#    | true                           |
#    | false                          |
#    | null                           |
#    | 42                             |
#    | 9223372036854775808            |
#    | 9223372036854775808123123123   |

# Note: most input parsing specs have an "Incorrect parameter values" scenario outline.
# But because all strings are acceptable as passwords, there are no invalid inputs.
# And unlike the "Incorrect body values" case, non-string JSON values aren't a factor
# because when it comes to parameters, strings are never quoted. Whereas our inability
# to distinguish between "true" and true in the body case is a side effect of our current
# code design, in this case it's actually an unavoidable feature: when we have, say,
# http://example.com/pet?name=true, the value of the name parameter is not necessarily
# the JSON boolean constant true - the example would look  the same if the parameter is
# intended as a string.


#Scenario Outline: Incorrect parameter defaults
#    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiPassword', type 'string', format 'password' and default value '<DefaultValue>'
#    When I try to parse the default value and expect an error
#    Then an 'OpenApiSpecificationException' should be thrown
#
#    Examples:
#    # I had been expecting to be able to produce a failure with these because
#    # the value handling doesn't go through the problematic code path that makes
#    # it impossible to detect these as wrong when they are in a request body.
#    # In these cases, it's Microsoft.OpenApi that parses the default value (because
#    # it goes into the OpenAPI spec). However, it turns out that if you state that
#    # a parameter type is a string, Microsoft.OpenApi will coerce any non-string
#    # default value to a string. So if you specify a default value as the JSON
#    # true constant, Microsoft.OpenApi acts as though you'd written the string
#    # value "true". It's not clear if this is required by the OpenAPI or JSON
#    # schema specifications, or if it's just the library trying to be helpful.
#    # If it's the latter, we might want to reinstate these cases once we move
#    # to Corvus.JsonSchema.
#    | ParameterLocation | DefaultValue                   |
#    | query             | thisisnotevenvalidjson         |
#    | query             | true                           |
#    | query             | false                          |
#    | query             | 42                             |
#    | query             | 9223372036854775808            |
#    | query             | 9223372036854775808123123123   |
