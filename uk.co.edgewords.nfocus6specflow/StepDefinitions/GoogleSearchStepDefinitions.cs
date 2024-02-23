//Class generated with Specflow extension
//Does not include ScenarioContext by default for sharing state between steps

using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using TechTalk.SpecFlow;

namespace uk.co.edgewords.nfocus6specflow.StepDefinitions
{
    //[Binding]
    public class GoogleSearchStepDefinitions
    {
        IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;
        public GoogleSearchStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am on the Google homepage")]
        public void GivenIAmOnTheGoogleHomepage()
        {
            driver = new EdgeDriver();
            driver.Url = "https://www.google.com/";

        }

        [When(@"I search for Edgewords")]
        public void WhenISearchForEdgewords()
        {
            driver.Quit();
        }

        [Then(@"Edgewords is the top result")]
        public void ThenEdgewordsIsTheTopResult()
        {
            throw new PendingStepException();
        }
    }
}
