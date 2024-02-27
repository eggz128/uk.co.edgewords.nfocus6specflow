using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using TechTalk.SpecFlow;

namespace uk.co.edgewords.nfocus6specflow.StepDefinitions
{
    [Binding]
    public class APISteps
    {
        private readonly ScenarioContext _scenarioContext;

        public APISteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"I request user (.*)")]
        public void WhenIRequestUser(int userId)
        {
            RestClientOptions options = new RestClientOptions("http://localhost:2002/api/");
            options.Authenticator = new HttpBasicAuthenticator("edge", "edgewords");

            var client = new RestClient(options);

            RestRequest request = new RestRequest("users/" + userId, Method.Get);

            RestResponse response = client.Execute(request);
            _scenarioContext["apiResponse"] = response;

        }

        [Then(@"I get a response code of (.*)")]
        public void ThenIGetAResponseCodeOf(int expectedStatusCode)
        {
            RestResponse response = (RestResponse)_scenarioContext["apiResponse"];
            Assert.That((int)response.StatusCode, Is.EqualTo(expectedStatusCode));
            int responseCode = (int)response.StatusCode;
            responseCode.Should().Be(expectedStatusCode);
        }

        [Then(@"the user is '(.*)'")]
        public void ThenTheUserIs(string expectedUserName)
        {
            RestResponse response = (RestResponse)_scenarioContext["apiResponse"];
            response.Content.Should().Contain(expectedUserName);
        }
    }
}
