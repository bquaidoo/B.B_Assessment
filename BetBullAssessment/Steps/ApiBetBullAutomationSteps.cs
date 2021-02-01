using BetBullAssessment.ApiFolder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace BetBullAssessment.Steps
{
    [Binding]
    public class ApiBetBullAutomationSteps
    {
        private readonly Application user;
        private ApiHelper<Data> ApiHelper;
        private ApiHelper<Application> ApiHelper2;
        private readonly ScenarioContext scenarioContext;

        public ApiBetBullAutomationSteps(ScenarioContext scenarioContext, Application user)
        {
            this.user = user;
            this.scenarioContext = scenarioContext;
            this.ApiHelper = new ApiHelper<Data>();
            this.ApiHelper2 = new ApiHelper<Application>();
        }

        [Given(@"I have endpoint '(.*)' and i register with email '(.*)' and password '(.*)' and i save content as '(.*)' and response code as '(.*)'")]
        public void GivenIHaveEndpointAndISaveContentAsAndResponseCodeAs(string endpoint, string email, string password, string result, string statusCode)
        {
            var url = ApiHelper.SetUrl(endpoint);
            var request = ApiHelper.CreatePostRequest(new Data() { email = email, password = password });
            var content = ApiHelper.GetResponse(url, request);
            var response = ApiHelper.GetContent<Data>(content);
            scenarioContext.Add(result, response);
            scenarioContext.Add(statusCode, (int)content.StatusCode);
        }

        [Given(@"I have endpoint '(.*)' and i save my content as '(.*)' and my response code as '(.*)'")]
        public void GivenIHaveEndpointAndISaveContentAsAndResponseCodeAs(string endpoint, string result, string statusCode)
        {
            var url = ApiHelper2.SetUrl(endpoint);
            var request = ApiHelper2.CreateGetRequest();
            var content = ApiHelper2.GetResponse(url, request);
            var response = ApiHelper2.GetContent<Application>(content);
            scenarioContext.Add(result, response);
            scenarioContext.Add(statusCode, (int)content.StatusCode);
        }


        [When(@"response '(.*)' is '(.*)'")]
        public void WhenResponseIs(string statusCode, int responseCode)
        {
            var response = scenarioContext.Get<int>(statusCode);
            if (response == responseCode)
                Assert.IsTrue(response == responseCode,
                    $"{response} does not match with {responseCode}");
            else
                throw new Exception($"{response} doesn't match {responseCode}");

        }

        [Then(@"the '(.*)' returns all the following message body:")]
        public void ThenTheReturnsAllTheFollowingMessageBody(string result, Table table)
        {
            var data = scenarioContext.Get<Data>(result);
            if (data != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(Convert.ToInt32(table.Rows[0]["id"]), data.id,
                        "not equal");
                    Assert.AreEqual(table.Rows[0]["token"], data.token,
                        "not equal");
                });
            }
        }

        [Then(@"the '(.*)' returns all the following body:")]
        public void ThenTheReturnsAllTheFollowingBody(string result, Table table)
        {
            var data = scenarioContext.Get<Application>(result);
            if (data != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(Convert.ToInt32(table.Rows[0]["page"]), data.page,
                        "not equal");
                    Assert.AreEqual(Convert.ToInt32(table.Rows[0]["per_page"]), data.per_page,
                        "not equal");
                    Assert.AreEqual(Convert.ToInt32(table.Rows[0]["total"]), data.total,
                        "not equal");
                    Assert.AreEqual(Convert.ToInt32(table.Rows[0]["total_pages"]), data.total_pages,
                        "not equal");
                    Assert.IsTrue(data.data.Count == 6, "count not equal");
                });
            }
            
        }

        [Then(@"the '(.*)' returns all the following msg:")]
        public void ThenTheReturnsAllTheFollowingMsg(string result, Table table)
        {
            var data = scenarioContext.Get<Data>(result);
            Assert.AreEqual(table.Rows[0]["msg"], data.error,
                "msg not equal");
        }

    }
}
