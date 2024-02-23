using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.edgewords.nfocus6specflow.Support;

using NUnit.Framework;
[assembly: Parallelizable(ParallelScope.Fixtures)] //Can only parallelise Features
[assembly: LevelOfParallelism(4)] //Worker thread i.e. max amount of Features to run in Parallel


namespace uk.co.edgewords.nfocus6specflow.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private IWebDriver _driver; //Hackish way to share the browser with other classes
        private readonly ScenarioContext _scenarioContext;
        private readonly WDWrapper _wrapper;
        public Hooks(ScenarioContext scenarioContext, WDWrapper wrapper)
        {
            _scenarioContext = scenarioContext;
            _wrapper = wrapper;
        }
        //[Before]
        //public void SetUp()
        //{
        //    _driver = new EdgeDriver();
        //    _scenarioContext["myDriver"] = _driver; //When putting stuff in to scenario context we lose the type information
        //    //_scenarioContext["myDriver"] = "This is not an IWebDriver it's a string";
        //}
        [Before]
        public void SetUpUsingTypeSafeWrapper()
        {
            _driver = new EdgeDriver();
            _wrapper.Driver = _driver;
            //_wrapper.Driver = "CanWePutAStringInNoItsACompileTimeError";
        }

        [After]
        public void TearDown()
        {
            Thread.Sleep(3000);
            _driver.Quit();
        }
    }
}
