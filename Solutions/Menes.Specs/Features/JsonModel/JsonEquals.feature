Feature: JsonEquals
	Validate the Json Equals operator

# JsonString
Scenario Outline: Equals for json element backed value as a string
	Given the JsonElement backed JsonString <jsonValue>
	When I compare it to the string <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value     | result |
		| "Hello"   | "Hello"   | true   |
		| "Hello"   | "Goodbye" | false  |
		| null      | null      | true   |
		| null      | "Goodbye" | false  |

Scenario Outline: Equals for dotnet backed value as a string
	Given the dotnet backed JsonString <jsonValue>
	When I compare it to the string <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value     | result |
		| "Hello"   | "Hello"   | true   |
		| "Hello"   | "Goodbye" | false  |

Scenario Outline: Equals for string json element backed value as an IJsonValue
	Given the JsonElement backed JsonString <jsonValue>
	When I compare the string to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| "Hello"   | "Hello"                        | true   |
		| "Hello"   | "Goodbye"                      | false  |
		| "Hello"   | 1                              | false  |
		| "Hello"   | 1.1                            | false  |
		| "Hello"   | [1,2,3]                        | false  |
		| "Hello"   | { "first": "1" }               | false  |
		| "Hello"   | true                           | false  |
		| "Hello"   | false                          | false  |
		| "Hello"   | "2018-11-13T20:20:39+00:00"    | false  |
		| "Hello"   | "2018-11-13"                   | false  |
		| "Hello"   | "hello@endjin.com"             | false  |
		| "Hello"   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "Hello"   | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for string dotnet backed value as an IJsonValue
	Given the dotnet backed JsonString <jsonValue>
	When I compare the string to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| "Hello"   | "Hello"                        | true   |
		| "Hello"   | "Goodbye"                      | false  |
		| "Hello"   | 1                              | false  |
		| "Hello"   | 1.1                            | false  |
		| "Hello"   | [1,2,3]                        | false  |
		| "Hello"   | { "first": "1" }               | false  |
		| "Hello"   | true                           | false  |
		| "Hello"   | false                          | false  |
		| "Hello"   | "2018-11-13T20:20:39+00:00"    | false  |
		| "Hello"   | "2018-11-13"                   | false  |
		| "Hello"   | "hello@endjin.com"             | false  |
		| "Hello"   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "Hello"   | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for string json element backed value as an object
	Given the JsonElement backed JsonString <jsonValue>
	When I compare the string to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| "Hello"   | "Hello"                        | true   |
		| "Hello"   | "Goodbye"                      | false  |
		| "Hello"   | 1                              | false  |
		| "Hello"   | 1.1                            | false  |
		| "Hello"   | [1,2,3]                        | false  |
		| "Hello"   | { "first": "1" }               | false  |
		| "Hello"   | true                           | false  |
		| "Hello"   | false                          | false  |
		| "Hello"   | "2018-11-13T20:20:39+00:00"    | false  |
		| "Hello"   | "2018-11-13"                   | false  |
		| "Hello"   | "hello@endjin.com"             | false  |
		| "Hello"   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "Hello"   | "{ \"first\": \"1\" }"         | false  |
		| "Hello"   | <new object()>                 | false  |
		| "Hello"   | null                           | false  |

Scenario Outline: Equals for string dotnet backed value as an object
	Given the dotnet backed JsonString <jsonValue>
	When I compare the string to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| "Hello"   | "Hello"                        | true   |
		| "Hello"   | "Goodbye"                      | false  |
		| "Hello"   | 1                              | false  |
		| "Hello"   | 1.1                            | false  |
		| "Hello"   | [1,2,3]                        | false  |
		| "Hello"   | { "first": "1" }               | false  |
		| "Hello"   | true                           | false  |
		| "Hello"   | false                          | false  |
		| "Hello"   | "2018-11-13T20:20:39+00:00"    | false  |
		| "Hello"   | "2018-11-13"                   | false  |
		| "Hello"   | "hello@endjin.com"             | false  |
		| "Hello"   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "Hello"   | "{ \"first\": \"1\" }"         | false  |
		| "Hello"   | <new object()>                 | false  |
		| "Hello"   | null                           | false  |
		| "Hello"   | <null>                         | false  |
		| "Hello"   | <undefined>                    | false  |
		| null      | null                           | true   |
		| null      | <null>                         | true   |
		| null      | <undefined>                    | false  |

