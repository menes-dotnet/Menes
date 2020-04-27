Feature: OpenApiValidation
	In order to diagnose bad requests or responses
	As a developer
	I want to be able to define openapi validation rules in my schema

@perScenarioContainer
Scenario Outline: Validate simple schema
	Given the schema '<Schema Fragment>'
	And the payload '<Payload JSON>'
	When I validate the payload against the schema
	Then the result should be <Result>

	Examples:
		| ID | Schema Fragment                                                                                                    | Payload JSON                      | Result  |
		| 1  | { "anyOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | 3                                 | valid   |
		| 2  | { "anyOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | 3.3                               | valid   |
		| 3  | { "anyOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | [3.3, "henry"]                    | valid   |
		| 4  | { "anyOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | true                              | valid   |
		| 5  | { "anyOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | false                             | valid   |
		| 6  | { "anyOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | { "foo": "something", "bar": 14 } | valid   |
		| 7  | { "anyOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | "A string"                        | invalid |
		# Item 8 is *invalid* because "3" matches BOTH a number AND an integer (i.e. two of, not one of)
		| 8  | { "oneOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | 3                                 | invalid |
		| 9  | { "oneOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | 3.3                               | valid   |
		| 10 | { "oneOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | [3.3, "henry"]                    | valid   |
		| 11 | { "oneOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | true                              | valid   |
		| 12 | { "oneOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | false                             | valid   |
		| 13 | { "oneOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | { "foo": "something", "bar": 14 } | valid   |
		| 14 | { "oneOf": [{"type": "object"}, {"type": "array"}, {"type": "boolean"}, {"type": "integer"}, {"type": "number"}] } | "A string"                        | invalid |
		| 15 | { "properties": {"foo": {type: "string"}, "bar": { type: "number" } } }                                            | { "foo": "something", "bar": 14 } | valid   |
		| 16 | { "type": "object", "properties": {"foo": {type: "string"}, "bar": { type: "number" } } }                          | { "foo": "something", "bar": 14 } | valid   |