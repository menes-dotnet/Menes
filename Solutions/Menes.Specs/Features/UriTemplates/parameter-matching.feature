Feature: parameter-matching
	Parameter matching specs

Scenario: Match URI to template
	When I create a regex for the template "http://example.com/{p1}/{p2}"
	Then the regex should match "http://example.com/foo/bar"

Scenario: Get parameters
	When I create a regex for the template "http://example.com/{p1}/{p2}"
	Then the matches for "http://example.com/foo/bar" should be
		| group | match |
		| p1    | foo   |
		| p2    | bar   |

Scenario: Get parameters with operators
	When I create a UriTemplate for "http://example.com/{+p1}/{p2*}"
	Then the parameters for "http://example.com/foo/bar" should be
		| name | value |
		| p1   | foo   |
		| p2   | bar   |

Scenario: Get parameters from query string
	When I create a UriTemplate for "http://example.com/{+p1}/{p2*}{?blur}"
	Then the parameters for "http://example.com/foo/bar?blur=45" should be
		| name | value |
		| p1   | foo   |
		| p2   | bar   |
		| blur | 45    |

Scenario: Get parameters from multiple query string
	When I create a UriTemplate for "http://example.com/{+p1}/{p2*}{?blur,blob}"
	Then the parameters for "http://example.com/foo/bar?blur=45" should be
		| name | value |
		| p1   | foo   |
		| p2   | bar   |
		| blur | 45    |

Scenario: Get parameters from multiple query string with two parameter values
	When I create a UriTemplate for "http://example.com/{+p1}/{p2*}{?blur,blob}"
	Then the parameters for "http://example.com/foo/bar?blur=45&blob=23" should be
		| name | value |
		| p1   | foo   |
		| p2   | bar   |
		| blur | 45    |
		| blob | 23    |

Scenario: Get parameters from multiple query string with optional and mandatory parameters
	When I create a UriTemplate for "http://example.com/{+p1}/{p2*}{?blur}{&blob}"
	Then the parameters for "http://example.com/foo/bar?blur=45&blob=23" should be
		| name | value |
		| p1   | foo   |
		| p2   | bar   |
		| blur | 45    |
		| blob | 23    |

Scenario: Get parameters from multiple query string with optional parameters
	When I create a UriTemplate for "http://example.com/{+p1}/{p2*}{?blur,blob}"
	Then the parameters for "http://example.com/foo/bar" should be
		| name | value |
		| p1   | foo   |
		| p2   | bar   |

Scenario: Glimpse URL
	When I create a UriTemplate for "http://example.com/Glimpse.axd?n=glimpse_ajax&parentRequestId={parentRequestId}{&hash,callback}"
	Then the parameters for "http://example.com/Glimpse.axd?n=glimpse_ajax&parentRequestId=123232323&hash=23ADE34FAE&callback=http%3A%2F%2Fexample.com%2Fcallback" should be
		| name            | value                       |
		| parentRequestId | 123232323                   |
		| hash            | 23ADE34FAE                  |
		| callback        | http://example.com/callback |

Scenario: URL with question mark as first character
	When I create a UriTemplate for "?hash={hash}"
	Then the parameters for "http://localhost:5000/glimpse/metadata?hash=123" should be
		| name | value |
		| hash | 123   |

Scenario: Level 1 decode
	When I create a UriTemplate for "/{p1}"
	Then the parameters for "/Hello%20World" should be
		| name | value       |
		| p1   | Hello World |

Scenario: Fragment parameter
	When I create a UriTemplate for "/foo{#p1}"
	Then the parameters for "/foo#Hello%20World!" should be
		| name | value        |
		| p1   | Hello World! |

Scenario: Fragment parameters
	When I create a UriTemplate for "/foo{#p1,p2}"
	Then the parameters for "/foo#Hello%20World!,blurg" should be
		| name | value        |
		| p1   | Hello World! |
		| p2   | blurg        |

Scenario: Optional path parameter
	When I create a UriTemplate for "/foo{/bar}/bob"
	Then the parameters for "/foo/yuck/bob" should be
		| name | value |
		| bar  | yuck  |

Scenario: Optional path parameter with multiple values
	When I create a UriTemplate for "/foo{/bar,baz}/bob"
	Then the parameters for "/foo/yuck/yob/bob" should be
		| name | value |
		| bar  | yuck  |
		| baz  | yob   |

Scenario: Update path parameter
	Given I create a UriTemplate for "http://example.org/{tenant}/customers"
	When I set the template parameter called "tenant" to "acmé"
	Then the resolved template should be one of
		| values                                 |
		| http://example.org/acm%C3%A9/customers |

Scenario: Query parameters the old way
	Given I create a UriTemplate for "http://example.org/customers?active={activeflag}"
	When I set the template parameter called "activeFlag" to "true"
	Then the resolved template should be one of
		| values                                   |
		| http://example.org/customers?active=True |

Scenario: Query parameters the new way
	Given I create a UriTemplate for "http://example.org/customers{?active}"
	When I set the template parameter called "active" to "true"
	Then the resolved template should be one of
		| values                                   |
		| http://example.org/customers?active=True |

Scenario: Query parameters the new way without value
	When I create a UriTemplate for "http://example.org/customers{?active}"
	Then the resolved template should be one of
		| values                       |
		| http://example.org/customers |