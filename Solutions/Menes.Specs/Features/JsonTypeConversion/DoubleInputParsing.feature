@perScenarioContainer

Feature: Double Input Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify double parameters within the OpenAPI specification and have corresponding input parameters deserialized and validated

Scenario Outline: Body with valid values for simple types
    Given I have constructed the OpenAPI specification with a request body of type 'number', and format 'double'
    When I try to parse the value '<Value>' as the request body
    Then the parameter body should be <ExpectedResult> of type System.Double

    Examples:
        | Value         | ExpectedResult |
        | 1234          | 1234           |
        | 0             | 0              |
        | -42           | -42            |
        | 2147483647    | 2147483647     |
        | -2147483648   | -2147483648    |
        | 1234.5        | 1234.5         |
        | -1234.567     | -1234.567      |
        | -1234.5678987 | -1234.5678987  |

Scenario Outline: Parameters with valid values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiDouble', type 'number', and format 'double'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiDouble'
    Then the parameter openApiDouble should be <ExpectedResult> of type System.Double

    Examples:
        | ParameterLocation | Value         | ExpectedResult |
        | path              | 1234          | 1234           |
        | path              | 0             | 0              |
        | path              | -42           | -42            |
        | path              | 2147483647    | 2147483647     |
        | path              | -2147483648   | -2147483648    |
        | path              | 1234.5        | 1234.5         |
        | path              | -1234.567     | -1234.567      |
        | path              | -1234.5678987 | -1234.5678987  |
        | query             | 1234          | 1234           |
        | query             | 0             | 0              |
        | query             | -42           | -42            |
        | header            | 1234          | 1234           |
        | header            | 0             | 0              |
        | header            | -42           | -42            |
        | cookie            | 1234          | 1234           |
        | cookie            | 0             | 0              |
        | cookie            | -42           | -42            |

Scenario: Array body with items of integer type
    Given I have constructed the OpenAPI specification with a request body of type array, containing items of type 'number' and format 'double'
    When I try to parse the value '[1,2,3,1234.5,-1234.5678987]' as the request body
    Then the parameter body should be [1,2,3,1234.5,-1234.5678987] of type System.String

Scenario: Array parameter with items of integer type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArray', of type array, containing items of type 'number' and format 'double'
    When I try to parse the query value '[1,-1234.5678987,3,4,5]' as the parameter 'openApiArray'
    Then the parameter openApiArray should be [1,-1234.5678987,3,4,5] of type System.String

Scenario: Array parameter with items of integer type via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArray', of type array, containing items of type 'number' and format 'double', and the default value for the parameter is '[1.0,2.0,-1234.5678987,4.0,5.0]'
    When I try to parse the default value
    Then the parameter openApiArray should be [1.0,2.0,-1234.5678987,4.0,5.0] of type System.String


Scenario: Array body with items of array type
    Given I have constructed the OpenAPI specification with a request body of type array, containing items which are arrays themselves with item type 'number' and format 'double'
    When I try to parse the value '[[1],[2,3],[4,5,6]]' as the request body
    Then the parameter body should be [[1],[2,3],[4,5,6]] of type System.String

Scenario: Array parameter with items of array type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiNestedArray', of type array, containing items which are arrays themselves with item type 'number' and format 'double'
    When I try to parse the query value '[[1],[2,-1234.567],[4,5,6]]' as the parameter 'openApiNestedArray'
    Then the parameter openApiNestedArray should be [[1],[2,-1234.567],[4,5,6]] of type System.String

Scenario: Array parameter with items of array type via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiNestedArray', of type array, containing items which are arrays themselves with item type 'number' and format 'double', and the default value for the parameter is '[[1.0],[2.0,3.0],[4.0,5.0,6.0]]'
    When I try to parse the default value
    Then the parameter openApiNestedArray should be [[1.0],[2.0,3.0],[4.0,5.0,6.0]] of type System.String


Scenario: Array body with items of object type
    Given I have constructed the OpenAPI specification with a request body of type array, containing items which are objects which has the property structure '{ "v1": {"type":"number","format": "double"}, "v2": {"type":"number","format": "double"} }'
    When I try to parse the value '[{"v1":1,"v2":2},{"v1":-3,"v2":0}]' as the request body
    Then the parameter body should be [{"v1":1,"v2":2},{"v1":-3,"v2":0}] of type System.String

Scenario: Array parameter with items of object type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArrayWithObjectItems', of type array, containing items which are objects which has the property structure '{ "v1": { "type":"number","format": "double" }, "v2": {"type":"number","format": "double"} }'
    When I try to parse the query value '[{"v1":1234.5678987,"v2":2},{"v1":-3,"v2":0}]' as the parameter 'openApiArrayWithObjectItems'
    Then the parameter openApiArrayWithObjectItems should be [{"v1":1234.5678987,"v2":2},{"v1":-3,"v2":0}] of type System.String

