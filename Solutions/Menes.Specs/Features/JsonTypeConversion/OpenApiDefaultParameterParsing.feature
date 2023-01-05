@perScenarioContainer

Feature: OpenApiDefaultParameterParsing
    In order to simplify setting values for parameters required for the underlying operation
    As a developer
    I want to be able to specify default values for those parameters within the OpenAPI specification and have those parameters validated and serialized for use downstream.

Scenario Outline: Parameters with valid values for simple types
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name '<ParameterName>', type '<Type>', format '<Format>' and default value '<DefaultValue>'
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


   
Scenario: Any parameter with null default value
    Given I have constructed the OpenAPI specification with a query parameter with name openApiNull, type string, format null and a null default value
    When I try to parse the default value and expect an error
    Then an 'OpenApiSpecificationException' should be thrown

Scenario Outline: Incorrect parameter values
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name '<ParameterName>', type '<Type>', and format '<Format>'
    When I try to parse the <ParameterLocation> value '<Value>' as the parameter '<ParameterName>' and expect an error
    Then an 'OpenApiBadRequestException' should be thrown

    Examples:
    | ParameterLocation | ParameterName   | Type    | Format    | Value                          |
    | query             | openApiDate     | string  | date      | "This is certainly not a date" |
    | header            | openApiDateTime | string  | date-time | "20170721T173228Z"             |
    | cookie            | openApiLong     | integer | int64     | 9223372036854775808123123123   |

Scenario Outline: Incorrect parameter defaults
    Given I have constructed the OpenAPI specification with a <ParameterLocation> parameter with name '<ParameterName>', type '<Type>', format '<Format>' and default value '<DefaultValue>'
    When I try to parse the default value and expect an error
    Then an 'OpenApiSpecificationException' should be thrown

    # 1st example:
    # If we set Type to string and Format to date, the DateConverter will definitely claim responsibility.
    # And if we then hand it a thing that's not a DateTimeOffset, it will fail when it tries to cast the JToken
    # to a DateTimeOffset. That cast is invoking an explicit conversion, and that throws a FormatException if
    # the text isn't a date.
    # 2nd example:
    # The very non-obvious aspect of this is that although 20170721T173228Z looks a lot like a valid date time,
    # it's not one of the acceptable forms for the date-time format. The closest acceptable format would be
    # 2017-07-21T17:32:28. I don't know what the rationale is for getting a different exception for that vs
    # the first example. They're both just strings that aren't in the expected format, and the only reason I
    # can see for getting different exception types is as an artifact of the implementation details - the
    # incorrectly formatted DateTimeOffset is detected by Json.NET at the point where we convert a JToken to
    # a DateTimeOffset, whereas the incorrectly formatted date-time is detected by the JSON Schema validation.
    # Since all three of these are errors caused by an incorrectly formatted string as the default value in
    # the OpenAPI spec. So I think it should be an OpenApiSpecificationException in all three cases.
    Examples:
    | ParameterLocation | ParameterName   | Type    | Format    | DefaultValue                   |
    | query             | openApiDate     | string  | date      | "This is certainly not a date" |
    | header            | openApiDateTime | string  | date-time | "20170721T173228Z"             |
    | cookie            | openApiLong     | integer | int64     | 9223372036854775808123123123   |