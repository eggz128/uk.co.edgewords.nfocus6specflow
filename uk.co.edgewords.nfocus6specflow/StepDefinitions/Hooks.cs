using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.edgewords.nfocus6specflow.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        public static IWebDriver driver; //Hackish way to share the browser with other classes

        [Before]
        public void SetUp()
        {
            driver = new EdgeDriver();
            
        }

        [After]
        public void TearDown()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
