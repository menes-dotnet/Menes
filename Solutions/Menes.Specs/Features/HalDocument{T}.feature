@perScenarioContainer
Feature: IHalDocument serialization
	In order avoid creating response classes that are very similar to my domain classes
	I want to be able to return a domain class as a HAL document

Scenario: Serializing a HAL document with a domain class
	Given I have a domain class
	And I have created an instance of IHalDocument from the domain class
	And I add a link to the IHalDocument
	And I add an embedded resource to the IHalDocument
	When I serialize it to JSON
	Then the properties of the domain class should be serialized as top level properties in the JSON
	Then the _embedded collection should be serialized as a top level property of the JSON
	Then the _links collection should be serialized as a top level property of the JSON

Scenario: Round tripping a HAL document with a domain class
	Given I have a domain class
	And I have created an instance of IHalDocument from the domain class
	And I add a link to the IHalDocument
	And I add an embedded resource to the IHalDocument
	When I serialize it to JSON
	And I deserialize the JSON back to a IHalDocument
	Then the properties of the original document should be present in the deserialized document
	Then the _embedded collection should be present in the deserialized document
	Then the _links collection should be present in the deserialized document
