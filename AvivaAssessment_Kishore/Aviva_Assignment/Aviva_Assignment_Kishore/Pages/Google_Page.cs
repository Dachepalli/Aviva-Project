using System;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using Aviva_Assignment.Utilities;
using NUnit.Framework;

namespace Aviva_Assignment
{
    class Google_Page : Utilities.Locators
    {
        private RemoteWebDriver driver;

        //Get the driver instance from the IOC
        public Google_Page(RemoteWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }


        // To get the json data
        dynamic data = Locators.Locator().Pages.Google_Home;

        // Passing input to the google search 
        public void SearchWithTextInGoogle(string Value)
        {
            Elements(data.googleSearchBox.Locator_Type, data.googleSearchBox.Locator).SendKeys(Value);
        }

        // Click on the google submit button
        public void ClickonSearchBtnInGoogle()
        {
            Elements(data.googleSearchBox.Locator_Type, data.googleSearchBox.Locator).Submit();
           
        }

        // Get result links and count from Aviva results page
        public void CountUrlLinksInGoogle(int linkcount)
        {

            IList<IWebElement> links = Elementlist(data.linksCount.Locator_Type, data.linksCount.Locator);

            Console.WriteLine("********* Output links for input keyword *********");

            foreach (var item in links)
            {
                Console.WriteLine(item.Text);
            }

            Console.WriteLine("***** Results Link Count ******* \n" + links.Count);
            //Assert.AreEqual(linkcount, links.Count);

        }

        // Print 5th Link
        public void PrintParticularLinkGoogle(int linkPosition)
        {
            
            IList<IWebElement> links = Elementlist(data.linksCount.Locator_Type, data.linksCount.Locator);
            Console.WriteLine("***** 5th link ******* \n" + links[linkPosition].Text);
        }

        // Click on the Aviva Login page
        public void ClickAvivaLinkInGoogleSearchPage()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].click();", Elements(data.avivaHomePageLink.Locator_Type, data.avivaHomePageLink.Locator));
         
        }

        // Navigate to the desired URL
        public void NavigateToURL(string navigateURL)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(navigateURL);
        }
    }
}
