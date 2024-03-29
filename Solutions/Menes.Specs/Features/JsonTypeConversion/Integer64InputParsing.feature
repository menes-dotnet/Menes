﻿@perScenarioContainer

Feature: Integer64 Input Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify 64-bit integer parameters within the OpenAPI specification and have corresponding input parameters deserialized and validated

Scenario Outline: Body with valid values for simple types
    Given I have constructed the OpenAPI specification with a request body of type 'integer', and format 'int64'
    When I try to parse the value '<Value>' as the request body
    Then the parameter body should be <ExpectedResult> of type System.Int64

    Examples:
        | Value                | ExpectedResult       |
        | 0                    | 0                    |
        | 1234                 | 1234                 |
        | 2147483647           | 2147483647           |
        | -2147483648          | -2147483648          |
        | 9223372036854775807  | 9223372036854775807  |
        | -9223372036854775808 | -9223372036854775808 |

Scenario Outline: Parameters with valid values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiInteger64', type 'integer', and format 'int64'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiInteger64'
    Then the parameter openApiInteger64 should be <ExpectedResult> of type System.Int64

    Examples:
        | ParameterLocation | Value                | ExpectedResult       |
        | path              | 1234                 | 1234                 |
        | path              | 0                    | 0                    |
        | path              | -42                  | -42                  |
        | path              | 2147483647           | 2147483647           |
        | path              | -2147483648          | -2147483648          |
        | path              | 9223372036854775807  | 9223372036854775807  |
        | path              | -9223372036854775808 | -9223372036854775808 |
        | query             | 1234                 | 1234                 |
        | query             | 0                    | 0                    |
        | query             | -42                  | -42                  |
        | header            | 1234                 | 1234                 |
        | header            | 0                    | 0                    |
        | header            | -42                  | -42                  |
        | cookie            | 1234                 | 1234                 |
        | cookie            | 0                    | 0                    |
        | cookie            | -42                  | -42                  |

Scenario: Array body with items of integer type
    Given I have constructed the OpenAPI specification with a request body of type array, containing items of type 'integer' and format 'int64'
    When I try to parse the value '[1,2,3,9223372036854775807,-9223372036854775808]' as the request body
    Then the parameter body should be [1,2,3,9223372036854775807,-9223372036854775808] of type System.String

Scenario: Array parameter with items of integer type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArray', of type array, containing items of type 'integer' and format 'int64'
    When I try to parse the query value '[1,-9223372036854775808,3,4,5]' as the parameter 'openApiArray'
    Then the parameter openApiArray should be [1,-9223372036854775808,3,4,5] of type System.String

Scenario: Array parameter with items of integer type via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArray', of type array, containing items of type 'integer' and format 'int64', and the default value for the parameter is '[1,2,-9223372036854775808,4,5]'
    When I try to parse the default value
    Then the parameter openApiArray should be [1,2,-9223372036854775808,4,5] of type System.String


Scenario: Array body with items of array type
    Given I have constructed the OpenAPI specification with a request body of type array, containing items which are arrays themselves with item type 'integer' and format 'int64'
    When I try to parse the value '[[1],[2,3],[4,5,6]]' as the request body
    Then the parameter body should be [[1],[2,3],[4,5,6]] of type System.String

Scenario: Array parameter with items of array type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiNestedArray', of type array, containing items which are arrays themselves with item type 'integer' and format 'int64'
    When I try to parse the query value '[[1],[2,3],[4,5,6]]' as the parameter 'openApiNestedArray'
    Then the parameter openApiNestedArray should be [[1],[2,3],[4,5,6]] of type System.String

Scenario: Array parameter with items of array type via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiNestedArray', of type array, containing items which are arrays themselves with item type 'integer' and format 'int64', and the default value for the parameter is '[[1],[2,3],[4,5,6]]'
    When I try to parse the default value
    Then the parameter openApiNestedArray should be [[1],[2,3],[4,5,6]] of type System.String


Scenario: Array body with items of object type
    Given I have constructed the OpenAPI specification with a request body of type array, containing items which are objects which has the property structure '{ "v1": {"type":"integer","format":"int64"}, "v2": {"type": "integer","format":"int64"} }'
    When I try to parse the value '[{"v1":1,"v2":2},{"v1":-3,"v2":0}]' as the request body
    Then the parameter body should be [{"v1":1,"v2":2},{"v1":-3,"v2":0}] of type System.String

Scenario: Array parameter with items of object type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArrayWithObjectItems', of type array, containing items which are objects which has the property structure '{ "v1": {"type":"integer","format":"int64"}, "v2": {"type":"integer","format":"int64"} }'
    When I try to parse the query value '[{"v1":1,"v2":2},{"v1":-3,"v2":0}]' as the parameter 'openApiArrayWithObjectItems'
    Then the parameter openApiArrayWithObjectItems should be [{"v1":1,"v2":2},{"v1":-3,"v2":0}] of type System.String

