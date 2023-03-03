@perScenarioContainer
@useSelfHostedApi

Feature: Create Pet
	In order to manage the list of pets
	As a pet shop owner
	I want to be able to add information for a new pet

Scenario Outline: Create a new pet with valid data
	When I request that a new pet be created
	| Id   | Name   | Tag   | Size   |
	| <Id> | <Name> | <Tag> | <Size> |
	Then the response status code should be 'Created'
	And the response object should have a property called '_links.self'
	And the response should contain the 'Location' header
	And the response object should have an integer property called 'id' with value <Id>
	And the response object should have a string property called 'name' with value '<Name>'
	And the response object should have a string property called 'tag' with value '<Tag>'
	And the response object should have a string property called 'size' with value '<Size>'
	And the response object should have a property called 'globalIdentifier'

	Examples:
		| Notes               | Id   | Name   | Tag              | Size  |
		| All fields provided | 2000 | Fluffy | three-headed-dog | large |

Scenario Outline: Attempt to create a new pet with invalid data
	When I request that a new pet be created
	| Id   | GlobalIdentifier   | Name   | Tag   | Size   |
	| <Id> | <GlobalIdentifier> | <Name> | <Tag> | <Size> |
	Then the response status code should be 'BadRequest'

	Examples:
		| Notes          | Id      | Name   | Tag              | Size  |
		| Missing Id     |         | Fluffy | three-headed-dog | large |
		| Non-integer Id | invalid | Fluffy | three-headed-dog | large |
		| Missing name   | 2000    |        | three-headed-dog | large |
		| Missing tag    | 2000    | Fluffy |                  | large |
		| Missing size   | 2000    | Fluffy | three-headed-dog |       |
		| Invalid size   | 2000    | Fluffy | three-headed-dog | huge  |

Scenario: Attempt to create a new pet without supplying any of the required properties
	When I request that a new pet be created without supplying any required properties
	Then the response status code should be 'BadRequest'
