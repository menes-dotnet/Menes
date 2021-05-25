Feature: JsonValues
	Validate the Json Value Wrappers

Scenario Outline: Equals for json element backed value as a string
	Given the JsonElement backed JsonString <jsonValue>
	When I compare it to the string <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value   | result |
		| Hello     | Hello   | true   |
		| Hello     | Goodbye | false  |

Scenario Outline: Equals for dotnet backed value as a string
	Given the dotnet backed JsonString <jsonValue>
	When I compare it to the string <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value   | result |
		| Hello     | Hello   | true   |
		| Hello     | Goodbye | false  |

Scenario Outline: Equals for string json element backed value as an IJsonValue
	Given the JsonElement backed JsonString <jsonValue>
	When I compare the string to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                     | result |
		| Hello     | Hello                     | true   |
		| Hello     | Goodbye                   | false  |
		| Hello     | 1                         | false  |
		| Hello     | 1.1                       | false  |
		| Hello     | [1,2,3]                   | false  |
		| Hello     | { "first": "1" }          | false  |
		| Hello     | true                      | false  |
		| Hello     | false                     | false  |
		| Hello     | 2018-11-13T20:20:39+00:00 | false  |
		| Hello     | hello@endjin.com          | false  |

Scenario Outline: Equals for string dotnet backed value as an IJsonValue
	Given the dotnet backed JsonString <jsonValue>
	When I compare the string to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                     | result |
		| Hello     | Hello                     | true   |
		| Hello     | Goodbye                   | false  |
		| Hello     | 1                         | false  |
		| Hello     | 1.1                       | false  |
		| Hello     | [1,2,3]                   | false  |
		| Hello     | { "first": "1" }          | false  |
		| Hello     | true                      | false  |
		| Hello     | false                     | false  |
		| Hello     | 2018-11-13T20:20:39+00:00 | false  |
		| Hello     | hello@endjin.com          | false  |

Scenario Outline: Equals for string json element backed value as an object
	Given the JsonElement backed JsonString <jsonValue>
	When I compare the string to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                     | result |
		| Hello     | Hello                     | true   |
		| Hello     | Goodbye                   | false  |
		| Hello     | 1                         | false  |
		| Hello     | 1.1                       | false  |
		| Hello     | [1,2,3]                   | false  |
		| Hello     | { "first": "1" }          | false  |
		| Hello     | true                      | false  |
		| Hello     | false                     | false  |
		| Hello     | 2018-11-13T20:20:39+00:00 | false  |
		| Hello     | hello@endjin.com          | false  |

Scenario Outline: Equals for string dotnet backed value as an object
	Given the dotnet backed JsonString <jsonValue>
	When I compare the string to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                     | result |
		| Hello     | Hello                     | true   |
		| Hello     | Goodbye                   | false  |
		| Hello     | 1                         | false  |
		| Hello     | 1.1                       | false  |
		| Hello     | [1,2,3]                   | false  |
		| Hello     | { "first": "1" }          | false  |
		| Hello     | true                      | false  |
		| Hello     | false                     | false  |
		| Hello     | 2018-11-13T20:20:39+00:00 | false  |
		| Hello     | hello@endjin.com          | false  |

Scenario Outline: Equals for json element backed value as a boolean
	Given the JsonElement backed JsonBoolean <jsonValue>
	When I compare it to the boolean <value>
	Then the result should be <result>

	Examples:
		| jsonValue                 | value | result |
		| Hello                     | true  | false  |
		| 1                         | true  | false  |
		| 1.1                       | true  | false  |
		| [1,2,3]                   | true  | false  |
		| { "first": "1" }          | true  | false  |
		| true                      | true  | true   |
		| false                     | false | true   |
		| true                      | false | false  |
		| false                     | true  | false  |
		| 2018-11-13T20:20:39+00:00 | true  | false  |
		| hello@endjin.com          | true  | false  |

Scenario Outline: Equals for dotnet backed value as a boolean
	Given the dotnet backed JsonBoolean <jsonValue>
	When I compare it to the boolean <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value | result |
		| false     | true  | false  |
		| false     | false | true   |
		| true      | true  | true   |
		| true      | false | false  |

Scenario Outline: Equals for boolean json element backed value as an IJsonValue
	Given the JsonElement backed JsonBoolean <jsonValue>
	When I compare the boolean to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                     | result |
		| false     | Hello                     | false  |
		| false     | 1                         | false  |
		| false     | 1.1                       | false  |
		| false     | [1,2,3]                   | false  |
		| false     | { "first": "1" }          | false  |
		| true      | true                      | true   |
		| false     | false                     | true   |
		| true      | false                     | false  |
		| false     | true                      | false  |
		| false     | 2018-11-13T20:20:39+00:00 | false  |
		| false     | hello@endjin.com          | false  |

Scenario Outline: Equals for boolean dotnet backed value as an IJsonValue
	Given the dotnet backed JsonBoolean <jsonValue>
	When I compare the boolean to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                     | result |
		| false     | Hello                     | false  |
		| false     | 1                         | false  |
		| false     | 1.1                       | false  |
		| false     | [1,2,3]                   | false  |
		| false     | { "first": "1" }          | false  |
		| true      | true                      | true   |
		| false     | false                     | true   |
		| true      | false                     | false  |
		| false     | true                      | false  |
		| false     | 2018-11-13T20:20:39+00:00 | false  |
		| false     | hello@endjin.com          | false  |

Scenario Outline: Equals for boolean json element backed value as an object
	Given the JsonElement backed JsonBoolean <jsonValue>
	When I compare the boolean to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                     | result |
		| false     | Hello                     | false  |
		| false     | 1                         | false  |
		| false     | 1.1                       | false  |
		| false     | [1,2,3]                   | false  |
		| false     | { "first": "1" }          | false  |
		| true      | true                      | true   |
		| false     | false                     | true   |
		| true      | false                     | false  |
		| false     | true                      | false  |
		| false     | 2018-11-13T20:20:39+00:00 | false  |
		| false     | hello@endjin.com          | false  |

Scenario Outline: Equals for boolean dotnet backed value as an object
	Given the dotnet backed JsonBoolean <jsonValue>
	When I compare the boolean to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                     | result |
		| false     | Hello                     | false  |
		| false     | 1                         | false  |
		| false     | 1.1                       | false  |
		| false     | [1,2,3]                   | false  |
		| false     | { "first": "1" }          | false  |
		| true      | true                      | true   |
		| false     | false                     | true   |
		| true      | false                     | false  |
		| false     | true                      | false  |
		| false     | 2018-11-13T20:20:39+00:00 | false  |
		| false     | hello@endjin.com          | false  |