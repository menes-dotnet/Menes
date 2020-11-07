Feature: allOf
    In order to use json-schema
    As a developer
    I want to support allOf

Scenario Outline: allOf
    Given the input JSON file "allOf.json"
    And the schema at "#/0/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/000/tests/000/data | true  | allOf                                                                            |
        | #/000/tests/001/data | false | mismatch second                                                                  |
        | #/000/tests/002/data | false | mismatch first                                                                   |
        | #/000/tests/003/data | false | wrong type                                                                       |

Scenario Outline: allOf with base schema
    Given the input JSON file "allOf.json"
    And the schema at "#/1/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/001/tests/000/data | true  | valid                                                                            |
        | #/001/tests/001/data | false | mismatch base schema                                                             |
        | #/001/tests/002/data | false | mismatch first allOf                                                             |
        | #/001/tests/003/data | false | mismatch second allOf                                                            |
        | #/001/tests/004/data | false | mismatch both                                                                    |

Scenario Outline: allOf simple types
    Given the input JSON file "allOf.json"
    And the schema at "#/2/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/002/tests/000/data | true  | valid                                                                            |
        | #/002/tests/001/data | false | mismatch one                                                                     |

Scenario Outline: allOf with boolean schemas, all true
    Given the input JSON file "allOf.json"
    And the schema at "#/3/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/003/tests/000/data | true  | any value is valid                                                               |

Scenario Outline: allOf with boolean schemas, some false
    Given the input JSON file "allOf.json"
    And the schema at "#/4/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/004/tests/000/data | false | any value is invalid                                                             |

Scenario Outline: allOf with boolean schemas, all false
    Given the input JSON file "allOf.json"
    And the schema at "#/5/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/005/tests/000/data | false | any value is invalid                                                             |

Scenario Outline: allOf with one empty schema
    Given the input JSON file "allOf.json"
    And the schema at "#/6/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/006/tests/000/data | true  | any data is valid                                                                |

Scenario Outline: allOf with two empty schemas
    Given the input JSON file "allOf.json"
    And the schema at "#/7/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/007/tests/000/data | true  | any data is valid                                                                |

Scenario Outline: allOf with the first empty schema
    Given the input JSON file "allOf.json"
    And the schema at "#/8/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/008/tests/000/data | true  | number is valid                                                                  |
        | #/008/tests/001/data | false | string is invalid                                                                |

Scenario Outline: allOf with the last empty schema
    Given the input JSON file "allOf.json"
    And the schema at "#/9/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/009/tests/000/data | true  | number is valid                                                                  |
        | #/009/tests/001/data | false | string is invalid                                                                |

Scenario Outline: nested allOf, to check validation semantics
    Given the input JSON file "allOf.json"
    And the schema at "#/10/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/010/tests/000/data | true  | null is valid                                                                    |
        | #/010/tests/001/data | false | anything non-null is invalid                                                     |

Scenario Outline: allOf combined with anyOf, oneOf
    Given the input JSON file "allOf.json"
    And the schema at "#/11/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/011/tests/000/data | false | allOf: false, anyOf: false, oneOf: false                                         |
        | #/011/tests/001/data | false | allOf: false, anyOf: false, oneOf: true                                          |
        | #/011/tests/002/data | false | allOf: false, anyOf: true, oneOf: false                                          |
        | #/011/tests/003/data | false | allOf: false, anyOf: true, oneOf: true                                           |
        | #/011/tests/004/data | false | allOf: true, anyOf: false, oneOf: false                                          |
        | #/011/tests/005/data | false | allOf: true, anyOf: false, oneOf: true                                           |
        | #/011/tests/006/data | false | allOf: true, anyOf: true, oneOf: false                                           |
        | #/011/tests/007/data | true  | allOf: true, anyOf: true, oneOf: true                                            |
