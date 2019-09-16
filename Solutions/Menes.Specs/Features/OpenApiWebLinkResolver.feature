Feature: OpenApiLinkResolver
	In order to simplify adding link relations to a response
	As a developer
	I want to be able to map link relations to operations and have a simple way of resolving them when I construct a response

Background:
	Given I have initialised the OpenApiDocument provider from test YAML file 'Menes.Specs.Steps.TestClasses.OpenApiWebLinkResolverTest.yaml'

Scenario: Resolve by type
	Given I have mapped link relations by type
		| RelationName | TargetType                        | OperationId |
		| image        | Menes.Specs.Steps.TestClasses.Pet | getPetImage |
	And I have an object called 'target' of type 'Menes.Specs.Steps.TestClasses.Pet'
		| Id | Name  | Tag |
		| 1  | Snowy | Dog |
	When I resolve the link relation 'image' for object 'target' with parameters
		| Key   | Value |
		| petId | 1     |
	Then the resulting link matches
		| Rel   | OperationId | Href          | Method |
		| image | getPetImage | /pets/1/image | get    |

Scenario: Resolve by content type - exact match
	Given I have mapped link relations by content type
		| RelationName | ContentType                | OperationId |
		| image        | menes/vnd.petstore.pet     | getPetImage |
		| image        | menes/vnd.petstore.pet.dog | getDogImage |
	And I have an object called 'target' of type 'Menes.Specs.Steps.TestClasses.Pet'
		| Id | Name  | Tag |
		| 1  | Snowy | Dog |
	When I resolve the link relation 'image' for object 'target' with parameters
		| Key   | Value |
		| petId | 1     |
	Then the resulting link matches
		| Rel   | OperationId | Href             | Method |
		| image | getDogImage | /pets/1/dogimage | get    |

Scenario: Resolve by content type - parent content type match
	Given I have mapped link relations by content type
		| RelationName | ContentType                | OperationId |
		| image        | menes/vnd.petstore.pet     | getPetImage |
		| image        | menes/vnd.petstore.pet.dog | getDogImage |
	And I have an object called 'target' of type 'Menes.Specs.Steps.TestClasses.Pet'
		| Id | Name  | Tag |
		| 1  | Snowy | Cat |
	When I resolve the link relation 'image' for object 'target' with parameters
		| Key   | Value |
		| petId | 1     |
	Then the resulting link matches
		| Rel   | OperationId | Href          | Method |
		| image | getPetImage | /pets/1/image | get    |