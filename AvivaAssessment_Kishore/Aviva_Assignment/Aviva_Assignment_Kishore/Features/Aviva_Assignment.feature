Feature: Verify the count of Links displayed for the search text and Print 5th Link Text
         Search with the keyword AVIVA and 
		 verify that returned links count and
		 print 5th link text in returned links list

	Background: 
    Given Launch browser with Google search engine

	@googlesearchforAviva 
	Scenario Outline: Search with Aviva and verify results links
	When user enter '<keyword>' in google search
	And click on search button
	Then user should display links returned in resultspage and verify '<linkcount>'
	And user should display '<link>' link 

	Examples: 
	| keyword | linkcount | link |
	| Aviva   | 6         | 5    |


	@PositiveScenario
    Scenario Outline: Verify Title in Aviva Home Page
	 When user enter '<keyword>' in google search
	And click on search button
    Then click on Aviva Login Link in the Google Search Page
	And verify Title of the '<Access>' of the Aviva Home Page

      Examples: 
      | keyword | Access |
      | Aviva | AVIVA Insta Access ™ - Access without Login |

	  
   @NegativeScenario
    Scenario Outline: Verify Error Message in Aviva Login Page
    When user enter '<keyword>' in google search
    And click on search button
    Then click on Aviva Login Link in the Google Search Page and click on Login
	And verify the Error Message in the Aviva Login Page

      Examples: 
      | keyword |
      | Aviva | 