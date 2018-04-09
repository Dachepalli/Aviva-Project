using Aviva_Assignment;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium.Remote;
using RelevantCodes.ExtentReports;
using RelevantCodes.ExtentReports.Model;
using System.Configuration;
using TechTalk.SpecFlow;

namespace Aviva_Assignment_Kishore
{
    [Binding]
    public class VerifyTheCountOfLinksDisplayedForTheSearchTextAndPrint5ThLinkTextSteps
    {
        private RemoteWebDriver driver;
        Google_Page googlepage;
        Aviva_Application avivaApplication;
        public ExtentReports extent;
        public ExtentTest test;

        public VerifyTheCountOfLinksDisplayedForTheSearchTextAndPrint5ThLinkTextSteps(RemoteWebDriver driver)
        {
            this.driver = driver;
            googlepage = new Google_Page(driver);
            avivaApplication = new Aviva_Application(driver);
        }
        [Given(@"Launch browser with Google search engine")]
        public void GivenLaunchBrowserWithGoogleSearchEngine()
        {
            googlepage.NavigateToURL(ConfigurationManager.AppSettings["Url"]);
        }

        [When(@"user enter '(.*)' in google search")]
        public void WhenUserEnterInGoogleSearch(string keyword)
        {
            googlepage.SearchWithTextInGoogle(keyword);
        }
        
        [When(@"click on search button")]
        public void WhenClickOnSearchButton()
        {
            googlepage.ClickonSearchBtnInGoogle();
        }
        
        [Then(@"user should display links returned in resultspage and verify '(.*)'")]
        public void ThenUserShouldDisplayLinksReturnedInResultspageAndVerify(int linkcount)
        {
            googlepage.CountUrlLinksInGoogle(linkcount);
        }
        
        [Then(@"user should display '(.*)' link")]
        public void ThenUserShouldDisplayLink(int linkposition)
        {
            googlepage.PrintParticularLinkGoogle(linkposition);
        }

        [Then(@"click on Aviva Login Link in the Google Search Page")]
        public void ThenClickOnAvivaLoginLinkInTheGoogleSearchPage()
        {
            googlepage.ClickAvivaLinkInGoogleSearchPage();
        }

        [Then(@"verify Title of the '(.*)' of the Aviva Home Page")]
        public void ThenVerifyTitleOfTheOfTheAvivaHomePage(string AvivaPage)
        {
            avivaApplication.ValidatingAvivaPageTitle(AvivaPage);
        }
        
        [Then(@"click on Aviva Login Link in the Google Search Page and click on Login")]
        public void ThenClickOnAvivaLoginLinkInTheGoogleSearchPageAndClickOnLogin()
        {
            googlepage.ClickAvivaLinkInGoogleSearchPage();
            avivaApplication.ClickLoginAvivaHomePage();

        }

        [Then(@"verify the Error Message in the Aviva Login Page")]
        public void ThenVerifyTheErrorMessageInTheAvivaLoginPage()
        {
            avivaApplication.ValidateTheLoginErrorMessage();
        }


    }
}
