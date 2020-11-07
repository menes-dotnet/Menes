Feature: additionalItems
    In order to use json-schema
    As a developer
    I want to support additionalItems

Scenario Outline: additionalItems as schema
    Given the input JSON file "additionalItems.json"
    And the schema at "#/0/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/000/tests/000/data | true  | additional items match schema                                                    |
        | #/000/tests/001/data | false | additional items do not match schema                                             |

Scenario Outline: items is schema, no additionalItems
    Given the input JSON file "additionalItems.json"
    And the schema at "#/1/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/001/tests/000/data | true  | all items match schema                                                           |

Scenario Outline: array of items with no additionalItems
    Given the input JSON file "additionalItems.json"
    And the schema at "#/2/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/002/tests/000/data | true  | empty array                                                                      |
        | #/002/tests/001/data | true  | fewer number of items present (1)                                                |
        | #/002/tests/002/data | true  | fewer number of items present (2)                                                |
        | #/002/tests/003/data | true  | equal number of items present                                                    |
        | #/002/tests/004/data | false | additional items are not permitted                                               |

Scenario Outline: additionalItems as false without items
    Given the input JSON file "additionalItems.json"
    And the schema at "#/3/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/003/tests/000/data | true  | items defaults to empty schema so everything is valid                            |
        | #/003/tests/001/data | true  | ignores non-arrays                                                               |

Scenario Outline: additionalItems are allowed by default
    Given the input JSON file "additionalItems.json"
    And the schema at "#/4/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/004/tests/000/data | true  | only the first item is validated                                                 |

Scenario Outline: additionalItems should not look in applicators, valid case
    Given the input JSON file "additionalItems.json"
    And the schema at "#/5/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/005/tests/000/data | true  | items defined in allOf are not examined                                          |

Scenario Outline: additionalItems should not look in applicators, invalid case
    Given the input JSON file "additionalItems.json"
    And the schema at "#/6/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/006/tests/000/data | false | items defined in allOf are not examined                                          |