# JsonBoolean
Scenario Outline: Equals for json element backed value as a boolean
	Given the JsonElement backed JsonBoolean <jsonValue>
	When I compare it to the boolean <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value | result |
		| true      | true  | true   |
		| false     | false | true   |
		| true      | false | false  |
		| false     | true  | false  |
		| true      | null  | false  |
		| null      | true  | false  |
		| null      | null  | true   |

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
		| jsonValue | value                          | result |
		| false     | "Hello"                        | false  |
		| false     | 1                              | false  |
		| false     | 1.1                            | false  |
		| false     | [1,2,3]                        | false  |
		| false     | { "first": "1" }               | false  |
		| true      | true                           | true   |
		| false     | false                          | true   |
		| true      | false                          | false  |
		| false     | true                           | false  |
		| false     | "2018-11-13T20:20:39+00:00"    | false  |
		| false     | "2018-11-13"                   | false  |
		| false     | "hello@endjin.com"             | false  |
		| false     | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| false     | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for boolean dotnet backed value as an IJsonValue
	Given the dotnet backed JsonBoolean <jsonValue>
	When I compare the boolean to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| false     | "Hello"                        | false  |
		| false     | 1                              | false  |
		| false     | 1.1                            | false  |
		| false     | [1,2,3]                        | false  |
		| false     | { "first": "1" }               | false  |
		| true      | true                           | true   |
		| false     | false                          | true   |
		| true      | false                          | false  |
		| false     | true                           | false  |
		| false     | "2018-11-13T20:20:39+00:00"    | false  |
		| false     | "2018-11-13"                   | false  |
		| false     | "hello@endjin.com"             | false  |
		| false     | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| false     | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for boolean json element backed value as an object
	Given the JsonElement backed JsonBoolean <jsonValue>
	When I compare the boolean to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| false     | "Hello"                        | false  |
		| false     | 1                              | false  |
		| false     | 1.1                            | false  |
		| false     | [1,2,3]                        | false  |
		| false     | { "first": "1" }               | false  |
		| true      | true                           | true   |
		| false     | false                          | true   |
		| true      | false                          | false  |
		| false     | true                           | false  |
		| false     | "2018-11-13T20:20:39+00:00"    | false  |
		| false     | "2018-11-13"                   | false  |
		| false     | "hello@endjin.com"             | false  |
		| false     | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| false     | "{ \"first\": \"1\" }"         | false  |
		| false     | <new object()>                 | false  |
		| false     | null                           | false  |

Scenario Outline: Equals for boolean dotnet backed value as an object
	Given the dotnet backed JsonBoolean <jsonValue>
	When I compare the boolean to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| false     | "Hello"                        | false  |
		| false     | 1                              | false  |
		| false     | 1.1                            | false  |
		| false     | [1,2,3]                        | false  |
		| false     | { "first": "1" }               | false  |
		| true      | true                           | true   |
		| false     | false                          | true   |
		| true      | false                          | false  |
		| false     | true                           | false  |
		| false     | "2018-11-13T20:20:39+00:00"    | false  |
		| false     | "2018-11-13"                   | false  |
		| false     | "hello@endjin.com"             | false  |
		| false     | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| false     | "{ \"first\": \"1\" }"         | false  |
		| false     | <new object()>                 | false  |
		| false     | null                           | false  |
		| false     | <null>                         | false  |
		| false     | <undefined>                    | false  |
		| null      | null                           | true   |
		| null      | <null>                         | true   |
		| null      | <undefined>                    | false  |

# JsonArray
Scenario Outline: Equals for json element backed value as an array
	Given the JsonElement backed JsonArray <jsonValue>
	When I compare it to the array <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value     | result |
		| [1,"2",3] | [1,"2",3] | true   |
		| [1,"2",3] | [3,"2",1] | false  |
		| [1,"2",3] | [1,2,3]   | false  |
		| []        | []        | true   |
		| []        | [3,2,1]   | false  |
		| null      | null      | true   |
		| null      | [1,2,3]   | false  |

