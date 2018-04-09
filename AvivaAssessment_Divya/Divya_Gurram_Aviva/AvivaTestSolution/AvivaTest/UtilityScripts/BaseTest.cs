using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AvivaTest.UtilityScripts
{
    public class BaseTest
    {
        public static IWebDriver driver;


        public void initializeDriver(string driverType)
        {
            switch (driverType)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "FF":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
           
        public void CloseBrowser()
        {
            driver.Close();
            driver.Quit();
        }

        public void NavigateToURL(string sURL)
        {
            driver.Navigate().GoToUrl(sURL);
        }
        public void EnterText(IWebElement WebEmelent, string Text)
        {
            WebEmelent.SendKeys(Text);
        }
        public void ClickElement(IWebElement WebEmelent)
        {
          
            WebEmelent.Click();
        }

        public Boolean IsElementPresent(IWebElement WebEmelent)
        {
            return WebEmelent.Displayed;
        }
        public string ElementText(IWebElement webEmelent)
        {
            return webEmelent.Text;

        }

        public string DrTitle()
        {
            return driver.Title;

        }

    }
}
