﻿@perScenarioContainer

Feature: OpenApiDefaultParameterParsing
	In order to simplify setting values for parameters required for the underlying operation
	As a developer
	I want to be able to specify default values for those parameters within the OpenAPI specification and have those parameters validated and serialized for use downstream.

Scenario Outline: Parameters with valid values for simple types
	Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name <ParameterName>, type <Type>, format <Format> and default value <DefaultValue>
	When I try to parse the default value
	Then the parameter <ParameterName> should be <ExpectedResult> of type <ExpectedResultType>

	Examples:
		| ParameterLocation | ParameterName   | Type    | Format    | DefaultValue                           | ExpectedResult                       | ExpectedResultType        |
		| query             | openApiDate     | string  | date      | 2017-07-21                             | 2017-07-21T00:00:00Z                 | System.DateTimeOffset     |
		| query             | openApiDateTime | string  | date-time | "2017-07-21T17:32:28Z"                 | 2017-07-21T17:32:28+00:00            | System.String             |
		| query             | openApiPassword | string  | password  | myVErySeCurePAsSworD123                | myVErySeCurePAsSworD123              | System.String             |
		| query             | openApiByte     | string  | byte      | U3dhZ2dlciByb2Nrcw==                   | U3dhZ2dlciByb2Nrcw==                 | ByteArrayFromBase64String |
		| query             | openApiString   | string  | uuid      | 9b7d63fb-1689-4697-9571-00d10b873d78   | 9b7d63fb-1689-4697-9571-00d10b873d78 | System.Guid               |
		| query             | openApiString   | string  | uri       | "https://myuri.com"                    | https://myuri.com                    | System.Uri                |
		| query             | openApiString   | string  |           | "I said \"What is a 'PC'?\""           | I said "What is a 'PC'?"             | System.String             |
		| query             | openApiBoolean  | boolean |           | true                                   | true                                 | System.Boolean            |
		| query             | openApiLong     | integer | int64     | 9223372036854775807                    | 9223372036854775807                  | System.Int64              |
		| query             | openApiInteger  | integer |           | 1234                                   | 1234                                 | System.Int32              |
		| query             | openApiNumber   | number  |           | 1234.5                                 | 1234.5                               | System.Double             |
		| query             | openApiFloat    | number  | float     | 1234.5                                 | 1234.5                               | System.Single             |
		| query             | openApiDouble   | number  | double    | 1234.5678                              | 1234.5678                            | System.Double             |
		| header            | openApiDate     | string  | date      | 2017-07-21                             | 2017-07-21T00:00:00Z                 | System.DateTimeOffset     |
		| header            | openApiDateTime | string  | date-time | "2017-07-21T17:32:28Z"                 | 2017-07-21T17:32:28+00:00            | System.String             |
		| header            | openApiPassword | string  | password  | myVErySeCurePAsSworD123                | myVErySeCurePAsSworD123              | System.String             |
		| header            | openApiByte     | string  | byte      | U3dhZ2dlciByb2Nrcw==                   | U3dhZ2dlciByb2Nrcw==                 | ByteArrayFromBase64String |
		| header            | openApiString   | string  | uuid      | 9b7d63fb-1689-4697-9571-00d10b873d78   | 9b7d63fb-1689-4697-9571-00d10b873d78 | System.Guid               |
		| header            | openApiString   | string  | uri       | "https://myuri.com"                    | https://myuri.com                    | System.Uri                |
		| header            | openApiString   | string  |           | "I said \"What is a 'PC'?\""           | I said "What is a 'PC'?"             | System.String             |
		| header            | openApiBoolean  | boolean |           | true                                   | true                                 | System.Boolean            |
		| header            | openApiLong     | integer | int64     | 9223372036854775807                    | 9223372036854775807                  | System.Int64              |
		| header            | openApiInteger  | integer |           | 1234                                   | 1234                                 | System.Int32              |
		| header            | openApiNumber   | number  |           | 1234.5                                 | 1234.5                               | System.Double             |
		| header            | openApiFloat    | number  | float     | 1234.5                                 | 1234.5                               | System.Single             |
		| header            | openApiDouble   | number  | double    | 1234.5678                              | 1234.5678                            | System.Double             |
		| cookie            | openApiDate     | string  | date      | 2017-07-21                             | 2017-07-21T00:00:00Z                 | System.DateTimeOffset     |
		| cookie            | openApiDateTime | string  | date-time | "2017-07-21T17:32:28Z"                 | 2017-07-21T17:32:28+00:00            | System.String             |
		| cookie            | openApiPassword | string  | password  | myVErySeCurePAsSworD123                | myVErySeCurePAsSworD123              | System.String             |
		| cookie            | openApiByte     | string  | byte      | U3dhZ2dlciByb2Nrcw==                   | U3dhZ2dlciByb2Nrcw==                 | ByteArrayFromBase64String |
		| cookie            | openApiString   | string  | uuid      | 9b7d63fb-1689-4697-9571-00d10b873d78   | 9b7d63fb-1689-4697-9571-00d10b873d78 | System.Guid               |
		| cookie            | openApiString   | string  | uri       | "https://myuri.com"                    | https://myuri.com                    | System.Uri                |
		| cookie            | openApiString   | string  |           | "I said \"What the ♻😟¥a is a 'PC'?\"" | I said "What the ♻😟¥a is a 'PC'?"   | System.String             |
		| cookie            | openApiBoolean  | boolean |           | true                                   | true                                 | System.Boolean            |
		| cookie            | openApiLong     | integer | int64     | 9223372036854775807                    | 9223372036854775807                  | System.Int64              |
		| cookie            | openApiInteger  | integer |           | 1234                                   | 1234                                 | System.Int32              |
		| cookie            | openApiNumber   | number  |           | 1234.5                                 | 1234.5                               | System.Double             |
		| cookie            | openApiFloat    | number  | float     | 1234.5                                 | 1234.5                               | System.Single             |
		| cookie            | openApiDouble   | number  | double    | 1234.5678                              | 1234.5678                            | System.Double             |

