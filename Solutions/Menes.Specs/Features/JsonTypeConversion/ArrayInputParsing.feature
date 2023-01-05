@perScenarioContainer

Feature: Array Input Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify JSON array inputs within the OpenAPI specification and have corresponding input parameters or bodies deserialized and validated

Scenario: Array body with properties of simple types
    Given I have constructed the OpenAPI specification with a request body of type array, containing items of type 'integer'
    When I try to parse the value '[1,2,3,4,5]' as the request body
    Then the parameter body should be [1,2,3,4,5] of type System.String

Scenario: Array parameter with items of simple type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArray', of type array, containing items of type 'integer'
    When I try to parse the query value '[1,2,3,4,5]' as the parameter 'openApiArray'
    Then the parameter openApiArray should be [1,2,3,4,5] of type System.String

Scenario: Array parameter with properties of simple types via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArray', of type array, containing items of type 'integer', and the default value for the parameter is '[1,2,3,4,5]'
    When I try to parse the default value
    Then the parameter openApiArray should be [1,2,3,4,5] of type System.String


Scenario: Array body with items of array type
    Given I have constructed the OpenAPI specification with a request body of type array, containing items which are arrays themselves with item type 'integer'
    When I try to parse the value '[[1],[2,3],[4,5,6]]' as the request body
    Then the parameter body should be [[1],[2,3],[4,5,6]] of type System.String

Scenario: Array parameter with items of array type
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiNestedArray', of type array, containing items which are arrays themselves with item type 'integer'
    When I try to parse the query value '[[1],[2,3],[4,5,6]]' as the parameter 'openApiNestedArray'
    Then the parameter openApiNestedArray should be [[1],[2,3],[4,5,6]] of type System.String

Scenario: Array parameter with items of array type via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiNestedArray', of type array, containing items which are arrays themselves with item type 'integer', and the default value for the parameter is '[[1],[2,3],[4,5,6]]'
    When I try to parse the default value
    Then the parameter openApiNestedArray should be [[1],[2,3],[4,5,6]] of type System.String


