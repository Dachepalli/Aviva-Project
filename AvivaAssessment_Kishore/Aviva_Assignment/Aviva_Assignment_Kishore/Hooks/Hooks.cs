using System;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using System.IO;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.IE;

namespace Aviva_Assignment_Kishore
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;

        public static RemoteWebDriver _driver;
        public static ExtentReports extent;
        public static ExtentTest test;
        private static string  tempFileName;


        // Creating Constructor for the IOC 
        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        // Initial Setup for the Extended reports
        [BeforeTestRun]
        public static void StartReport()
        {
            Console.WriteLine("**************Execution Started*********************");

            //To obtain the current solution path/project path
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).FullName;

            if (projectPath.Contains("bin"))
            {
                projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            }

            //Append the html report file to current project path
            string reportPath = projectPath + "\\Aviva_Assignment_Kishore\\Reports\\TestRunReport.html";

            //Boolean value for replacing exisisting report
            extent = new ExtentReports(reportPath, true);

            //Add QA system info to html report

            extent.AddSystemInfo("Host Name", "Aviva")
                .AddSystemInfo("Environment", "QA")
                .AddSystemInfo("Username", "Kishore");

            //Adding config.xml file
            extent.LoadConfig(projectPath + "extent-Config.xml");
        }


        // Initilasing Driver thorugh IOC
        [BeforeScenario]
        public void Initialize()
        {   
            Console.WriteLine("**************Scenarios Execution Started***************");

            SelectBrowser(BrowserType.Chrome);
            _objectContainer.RegisterInstanceAs<RemoteWebDriver>(_driver);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            //Getting Scenerio information for the extended reports
            test = extent.StartTest(ScenarioContext.Current.ScenarioInfo.Title);
        }

        // Takes screenshot after every step
        [AfterStep]
        public void AfterStepMethod()
        {
            TakeScreenshot();
        }

        // Quit the browser after every scenario
        [AfterScenario]
        public void GetResultAndQuit()

        {
            Console.WriteLine("*****************Scenario Execution Completed****************");

            string executionStatus = ScenarioContext.Current.ScenarioExecutionStatus.ToString();
            if (executionStatus == "OK")
            {
                test.Log(LogStatus.Pass, ScenarioContext.Current.ScenarioInfo.Title+" : Passed");
            }
            else {
            
                test.Log(LogStatus.Fail, ScenarioContext.Current.ScenarioInfo.Title + " : Failed");
                test.Log(LogStatus.Error, "StackTrace:" + "<pre>" + ScenarioContext.Current.TestError + "</pre>");
                test.Log(LogStatus.Fail, "Error Screenshot:"+test.AddScreenCapture(tempFileName));
            }

            extent.EndTest(test);
            _driver.Quit();
        }
            
        
        // Push the infromation into extended reports and close the driver 
        [AfterTestRun]
        public static void EndReport()
        {
            Console.WriteLine("***************Information Captured in Reports*************");

            extent.Flush();
            extent.Close();
        }


        // Selection of browser
        void SelectBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                  /*  DesiredCapabilities cap = new DesiredCapabilities();
                    cap.SetCapability(CapabilityType.Platform, "WINDOWS");
                    cap.SetCapability(CapabilityType.BrowserName, "chrome");


                    _driver = new RemoteWebDriver(
                            new Uri("http://localhost:4444/wd/hub"), cap);*/

                    _driver = new ChromeDriver();
                    break;
                case BrowserType.Firefox:
                    _driver = new FirefoxDriver();

                    break;
                case BrowserType.IE:

                  /*  DesiredCapabilities cap2 = new DesiredCapabilities();
                    cap2.SetCapability(CapabilityType.Platform, "WINDOWS");
                    cap2.SetCapability(CapabilityType.BrowserName, "internet explorer");


                    _driver = new RemoteWebDriver(
                            new Uri("http://localhost:4444/wd/hub"), cap2);*/

                    _driver = new InternetExplorerDriver();
                    break;
                default:
                    break;
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
        }


        // Perform the Screenshot
        public void TakeScreenshot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)_driver;
            if (takesScreenshot != null)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);

                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }
        }



    }

    // user defined functions for browser selection
    enum BrowserType
    {
        Chrome,
        Firefox,
        IE
    }
}
