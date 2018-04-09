using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvivaTest.UtilityScripts;

namespace AvivaTest.Pages
{
    public class SearchResultsPage:BaseTest
    {
        public SearchResultsPage()
        {
            PageFactory.InitElements(BaseTest.driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//h3/a")]
        public IList<IWebElement> LinksCount { get; set; }

        public int getLinksCount()
        {
            return LinksCount.Count;
        }
        public string LinkText(int num)
        {
            return ElementText(LinksCount[num - 1]);
        }
    }
}
