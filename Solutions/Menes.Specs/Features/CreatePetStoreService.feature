@perScenarioContainer

Feature: CreatePetStoreService
	In order to avoid boilerplate code writing
	As an API designer
	I want to be able to generate the service code and boilerplate types for my services.


Scenario: Generate the petstore
	Given I load the OpenApiDocument for "./yaml/petstore.yaml" as "PetStoreDocument"
	And I generate the service for the "PetStoreDocument" with the service name "PetStoreService"
	Then the code for the service "PetStoreService" should be "Some code"
