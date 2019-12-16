Feature: LinkCollectionExtensions
    In order to be able to resolve links in mappers and services
    As a developer
    I want to be able to resolve links and add the resolved links to a link collection

Background:
    Given I have an object called 'target' of type 'Menes.Specs.Steps.TestClasses.Pet'
        | Id | Name  | Tag |
        | 1  | Snowy | Dog |

Scenario: Resolve and add by owner and relation
    And my link resolver returns a link called 'link' when resolving by owner and relation
    When I resolve and add a relation for the owner 'target' and the relation 'my-relation'
    Then the link resolver should have been asked to resolve for the owner 'target' and the relation 'my-relation'
    And the link 'link' should have been added to the link collection with relation 'my-relation'

Scenario: Resolve and add by owner relation and context
    And my link resolver returns a link called 'link' when resolving by owner, relation, and context
    When I resolve and add a relation for the owner 'target', the relation 'my-relation', and the context 'context'
    Then the link resolver should have been asked to resolve for the owner 'target', the relation 'my-relation', and the context 'context'
    And the link 'link' should have been added to the link collection with relation 'my-relation'

Scenario: Resolve and add by operation id and relation
    And my link resolver returns a link called 'link' when resolving by operation id and relation
    When I resolve and add a relation for the operation 'opId' and the relation 'my-relation'
    Then the link resolver should have been asked to resolve for the operation 'opId' and the relation 'my-relation'
    And the link 'link' should have been added to the link collection with relation 'my-relation'
