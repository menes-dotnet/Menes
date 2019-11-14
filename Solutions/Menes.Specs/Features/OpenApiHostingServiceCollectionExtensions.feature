Feature: OpenApiHostingServiceCollectionExtensions
	In order to use Menes in my application
	As a developer
	I want to be able to add Menes services and related components to my service collection

	
Scenario: Add HAL document mappers with resource type parameter
	Given I have created a service collection to register my services against
	When I register a HalDocumentMapper for a resource type to the service collection
	Then it should be added as a Singleton with the service type matching the concrete type of the mapper
	And It should be added as a Singleton with a service type of IHalDocumentMapper
	And it should be added as a Singleton with a service type of IHalDocumentMapper{TResource}

Scenario: Add HAL document mappers with resource and context type parameters
	Given I have created a service collection to register my services against
	When I register a HalDocumentMapper for a resource and context type to the service collection
	Then it should be added as a Singleton with the service type matching the concrete type of the mapper with context
	And It should be added as a Singleton with a service type of IHalDocumentMapper
	And it should be added as a Singleton with a service type of IHalDocumentMapper{TResource, TContext}
