Feature: ExemptOperationIdsAccessPolicy
    In order to enable certain Open API operations to opt out of service-wide access control policies
    As an Open API service develoepr
    I want to be able to define exemptions

Scenario: Operation id is first exempt one
    Given I have a policy that exempts ids 'op1' and 'op2'
    When I evaluate the exemption policy with an operation id of 'op1'
    Then the policy should allow the operation

Scenario: Operation id is second exempt one
    Given I have a policy that exempts ids 'op1' and 'op2'
    When I evaluate the exemption policy with an operation id of 'op2'
    Then the policy should allow the operation

Scenario: Operation id is not exempt
    Given I have a policy that exempts ids 'op1' and 'op2'
    When I evaluate the exemption policy with an operation id of 'op3'
    Then the policy should deny the operation
