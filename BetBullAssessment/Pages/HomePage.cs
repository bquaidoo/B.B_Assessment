using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BetBullAssessment.Pages
{
    public class HomePage:Driver
    {
        private const string url = "http://automationpractice.com/index.php";

        public IWebElement Login() => driver.FindElement(By.XPath("//a[@class='login']"));
       
        public void GotoSite()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            driver = new ChromeDriver(option);
            driver.Navigate().GoToUrl(url);
        }

        public void CloseBrowser() => driver.Quit();
        public void ClickLogin() => Login().Click();
       
    }
}
