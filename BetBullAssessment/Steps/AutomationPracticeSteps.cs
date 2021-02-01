using BetBullAssessment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace BetBullAssessment.Steps
{
    [Binding]
    public class AutomationPracticeSteps
    {
        HomePage homePage;
        LoginPage loginPage;
        private readonly ScenarioContext ScenarioContext;
        public AutomationPracticeSteps(ScenarioContext _ScenarioContext)
        {
            homePage = new HomePage();
            loginPage = new LoginPage();
            this.ScenarioContext = _ScenarioContext;
        }

        [Given(@"I am on automation practice site")]
        public void GivenIAmOnAutomationPracticeSite()
        {
            homePage.GotoSite();
        }
        
        [Given(@"I click on login button")]
        public void GivenIClickOnLoginButton()
        {
            homePage.ClickLogin();
        }

        [Given(@"I enter Email address '(.*)'")]
        public void GivenIEnterEmailAddress(string email)
        {
            loginPage.EnterEmailAdress(email);
        }

        [Given(@"I enter Password '(.*)'")]
        public void GivenIEnterPassword(string password)
        {
            loginPage.EnterPassword(password);
        }

        [When(@"I attempt to sign in with no credentials")]
        public void WhenIAttemptToSignInWithNoCredentials()
        {
            loginPage.ClickSignin();
        }
        
        [Then(@"I should get error message '(.*)'")]
        public void ThenIShouldGetErrorMessage(string errorMsg)
        {
            Assert.IsTrue(loginPage.GetErroMsg().Contains(errorMsg), 
                $"{errorMsg} does not match{loginPage.GetErroMsg()}");
        }

        [Then(@"I close browser")]
        public void ThenICloseBrowser()
        {
            homePage.CloseBrowser();
        }

    }
}