Scenario Outline: Equals for dotnet backed value as an array
	Given the dotnet backed JsonArray <jsonValue>
	When I compare it to the array <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value     | result |
		| [1,"2",3] | [1,"2",3] | true   |
		| [1,"2",3] | [3,"2",1] | false  |
		| [1,"2",3] | [1,2,3]   | false  |
		| []        | []        | true   |
		| []        | [3,2,1]   | false  |

Scenario Outline: Equals for array json element backed value as an IJsonValue
	Given the JsonElement backed JsonArray <jsonValue>
	When I compare the array to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| [1,2,3]   | "Hello"                        | false  |
		| [1,2,3]   | 1                              | false  |
		| [1,2,3]   | 1.1                            | false  |
		| [1,2,3]   | [1,2,3]                        | true   |
		| [1,2,3]   | { "first": "1" }               | false  |
		| [1,2,3]   | true                           | false  |
		| [1,2,3]   | false                          | false  |
		| [1,2,3]   | "2018-11-13T20:20:39+00:00"    | false  |
		| [1,2,3]   | "2018-11-13"                   | false  |
		| [1,2,3]   | "hello@endjin.com"             | false  |
		| [1,2,3]   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| [1,2,3]   | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for array dotnet backed value as an IJsonValue
	Given the dotnet backed JsonArray <jsonValue>
	When I compare the array to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| [1,2,3]   | "Hello"                        | false  |
		| [1,2,3]   | 1                              | false  |
		| [1,2,3]   | 1.1                            | false  |
		| [1,2,3]   | [1,2,3]                        | true   |
		| [1,2,3]   | { "first": "1" }               | false  |
		| [1,2,3]   | true                           | false  |
		| [1,2,3]   | false                          | false  |
		| [1,2,3]   | "2018-11-13T20:20:39+00:00"    | false  |
		| [1,2,3]   | "2018-11-13"                   | false  |
		| [1,2,3]   | "hello@endjin.com"             | false  |
		| [1,2,3]   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| [1,2,3]   | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for array json element backed value as an object
	Given the JsonElement backed JsonArray <jsonValue>
	When I compare the array to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| [1,2,3]   | "Hello"                        | false  |
		| [1,2,3]   | 1                              | false  |
		| [1,2,3]   | 1.1                            | false  |
		| [1,2,3]   | [1,2,3]                        | true   |
		| [1,2,3]   | { "first": "1" }               | false  |
		| [1,2,3]   | true                           | false  |
		| [1,2,3]   | false                          | false  |
		| [1,2,3]   | "2018-11-13T20:20:39+00:00"    | false  |
		| [1,2,3]   | "2018-11-13"                   | false  |
		| [1,2,3]   | "hello@endjin.com"             | false  |
		| [1,2,3]   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| [1,2,3]   | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for array dotnet backed value as an object
	Given the dotnet backed JsonArray <jsonValue>
	When I compare the array to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue | value                          | result |
		| [1,2,3]   | "Hello"                        | false  |
		| [1,2,3]   | 1                              | false  |
		| [1,2,3]   | 1.1                            | false  |
		| [1,2,3]   | [1,2,3]                        | true   |
		| [1,2,3]   | { "first": "1" }               | false  |
		| [1,2,3]   | true                           | false  |
		| [1,2,3]   | false                          | false  |
		| [1,2,3]   | "2018-11-13T20:20:39+00:00"    | false  |
		| [1,2,3]   | "2018-11-13"                   | false  |
		| [1,2,3]   | "hello@endjin.com"             | false  |
		| [1,2,3]   | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| [1,2,3]   | "{ \"first\": \"1\" }"         | false  |
		| [1,2,3]   | <new object()>                 | false  |
		| [1,2,3]   | null                           | false  |
		| [1,2,3]   | <null>                         | false  |
		| [1,2,3]   | <undefined>                    | false  |
		| null      | null                           | true   |
		| null      | <null>                         | true   |
		| null      | <undefined>                    | false  |

# JsonBase64Content
Scenario Outline: Equals for json element backed value as a base64content
	Given the JsonElement backed JsonBase64Content <jsonValue>
	When I compare it to the base64content <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| null                           | null                           | true   |
		| null                           | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |

Scenario Outline: Equals for dotnet backed value as a base64content
	Given the dotnet backed JsonBase64Content <jsonValue>
	When I compare it to the base64content <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |

