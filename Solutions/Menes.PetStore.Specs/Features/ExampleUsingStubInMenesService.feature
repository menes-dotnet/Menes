@perScenarioContainer
@useSelfHostedApi

Feature: Example Using Stub In Menes Service
	In order to make testing my services easier
	As a developer
	I want to be able to use mocks and stubs when self-hosting a Menes service

# Please note that in practice, you'd be very unlikely to ever replace an IOpenApiService with a stub. However, the
# PetStore example doesn't have many services that can be replaced. As a result, and for demo purposes only, we are
# swapping the PetStoreService out for a stub version.
@useStubServiceImplementation
Scenario: Use a stubbed service implementation
	When I request the pet with Id 5000
	Then the response status code should be 'OK'
	And the response object should have a property called '_links.self'
	And the response object should have an integer property called 'id' with value 5000
	And the response object should have a string property called 'name' with value 'stub5000'
	And the response object should have a string property called 'tag' with value 'stub'
	And the response object should have a string property called 'size' with value 'small'
	And the response object should have a string property called 'globalIdentifier' with value '00000000-0000-0000-0000-000000000000'
