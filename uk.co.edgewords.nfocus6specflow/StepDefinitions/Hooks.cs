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
        private IWebDriver _driver; //Hackish way to share the browser with other classes
        private readonly ScenarioContext _scenarioContext;
        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Before]
        public void SetUp()
        {
            _driver = new EdgeDriver();
            _scenarioContext["myDriver"] = _driver; //When putting stuff in to scenario context we lose the type information
            //_scenarioContext["myDriver"] = "This is not an IWebDriver it's a string";
        }

        [After]
        public void TearDown()
        {
            Thread.Sleep(3000);
            _driver.Quit();
        }
    }
}
