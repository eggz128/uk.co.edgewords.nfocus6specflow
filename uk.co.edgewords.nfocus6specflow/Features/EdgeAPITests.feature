@API
Feature: EdgeAPITests

Scenario: Check a single user
	When I request user 1
	Then I get a response code of 200
	And the user is 'Jane Jones'
