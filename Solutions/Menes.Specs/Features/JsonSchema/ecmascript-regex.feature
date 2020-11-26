Feature: ecmascript-regex
    In order to use json-schema
    As a developer
    I want to support ecmascript-regex

Scenario Outline: ECMA 262 regex $ does not match trailing newline
/* Schema: 
{
            "type": "string",
            "pattern": "^abc$"
        }
*/
    Given the input JSON file "ecmascript-regex.json"
    And the schema at "#/0/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/000/tests/000/data | false | matches in Python, but should not in jsonschema                                  |
        | #/000/tests/001/data | true  | should match                                                                     |

Scenario Outline: ECMA 262 regex converts \t to horizontal tab
/* Schema: 
{
            "type": "string",
            "pattern": "^\\t$"
        }
*/
    Given the input JSON file "ecmascript-regex.json"
    And the schema at "#/1/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/001/tests/000/data | false | does not match                                                                   |
        | #/001/tests/001/data | true  | matches                                                                          |

Scenario Outline: ECMA 262 regex escapes control codes with \c and upper letter
/* Schema: 
{
            "type": "string",
            "pattern": "^\\cC$"
        }
*/
    Given the input JSON file "ecmascript-regex.json"
    And the schema at "#/2/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/002/tests/000/data | false | does not match                                                                   |
        | #/002/tests/001/data | true  | matches                                                                          |

Scenario Outline: ECMA 262 regex escapes control codes with \c and lower letter
/* Schema: 
{
            "type": "string",
            "pattern": "^\\cc$"
        }
*/
    Given the input JSON file "ecmascript-regex.json"
    And the schema at "#/3/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/003/tests/000/data | false | does not match                                                                   |
        | #/003/tests/001/data | true  | matches                                                                          |

Scenario Outline: ECMA 262 \d matches ascii digits only
/* Schema: 
{
            "type": "string",
            "pattern": "^\\d$"
        }
*/
    Given the input JSON file "ecmascript-regex.json"
    And the schema at "#/4/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/004/tests/000/data | true  | ASCII zero matches                                                               |
        | #/004/tests/001/data | false | NKO DIGIT ZERO does not match (unlike e.g. Python)                               |
        | #/004/tests/002/data | false | NKO DIGIT ZERO (as \u escape) does not match                                     |

Scenario Outline: ECMA 262 \D matches everything but ascii digits
/* Schema: 
{
            "type": "string",
            "pattern": "^\\D$"
        }
*/
    Given the input JSON file "ecmascript-regex.json"
    And the schema at "#/5/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/005/tests/000/data | false | ASCII zero does not match                                                        |
        | #/005/tests/001/data | true  | NKO DIGIT ZERO matches (unlike e.g. Python)                                      |
        | #/005/tests/002/data | true  | NKO DIGIT ZERO (as \u escape) matches                                            |

Scenario Outline: ECMA 262 \w matches ascii letters only
/* Schema: 
{
            "type": "string",
            "pattern": "^\\w$"
        }
*/
    Given the input JSON file "ecmascript-regex.json"
    And the schema at "#/6/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/006/tests/000/data | true  | ASCII 'a' matches                                                                |
        | #/006/tests/001/data | false | latin-1 e-acute does not match (unlike e.g. Python)                              |

Scenario Outline: ECMA 262 \W matches everything but ascii letters
/* Schema: 
{
            "type": "string",
            "pattern": "^\\W$"
        }
*/
    Given the input JSON file "ecmascript-regex.json"
    And the schema at "#/7/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/007/tests/000/data | false | ASCII 'a' does not match                                                         |
        | #/007/tests/001/data | true  | latin-1 e-acute matches (unlike e.g. Python)                                     |

Scenario Outline: ECMA 262 \s matches whitespace
/* Schema: 
{
            "type": "string",
            "pattern": "^\\s$"
        }
*/
    Given the input JSON file "ecmascript-regex.json"
    And the schema at "#/8/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/008/tests/000/data | true  | ASCII space matches                                                              |
        | #/008/tests/001/data | true  | Character tabulation matches                                                     |
        | #/008/tests/002/data | true  | Line tabulation matches                                                          |
        | #/008/tests/003/data | true  | Form feed matches                                                                |
        | #/008/tests/004/data | true  | latin-1 non-breaking-space matches                                               |
        | #/008/tests/005/data | true  | zero-width whitespace matches                                                    |
        | #/008/tests/006/data | true  | line feed matches (line terminator)                                              |
        | #/008/tests/007/data | true  | paragraph separator matches (line terminator)                                    |
        | #/008/tests/008/data | true  | EM SPACE matches (Space_Separator)                                               |
        | #/008/tests/009/data | false | Non-whitespace control does not match                                            |
        | #/008/tests/010/data | false | Non-whitespace does not match                                                    |

Scenario Outline: ECMA 262 \S matches everything but whitespace
/* Schema: 
{
            "type": "string",
            "pattern": "^\\S$"
        }
*/
    Given the input JSON file "ecmascript-regex.json"
    And the schema at "#/9/schema"
    And the input data at "<inputDataReference>"
    And I generate a type for the schema
    And I construct an instance of the schema type from the data
    When I validate the instance
    Then the result will be <valid>

    Examples:
        | inputDataReference   | valid | description                                                                      |
        | #/009/tests/000/data | false | ASCII space does not match                                                       |
        | #/009/tests/001/data | false | Character tabulation does not match                                              |
        | #/009/tests/002/data | false | Line tabulation does not match                                                   |
        | #/009/tests/003/data | false | Form feed does not match                                                         |
        | #/009/tests/004/data | false | latin-1 non-breaking-space does not match                                        |
        | #/009/tests/005/data | false | zero-width whitespace does not match                                             |
        | #/009/tests/006/data | false | line feed does not match (line terminator)                                       |
        | #/009/tests/007/data | false | paragraph separator does not match (line terminator)                             |
        | #/009/tests/008/data | false | EM SPACE does not match (Space_Separator)                                        |
        | #/009/tests/009/data | true  | Non-whitespace control matches                                                   |
        | #/009/tests/010/data | true  | Non-whitespace matches                                                           |
