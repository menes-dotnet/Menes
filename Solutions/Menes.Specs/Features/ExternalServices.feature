Feature: ExternalServices

As a developer writing a web service
I need to be able to generate URLs for other Menes-based services
So that my service can provide client applications with links to relevant entities


Scenario: Pass IConfiguration during registration
    Given my configuration contains the setting 'MyExternalService' with the value 'http://example.com:1234'
    And I have registered an external service with an embedded definition, passing an IConfiguration directly, and a base URL configuration key of 'MyExternalService'
    When I resolve an external service URL for the operation 'getWithTwoPathParameters' with these parameters
        | Name         | Type          | Value |
        | pathElement1 | System.String | p1    |
        | pathElement2 | System.Int64  | 1234  |
    Then the resolved external service URL is 'http://example.com:1234/test/p1/path/1234'
