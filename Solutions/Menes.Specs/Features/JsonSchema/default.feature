Feature: default
    In order to use json-schema
    As a developer
    I want to support default

Scenario Outline: invalid type for default
    Given the input JSON file "default.json"
    And the schema at "#/0/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/000/tests/000/data | true  | valid when property is specified                                                 |
        | #/000/tests/001/data | true  | still valid when the invalid default is used                                     |

Scenario Outline: invalid string value for default
    Given the input JSON file "default.json"
    And the schema at "#/1/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/001/tests/000/data | true  | valid when property is specified                                                 |
        | #/001/tests/001/data | true  | still valid when the invalid default is used                                     |
