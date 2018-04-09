using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;

namespace Aviva_Assignment.Utilities
{
    class Locators
    {
        private RemoteWebDriver driver;
        public IWebElement element;
        public IList<IWebElement> elementList;
        

        //Get the driver instance from the IOC
        public Locators(RemoteWebDriver driver)
        {
            this.driver = driver;
        }


        // Load the Json Locator file
        public static dynamic Locator()

        {
           // string path = Directory.GetParent(Environment.CurrentDirectory).FullName;
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            if (path.Contains("bin"))
            {
                path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            }

            string filepath = path + "\\Aviva_Assignment_Kishore\\Locator.json";       
            dynamic jsonData = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(filepath));
            return jsonData;
        }



        // Perform the selenium operation for identification by passing the element
        public IWebElement Elements(dynamic locatorType, dynamic locatorText)
        {
            var locatortype = (string)locatorType;
            var locator = (string)locatorText;
            switch (locatortype)
            {
                case "Xpath":
                    element = driver.FindElementByXPath(locator);
                    break;
                case "Class":
                    element = driver.FindElementByClassName(locator);
                    break;
                case "ID":
                    element = driver.FindElementById(locator);
                    break;
                case "Name":
                    element = driver.FindElementByName(locator);
                    break;
                case "LinkText":
                    element = driver.FindElementByLinkText(locator);
                    break;
                case "PartialLinkText":
                    element = driver.FindElementByPartialLinkText(locator);
                    break;
            }
            return element;
        }

        // Perform the selenium operation for identification by passing the elements
        public IList<IWebElement> Elementlist(dynamic locatorType, dynamic locatorText)
        {
            var locatortype = (string)locatorType;
            var locator = (string)locatorText;
            switch (locatortype)
            {
                case "Xpath":
                    IList<IWebElement> elementList = driver.FindElementsByXPath(locator);
                    return elementList;
            }

            return elementList;


        }
    }

}
