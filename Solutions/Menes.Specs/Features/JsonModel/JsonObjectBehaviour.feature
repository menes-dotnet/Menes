Feature: JsonObjectBehaviour
	Behaviours of a JsonObject

Scenario: Write a jsonelement-backed JsonObject to a string
	Given the JsonElement backed JsonObject {"foo": 3, "bar": "hello", "baz": null}
	When the json value is round-tripped via a string
	Then the round-tripped result should be an Object
	And the round-tripped result should be equal to the JsonAny {"foo": 3, "bar": "hello", "baz": null}

Scenario: Write a dotnet-backed JsonObject to a string
	Given the dotnet backed JsonObject {"foo": 3, "bar": "hello", "baz": null}
	When the json value is round-tripped via a string
	Then the round-tripped result should be an Object
	And the round-tripped result should be equal to the JsonAny {"foo": 3, "bar": "hello", "baz": null}
