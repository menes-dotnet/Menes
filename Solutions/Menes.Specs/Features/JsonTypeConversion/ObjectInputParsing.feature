@perScenarioContainer

Feature: Object Input Parsing
    In order to implement a web API
    As a developer
    I want to be able to specify JSON object inputs within the OpenAPI specification and have corresponding input parameters or bodies deserialized and validated

Scenario: Object body with properties of simple types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "id": { "type": "integer" }, "name": {"type": "string"} }'
    When I try to parse the value '{"id":123,"name":"Ed"}' as the request body
    Then the parameter body should be {"id":123,"name":"Ed"} of type System.String

Scenario: Object parameter with properties of simple types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "id": { "type": "integer" }, "name": {"type": "string"} }'
    When I try to parse the query value '{"id":123,"name":"Ed"}' as the parameter 'openApiObject'
    Then the parameter openApiObject should be {"id":123,"name":"Ed"} of type System.String

Scenario: Object parameter with properties of simple types via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "id": { "type": "integer" }, "name": {"type": "string"} }', and the default value for the parameter is '{"id":123,"name":"Ed"}'
    When I try to parse the default value
    Then the parameter openApiObject should be {"id":123,"name":"Ed"} of type System.String


Scenario Outline: Object body with property-based discriminator using configured discriminated types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "objectType": { "type": "string" } }' with 'objectType' as the discriminator
    When I try to parse the value '{"objectType":"<Discriminator>"}' as the request body
    Then the parameter body should be of type '<ExpectedType>'

    Examples:
        | Discriminator                | ExpectedType                 |
        | registeredDiscriminatedType1 | RegisteredDiscriminatedType1 |
        | registeredDiscriminatedType2 | RegisteredDiscriminatedType2 |

Scenario: Object body with property-based discriminator using registered content type
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "objectType": { "type": "string" } }' with 'objectType' as the discriminator
    When I try to parse the value '{"objectType":"<Discriminator>"}' as the request body
    Then the parameter body should be of type '<ExpectedType>'

    Examples:
        | Discriminator          | ExpectedType           |
        | registeredContentType1 | RegisteredContentType1 |
        | registeredContentType2 | RegisteredContentType2 |


Scenario: Object body with properties of complex types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "names": { "type": "array", "items": { "type": "string" } }, "details": {"type": "object", "properties": { "age": { "type": "integer" }, "hairColour": { "type": "string" } } } }'
    When I try to parse the value '{"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}}' as the request body
    Then the parameter body should be {"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}} of type System.String

Scenario: Object parameter with properties of complex types
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "names": { "type": "array", "items": { "type": "string" } }, "details": {"type": "object", "properties": { "age": { "type": "integer" }, "hairColour": { "type": "string" } } } }'
    When I try to parse the query value '{"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}}' as the parameter 'openApiObjectWithComplexProperties'
    Then the parameter openApiObjectWithComplexProperties should be {"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}} of type System.String

Scenario: Object parameter with properties of complex types via default
    Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "names": { "type": "array", "items": { "type": "string" } }, "details": {"type": "object", "properties": { "age": { "type": "integer" }, "hairColour": { "type": "string" } } } }', and the default value for the parameter is '{"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}}'
    When I try to parse the default value
    Then the parameter openApiObjectWithComplexProperties should be {"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}} of type System.String


Scenario Outline: Incorrect body values with properties of simple types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "id": { "type": "integer" }, "name": {"type": "string"} }'
    When I try to parse the value '<Value>' as the request body and expect an error
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

Scenario Outline: Incorrect body values with properties of complex types
    Given I have constructed the OpenAPI specification with a request body of type object, containing properties in the structure '{ "names": { "type": "array", "items": { "type": "string" } }, "details": {"type": "object", "properties": { "age": { "type": "integer" }, "hairColour": { "type": "string" } } } }'
    When I try to parse the value '<Value>' as the request body and expect an error
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
    | "text"                                                              |

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
