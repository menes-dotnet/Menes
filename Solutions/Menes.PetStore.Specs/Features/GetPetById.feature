@perScenarioContainer
@useSelfHostedApi

Feature: Get Pet By Id
	In order to access the pets in the store
	As an API consumer
	I want to be able to request a pet by its Id

Scenario: Request a pet
	When I request the pet with Id 1
	Then the response status code should be 'OK'

Scenario: Request a pet that does not exist
	When I request the pet with Id 1000
	Then the response status code should be 'NotFound'
