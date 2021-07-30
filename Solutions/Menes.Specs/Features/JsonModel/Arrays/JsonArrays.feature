Feature: JsonArrays
	Getting, setting, adding and removing elements in an array.

Scenario Outline: Remove items from a JsonElement backed JsonArray
	Given the JsonElement backed <jsonValueType>  <value>
	When I remove the item at index <itemIndex> from the <jsonValueType>
	Then the item in the <jsonValueType> at index <itemIndex> should be <expectedValue> of type <expectedType>

	Examples:
		| jsonValueType | itemIndex | value             | expectedValue                 | expectedType                  |
		| JsonArray     | 0         | ["foo", "bar", 3] | "bar"                         | JsonString                    |
		| JsonAny       | 0         | ["foo", "bar", 3] | "bar"                         | JsonString                    |
		| JsonNotAny    | 0         | ["foo", "bar", 3] | "bar"                         | JsonString                    |
		| JsonArray     | 1         | ["foo", "bar", 3] | 3                             | JsonNumber                    |
		| JsonAny       | 1         | ["foo", "bar", 3] | 3                             | JsonNumber                    |
		| JsonNotAny    | 1         | ["foo", "bar", 3] | 3                             | JsonNumber                    |

Scenario Outline: Set items to JsonElement backed JsonArray
	Given the JsonElement backed <jsonValueType> <value>
	When I set the item in the <jsonValueType> at index <itemIndex> to the value <itemValue>
	Then the item in the <jsonValueType> at index <itemIndex> should be <expectedValue> of type <expectedType>

	Examples:
		| jsonValueType | itemIndex | value             | itemValue | expectedValue                 | expectedType                  |
		| JsonArray     | 0         | ["foo", "bar", 3] | "baz"     | "baz"                         | JsonString                    |
		| JsonAny       | 0         | ["foo", "bar", 3] | "baz"     | "baz"                         | JsonString                    |
		| JsonNotAny    | 0         | ["foo", "bar", 3] | "baz"     | "baz"                         | JsonString                    |
		| JsonArray     | 1         | ["foo", "bar", 3] | "baz"     | "baz"                         | JsonString                    |
		| JsonAny       | 1         | ["foo", "bar", 3] | "baz"     | "baz"                         | JsonString                    |
		| JsonNotAny    | 1         | ["foo", "bar", 3] | "baz"     | "baz"                         | JsonString                    |
		| JsonArray     | 2         | ["foo", "bar", 3] | "baz"     | "baz"                         | JsonString                    |
		| JsonAny       | 2         | ["foo", "bar", 3] | "baz"     | "baz"                         | JsonString                    |
		| JsonNotAny    | 2         | ["foo", "bar", 3] | "baz"     | "baz"                         | JsonString                    |