Scenario: Array parameter with items of simple type
	Given I have constructed the OpenAPI specification with a parameter with name 'openApiArray', of type array, containing items of type 'integer', and the default value for the parameter is '[1,2,3,4,5]'
	When I try to parse the default value
	Then the parameter openApiArray should be [1,2,3,4,5] of type System.String

Scenario: Array parameter with items of array type
	Given I have constructed the OpenAPI specification with a parameter with name 'openApiNestedArray', of type array, containing items which are arrays themselves with item type 'integer', and the default value for the parameter is '[[1],[2,3],[4,5,6]]'
	When I try to parse the default value
	Then the parameter openApiNestedArray should be [[1],[2,3],[4,5,6]] of type System.String

Scenario: Array parameter with items of object type
	Given I have constructed the OpenAPI specification with a parameter with name 'openApiArrayWithObjectItems', of type array, containing items which are objects which has the property structure '{ "id": { "type": "integer" }, "name": {"type": "string"} }', and the default value for the parameter is '[{"id": 123, "name": "Ed"}, {"id": 456, "name": "Ian"}]'
	When I try to parse the default value
	Then the parameter openApiArrayWithObjectItems should be [{"id":123,"name":"Ed"},{"id":456,"name":"Ian"}] of type System.String
	
Scenario: Object parameter with properties of simple types
	Given I have constructed the OpenAPI specification with a parameter with name 'openApiObject', of type object, containing properties in the structure '{ "id": { "type": "integer" }, "name": {"type": "string"} }', and the default value for the parameter is '{"id":123, "name": "Ed"}'
	When I try to parse the default value
	Then the parameter openApiObject should be {"id":123,"name":"Ed"} of type System.String

Scenario: Object parameter with properties of complex types
	Given I have constructed the OpenAPI specification with a parameter with name 'openApiObjectWithComplexProperties', of type object, containing properties in the structure '{ "names": { "type": "array", "items": { "type": "string" } }, "details": {"type": "object", "properties": { "age": { "type": "integer" }, "hairColour": { "type": "string" } } } }', and the default value for the parameter is '{"names": ["Ed","Ian"] , "details": {"age": 24, "hairColour": "Brown"} }'
	When I try to parse the default value
	Then the parameter openApiObjectWithComplexProperties should be {"names":["Ed","Ian"],"details":{"age":24,"hairColour":"Brown"}} of type System.String

Scenario: Any parameter with null default value
	Given I have constructed the OpenAPI specification with a query parameter with name openApiNull, type string, format null and a null default value
	When I try to parse the default value and expect an error
	Then an 'OpenApiSpecificationException' should be thrown

Scenario Outline: Incorrect parameter values
	Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name <ParameterName>, type <Type>, format <Format> and default value <DefaultValue>
	When I try to parse the default value and expect an error
	Then an '<ExceptionType>' should be thrown

	Examples:
	| ParameterLocation | ParameterName   | Type    | Format    | DefaultValue                 | ExceptionType                 |
	| query             | openApiDate     | string  | date      | This is certainly not a date | FormatException               |
	| header            | openApiDateTime | string  | date-time | 20170721T173228Z             | OpenApiBadRequestException    |
	| cookie            | openApiLong     | integer | int64     | 9223372036854775808123123123 | OpenApiSpecificationException |