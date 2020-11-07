Feature: refRemote
    In order to use json-schema
    As a developer
    I want to support refRemote

Scenario Outline: remote ref
    Given the input JSON file "refRemote.json"
    And the schema at "#/0/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/000/tests/000/data | true  | remote ref valid                                                                 |
        | #/000/tests/001/data | false | remote ref invalid                                                               |

Scenario Outline: fragment within remote ref
    Given the input JSON file "refRemote.json"
    And the schema at "#/1/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/001/tests/000/data | true  | remote fragment valid                                                            |
        | #/001/tests/001/data | false | remote fragment invalid                                                          |

Scenario Outline: ref within remote ref
    Given the input JSON file "refRemote.json"
    And the schema at "#/2/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/002/tests/000/data | true  | ref within ref valid                                                             |
        | #/002/tests/001/data | false | ref within ref invalid                                                           |

Scenario Outline: base URI change
    Given the input JSON file "refRemote.json"
    And the schema at "#/3/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/003/tests/000/data | true  | base URI change ref valid                                                        |
        | #/003/tests/001/data | false | base URI change ref invalid                                                      |

Scenario Outline: base URI change - change folder
    Given the input JSON file "refRemote.json"
    And the schema at "#/4/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/004/tests/000/data | true  | number is valid                                                                  |
        | #/004/tests/001/data | false | string is invalid                                                                |

Scenario Outline: base URI change - change folder in subschema
    Given the input JSON file "refRemote.json"
    And the schema at "#/5/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/005/tests/000/data | true  | number is valid                                                                  |
        | #/005/tests/001/data | false | string is invalid                                                                |

Scenario Outline: root ref in remote ref
    Given the input JSON file "refRemote.json"
    And the schema at "#/6/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/006/tests/000/data | true  | string is valid                                                                  |
        | #/006/tests/001/data | true  | null is valid                                                                    |
        | #/006/tests/002/data | false | object is invalid                                                                |
