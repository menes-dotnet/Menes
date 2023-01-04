@perScenarioContainer

Feature: Boolean Input Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify boolean inputs within the OpenAPI specification and have corresponding input parameters or bodies deserialized and validated

Scenario Outline: Body with valid values for simple types
    Given I have constructed the OpenAPI specification with a request body of type 'boolean', and format ''
    When I try to parse the value '<Value>' as the request body
    Then the parameter body should be <ExpectedResult> of type System.Boolean

    Examples:
        | Value | ExpectedResult |
        | true  | true           |
        | false | false          |

Scenario Outline: Parameters with valid values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiBoolean', type 'boolean', and format ''
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiBoolean'
    Then the parameter openApiBoolean should be <ExpectedResult> of type System.Boolean

    Examples:
        | ParameterLocation | Value | ExpectedResult |
        | path              | true  | true           |
        | path              | false | false          |
        | query             | true  | true           |
        | query             | false | false          |
        | header            | true  | true           |
        | header            | false | false          |
        | cookie            | true  | true           |
        | cookie            | false | false          |

Scenario Outline: Parameters with valid default values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiBoolean', type 'boolean', format '' and default value '<DefaultValue>'
    When I try to parse the default value
    Then the parameter openApiBoolean should be <ExpectedResult> of type System.Boolean

    Examples:
        | ParameterLocation | DefaultValue | ExpectedResult |
        | query             | true         | true           |
        | query             | false        | false          |
        | header            | true         | true           |
        | header            | false        | false          |
        | cookie            | true         | true           |
        | cookie            | false        | false          |

Scenario: Array body with items of boolean type
    Given I have constructed the OpenAPI specification with a request body of type array, containing items of type 'boolean'
    When I try to parse the value '[true,false,true,true,false]' as the request body
    Then the parameter body should be [true,false,true,true,false] of type System.String

Scenario: Array parameter with items of boolean type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArray', of type array, containing items of type 'boolean'
    When I try to parse the query value '[true,false,true,true,false]' as the parameter 'openApiArray'
    Then the parameter openApiArray should be [true,false,true,true,false] of type System.String

Scenario: Array parameter with items of boolean type via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArray', of type array, containing items of type 'boolean', and the default value for the parameter is '[true,false,true,true,false]'
    When I try to parse the default value
    Then the parameter openApiArray should be [true,false,true,true,false] of type System.String


Scenario: Array body with items of array type
    Given I have constructed the OpenAPI specification with a request body of type array, containing items which are arrays themselves with item type 'boolean'
    When I try to parse the value '[[true],[false,true],[true,false,true]]' as the request body
    Then the parameter body should be [[true],[false,true],[true,false,true]] of type System.String

Scenario: Array parameter with items of array type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiNestedArray', of type array, containing items which are arrays themselves with item type 'boolean'
    When I try to parse the query value '[[true],[false,true],[true,false,true]]' as the parameter 'openApiNestedArray'
    Then the parameter openApiNestedArray should be [[true],[false,true],[true,false,true]] of type System.String

Scenario: Array parameter with items of array type via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiNestedArray', of type array, containing items which are arrays themselves with item type 'boolean', and the default value for the parameter is '[[true],[false,true],[true,false,true]]'
    When I try to parse the default value
    Then the parameter openApiNestedArray should be [[true],[false,true],[true,false,true]] of type System.String


Scenario: Array body with items of object type
    Given I have constructed the OpenAPI specification with a request body of type array, containing items which are objects which has the property structure '{ "v1": { "type": "boolean" }, "v2": {"type": "boolean"} }'
    When I try to parse the value '[{"v1":true,"v2":false},{"v1":false,"v2":true}]' as the request body
    Then the parameter body should be [{"v1":true,"v2":false},{"v1":false,"v2":true}] of type System.String
    
Scenario: Array parameter with items of object type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArrayWithObjectItems', of type array, containing items which are objects which has the property structure '{ "v1": { "type": "boolean" }, "v2": {"type": "boolean"} }'
    When I try to parse the query value '[{"v1":true,"v2":false},{"v1":false,"v2":true}]' as the parameter 'openApiArrayWithObjectItems'
    Then the parameter openApiArrayWithObjectItems should be [{"v1":true,"v2":false},{"v1":false,"v2":true}] of type System.String
    
Scenario: Array parameter with items of object type via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArrayWithObjectItems', of type array, containing items which are objects which has the property structure '{ "v1": { "type": "boolean" }, "v2": {"type": "boolean"} }', and the default value for the parameter is '[{"v1":true,"v2":false},{"v1":false,"v2":true}]'
    When I try to parse the default value
    Then the parameter openApiArrayWithObjectItems should be [{"v1":true,"v2":false},{"v1":false,"v2":true}] of type System.String
    

