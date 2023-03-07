@perScenarioContainer
@useSelfHostedApi

Feature: Get Pet By Id
	In order to access the pets in the store
	As an API consumer
	I want to be able to request a pet by its Id

Scenario: Request a pet
	When I request the pet with Id 1
	Then the response status code should be 'OK'
	And the response should contain the 'ETag' header
	And the response object should have a property called '_links.self'
	And the response object should have a property called 'id'
	And the response object should have a property called 'name'
	And the response object should have a property called 'tag'
	And the response object should have a property called 'size'
	And the response object should have a property called 'globalIdentifier'

Scenario: Request a pet that does not exist
	When I request the pet with Id 1000
	Then the response status code should be 'NotFound'
