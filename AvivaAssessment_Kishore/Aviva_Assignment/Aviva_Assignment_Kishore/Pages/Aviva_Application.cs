using System;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Aviva_Assignment.Utilities;
using OpenQA.Selenium.Support.UI;

namespace Aviva_Assignment
{
    class Aviva_Application : Utilities.Locators
    {
        private RemoteWebDriver driver;

        //Get the driver instance from the IOC 
        public Aviva_Application(RemoteWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //Get the Json locator data
        dynamic data = Locators.Locator().Pages.Aviva_Login;

        //Validtion of Aviva page title
        public void ValidatingAvivaPageTitle(string AvivaPage)
        {
            IWebElement title =Elements(data.title.Locator_Type, data.title.Locator);
            Console.WriteLine(title.Text);
            Assert.AreEqual(title.Text, AvivaPage); 
        }

        // Perform click operation on login button
        public void ClickLoginAvivaHomePage()
        {
    
            Elements(data.login.Locator_Type, data.login.Locator).Click();
           
        }

        // Validates the error message on the login without field values 
        public void ValidateTheLoginErrorMessage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IWebElement error = Elements(data.loginError.Locator_Type, data.loginError.Locator);
            Console.WriteLine("********Error Meassage********\n"+error.Text);
            Assert.AreEqual("Please fill in all 3 fields.", error.Text);
        }

    }
}
