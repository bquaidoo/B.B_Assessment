using OpenQA.Selenium;

namespace BetBullAssessment.Pages
{
    public class LoginPage:Driver
    {
        public IWebElement Signin() => driver.FindElement(By.Id("SubmitLogin"));
        public IWebElement erroMsg() => driver.FindElement(By.XPath("//div[@class='alert alert-danger']"));
        public IWebElement EmailAdress() => driver.FindElement(By.Id("email"));
        public IWebElement Password() => driver.FindElement(By.XPath("//input[@type='password']"));
        public void ClickSignin() => Signin().Click();
        public string GetErroMsg() => erroMsg().Text;
        public void EnterEmailAdress(string email) => EmailAdress().SendKeys(email);
        public void EnterPassword(string password) => Password().SendKeys(password);
    }
}