Scenario Outline: Equals for base64content json element backed value as an IJsonValue
	Given the JsonElement backed JsonBase64Content <jsonValue>
	When I compare the base64content to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for base64content dotnet backed value as an IJsonValue
	Given the dotnet backed JsonBase64Content <jsonValue>
	When I compare the base64content to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for base64content json element backed value as an object
	Given the JsonElement backed JsonBase64Content <jsonValue>
	When I compare the base64content to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <new object()>                 | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | null                           | false  |

Scenario Outline: Equals for base64content dotnet backed value as an object
	Given the dotnet backed JsonBase64Content <jsonValue>
	When I compare the base64content to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <new object()>                 | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | null                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <null>                         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <undefined>                    | false  |
		| null                           | null                           | true   |
		| null                           | <null>                         | true   |
		| null                           | <undefined>                    | false  |

# JsonBase64String
Scenario Outline: Equals for json element backed value as a base64string
	Given the JsonElement backed JsonBase64String <jsonValue>
	When I compare it to the base64string <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| null                           | null                           | true   |
		| null                           | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |

Scenario Outline: Equals for dotnet backed value as a base64string
	Given the dotnet backed JsonBase64String <jsonValue>
	When I compare it to the base64string <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |

Scenario Outline: Equals for base64string json element backed value as an IJsonValue
	Given the JsonElement backed JsonBase64String <jsonValue>
	When I compare the base64string to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for base64string dotnet backed value as an IJsonValue
	Given the dotnet backed JsonBase64String <jsonValue>
	When I compare the base64string to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for base64string json element backed value as an object
	Given the JsonElement backed JsonBase64String <jsonValue>
	When I compare the base64string to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <new object()>                 | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | null                           | false  |

Scenario Outline: Equals for base64string dotnet backed value as an object
	Given the dotnet backed JsonBase64String <jsonValue>
	When I compare the base64string to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue                      | value                          | result |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Hello"                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "Goodbye"                      | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1                              | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | 1.1                            | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | [1,2,3]                        | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | { "first": "1" }               | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false                          | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13T20:20:39+00:00"    | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "2018-11-13"                   | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "hello@endjin.com"             | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | true   |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | "{ \"first\": \"1\" }"         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <new object()>                 | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | null                           | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <null>                         | false  |
		| "eyAiaGVsbG8iOiAid29ybGQiIH0=" | <undefined>                    | false  |
		| null                           | null                           | true   |
		| null                           | <null>                         | true   |
		| null                           | <undefined>                    | false  |

# JsonContent
Scenario Outline: Equals for json element backed value as a content
	Given the JsonElement backed JsonContent <jsonValue>
	When I compare it to the content <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                  | result |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }" | true   |
		| "{ \"first\": \"1\" }" | "Goodbye"              | false  |
		| null                   | null                   | true   |
		| null                   | "{ \"first\": \"1\" }" | false  |

Scenario Outline: Equals for dotnet backed value as a content
	Given the dotnet backed JsonContent <jsonValue>
	When I compare it to the content <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                  | result |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }" | true   |
		| "{ \"first\": \"1\" }" | "Goodbye"              | false  |

Scenario Outline: Equals for content json element backed value as an IJsonValue
	Given the JsonElement backed JsonContent <jsonValue>
	When I compare the content to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                          | result |
		| "{ \"first\": \"1\" }" | "Hello"                        | false  |
		| "{ \"first\": \"1\" }" | "Goodbye"                      | false  |
		| "{ \"first\": \"1\" }" | 1                              | false  |
		| "{ \"first\": \"1\" }" | 1.1                            | false  |
		| "{ \"first\": \"1\" }" | [1,2,3]                        | false  |
		| "{ \"first\": \"1\" }" | { "first": "1" }               | false  |
		| "{ \"first\": \"1\" }" | true                           | false  |
		| "{ \"first\": \"1\" }" | false                          | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13T20:20:39+00:00"    | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13"                   | false  |
		| "{ \"first\": \"1\" }" | "hello@endjin.com"             | false  |
		| "{ \"first\": \"1\" }" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }"         | true   |