Scenario: Array body with items of object type with properties of complex types
    Given I have constructed the OpenAPI specification with a request body of type array, containing items which are arrays themselves with item type 'integer'
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "names": { "type": "array", "items": { "type": "string" } }, "details": {"type": "object", "properties": { "age": { "type": "integer" }, "hairColour": { "type": "string" } } } }'
    When I try to parse the value '{"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}}' as the request body
    Then the parameter body should be {"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}} of type System.String

Scenario: Array parameter with items of object type with properties of complex types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiArrayWithObjectItems', of type array, containing items which are objects which has the property structure '{ "id": { "type": "integer" }, "name": {"type": "string"} }', and the default value for the parameter is '[{"id": 123, "name": "Ed"}, {"id": 456, "name": "Ian"}]'
    When I try to parse the default value
    Then the parameter openApiArrayWithObjectItems should be [{"id":123,"name":"Ed"},{"id":456,"name":"Ian"}] of type System.String

Scenario: Array parameter with items of object type with properties of complex types via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "names": { "type": "array", "items": { "type": "string" } }, "details": {"type": "object", "properties": { "age": { "type": "integer" }, "hairColour": { "type": "string" } } } }', and the default value for the parameter is '{"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}}'
    When I try to parse the default value
    Then the parameter openApiObjectWithComplexProperties should be {"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}} of type System.String


Scenario Outline: Incorrect body values with array simple types
    Given I have constructed the OpenAPI specification with a request body of type array, containing items of type 'integer'
    When I try to parse the value '<Value>' as the request body and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | Value                    |
    | {"id":123.0,"name":"Ed"} |
    | true                     |
    | null                     |
    | 42                       |
    | 42.0                     |
    | "text"                   |
    | [1,2,3.0]                |
    | ["1", "2"]               |
    | [true, false]            |

Scenario Outline: Incorrect body values with properties of complex types
    Given I have constructed the OpenAPI specification with a request body of type array, containing items which are objects which has the property structure '{ "names": { "type": "array", "items": { "type": "string" } }, "details": {"type": "object", "properties": { "age": { "type": "integer" }, "hairColour": { "type": "string" } } } }'
    When I try to parse the value '<Value>' as the request body and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | Value                                                                 |
    | {"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}}      |
    | [{"names":["Ed",42],"details":{"age":24,"hairColour":"Brown"}}]       |
    | [{"names":["Ed",true],"details":{"age":24,"hairColour":"Brown"}}]     |
    | [{"names":["Ed",null],"details":{"age":24,"hairColour":"Brown"}}]     |
    | [{"names":["Ed",{}],"details":{"age":24,"hairColour":"Brown"}}]       |
    | [{"names":["Ed","Ian"],"details":{"age":24.1,"hairColour":"Brown"}}]  |
    | [{"names":["Ed","Ian"],"details":{"age":"24","hairColour":"Brown"}}]  |
    | [{"names":["Ed","Ian"],"details":{"age":"Ian","hairColour":"Brown"}}] |
    | [{"names":["Ed","Ian"],"details":{"age":true,"hairColour":"Brown"}}]  |
    | [{"names":["Ed","Ian"],"details":{"age":null,"hairColour":"Brown"}}]  |
    | [{"names":["Ed","Ian"],"details":{"age":{},"hairColour":"Brown"}}]    |
    | [{"names":["Ed","Ian"],"details":{"age":24,"hairColour":1}}]          |
    | [{"names":["Ed","Ian"],"details":{"age":24,"hairColour":1.1}}]        |
    | [{"names":["Ed","Ian"],"details":{"age":24,"hairColour":null}}]       |
    | [{"names":["Ed","Ian"],"details":{"age":24,"hairColour":true}}]       |
    | [{"names":["Ed","Ian"],"details":{"age":24,"hairColour":{}}}]         |
    | null                                                                  |
    | true                                                                  |
    | false                                                                 |
    | 42                                                                    |
    | 42.0                                                                  |
    | "text"                                                                |

Scenario Outline: Incorrect parameter values
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "id": { "type": "integer" }, "name": {"type": "string"} }'
    When I try to parse the query value '<Value>' as the parameter 'openApiObject' and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | Value                    |
    | {"id":123.0,"name":"Ed"} |
    | {"id":"123","name":"Ed"} |
    | {"id":true,"name":"Ed"}  |
    | {"id":null,"name":"Ed"}  |
    | {"id":123,"name":true}   |
    | {"id":123,"name":null}   |
    | {"id":123,"name":456}    |
    | {"id":123,"name":456.7}  |
    | null                     |
    | true                     |
    | false                    |
    | 42                       |
    | 42.0                     |
    | text                     |

Scenario Outline: Incorrect parameter values with complex types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "names": { "type": "array", "items": { "type": "string" } }, "details": {"type": "object", "properties": { "age": { "type": "integer" }, "hairColour": { "type": "string" } } } }'
    When I try to parse the query value '<Value>' as the parameter 'openApiObjectWithComplexProperties' and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | Value                                                               |
    | {"names":["Ed",42],"details":{"age":24,"hairColour":"Brown"}}       |
    | {"names":["Ed",true],"details":{"age":24,"hairColour":"Brown"}}     |
    | {"names":["Ed",null],"details":{"age":24,"hairColour":"Brown"}}     |
    | {"names":["Ed",{}],"details":{"age":24,"hairColour":"Brown"}}       |
    | {"names":["Ed","Ian"],"details":{"age":24.1,"hairColour":"Brown"}}  |
    | {"names":["Ed","Ian"],"details":{"age":"24","hairColour":"Brown"}}  |
    | {"names":["Ed","Ian"],"details":{"age":"Ian","hairColour":"Brown"}} |
    | {"names":["Ed","Ian"],"details":{"age":true,"hairColour":"Brown"}}  |
    | {"names":["Ed","Ian"],"details":{"age":null,"hairColour":"Brown"}}  |
    | {"names":["Ed","Ian"],"details":{"age":{},"hairColour":"Brown"}}    |
    | {"names":["Ed","Ian"],"details":{"age":24,"hairColour":1}}          |
    | {"names":["Ed","Ian"],"details":{"age":24,"hairColour":1.1}}        |
    | {"names":["Ed","Ian"],"details":{"age":24,"hairColour":null}}       |
    | {"names":["Ed","Ian"],"details":{"age":24,"hairColour":true}}       |
    | {"names":["Ed","Ian"],"details":{"age":24,"hairColour":{}}}         |
    | null                                                                |
    | true                                                                |
    | false                                                               |
    | 42                                                                  |
    | 42.0                                                                |
    | text                                                                |

Scenario Outline: Incorrect parameter defaults
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "id": { "type": "integer" }, "name": {"type": "string"} }', and the default value for the parameter is '<DefaultValue>'
    When I try to parse the default value and expect an error
    Then an 'OpenApiSpecificationException' should be thrown

    Examples:
    | DefaultValue             |
    | {"id":123.0,"name":"Ed"} |
    | {"id":"123","name":"Ed"} |
    | {"id":true,"name":"Ed"}  |
    | {"id":null,"name":"Ed"}  |
    | {"id":123,"name":null}   |
    # You'd expect these next 3 to fail, but Microsoft.OpenApi knows that "name" is supposed to be a string,
    # so it "helpfully" converts JSON values of type bool or number to strings in the schema's default
    # values. It's not clear whether that's correct. We might need to revisit this when moving to
    # Corvus.JsonSchema.
    #| {"id":123,"name":true}   |
    #| {"id":123,"name":456}    |
    #| {"id":123,"name":456.7}  |
    | null                     |
    | true                     |
    | false                    |
    | 42                       |
    | 42.0                     |
    | text                     |


