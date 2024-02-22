Feature: GoogleSearch
In order to get more business
Tom (CEO) wants
us to appear high in testing search results

Scenario: Search Google for Edgewords
	Given I am on the Google homepage
	When I Google for 'BBC'
	Then 'Edgewords' is the top result

Scenario: Search Google for Automated Software Testing
	Given i am on the Google homepage
	Given We are on gOoGLe Now