Scenario Outline: Equals for content dotnet backed value as an IJsonValue
	Given the dotnet backed JsonContent <jsonValue>
	When I compare the content to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                          | result |
		| "{ \"first\": \"1\" }" | "Hello"                        | false  |
		| "{ \"first\": \"1\" }" | "Goodbye"                      | false  |
		| "{ \"first\": \"1\" }" | 1                              | false  |
		| "{ \"first\": \"1\" }" | 1.1                            | false  |
		| "{ \"first\": \"1\" }" | [1,2,3]                        | false  |
		| "{ \"first\": \"1\" }" | { "first": "1" }               | false  |
		| "{ \"first\": \"1\" }" | true                           | false  |
		| "{ \"first\": \"1\" }" | false                          | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13T20:20:39+00:00"    | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13"                   | false  |
		| "{ \"first\": \"1\" }" | "hello@endjin.com"             | false  |
		| "{ \"first\": \"1\" }" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }"         | true   |

Scenario Outline: Equals for content json element backed value as an object
	Given the JsonElement backed JsonContent <jsonValue>
	When I compare the content to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                          | result |
		| "{ \"first\": \"1\" }" | "Hello"                        | false  |
		| "{ \"first\": \"1\" }" | "Goodbye"                      | false  |
		| "{ \"first\": \"1\" }" | 1                              | false  |
		| "{ \"first\": \"1\" }" | 1.1                            | false  |
		| "{ \"first\": \"1\" }" | [1,2,3]                        | false  |
		| "{ \"first\": \"1\" }" | { "first": "1" }               | false  |
		| "{ \"first\": \"1\" }" | true                           | false  |
		| "{ \"first\": \"1\" }" | false                          | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13T20:20:39+00:00"    | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13"                   | false  |
		| "{ \"first\": \"1\" }" | "hello@endjin.com"             | false  |
		| "{ \"first\": \"1\" }" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }"         | true   |
		| "{ \"first\": \"1\" }" | <new object()>                 | false  |
		| "{ \"first\": \"1\" }" | null                           | false  |

Scenario Outline: Equals for content dotnet backed value as an object
	Given the dotnet backed JsonContent <jsonValue>
	When I compare the content to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue              | value                          | result |
		| "{ \"first\": \"1\" }" | "Hello"                        | false  |
		| "{ \"first\": \"1\" }" | "Goodbye"                      | false  |
		| "{ \"first\": \"1\" }" | 1                              | false  |
		| "{ \"first\": \"1\" }" | 1.1                            | false  |
		| "{ \"first\": \"1\" }" | [1,2,3]                        | false  |
		| "{ \"first\": \"1\" }" | { "first": "1" }               | false  |
		| "{ \"first\": \"1\" }" | true                           | false  |
		| "{ \"first\": \"1\" }" | false                          | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13T20:20:39+00:00"    | false  |
		| "{ \"first\": \"1\" }" | "2018-11-13"                   | false  |
		| "{ \"first\": \"1\" }" | "hello@endjin.com"             | false  |
		| "{ \"first\": \"1\" }" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "{ \"first\": \"1\" }" | "{ \"first\": \"1\" }"         | true   |
		| "{ \"first\": \"1\" }" | <new object()>                 | false  |
		| "{ \"first\": \"1\" }" | null                           | false  |
		| "{ \"first\": \"1\" }" | <null>                         | false  |
		| "{ \"first\": \"1\" }" | <undefined>                    | false  |
		| null                   | null                           | true   |
		| null                   | <null>                         | true   |
		| null                   | <undefined>                    | false  |

# JsonDate
Scenario Outline: Equals for json element backed value as a date
	Given the JsonElement backed JsonDate <jsonValue>
	When I compare it to the date <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value        | result |
		| "2018-11-13" | "2018-11-13" | true   |
		| "Garbage"    | "2018-11-13" | false  |
		| "2018-11-13" | "Goodbye"    | false  |
		| null         | null         | true   |
		| null         | "2018-11-13" | false  |

Scenario Outline: Equals for dotnet backed value as a date
	Given the dotnet backed JsonDate <jsonValue>
	When I compare it to the date <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value        | result |
		| "Garbage"    | "2018-11-13" | false  |
		| "2018-11-13" | "2018-11-13" | true   |
		| "2018-11-13" | "Goodbye"    | false  |

