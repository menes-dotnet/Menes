Feature: id
    In order to use json-schema
    As a developer
    I want to support id

Scenario Outline: Invalid use of fragments in location-independent $id
    Given the input JSON file "id.json"
    And the schema at "#/0/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/000/tests/000/data | false | Identifier name                                                                  |
        | #/000/tests/001/data | false | Identifier name and no ref                                                       |
        | #/000/tests/002/data | false | Identifier path                                                                  |
        | #/000/tests/003/data | false | Identifier name with absolute URI                                                |
        | #/000/tests/004/data | false | Identifier path with absolute URI                                                |
        | #/000/tests/005/data | false | Identifier name with base URI change in subschema                                |
        | #/000/tests/006/data | false | Identifier path with base URI change in subschema                                |

Scenario Outline: Valid use of empty fragments in location-independent $id
    Given the input JSON file "id.json"
    And the schema at "#/1/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/001/tests/000/data | true  | Identifier name with absolute URI                                                |
        | #/001/tests/001/data | true  | Identifier name with base URI change in subschema                                |

Scenario Outline: Unnormalized $ids are allowed but discouraged
    Given the input JSON file "id.json"
    And the schema at "#/2/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/002/tests/000/data | true  | Unnormalized identifier                                                          |
        | #/002/tests/001/data | true  | Unnormalized identifier and no ref                                               |
        | #/002/tests/002/data | true  | Unnormalized identifier with empty fragment                                      |
        | #/002/tests/003/data | true  | Unnormalized identifier with empty fragment and no ref                           |
