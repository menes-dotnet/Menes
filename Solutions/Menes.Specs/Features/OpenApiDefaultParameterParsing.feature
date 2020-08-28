Feature: OpenApiDefaultParameterParsing
	In order to simplify setting values for parameters required for the underlying operation
	As a developer
	I want to be able to specify default values for those parameters within the OpenAPI specification and have those parameters validated and serialized for use downstream.

@perScenarioContainer
Scenario Outline: Parameters with valid values for simple types
	Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name <ParameterName>, type <Type>, format <Format> and default value <DefaultValue>
	When I try to parse the default value
	Then the parameter <ParameterName> should be <ExpectedResult> of type <ExpectedResultType>

	Examples:
		| ParameterLocation | ParameterName   | Type    | Format    | DefaultValue                | ExpectedResult          | ExpectedResultType        |
		| query             | openApiDate     | string  | date      | 2017-07-21                  | 2017-07-21T00:00:00Z    | System.DateTimeOffset     |
		| query             | openApiDateTime | string  | date-time | "2017-07-21T17:32:28Z" | 2017-07-21T17:32:28+00:00    | System.String             |
		| query             | openApiPassword | string  | password  | "myVErySeCurePAsSworD123"   | myVErySeCurePAsSworD123 | System.String             |
		| query             | openApiByte     | string  | byte      | U3dhZ2dlciByb2Nrcw==        | U3dhZ2dlciByb2Nrcw==    | ByteArrayFromBase64String |
		| query             | openApiBinary   | string  | binary    | "U0VORCBIRUxQ"                | U0VORCBIRUxQ            | System.String |
		| query             | openApiString   | string  |           | "Don't decode the above"    | Don't decode the above  | System.String             |
		| query             | openApiBoolean  | boolean |           | true                        | true                    | System.Boolean            |
		| query             | openApiLong     | integer | int64     | 9223372036854775807         | 9223372036854775807     | System.Int64              |
		| query             | openApiInteger  | integer |           | 1234                        | 1234                    | System.Int32              |
		| query             | openApiFloat    | number  | float     | 1234.5                      | 1234.5                  | System.Single             |
		| query             | openApiDouble   | number  | double    | 1234.5678                   | 1234.5678               | System.Double             |
#		| query             | openApiNull     | string  |           |                           |                           |                           |
#		| path              | openApiDate     | string  | date      | 2017-07-21                | 2017-07-21                |  System.DateTimeOffset                         |
#		| path              | openApiDateTime | string  | date-time | "2017-07-21T17:32:28Z"      | 2017-07-21T17:32:28Z      |   System.String                        |
#		| path              | openApiPassword | string  | password  | "myVErySeCurePAsSworD123" | myVErySeCurePAsSworD123 |    System.String                       |
#		| path              | openApiByte     | string  | byte      | U3dhZ2dlciByb2Nrcw==      | U3dhZ2dlciByb2Nrcw==      |  ByteArrayFromBase64String                         |
#		| path              | openApiBinary   | string  | binary    | U0VORCBIRUxQ              | U0VORCBIRUxQ              |  ByteArrayFromBase64String                         |
#		| path              | openApiString   | string  |           | "Don't decode the above"  | Don't decode the above  |    System.String                       |
#		| path              | openApiBoolean  | boolean |           | true                      | true                      |  System.Boolean                         |
#		| path              | openApiLong     | integer | int64     | 9223372036854775807       | 9223372036854775807       |  System.Int64                         |
#		| path              | openApiInteger  | integer |           | 1234                      | 1234                      |    System.Int32                       |
#		| path              | openApiFloat    | number  | float     | 1234.5                    | 1234.5                    |   System.Single                        |
#		| path              | openApiDouble   | number  | double    | 1234.5678                 | 1234.5678                 |   System.Double                        |
#		| path              | openApiNull     | string  |           |                           |                           |                           |
		| header            | openApiDate     | string  | date      | 2017-07-21                | 2017-07-21T00:00:00Z                |  System.DateTimeOffset                         |
		| header            | openApiDateTime | string  | date-time | "2017-07-21T17:32:28Z"      | 2017-07-21T17:32:28+00:00      |   System.String                        |
		| header            | openApiPassword | string  | password  | "myVErySeCurePAsSworD123" | myVErySeCurePAsSworD123 |       System.String                    |
		| header            | openApiByte     | string  | byte      | U3dhZ2dlciByb2Nrcw==      | U3dhZ2dlciByb2Nrcw==      |  ByteArrayFromBase64String                         |
		| header            | openApiBinary   | string  | binary    | "U0VORCBIRUxQ"              | U0VORCBIRUxQ              |   System.String                        |
		| header            | openApiString   | string  |           | "Don't decode the above"  | Don't decode the above  |     System.String                      |
		| header            | openApiBoolean  | boolean |           | true                      | true                      |   System.Boolean                        |
		| header            | openApiLong     | integer | int64     | 9223372036854775807       | 9223372036854775807       |  System.Int64                         |
		| header            | openApiInteger  | integer |           | 1234                      | 1234                      |  System.Int32                         |
		| header            | openApiFloat    | number  | float     | 1234.5                    | 1234.5                    |  System.Single                         |
		| header            | openApiDouble   | number  | double    | 1234.5678                 | 1234.5678                 |  System.Double                         |
#		| header            | openApiNull     | string  |           |                           |                           |                           |
		| cookie            | openApiDate     | string  | date      | 2017-07-21                | 2017-07-21T00:00:00Z                | System.DateTimeOffset                          |
		| cookie            | openApiDateTime | string  | date-time | "2017-07-21T17:32:28Z"      | 2017-07-21T17:32:28+00:00      |  System.String                         |
		| cookie            | openApiPassword | string  | password  | "myVErySeCurePAsSworD123" | myVErySeCurePAsSworD123 |     System.String                      |
		| cookie            | openApiByte     | string  | byte      | U3dhZ2dlciByb2Nrcw==      | U3dhZ2dlciByb2Nrcw==      |  ByteArrayFromBase64String                         |
		| cookie            | openApiBinary   | string  | binary    | U0VORCBIRUxQ              | U0VORCBIRUxQ              |  System.String                         |
		| cookie            | openApiString   | string  |           | "Don't decode the above"  | Don't decode the above  |    System.String                       |
		| cookie            | openApiBoolean  | boolean |           | true                      | true                      | System.Boolean            |
		| cookie            | openApiLong     | integer | int64     | 9223372036854775807       | 9223372036854775807       |  System.Int64                         |
		| cookie            | openApiInteger  | integer |           | 1234                      | 1234                      |  System.Int32                         |
		| cookie            | openApiFloat    | number  | float     | 1234.5                    | 1234.5                    |  System.Single                         |
		| cookie            | openApiDouble   | number  | double    | 1234.5678                 | 1234.5678                 |  System.Double                         |
#		| cookie            | openApiNull     | string  |           |                           |                           |                           |

Scenario: Array parameter with items of simple type
	Given I have constructed the OpenAPI specification with a parameter of type array with name 'openApiArray', item type 'integer', and default value '[1,2,3,4,5]'
	When I try to parse the default value
	Then the serialized result should be '{[1,2,3,4,5]}'

Scenario: Array parameter with items of array type
	Given I have constructed the OpenAPI specification with a parameter of type array with name 'openApiNestedArray' containing items which are arrays themselves with item type 'integer'
	When I try to parse the default value
	Then the serialized result should be '{[1,2,3,4,5]}'

# Do we want to handle our custom string formats? (Uri, Uuid?)
# Do we want to add incorrect 