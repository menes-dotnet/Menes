@perScenarioContainer
Feature: OpenApiDocumentProvider
	In order to route requests to OpenApi operations
	As a developer
	I want to load my OpenApi definition and use it to match requests to operations

Scenario: Load an OpenApi document
	Given I load an OpenApi document from the embedded resource 'Menes.Specs.Data.PetStore.yaml' and call it 'PetStore'
	When I add the OpenApi document called 'PetStore' to the OpenApiDocumentProvider
	Then the OpenApiDocumentProvider contains 1 document

Scenario Outline: Match requests to operation path templates - success
	Given I load an OpenApi document from the embedded resource 'Menes.Specs.Data.PetStore.yaml' and call it 'PetStore'
	And I add the OpenApi document called 'PetStore' to the OpenApiDocumentProvider
	When I get the operation path template for path '<Path>' and method '<Method>'
	Then an operation template is returned
	And the operation template has operation Id '<Expected Operation Id>' 

	Examples:
	| Description                 | Path              | Method | Expected Operation Id |
	| GET with path parameter     | /pet/65           | GET    | getPetById            |
	| POST without path parameter | /pet              | POST   | addPet                |
	| PUT without path parameter  | /pet              | PUT    | updatePet             |
	| POST with path parameter    | /pet/65           | POST   | updatePetWithForm     |
	| DELETE with path parameter  | /pet/65           | DELETE | deletePet             |
	| GET with query parameter    | /pet/findByStatus | GET    | findPetsByStatus      |

Scenario Outline: Match requests to operation path templates - failure
	Given I load an OpenApi document from the embedded resource 'Menes.Specs.Data.PetStore.yaml' and call it 'PetStore'
	And I add the OpenApi document called 'PetStore' to the OpenApiDocumentProvider
	When I get the operation path template for path '<Path>' and method '<Method>'
	Then no operation template is returned

	Examples:
	| Description                                              | Path                                 | Method |
	| No matching path                                         | /dogs                                | GET    |
	| Invalid method for the specified path                    | /pet                                 | GET    |
	| GET with path parameter value that does not match schema | /pet/fenton                          | GET    |
	| End of request path matches a specified path             | /this/is/unexpected/pet/findByStatus | GET    |
