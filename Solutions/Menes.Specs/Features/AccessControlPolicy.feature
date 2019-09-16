Feature: AccessControlPolicy
	In order to secure an OpenApi service
	As a developer
	I want to be able to configure access control policies

Scenario Outline: The request details are passed to all policies
    Given I have configured 3 access control policies
    When I check access for a '<httpMethod>' request for '<path>' with an operationId of '<operationId>'
    Then each policy should receive a path of '<path>'
    And each policy should receive an operationId of '<operationId>'
    And each policy should receive an HttpMethod of '<httpMethod>'
    And each policy should receive the ClaimsPrincipal attached to the context
    And each policy should receive the Tenant attached to the context

    Examples:
    | path    | operationId | httpMethod |
    | /test/1 | op1         | GET        |
    | /test/2 | op2         | GET        |
    | /test/1 | op1         | PUT        |
    | /test/2 | op2         | POST       |

Scenario: The one and only access control policy blocks the request
	Given I have configured 1 access control policy
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 blocks access without explanation
    Then the result should block the operation
    And the result should have no explanation

Scenario: The one and only access control policy blocks the request with an explanation
	Given I have configured 1 access control policy
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 blocks access with explanation 'you need to be in the in-crowd group'
	Then the result should block the operation
    And the result should have the explanation 'you need to be in the in-crowd group'

Scenario: The one and only access control policy allows the request
	Given I have configured 1 access control policy
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 allows access
    Then the result should allow the operation
    And the result should have no explanation

Scenario: The first of two access control policies blocks the request
    Given I have configured 2 access control policies
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 blocks access without explanation
    And policy 1 allows access
    Then the result should block the operation
    And the result should have no explanation

Scenario: The first of two access control policies blocks the request with an explanation
    Given I have configured 2 access control policies
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 blocks access with explanation 'you looked at me funny'
    And policy 1 allows access
	Then the result should block the operation
    And the result should have the explanation 'you looked at me funny'

Scenario: The second of two access control policies blocks the request
    Given I have configured 2 access control policies
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 allows access
    And policy 1 blocks access without explanation
    Then the result should block the operation
    And the result should have no explanation

Scenario: The second of two access control policies blocks the request with an explanation
    Given I have configured 2 access control policies
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 allows access
    And policy 1 blocks access with explanation 'not on my watch'
	Then the result should block the operation
    And the result should have the explanation 'not on my watch'

Scenario: Both access control policies block the request
    Given I have configured 2 access control policies
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 blocks access without explanation
    And policy 1 blocks access without explanation
    Then the result should block the operation
    And the result should have no explanation

Scenario: Both access control policies block the request and the first provides an explanation
    Given I have configured 2 access control policies
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 blocks access with explanation 'token has incorrect polarity'
    And policy 1 blocks access without explanation
	Then the result should block the operation
    And the result should have the explanation 'token has incorrect polarity'

Scenario: Both access control policies block the request and the second provides an explanation
    Given I have configured 2 access control policies
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 blocks access without explanation
    And policy 1 blocks access with explanation 'computer says no'
	Then the result should block the operation
    And the result should have the explanation 'computer says no'

Scenario: Both access control policies block the request and both provide an explanation
    Given I have configured 2 access control policies
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 blocks access with explanation 'token has incorrect polarity'
    And policy 1 blocks access with explanation 'computer says no'
	Then the result should block the operation
    And the result should have the explanation 'token has incorrect polarity; computer says no'

Scenario: Both access control policies allow the request
    Given I have configured 2 access control policies
    When I check access for a 'GET' request for '/test/1' with an operationId of 'op1'
    And policy 0 allows access
    And policy 1 allows access
    Then the result should allow the operation
    And the result should have no explanation
