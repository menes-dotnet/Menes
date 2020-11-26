Feature: non-bmp-regex
    In order to use json-schema
    As a developer
    I want to support non-bmp-regex

Scenario Outline: Proper UTF-16 surrogate pair handling: pattern
/* Schema: 
{ "pattern": "^🐲*$" }
*/
    Given the input JSON file "non-bmp-regex.json"
    And the schema at "#/0/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/000/tests/000/data | true  | matches empty                                                                    |
        | #/000/tests/001/data | true  | matches single                                                                   |
        | #/000/tests/002/data | true  | matches two                                                                      |
        | #/000/tests/003/data | false | doesn't match one                                                                |
        | #/000/tests/004/data | false | doesn't match two                                                                |
        | #/000/tests/005/data | false | doesn't match one ASCII                                                          |
        | #/000/tests/006/data | false | doesn't match two ASCII                                                          |

Scenario Outline: Proper UTF-16 surrogate pair handling: patternProperties
/* Schema: 
{
            "patternProperties": {
                "^🐲*$": {
                    "type": "integer"
                }
            }
        }
*/
    Given the input JSON file "non-bmp-regex.json"
    And the schema at "#/1/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/001/tests/000/data | true  | matches empty                                                                    |
        | #/001/tests/001/data | true  | matches single                                                                   |
        | #/001/tests/002/data | true  | matches two                                                                      |
        | #/001/tests/003/data | false | doesn't match one                                                                |
        | #/001/tests/004/data | false | doesn't match two                                                                |
