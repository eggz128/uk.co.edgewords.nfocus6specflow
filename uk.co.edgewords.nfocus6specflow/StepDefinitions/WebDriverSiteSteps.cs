using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using uk.co.edgewords.nfocus6specflow.Support.POMClasses;
using NUnit.Framework;

namespace uk.co.edgewords.nfocus6specflow.StepDefinitions
{
    [Binding]
    public class WebDriverSiteSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;

        public WebDriverSiteSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._driver = (IWebDriver)_scenarioContext["myDriver"];
        }
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _driver.Url = "https://www.edgewordstraining.co.uk/webdriver2";
            HomePagePOM home = new HomePagePOM(_driver);
            home.GoLogin();
        }

        [When(@"I use the username '(.*)' and the password '(.*)' to login")]
        public void WhenIUseTheUsernameAndThePasswordToLogin(string username, string password)
        {
            LoginPagePOM login = new LoginPagePOM(_driver);
            bool loginSuccess = login.LoginExpectSuccess(username, password);
            _scenarioContext["LoggedIn"] = loginSuccess;
        }

        [Then(@"I am logged in")]
        public void ThenIAmLoggedIn()
        {
            bool loginSuccess = (bool)_scenarioContext["LoggedIn"];
            Assert.That(loginSuccess, Is.True, "We are not logged in");
        }
    }
}
