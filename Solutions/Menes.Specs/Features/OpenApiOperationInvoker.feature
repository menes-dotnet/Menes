@perScenarioContainer
@useZeroArgumentTestOperations

Feature: OpenApiOperationInvoker
    In order to implement an Open API service
    As a developer
    I want the OpenApiOperationInvoker to invoke my service implementation method, and all associated services

Scenario Outline: The request details are passed to the scope builders
    Given the operation path template has an Operation with an operationId of '<operationId>'
    When I handle a '<httpMethod>' request for '<path>' with scope builders
    Then the scope builder should receive a path of '<path>'
    And the scope builder should receive an operationId of '<operationId>'
    And the scope builder should receive an HttpMethod of '<httpMethod>'

    Examples:
    | path    | operationId | httpMethod |
    | /test/1 | op1         | GET        |
    | /test/2 | op2         | GET        |
    | /test/1 | op1         | PUT        |
    | /test/2 | op2         | POST       |

Scenario Outline: The request details are passed to the access checker
    Given the operation path template has an Operation with an operationId of '<operationId>'
    When I handle a '<httpMethod>' request for '<path>'
    Then the access checker should receive a path of '<path>'
    And the access checker should receive an operationId of '<operationId>'
    And the access checker should receive an HttpMethod of '<httpMethod>'

    Examples:
    | path    | operationId | httpMethod |
    | /test/1 | op1         | GET        |
    | /test/2 | op2         | GET        |
    | /test/1 | op1         | PUT        |
    | /test/2 | op2         | POST       |

Scenario Outline: The access checker blocks the request without an explanation
    Given I have configured unauthenticated requests to produce <configuredStatusWhenUnauthenticated>
    And the operation path template has an Operation with an operationId of 'op1'
    When I handle a 'GET' request for '/test/1'
    And the access checker blocks access with '<resultType>'
    Then the operation method should not be invoked
    And the invoker should map an '<exceptionType>' with no explanation
    And the invoker should pass the result from the exception mapper to the result builder
    And the invoker should return the result from the result builder

    Examples:
    | configuredStatusWhenUnauthenticated | resultType       | exceptionType                   |
    | null                                | NotAllowed       | OpenApiForbiddenException       |
    | Forbidden                           | NotAllowed       | OpenApiForbiddenException       |
    | Unauthorized                        | NotAllowed       | OpenApiForbiddenException       |
    | ServerError                         | NotAllowed       | OpenApiForbiddenException       |
    | null                                | NotAuthenticated | OpenApiUnauthorizedException    |
    | Forbidden                           | NotAuthenticated | OpenApiForbiddenException       |
    | Unauthorized                        | NotAuthenticated | OpenApiUnauthorizedException    |

Scenario: The access checker blocks the request without an explanation and unauthenticated requests should produce ServerError
    Given I have configured unauthenticated requests to produce ServerError
    And the operation path template has an Operation with an operationId of 'op1'
    When I handle a 'GET' request for '/test/1'
    And the access checker blocks access with 'NotAuthenticated'
    Then the operation method should not be invoked
    And the invoker should complete without exceptions
    And invoker should return a 500 error result

Scenario: The access checker blocks the request with an explanation
    Given the operation path template has an Operation with an operationId of 'op1'
    When I handle a 'GET' request for '/test/1'
    And the access checker blocks access with an explanation of 'no dice'
    Then the operation method should not be invoked
    And the invoker should map an OpenApiForbiddenException with an explanation of 'no dice'
    And the invoker should pass the result from the exception mapper to the result builder
    And the invoker should return the result from the result builder

Scenario: The access checker does not block the request
    Given the operation path template has an Operation with an operationId of 'op1'
    When I handle a 'GET' request for '/test/1'
    And the access checker allows access
    Then the invoker should complete without exceptions
    And the operation method should be invoked
    And the invoker should pass the method result to the result builder
    And the invoker should return the result from the result builder
