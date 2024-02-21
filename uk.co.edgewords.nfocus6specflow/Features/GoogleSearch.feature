Feature: GoogleSearch
In order to get more business
Tom (CEO) wants
us to appear high in testing search results

Scenario: Search Google for Edgewords
	Given I am on the Google homepage
	When I search for 'BBC'
	Then 'Edgewords' is the top result
