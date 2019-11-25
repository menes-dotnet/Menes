@perScenarioContainer

Feature: OperationInstrumentation
	In order to monitor service usage and performance
	As a developer
	I want operation execution to be reported automatically through the instrumentation API

Background:
    Given the operation locator maps the operation id 'TestOperationId' to an operation named 'TestOperation'

Scenario: Operation started
	When I handle a 'POST' to '/test/path' with an operation id of 'TestOperationId'
    And the operation invoker has been invoked
	Then instrumentation should start a request named 'TestOperation'
    And the instrumentation should report an OpenAPI operation id of 'TestOperationId'
    And the request should not have been finished yet

Scenario: Operation succeeded
	When I handle a 'POST' to '/test/path' with an operation id of 'TestOperationId'
    And the operation invoker has been invoked
    And the operation completes
	Then instrumentation should start a request named 'TestOperation'
    And the request should have been finished

# Things to test:
# Request started before my code is invoked
# Request not completed before my code is invoked
# Request completed once handling completes
# Request name is based on operation id
# Do we care about the type argument to IOperationsInstrumentation
# Do we include path, method info?
# What do we do if the operationLocator fails to find the operation?
# What about access checks?

# Would only be relevant if logging code was in OpenApiHost, not OpenApiOperationInvoker
# When operation not found, no request is reported

# Question:
# Should we write a specialized diagnostic interface that OpenApiOperationInvoker calls to describe
# all the happenings, and then write an implementation of that which plumbs everything through to
# the instrumentation interfaces?