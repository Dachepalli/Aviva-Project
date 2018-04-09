using System;
using TechTalk.SpecFlow;
using AvivaTest.UtilityScripts;
using AvivaTest.Pages;
using NUnit.Framework;

namespace AvivaTest.TestFeatureSteps
{
    [Binding]
    public class AvivaGoogleTestSteps:BaseTest
    {
        GoogleSearchPage googleSearchPage;
        SearchResultsPage searchResultspage;
        
        public  AvivaGoogleTestSteps()
        {
            googleSearchPage = new GoogleSearchPage();
            searchResultspage = new SearchResultsPage();
        }
    
       
        [Given(@"Launch GoogleHome Page")]
        public void GivenLaunchGoogleHomePage()
        {
            googleSearchPage.NavigateToURL("https://google.com");
        }

        [Given(@"Search With ""(.*)""")]
        public void GivenSearchWith(string p0)
        {
            googleSearchPage.searchWithText(p0);
        }

        [Given(@"Search With Text ""(.*)""")]
        public void GivenSearchWithText(string p0)
        {
            googleSearchPage.searchWithText(p0);
        }
        
        [When(@"click on Search Button")]
        public void WhenClickOnSearchButton()
        {
            googleSearchPage.ClickonSearch();
        }


        [Then(@"User verifies and prints the number of search results returned")]
        public void ThenUserVerifiesAndPrintsTheNumberOfSearchResultsReturned()
        {
            int searResults = searchResultspage.getLinksCount();
            Console.WriteLine("Aviva Google SearchResults: " + searResults);
            Assert.AreEqual(true, searchResultspage.getLinksCount()>5);
        }

        [Then(@"User prints the link text of (.*)th link")]
        public void ThenUserPrintsTheLinkTextOfThLink(int p0)
        {
            string fifthText = searchResultspage.LinkText(5);
            Console.WriteLine("Fifth Link Text: " + fifthText);

        }


        [Then(@"verify the Browser title ""(.*)""")]
        public void ThenVerifyTheBrowserTitle(string p0)
        {
            string title = DrTitle();
            Assert.AreNotEqual(title, p0);
        }

        [Then(@"I should verify the links count from Aviva google Search Results")]
        public void ThenIShouldVerifyTheLinksCountFromAvivaGoogleSearchResults()
        {
            Assert.AreEqual(searchResultspage.getLinksCount(),6);
        }

      
    }
}
