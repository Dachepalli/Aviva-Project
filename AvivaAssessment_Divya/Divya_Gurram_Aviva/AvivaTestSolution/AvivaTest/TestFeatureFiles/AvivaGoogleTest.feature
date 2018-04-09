Feature: AvivaTest
	Launch Google Page on a opened browser
	Search with Aviva and verify the links count

Background: 
Given Launch GoogleHome Page 

	
@Positive
Scenario Outline: Verify Aviva Search and Print Fifth Link Text  in the Search Results Page
	And Search With "<searchString>"
	When click on Search Button
	Then User verifies and prints the number of search results returned
	And User prints the link text of <linkNum>th link

	Examples: 
	| searchString | linkNum |
	| Aviva        | 5       |
	

@Negative
Scenario: Verify Aviva google page with wrong name 
	And Search With Text "Aviva"
	When click on Search Button
	Then  verify the Browser title "SamplePage"
