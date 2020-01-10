Feature: ShortCircuitingAccessControlPolicyAdapter
    In order to avoid unnecessary work when imposing access control
    As an Open API service developer
    I want to be able to evalute fast-running access control policies so I can skip the slow ones if they are unnecessary

Scenario Outline: Passes arguments to first policy
    Given I have configured 2 other access policies
    When I invoke the adapter for a '<httpMethod>' request for '<path>' with an operationId of '<operationId>'
    Then the first policy should receive a path of '<path>'
    And the first policy should receive an operationId of '<operationId>'
    And the first policy should receive an HttpMethod of '<httpMethod>'

    Examples:
    | path    | operationId | httpMethod |
    | /test/1 | op1         | GET        |
    | /test/2 | op2         | GET        |
    | /test/1 | op1         | PUT        |
    | /test/2 | op2         | POST       |

Scenario: First policy says allow
    Given I have configured 2 other access policies
    When I invoke the adapter for a 'GET' request for '/p/1' with an operationId of 'op3'
    And the first policy allows access
    Then the adapter result should allow the operation
    And the adapter result should have no explanation
    And none of the other policies should have been invoked

Scenario Outline: When first policy blocks the request
    Given I have configured 2 other access policies
    When I invoke the adapter for a '<httpMethod>' request for '<path>' with an operationId of '<operationId>'
    And the first policy denies access
    Then the other policies should receive a path of '<path>'
    And the other policies should receive an operationId of '<operationId>'
    And the other policies should receive an HttpMethod of '<httpMethod>'

    Examples:
    | path    | operationId | httpMethod |
    | /test/1 | op1         | GET        |
    | /test/2 | op2         | GET        |
    | /test/1 | op1         | PUT        |
    | /test/2 | op2         | POST       |

Scenario: The first policy blocks the request and all of the others allows it
    Given I have configured 2 other access policies
    Given I have configured 2 access control policies
    When I invoke the adapter for a 'GET' request for '/p/1' with an operationId of 'op3'
    And the first policy denies access
    And the other policy 0 allows access
    And the other policy 1 allows access
    Then the adapter result should allow the operation
    And the adapter result should have no explanation

Scenario: The first policy blocks the request and one of the others allows it
    Given I have configured 2 other access policies
    Given I have configured 2 access control policies
    When I invoke the adapter for a 'GET' request for '/p/1' with an operationId of 'op3'
    And the first policy denies access
    And the other policy 0 allows access
    And the other policy 1 denies access
    Then the adapter result should block the operation
    And the adapter result should have no explanation
    And the adapter result type should be 'NotAllowed'

Scenario Outline: The first policy blocks the request and all of the others deny it
    Given I have configured 2 other access policies
    When I invoke the adapter for a 'GET' request for '/p/1' with an operationId of 'op3'
    And the first policy denies access with result '<firstPolicyResult>'
    And the other policy 0 denies access with result '<otherPolicy0Result>' and explanation 'stop that'
    And the other policy 1 denies access with result '<otherPolicy1Result>' and explanation 'no no no'
    Then the adapter result should block the operation
    And the adapter result should have an explanation of 'stop that; no no no'
    And the adapter result type should be '<adapterResult>'

    Examples: 
    | firstPolicyResult | otherPolicy0Result | otherPolicy1Result | adapterResult    |
    | NotAllowed        | NotAllowed         | NotAllowed         | NotAllowed       |
    | NotAuthenticated  | NotAllowed         | NotAllowed         | NotAllowed       |
    | NotAllowed        | NotAuthenticated   | NotAllowed         | NotAuthenticated |
    | NotAllowed        | NotAllowed         | NotAuthenticated   | NotAuthenticated |
