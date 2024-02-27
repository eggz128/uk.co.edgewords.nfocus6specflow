@Regressions 
Feature: GoogleSearch
In order to get more business
Tom (CEO) wants
us to appear high in testing search results

@Tag1 @Tag2 @GUI
Scenario: Search Google for Edgewords
	Given I am on the Google homepage
	When I Google for 'BBC'
	Then 'Edgewords' is the top result

@Tag2
Scenario Outline: Search Google for stuff
	Given i am on the Google homepage
	When I search for '<searchTerm>'
	Then '<expectedSearchResult>' is the top result

Examples:
	| searchTerm | expectedSearchResult |
	| edgewords  | Edgewords            |
	| BBC        | BBC                  |
	| News       | BBC                  |

Scenario: Verify edgewords title and desription in search results
	
	Given I am on the Google homepage
	
	Given I am on the Google homepage
	When I search for 'Edgewords'
	Then I should see in the results
		| url                                 | title                                                    |
		| https://www.edgewordstraining.co.uk | Edgewords Training - Automated Software Testing Training |
		| https://github.com > edgewords      | Edgewords Training edgewords                             |
		#Url actually uses the quote char › not greater than >