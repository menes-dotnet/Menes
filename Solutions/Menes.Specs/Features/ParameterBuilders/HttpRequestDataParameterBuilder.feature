@perScenarioContainer

Feature: Azure Functions HttpRequestData Parameter Builder
    In order to implement a web API that can run in Azure Functions with the isolated worker model
    As a developer
    I want Menes to be able to extract inputs from requests wrapped as HttpRequestData

Scenario: Body
    Given I have constructed the OpenAPI specification with a request body of type array, containing items of type 'integer'
    When I try to parse the value '[1,2,3,4,5]' as the HttpRequestData body
    Then the parameter body should be [1,2,3,4,5] of type System.String

Scenario Outline: Cookie
    Given I have constructed the OpenAPI specification with a cookie parameter with name 'openApiBoolean', type 'boolean', and format ''
    When I try to parse the value '<Value>' as the cookie 'openApiBoolean' in an HttpRequestData
    Then the parameter openApiBoolean should be <ExpectedValue> of type System.Boolean

    Examples: 
    | Value | ExpectedValue |
    | true  | true          |
    | false | false         |

Scenario Outline: Header
    Given I have constructed the OpenAPI specification with a header parameter with name 'openApiBoolean', type 'boolean', and format ''
    When I try to parse the value '<Value>' as the header 'openApiBoolean' in an HttpRequestData
    Then the parameter openApiBoolean should be <ExpectedValue> of type System.Boolean

    Examples: 
    | Value | ExpectedValue |
    | true  | true          |
    | false | false         |

Scenario Outline: Query
    Given I have constructed the OpenAPI specification with a query parameter with name 'openApiBoolean', type 'boolean', and format ''
    When I try to parse the value '<Value>' as the query parameter 'openApiBoolean' in an HttpRequestData
    Then the parameter openApiBoolean should be <ExpectedValue> of type System.Boolean

    Examples: 
    | Value | ExpectedValue |
    | true  | true          |
    | false | false         |