Scenario: Array parameter with items of object type via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArrayWithObjectItems', of type array, containing items which are objects which has the property structure '{ "v1": {"type":"integer","format":"int64"}, "v2": {"type":"integer","format":"int64"} }', and the default value for the parameter is '[{"v1":1,"v2":2},{"v1":-3,"v2":0}]'
    When I try to parse the default value
    Then the parameter openApiArrayWithObjectItems should be [{"v1":1,"v2":2},{"v1":-3,"v2":0}] of type System.String
    

Scenario: Object body with properties of simple types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "v1": {"type":"integer","format":"int64"}, "v2": {"type":"integer","format":"int64"} }'
    When I try to parse the value '{"v1": -42, "v2": 23}' as the request body
    Then the parameter body should be {"v1": -42, "v2": 23} of type System.String
    
Scenario: Object parameter with properties of simple types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "v1": {"type":"integer","format":"int64"}, "v2": {"type":"integer","format":"int64"} }'
    When I try to parse the query value '{"v1": -42, "v2": 23}' as the parameter 'openApiObject'
    Then the parameter openApiObject should be {"v1": -42, "v2": 23} of type System.String
    
Scenario: Object parameter with properties of simple types via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "v1": {"type":"integer","format":"int64"}, "v2": {"type":"integer","format":"int64"} }', and the default value for the parameter is '{"v1":-42,"v2":23}'
    When I try to parse the default value
    Then the parameter openApiObject should be {"v1":-42,"v2":23} of type System.String


Scenario: Object body with properties of complex types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "values": { "type": "array", "items": {"type":"integer","format":"int64"} }, "details": {"type": "object", "properties": { "v1": {"type":"integer","format":"int64"}, "v2": {"type":"integer","format":"int64"} } } }'
    When I try to parse the value '{"values":[-10,22],"details":{"v1":0,"v2":42}}' as the request body
    Then the parameter body should be {"values":[-10,22],"details":{"v1":0,"v2":42}} of type System.String

Scenario: Object parameter with properties of complex types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "values": { "type": "array", "items": {"type":"integer","format":"int64"} }, "details": {"type": "object", "properties": { "v1": {"type":"integer","format":"int64"}, "v2": {"type":"integer","format":"int64"} } } }'
    When I try to parse the query value '{"values":[-10,22],"details":{"v1":0,"v2":42}}' as the parameter 'openApiObjectWithComplexProperties'
    Then the parameter openApiObjectWithComplexProperties should be {"values":[-10,22],"details":{"v1":0,"v2":42}} of type System.String

Scenario: Object parameter with properties of complex types via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "values": { "type": "array", "items": {"type":"integer","format":"int64"} }, "details": {"type": "object", "properties": { "v1": {"type":"integer","format":"int64"}, "v2": {"type":"integer","format":"int64"} } } }', and the default value for the parameter is '{"values":[-10,22],"details":{"v1":0,"v2":42}}'
    When I try to parse the default value
    Then the parameter openApiObjectWithComplexProperties should be {"values":[-10,22],"details":{"v1":0,"v2":42}} of type System.String


Scenario Outline: Incorrect body values
    Given I have constructed the OpenAPI specification with a request body of type 'integer', and format 'int64'
    When I try to parse the value '<Value>' as the request body and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | Value                             |
    | "This is certainly not a integer" |
    | thisisnotevenvalidjson            |
    | true                              |
    | false                             |
    | null                              |
    | 9223372036854775808               |
    | 9223372036854775808123123123      |
    | "20170721T173228Z"                |

Scenario Outline: Incorrect parameter values
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiInteger', type 'integer', and format 'int64'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiInteger' and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | ParameterLocation | Value                           |
    | query             | This is certainly not a integer |
    | query             | true                            |
    | query             | false                           |
    | query             | null                            |
    | query             | 9223372036854775808             |
    | query             | 9223372036854775808123123123    |
    | query             | 20170721T173228Z                |
    | header            | This is certainly not a integer |
    | cookie            | This+is+certainly+not+a+integer |
    | path              | This+is+certainly+not+a+integer |

Scenario Outline: Incorrect parameter defaults
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiInteger', type 'integer', format 'int64' and default value '<DefaultValue>'
    When I try to parse the default value and expect an error
    Then an 'OpenApiSpecificationException' should be thrown

    Examples:
    # Not doing path, because it doesn't really make sense to provide a default - we're only going to match
    # the path template if all parts are present. (E.g., if the path is /pets/{petId}, we don't expect /pets/
    # to match.
    | ParameterLocation | DefaultValue                      |
    | query             | "This is certainly not a integer" |
    | query             | thisisnotevenvalidjson            |
    | query             | true                              |
    | query             | false                             |
    | query             | 9223372036854775808               |
    | query             | 9223372036854775808123123123      |
    | query             | "20170721T173228Z"                |
    # String-typed numbers are incorrect. JSON numeric values should be used.
    | query             | "42"                              |
    | header            | "This is certainly not a integer" |
    | cookie            | "This is certainly not a integer" |