Scenario: Object body with properties of simple types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "v1": { "type": "boolean" }, "v2": {"type": "boolean"} }'
    When I try to parse the value '{"v1":true,"v2":false}' as the request body
    Then the parameter body should be {"v1":true,"v2":false} of type System.String

Scenario: Object parameter with properties of simple types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "v1": { "type": "boolean" }, "v2": {"type": "boolean"} }'
    When I try to parse the query value '{"v1":true,"v2":false}' as the parameter 'openApiObject'
    Then the parameter openApiObject should be {"v1":true,"v2":false} of type System.String

Scenario: Object parameter with properties of simple types via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "v1": { "type": "boolean" }, "v2": {"type": "boolean"} }', and the default value for the parameter is '{"v1":true,"v2":false}'
    When I try to parse the default value
    Then the parameter openApiObject should be {"v1":true,"v2":false} of type System.String


Scenario: Object body with properties of complex types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "values": { "type": "array", "items": { "type": "boolean" } }, "details": {"type": "object", "properties": { "v1": { "type": "boolean" }, "v2": { "type": "boolean" } } } }'
    When I try to parse the value '{"values":[true,false],"details":{"v1":true,"v2":false}}' as the request body
    Then the parameter body should be {"values":[true,false],"details":{"v1":true,"v2":false}} of type System.String

Scenario: Object parameter with properties of complex types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "values": { "type": "array", "items": { "type": "boolean" } }, "details": {"type": "object", "properties": { "v1": { "type": "boolean" }, "v2": { "type": "boolean" } } } }'
    When I try to parse the query value '{"values":[true,false],"details":{"v1":true,"v2":false}}' as the parameter 'openApiObjectWithComplexProperties'
    Then the parameter openApiObjectWithComplexProperties should be {"values":[true,false],"details":{"v1":true,"v2":false}} of type System.String

Scenario: Object parameter with properties of complex types via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "values": { "type": "array", "items": { "type": "boolean" } }, "details": {"type": "object", "properties": { "v1": { "type": "boolean" }, "v2": { "type": "boolean" } } } }', and the default value for the parameter is '{"values":[true,false],"details":{"v1":true,"v2":false}}'
    When I try to parse the default value
    Then the parameter openApiObjectWithComplexProperties should be {"values":[true,false],"details":{"v1":true,"v2":false}} of type System.String


Scenario Outline: Incorrect body values
    Given I have constructed the OpenAPI specification with a request body of type 'boolean', and format ''
    When I try to parse the value '<Value>' as the request body and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | Value                             |
    | "This is certainly not a boolean" |
    | thisisnotevenvalidjson            |
    | null                              |
    | 42                                |
    | 9223372036854775807               |
    | 9223372036854775808123123123      |
    | "20170721T173228Z"                |

Scenario Outline: Incorrect parameter values
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiBoolean', type 'boolean', and format ''
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiBoolean' and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | ParameterLocation | Value                           |
    | query             | This is certainly not a boolean |
    | query             | null                            |
    | query             | 42                              |
    | query             | 9223372036854775807             |
    | query             | 9223372036854775808123123123    |
    | query             | 20170721T173228Z                |
    | header            | This is certainly not a boolean |
    | cookie            | This+is+certainly+not+a+boolean |
    | path              | This+is+certainly+not+a+boolean |

Scenario Outline: Incorrect parameter defaults
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiBoolean', type 'boolean', format '' and default value '<DefaultValue>'
    When I try to parse the default value and expect an error
    Then an 'OpenApiSpecificationException' should be thrown

    Examples:
    # Not doing path, because it doesn't really make sense to provide a default - we're only going to match
    # the path template if all parts are present. (E.g., if the path is /pets/{petId}, we don't expect /pets/
    # to match.
    | ParameterLocation | DefaultValue                      |
    | query             | "This is certainly not a boolean" |
    | query             | thisisnotevenvalidjson            |
    | query             | null                            |
    | query             | 42                                |
    | query             | 9223372036854775807               |
    | query             | 9223372036854775808123123123      |
    | query             | "20170721T173228Z"                |
    # String values of "true" and "false" are incorrect. The JSON true and false values should be used.
    | query             | "true"                            |
    | query             | "false"                           |
    | header            | "This is certainly not a boolean" |
    | cookie            | "This is certainly not a boolean" |