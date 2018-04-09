using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using AvivaTest.UtilityScripts;

namespace AvivaTest.Pages
{
    class GoogleSearchPage:BaseTest
    {
        public GoogleSearchPage()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.Name, Using = "btnK")]
        public IWebElement GoogleSearch { get; set; }

        public void searchWithText(string sText)
        {
            EnterText(SearchBox, sText);
        }
        public void ClickonSearch()
        {
            GoogleSearch.Submit();
        }
        
    }
}