Scenario Outline: Incorrect parameter defaults with complex types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "names": { "type": "array", "items": { "type": "string" } }, "details": {"type": "object", "properties": { "age": { "type": "integer" }, "hairColour": { "type": "string" } } } }', and the default value for the parameter is '<DefaultValue>'
    When I try to parse the default value and expect an error
    Then an 'OpenApiSpecificationException' should be thrown

    Examples:
    | DefaultValue                      |
    | {"names":["Ed",null],"details":{"age":24,"hairColour":"Brown"}}     |
    | {"names":["Ed",{}],"details":{"age":24,"hairColour":"Brown"}}       |
    | {"names":["Ed","Ian"],"details":{"age":24.1,"hairColour":"Brown"}}  |
    | {"names":["Ed","Ian"],"details":{"age":"24","hairColour":"Brown"}}  |
    | {"names":["Ed","Ian"],"details":{"age":"Ian","hairColour":"Brown"}} |
    | {"names":["Ed","Ian"],"details":{"age":true,"hairColour":"Brown"}}  |
    | {"names":["Ed","Ian"],"details":{"age":null,"hairColour":"Brown"}}  |
    | {"names":["Ed","Ian"],"details":{"age":{},"hairColour":"Brown"}}    |
    | {"names":["Ed","Ian"],"details":{"age":24,"hairColour":null}}       |
    | {"names":["Ed","Ian"],"details":{"age":24,"hairColour":{}}}         |
    # You'd expect these next 5 to fail, but Microsoft.OpenApi knows that "name" is supposed to be a string,
    # so it "helpfully" converts JSON values of type bool or number to strings in the schema's default
    # values. It's not clear whether that's correct. We might need to revisit this when moving to
    # Corvus.JsonSchema.
    #| {"names":["Ed",42],"details":{"age":24,"hairColour":"Brown"}}       |
    #| {"names":["Ed",true],"details":{"age":24,"hairColour":"Brown"}}     |
    #| {"names":["Ed","Ian"],"details":{"age":24,"hairColour":1}}          |
    #| {"names":["Ed","Ian"],"details":{"age":24,"hairColour":1.1}}        |
    #| {"names":["Ed","Ian"],"details":{"age":24,"hairColour":true}}       |
    | null                                                                |
    | true                                                                |
    | false                                                               |
    | 42                                                                  |
    | 42.0                                                                |
    | text                                                                |
