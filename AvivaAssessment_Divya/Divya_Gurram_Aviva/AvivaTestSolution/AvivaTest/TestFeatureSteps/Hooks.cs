using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AvivaTest.UtilityScripts
{
    [Binding]
    public class Hooks:BaseTest
    {
        ScreenShots st;
        [BeforeScenario]
        public void BeforeScenarioTest()
        {
            initializeDriver("Chrome");
            st = new ScreenShots();
        }

        [AfterScenario]
        public void TearDown()
        {
            CloseBrowser();
        }
        [AfterStep()]
        public void TakeScreenshots()
        {
            st.TakeScreenshot();
        }
    }
}
