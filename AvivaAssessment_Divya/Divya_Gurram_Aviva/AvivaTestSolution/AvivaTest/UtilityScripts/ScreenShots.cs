using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvivaTest.UtilityScripts
{
   public class ScreenShots :BaseTest
    {
        public  ScreenShots()
        {
            PageFactory.InitElements(BaseTest.driver,this);
        }

        public object SeleniumImageFormat { get; private set; }

        public void TakeScreenshot()
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot) BaseTest.driver;
            if (takesScreenshot != null)
            {
                var screenshot = takesScreenshot.GetScreenshot();
                var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                screenshot.SaveAsFile(tempFileName,ScreenshotImageFormat.Jpeg);
                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }
        }
    }
}
