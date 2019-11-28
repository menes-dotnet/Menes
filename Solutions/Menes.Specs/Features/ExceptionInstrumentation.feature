@perScenarioContainer
@useZeroArgumentTestOperations

Feature: ExceptionInstrumentation
	In order to monitor service usage and performance
	As a developer
	I want exceptions thrown by operations to be reported automatically through the instrumentation API

Background:
    Given the operation locator maps the operation id 'TestOperationId' to an operation named 'TestOperation'

Scenario: Operation threw exception
	When I handle a 'POST' to '/test/path' with an operation id of 'TestOperationId'
    And the operation invoker has been invoked
    And the operation throws an exception
	Then instrumentation should start a request named 'TestOperation'
    And the instrumentation should report the exception thrown by the operation
    And the exception instrumentation should report an OpenAPI operation id of 'TestOperationId'
    And the request should not have been finished at the point when the exception was reported
    And the request should have been finished
