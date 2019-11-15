Feature: OpenApi Hosting Initialisation
	In order to use Menes in my application
	As a developer
	I want to be able to add Menes services and related components to my service collection

Background:
	Given I have created a service collection to register my services against

Scenario: Adding AspNetCore OpenApi hosting adds the IOpenApiHost for HttpRequest and IActionResult
	When I add AspNetCore OpenApi hosting to the service collection
	And I build the service provider from the service collection
	Then a service is available as a Singleton for type IOpenApiHost{HttpRequest, IActionResult}

Scenario: Adding OpenApi hosting enables auditing to console by default
	Given I have added AspNetCore OpenApi hosting to the service collection
	And I have built the service provider from the service collection
	Then an audit log builder service is available for auditing operations which return OpenApiResults
	And an audit log builder service is available for auditing operations which return a POCO
	And an audit log sink service is available for console logging
	And auditing is enabled

Scenario Outline: OpenApi host initialisation maps standard Menes exception types to their corresponding HTTP status codes
	Given I have added AspNetCore OpenApi hosting to the service collection
	And I have built the service provider from the service collection
	When I request an instance of the OpenApi host
	Then the exception of type '<Exception Type>' is mapped to response code '<Mapped Response Code>'

	Examples:
	| Exception Type                                                    | Mapped Response Code |
	| Menes.Exceptions.OpenApiBadRequestException, Menes.Abstractions   | 400                  |
	| Menes.Exceptions.OpenApiUnauthorizedException, Menes.Abstractions | 401                  |
	| Menes.Exceptions.OpenApiForbiddenException, Menes.Abstractions    | 403                  |
	| Menes.Exceptions.OpenApiNotFoundException, Menes.Abstractions     | 404                  |

Scenario: OpenApi host initialisation adds link maps from registered IHalDocumentMapper types
	Given I have added AspNetCore OpenApi hosting to the service collection
	And I have registered a HalDocumentMapper for a resource type to the service collection
	And I have registered a HalDocumentMapper for a resource and context type to the service collection
	And I have built the service provider from the service collection
	When I request an instance of the OpenApi host
	Then the HalDocumentMapper for resource type has configured its links
	And the HalDocumentMapper for resource and context types has configured its links

Scenario: Registering HAL document mappers with resource type parameters adds them to the container with the concrete type, the IHalDocumentMapper interface and the generic IHalDocumentMapper interface
	When I register a HalDocumentMapper for a resource type to the service collection
	And I build the service provider from the service collection
	Then it should be available as a Singleton with the service type matching the concrete type of the mapper
	And It should be available as a Singleton with a service type of IHalDocumentMapper
	And it should be available as a Singleton with a service type of IHalDocumentMapper{TResource}

Scenario: Registering HAL document mappers with resource and context type parameters adds them to the container with the concrete type, the IHalDocumentMapper interface and the generic IHalDocumentMapper interface
	When I register a HalDocumentMapper for a resource and context type to the service collection
	And I build the service provider from the service collection
	Then it should be available as a Singleton with the service type matching the concrete type of the mapper with context
	And It should be available as a Singleton with a service type of IHalDocumentMapper
	And it should be available as a Singleton with a service type of IHalDocumentMapper{TResource, TContext}