Scenario Outline: Equals for date json element backed value as an IJsonValue
	Given the JsonElement backed JsonDate <jsonValue>
	When I compare the date to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value                          | result |
		| "2018-11-13" | "Hello"                        | false  |
		| "2018-11-13" | "Goodbye"                      | false  |
		| "2018-11-13" | 1                              | false  |
		| "2018-11-13" | 1.1                            | false  |
		| "2018-11-13" | [1,2,3]                        | false  |
		| "2018-11-13" | { "first": "1" }               | false  |
		| "2018-11-13" | true                           | false  |
		| "2018-11-13" | false                          | false  |
		| "2018-11-13" | "2018-11-13T20:20:39+00:00"    | false  |
		| "2018-11-13" | "2018-11-13"                   | true   |
		| "Garbage"    | "2018-11-13"                   | false  |
		| "2018-11-13" | "hello@endjin.com"             | false  |
		| "2018-11-13" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13" | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for date dotnet backed value as an IJsonValue
	Given the dotnet backed JsonDate <jsonValue>
	When I compare the date to the IJsonValue <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value                          | result |
		| "2018-11-13" | "Hello"                        | false  |
		| "2018-11-13" | "Goodbye"                      | false  |
		| "2018-11-13" | 1                              | false  |
		| "2018-11-13" | 1.1                            | false  |
		| "2018-11-13" | [1,2,3]                        | false  |
		| "2018-11-13" | { "first": "1" }               | false  |
		| "2018-11-13" | true                           | false  |
		| "2018-11-13" | false                          | false  |
		| "2018-11-13" | "2018-11-13T20:20:39+00:00"    | false  |
		| "2018-11-13" | "2018-11-13"                   | true   |
		| "Garbage"    | "2018-11-13"                   | false  |
		| "2018-11-13" | "hello@endjin.com"             | false  |
		| "2018-11-13" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13" | "{ \"first\": \"1\" }"         | false  |

Scenario Outline: Equals for date json element backed value as an object
	Given the JsonElement backed JsonDate <jsonValue>
	When I compare the date to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value                          | result |
		| "2018-11-13" | "Hello"                        | false  |
		| "2018-11-13" | "Goodbye"                      | false  |
		| "2018-11-13" | 1                              | false  |
		| "2018-11-13" | 1.1                            | false  |
		| "2018-11-13" | [1,2,3]                        | false  |
		| "2018-11-13" | { "first": "1" }               | false  |
		| "2018-11-13" | true                           | false  |
		| "2018-11-13" | false                          | false  |
		| "2018-11-13" | "2018-11-13T20:20:39+00:00"    | false  |
		| "2018-11-13" | "2018-11-13"                   | true   |
		| "2018-11-13" | "hello@endjin.com"             | false  |
		| "2018-11-13" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13" | "{ \"first\": \"1\" }"         | false  |
		| "2018-11-13" | <new object()>                 | false  |
		| "2018-11-13" | null                           | false  |

Scenario Outline: Equals for date dotnet backed value as an object
	Given the dotnet backed JsonDate <jsonValue>
	When I compare the date to the object <value>
	Then the result should be <result>

	Examples:
		| jsonValue    | value                          | result |
		| "2018-11-13" | "Hello"                        | false  |
		| "2018-11-13" | "Goodbye"                      | false  |
		| "2018-11-13" | 1                              | false  |
		| "2018-11-13" | 1.1                            | false  |
		| "2018-11-13" | [1,2,3]                        | false  |
		| "2018-11-13" | { "first": "1" }               | false  |
		| "2018-11-13" | true                           | false  |
		| "2018-11-13" | false                          | false  |
		| "2018-11-13" | "2018-11-13T20:20:39+00:00"    | false  |
		| "2018-11-13" | "2018-11-13"                   | true   |
		| "2018-11-13" | "hello@endjin.com"             | false  |
		| "2018-11-13" | "eyAiaGVsbG8iOiAid29ybGQiIH0=" | false  |
		| "2018-11-13" | "{ \"first\": \"1\" }"         | false  |
		| "2018-11-13" | <new object()>                 | false  |
		| "2018-11-13" | null                           | false  |
		| "2018-11-13" | <null>                         | false  |
		| "2018-11-13" | <undefined>                    | false  |
		| null         | null                           | true   |
		| null         | <null>                         | true   |
		| null         | <undefined>                    | false  |