Feature: JsonArrays
	Getting, setting, adding and removing elements in an array.

Scenario Outline: Remove items from a JsonElement backed JsonArray
	Given the JsonElement backed <jsonValueType>  <value>
	When I remove the item at index <itemIndex> from the <jsonValueType>
	Then the item in the <jsonValueType> at index <itemIndex> should be <expectedValue> of type <expectedType>

	Examples:
		| jsonValueType | itemIndex | value             | expectedValue | expectedType |
		| JsonArray     | 0         | ["foo", "bar", 3] | "bar"         | JsonString   |
		| JsonAny       | 0         | ["foo", "bar", 3] | "bar"         | JsonString   |
		| JsonNotAny    | 0         | ["foo", "bar", 3] | "bar"         | JsonString   |
		| JsonArray     | 1         | ["foo", "bar", 3] | 3             | JsonNumber   |
		| JsonAny       | 1         | ["foo", "bar", 3] | 3             | JsonNumber   |
		| JsonNotAny    | 1         | ["foo", "bar", 3] | 3             | JsonNumber   |

Scenario Outline: Set items to JsonElement backed JsonArray
	Given the JsonElement backed <jsonValueType> <value>
	When I set the item in the <jsonValueType> at index <itemIndex> to the value <itemValue>
	Then the item in the <jsonValueType> at index <itemIndex> should be <expectedValue> of type <expectedType>

	Examples:
		| jsonValueType | itemIndex | value             | itemValue | expectedValue | expectedType |
		| JsonArray     | 0         | ["foo", "bar", 3] | "baz"     | "baz"         | JsonString   |
		| JsonAny       | 0         | ["foo", "bar", 3] | "baz"     | "baz"         | JsonString   |
		| JsonNotAny    | 0         | ["foo", "bar", 3] | "baz"     | "baz"         | JsonString   |
		| JsonArray     | 1         | ["foo", "bar", 3] | "baz"     | "baz"         | JsonString   |
		| JsonAny       | 1         | ["foo", "bar", 3] | "baz"     | "baz"         | JsonString   |
		| JsonNotAny    | 1         | ["foo", "bar", 3] | "baz"     | "baz"         | JsonString   |
		| JsonArray     | 2         | ["foo", "bar", 3] | "baz"     | "baz"         | JsonString   |
		| JsonAny       | 2         | ["foo", "bar", 3] | "baz"     | "baz"         | JsonString   |
		| JsonNotAny    | 2         | ["foo", "bar", 3] | "baz"     | "baz"         | JsonString   |


Scenario Outline: Remove items from a JsonElement backed JsonArray where the index is out of range
	Given the JsonElement backed <jsonValueType>  <value>
	When I remove the item at index <itemIndex> from the <jsonValueType>
	Then the array operation should produce an ArgumentOutOfRangeException

	Examples:
		| jsonValueType | itemIndex | value             |
		| JsonArray     | 3         | ["foo", "bar", 3] |
		| JsonAny       | 3         | ["foo", "bar", 3] |
		| JsonNotAny    | 3         | ["foo", "bar", 3] |

Scenario Outline: Set items to JsonElement backed JsonArray where the index is out of range
	Given the JsonElement backed <jsonValueType> <value>
	When I set the item in the <jsonValueType> at index <itemIndex> to the value <itemValue>
	Then the array operation should produce an ArgumentOutOfRangeException

	Examples:
		| jsonValueType | itemIndex | value             | itemValue |
		| JsonArray     | 3         | ["foo", "bar", 3] | "baz"     |
		| JsonAny       | 3         | ["foo", "bar", 3] | "baz"     |
		| JsonNotAny    | 3         | ["foo", "bar", 3] | "baz"     |

Scenario Outline: Get items from a JsonElement backed JsonArray where the index is out of range
	Given the JsonElement backed <jsonValueType> <value>
	When I get the <itemType> in the <jsonValueType> at index <itemIndex>
	Then the array operation should produce an ArgumentOutOfRangeException

	Examples:
		| jsonValueType | itemIndex | value             | itemType   |
		| JsonArray     | 3         | ["foo", "bar", 3] | JsonString |
		| JsonAny       | 3         | ["foo", "bar", 3] | JsonString |
		| JsonNotAny    | 3         | ["foo", "bar", 3] | JsonString |