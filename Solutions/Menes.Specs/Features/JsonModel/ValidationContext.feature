Feature: ValidationContext
	Storing validation results in a ValidatioContext

Scenario Outline: Add results to the stack
	Given a <validOrInvalid> validation context <withOrWithoutResults>, <withOrWithoutStack>, <withOrWithoutEvaluatedProperties>, and <withOrWithoutEvaluatedItems>
	When I add a <validOrInvalidResult> with the message <message>
	Then the validationResult should be <validationResultValidOrInvalid>

	Examples:
		| validOrInvalid | withOrWithoutResults | withOrWithoutStack | withOrWithoutEvaluatedProperties | withOrWithoutEvaluatedItems | validOrInvalidResult | message     | validationResultValidOrInvalid |
		| valid          | without results      | with a stack       | without evaluated properties     | without evaluated items     | valid result         | <null>      | valid                          |
		| valid          | without results      | without a stack    | without evaluated properties     | without evaluated items     | valid result         | <null>      | valid                          |
		| valid          | without results      | with a stack       | without evaluated properties     | without evaluated items     | invalid result       | <null>      | invalid                        |
		| valid          | without results      | without a stack    | without evaluated properties     | without evaluated items     | invalid result       | <null>      | invalid                        |
		| invalid        | without results      | with a stack       | without evaluated properties     | without evaluated items     | valid result         | <null>      | invalid                        |
		| invalid        | without results      | without a stack    | without evaluated properties     | without evaluated items     | valid result         | <null>      | invalid                        |
		| invalid        | without results      | with a stack       | without evaluated properties     | without evaluated items     | invalid result       | <null>      | invalid                        |
		| invalid        | without results      | without a stack    | without evaluated properties     | without evaluated items     | invalid result       | <null>      | invalid                        |
		| valid          | without results      | with a stack       | without evaluated properties     | without evaluated items     | valid result         | "A message" | valid                          |
		| valid          | without results      | without a stack    | without evaluated properties     | without evaluated items     | valid result         | "A message" | valid                          |
		| valid          | without results      | with a stack       | without evaluated properties     | without evaluated items     | invalid result       | "A message" | invalid                        |
		| valid          | without results      | without a stack    | without evaluated properties     | without evaluated items     | invalid result       | "A message" | invalid                        |
		| invalid        | without results      | with a stack       | without evaluated properties     | without evaluated items     | valid result         | "A message" | invalid                        |
		| invalid        | without results      | without a stack    | without evaluated properties     | without evaluated items     | valid result         | "A message" | invalid                        |
		| invalid        | without results      | with a stack       | without evaluated properties     | without evaluated items     | invalid result       | "A message" | invalid                        |
		| invalid        | without results      | without a stack    | without evaluated properties     | without evaluated items     | invalid result       | "A message" | invalid                        |
		| valid          | with results         | with a stack       | without evaluated properties     | without evaluated items     | valid result         | <null>      | valid                          |
		| valid          | with results         | without a stack    | without evaluated properties     | without evaluated items     | valid result         | <null>      | valid                          |
		| valid          | with results         | with a stack       | without evaluated properties     | without evaluated items     | invalid result       | <null>      | invalid                        |
		| valid          | with results         | without a stack    | without evaluated properties     | without evaluated items     | invalid result       | <null>      | invalid                        |
		| invalid        | with results         | with a stack       | without evaluated properties     | without evaluated items     | valid result         | <null>      | invalid                        |
		| invalid        | with results         | without a stack    | without evaluated properties     | without evaluated items     | valid result         | <null>      | invalid                        |
		| invalid        | with results         | with a stack       | without evaluated properties     | without evaluated items     | invalid result       | <null>      | invalid                        |
		| invalid        | with results         | without a stack    | without evaluated properties     | without evaluated items     | invalid result       | <null>      | invalid                        |
		| valid          | with results         | with a stack       | without evaluated properties     | without evaluated items     | valid result         | "A message" | valid                          |
		| valid          | with results         | without a stack    | without evaluated properties     | without evaluated items     | valid result         | "A message" | valid                          |
		| valid          | with results         | with a stack       | without evaluated properties     | without evaluated items     | invalid result       | "A message" | invalid                        |
		| valid          | with results         | without a stack    | without evaluated properties     | without evaluated items     | invalid result       | "A message" | invalid                        |
		| invalid        | with results         | with a stack       | without evaluated properties     | without evaluated items     | valid result         | "A message" | invalid                        |
		| invalid        | with results         | without a stack    | without evaluated properties     | without evaluated items     | valid result         | "A message" | invalid                        |
		| invalid        | with results         | with a stack       | without evaluated properties     | without evaluated items     | invalid result       | "A message" | invalid                        |
		| invalid        | with results         | without a stack    | without evaluated properties     | without evaluated items     | invalid result       | "A message" | invalid                        |

Scenario Outline: With evaluated properties
	Given a <validOrInvalid> validation context <withOrWithoutResults>, <withOrWithoutStack>, <withOrWithoutEvaluatedProperties>, and <withOrWithoutEvaluatedItems>
	When I evaluate the properties at [<evaluateIndices>]
	Then the properties at [<notEvaluatedIndices>] should not be evaluated
	Then the properties at [<evaluatedIndices>] should be evaluated

	Examples:
		| validOrInvalid | withOrWithoutResults | withOrWithoutStack | withOrWithoutEvaluatedProperties | withOrWithoutEvaluatedItems | evaluateIndices | evaluatedIndices | notEvaluatedIndices                                   |
		| valid          | without results      | without a stack    | without evaluated properties     | without evaluated items     | 1,2,3           | <none>           | 0,1,2,3,4                                             |
		| valid          | without results      | without a stack    | with evaluated properties        | without evaluated items     | 1,2,3           | 1,2,3            | 0,4                                                   |
		| valid          | without results      | without a stack    | with evaluated properties        | without evaluated items     | 66,129          | 66,129           | 0,1,2,3,4,63,64,65,67,68,126,127,128,130              |
		| valid          | without results      | without a stack    | with evaluated properties        | without evaluated items     | 65536           | 65536            | 0,1,2,3,4,63,64,65,67,68,126,127,128,130,65535,262144 |