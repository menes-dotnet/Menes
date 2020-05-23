@perScenarioContainer
@useSelfHostedApi
Feature: ListPets
	In order to access the pets in the store
	As an API consumer
	I want to be able to request a list of pets

Scenario: Request a page of pets
	When I request a list of pets
	Then the response status code should be 'OK'
	Then the response object should have an integer property called 'totalCount' with value 103
	And the response object should have an integer property called 'pageSize' with value 10
	And the response object should have a property called '_links.self'
	And the response object should have an array property called '_links.pets' containing 10 entries
	And the response object should have an array property called '_embedded.pets' containing 10 entries
	And the response object should have a property called '_links.create'
	And the response object should have a property called '_links.next'
	And the response should contain the 'x-next' header

Scenario: Request a page of pets specifying a non-standard limit
	When I request a list of pets with a limit of 50
	Then the response status code should be 'OK'
	Then the response object should have an integer property called 'totalCount' with value 103
	And the response object should have an integer property called 'pageSize' with value 50
	And the response object should have a property called '_links.self'
	And the response object should have an array property called '_links.pets' containing 50 entries
	And the response object should have an array property called '_embedded.pets' containing 50 entries
	And the response object should have a property called '_links.create'
	And the response object should have a property called '_links.next'
	And the response should contain the 'x-next' header

Scenario: Request a final page of pets using the next link from a previous page
	Given I have requested a list of pets with a limit of 100
	When I request a list of pets using the value of '_links.next.href' from the previous response object
	Then the response status code should be 'OK'
	Then the response object should have an integer property called 'totalCount' with value 103
	And the response object should have an integer property called 'pageSize' with value 100
	And the response object should have a property called '_links.self'
	And the response object should have an array property called '_links.pets' containing 3 entries
	And the response object should have an array property called '_embedded.pets' containing 3 entries
	And the response object should have a property called '_links.create'
	And the response object should not have a property called '_links.next'
	And the response should not contain the 'x-next' header
	

Scenario Outline: Request a page of pets specifying an invalid limit
	When I request a list of pets with a limit of <Limit>
	Then the response status code should be 'BadRequest'

	Examples:
	| Limit |
	| 0     |
	| 101   |
	| 1000  |
