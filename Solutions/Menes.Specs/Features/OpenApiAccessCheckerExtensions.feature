@perScenarioContainer
Feature: OpenApiAccessCheckerExtensions
	In order to ensure that I only return links to a user if they have permission to use them
	As a developer
	I want to be able to check all links in a IHalDocument based response in a single call

Background:
	Given I have a IHalDocument called 'embeddedDocument'
	And the IHalDocument called 'embeddedDocument' has internal links
		| Rel                                                                 | OperationId     | Href                        | OperationType |
		| self                                                                | getEmbedded     | /things/target/embedded/1   | get           |
		| itemInEmbeddedDocumentToWhichUserDoesNotHavePermissionButIsEmbedded | getEmbeddedLink | /things/target/embedded/1/1 | get           |
		| itemInEmbeddedDocumentToWhichUserDoesNotHavePermission              | getEmbeddedLink | /things/target/embedded/1/2 | get           |
	And I have a IHalDocument called 'embeddedDocument2'
	And the IHalDocument called 'embeddedDocument2' has internal links
		| Rel  | OperationId | Href                      | OperationType |
		| self | getEmbedded | /things/target/embedded/2 | get           |
	And I have a IHalDocument called 'target'
	And the IHalDocument called 'target' has internal links
		| Rel                                                       | OperationId | Href                      | OperationType |
		| self                                                      | getTarget   | /things/target            | get           |
		| itemInTargetToWhichUserHasPermission                      | getEmbedded | /things/target/embedded/1 | get           |
		| itemInTargetToWhichUserDoesNotHavePermissionButIsEmbedded | getEmbedded | /things/target/embedded/2 | get           |
	And the IHalDocument called 'target' has embedded resources
		| Rel                                                       | Object              |
		| itemInTargetToWhichUserHasPermission                      | {embeddedDocument}  |
		| itemInTargetToWhichUserDoesNotHavePermissionButIsEmbedded | {embeddedDocument2} |
	And the current user does not have permission to
		| Url                         | OperationType |
		| /things/target/embedded/1/1 | get           |
		| /things/target/embedded/1/2 | get           |
		| /things/target/embedded/2   | get           |

@useChildObjects
Scenario: Default checking is recursive; child item links to which the user doesn't have access are removed
	When I ask the access checker to remove forbidden links from the IHalDocument called 'target' with the following options
		| Option |
		| None   |
	Then the IHalDocument called 'target' should contain only the following link relations
		| Rel                                  |
		| self                                 |
		| itemInTargetToWhichUserHasPermission |
	And the IHalDocument called 'embeddedDocument' should contain only the following link relations
		| Rel  |
		| self |
	And the IHalDocument called 'target' should contain only the following embedded resources
		| Rel                                  |
		| itemInTargetToWhichUserHasPermission |
	And the IHalDocument called 'embeddedDocument' should contain no embedded resources

@useChildObjects
Scenario: When non-recursive checking is used, only links and resources from the top level document are removed
	When I ask the access checker to remove forbidden links from the IHalDocument called 'target' with the following options
		| Option       |
		| NonRecursive |
	Then the IHalDocument called 'target' should contain only the following link relations
		| Rel                                  |
		| self                                 |
		| itemInTargetToWhichUserHasPermission |
	And the IHalDocument called 'embeddedDocument' should contain only the following link relations
		| Rel                                                                 |
		| self                                                                |
		| itemInEmbeddedDocumentToWhichUserDoesNotHavePermissionButIsEmbedded |
		| itemInEmbeddedDocumentToWhichUserDoesNotHavePermission              |
	And the IHalDocument called 'target' should contain only the following embedded resources
		| Rel                                  |
		| itemInTargetToWhichUserHasPermission |

@useChildObjects
Scenario: When unsafe checking is used, only links that do not have corresponding embedded resources are removed.
	When I ask the access checker to remove forbidden links from the IHalDocument called 'target' with the following options
		| Option |
		| Unsafe |
	Then the IHalDocument called 'target' should contain only the following link relations
		| Rel                                                       |
		| self                                                      |
		| itemInTargetToWhichUserHasPermission                      |
		| itemInTargetToWhichUserDoesNotHavePermissionButIsEmbedded |
	And the IHalDocument called 'embeddedDocument' should contain only the following link relations
		| Rel                                                                 |
		| self                                                                |
	And the IHalDocument called 'target' should contain only the following embedded resources
		| Rel                                                       |
		| itemInTargetToWhichUserHasPermission                      |
		| itemInTargetToWhichUserDoesNotHavePermissionButIsEmbedded |