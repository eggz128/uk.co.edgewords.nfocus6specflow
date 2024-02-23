using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uk.co.edgewords.nfocus6specflow.Support;

namespace uk.co.edgewords.nfocus6specflow.StepDefinitions
{
    [Binding]
    internal class OtherClassThatContainsSteps
    {
        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;
        private readonly WDWrapper _wrapper;
        public OtherClassThatContainsSteps(ScenarioContext scenarioContext, WDWrapper wrapper)
        {
            _scenarioContext = scenarioContext;
            //this.driver = (IWebDriver)_scenarioContext["myDriver"];
            this.driver = wrapper.Driver; //Get the driver back from the passed wrapper object. No casting needed - it can only ever contain a IWebDriver.
        }

        [StepDefinition(@"(?:I|i) (?:search|Google) for '(.*)'")] //RegEx ( ) captures a paramitersied value. (?: ) is a non capture group that will not be passed to the method
        //[StepDefinition(@"I search for '{string}'")] //Cucumber Expression useable in Specflow4 (ReqnRoll) or Cucumber
        public void WhenISearchForSomething(string searchTerm) //ANd passes the captured value to the method to use
        {
            string passedVal = (string)_scenarioContext["someValueToBePassedAround"];
            Console.WriteLine(passedVal);
            driver.FindElement(By.CssSelector("textarea[aria-label=Search]")).SendKeys(searchTerm + Keys.Enter);
        }
    }
}
