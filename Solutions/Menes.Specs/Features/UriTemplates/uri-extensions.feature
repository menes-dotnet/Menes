Feature: uri-extensions
	Uri extension features

Scenario: Change an existing parameter within multiple
	Given the target uri "http://example/customer?view=False&foo=bar"
	When I get the query string parameters for the target uri
	And I set the parameter called "view" to "true"
	And I make a template for the target uri from the parameters
	Then the resolved template should be one of
		| values                                    |
		| http://example/customer?view=True&foo=bar |
		| http://example/customer?foo=bar&view=True |

Scenario: Change an existing parameter
	Given the target uri "http://example/customer?view=False&foo=bar"
	And I make a template for the target uri
	When I set the template parameter called "view" to "true"
	Then the resolved template should be one of
		| values                                    |
		| http://example/customer?view=True&foo=bar |
		| http://example/customer?foo=bar&view=True |

Scenario: Clear an existing parameter
	Given the target uri "http://example/customer?view=False&foo=bar"
	And I make a template for the target uri
	When I clear the template parameter called "view"
	Then the resolved template should be one of
		| values                          |
		| http://example/customer?foo=bar |