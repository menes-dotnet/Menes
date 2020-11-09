Feature: anchor
    In order to use json-schema
    As a developer
    I want to support anchor

Scenario Outline: Location-independent identifier
/* Schema: 
{
            "$ref": "#foo",
            "$defs": {
                "A": {
                    "$anchor": "foo",
                    "type": "integer"
                }
            }
        }
*/
    Given the input JSON file "anchor.json"
    And the schema at "#/0/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/000/tests/000/data | true  | match                                                                            |
        | #/000/tests/001/data | false | mismatch                                                                         |

Scenario Outline: Location-independent identifier with absolute URI
/* Schema: 
{
            "$ref": "http://localhost:1234/bar#foo",
            "$defs": {
                "A": {
                    "$id": "http://localhost:1234/bar",
                    "$anchor": "foo",
                    "type": "integer"
                }
            }
        }
*/
    Given the input JSON file "anchor.json"
    And the schema at "#/1/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/001/tests/000/data | true  | match                                                                            |
        | #/001/tests/001/data | false | mismatch                                                                         |

Scenario Outline: Location-independent identifier with base URI change in subschema
/* Schema: 
{
            "$id": "http://localhost:1234/root",
            "$ref": "http://localhost:1234/nested.json#foo",
            "$defs": {
                "A": {
                    "$id": "nested.json",
                    "$defs": {
                        "B": {
                            "$anchor": "foo",
                            "type": "integer"
                        }
                    }
                }
            }
        }
*/
    Given the input JSON file "anchor.json"
    And the schema at "#/2/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/002/tests/000/data | true  | match                                                                            |
        | #/002/tests/001/data | false | mismatch                                                                         |