Scenario: Array parameter with items of object type via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArrayWithObjectItems', of type array, containing items which are objects which has the property structure '{ "v1": { "type":"number","format": "double" }, "v2": {"type":"number","format": "double"} }', and the default value for the parameter is '[{"v1":1.0,"v2":1234.5678987},{"v1":-3.0,"v2":0.0}]'
    When I try to parse the default value
    Then the parameter openApiArrayWithObjectItems should be [{"v1":1.0,"v2":1234.5678987},{"v1":-3.0,"v2":0.0}] of type System.String
    

Scenario: Object body with properties of simple types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "v1": { "type":"number","format": "double" }, "v2": {"type":"number","format": "double"} }'
    When I try to parse the value '{"v1": -42, "v2": 1234.5678987}' as the request body
    Then the parameter body should be {"v1": -42, "v2": 1234.5678987} of type System.String
    
Scenario: Object parameter with properties of simple types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "v1": { "type":"number","format": "double" }, "v2": {"type":"number","format": "double"} }'
    When I try to parse the query value '{"v1": -42, "v2": 23}' as the parameter 'openApiObject'
    Then the parameter openApiObject should be {"v1": -42, "v2": 23} of type System.String
    
Scenario: Object parameter with properties of simple types via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "v1": { "type":"number","format": "double" }, "v2": {"type":"number","format": "double"} }', and the default value for the parameter is '{"v1":-42.0,"v2":23.0}'
    When I try to parse the default value
    Then the parameter openApiObject should be {"v1":-42.0,"v2":23.0} of type System.String


Scenario: Object body with properties of complex types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "values": { "type": "array", "items": { "type":"number","format": "double" } }, "details": {"type": "object", "properties": { "v1": { "type":"number","format": "double" }, "v2": { "type":"number","format": "double" } } } }'
    When I try to parse the value '{"values":[-10,22],"details":{"v1":0,"v2":42}}' as the request body
    Then the parameter body should be {"values":[-10,22],"details":{"v1":0,"v2":42}} of type System.String

Scenario: Object parameter with properties of complex types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "values": { "type": "array", "items": { "type":"number","format": "double" } }, "details": {"type": "object", "properties": { "v1": { "type":"number","format": "double" }, "v2": { "type":"number","format": "double" } } } }'
    When I try to parse the query value '{"values":[-10,22],"details":{"v1":0,"v2":42}}' as the parameter 'openApiObjectWithComplexProperties'
    Then the parameter openApiObjectWithComplexProperties should be {"values":[-10,22],"details":{"v1":0,"v2":42}} of type System.String

Scenario: Object parameter with properties of complex types via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "values": { "type": "array", "items": { "type":"number","format": "double" } }, "details": {"type": "object", "properties": { "v1": { "type":"number","format": "double" }, "v2": { "type":"number","format": "double" } } } }', and the default value for the parameter is '{"values":[-10.0,22.0],"details":{"v1":0.0,"v2":42.0}}'
    When I try to parse the default value
    Then the parameter openApiObjectWithComplexProperties should be {"values":[-10.0,22.0],"details":{"v1":0.0,"v2":42.0}} of type System.String


Scenario Outline: Incorrect body values
    Given I have constructed the OpenAPI specification with a request body of type 'number', and format 'double'
    When I try to parse the value '<Value>' as the request body and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | Value                            |
    | "This is certainly not a double" |
    | thisisnotevenvalidjson           |
    | true                             |
    | false                            |
    | null                             |
    | "20170721T173228Z"               |

Scenario Outline: Incorrect parameter values
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiInteger', type 'number', and format 'double'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter 'openApiInteger' and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | ParameterLocation | Value                          |
    | query             | This is certainly not a double |
    | query             | true                           |
    | query             | false                          |
    | query             | null                           |
    | query             | 20170721T173228Z               |
    | header            | This is certainly not a double |
    | cookie            | This+is+certainly+not+a+double |
    | path              | This+is+certainly+not+a+double |

Scenario Outline: Incorrect parameter defaults
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name 'openApiInteger', type 'number', format 'double' and default value '<DefaultValue>'
    When I try to parse the default value and expect an error
    Then an 'OpenApiSpecificationException' should be thrown

    Examples:
    # Not doing path, because it doesn't really make sense to provide a default - we're only going to match
    # the path template if all parts are present. (E.g., if the path is /pets/{petId}, we don't expect /pets/
    # to match.
    | ParameterLocation | DefaultValue                     |
    | query             | "This is certainly not a double" |
    | query             | thisisnotevenvalidjson           |
    | query             | true                             |
    | query             | false                            |
    | query             | "20170721T173228Z"               |
    # String-typed numbers are incorrect. JSON numeric values should be used.
    | query             | "42"                             |
    | header            | "This is certainly not a double" |
    | cookie            | "This is certainly not a double" |