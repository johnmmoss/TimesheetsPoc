using OpenQA.Selenium;

namespace AcceptanceTests.Pages
{
    public class TimeCodeAddPage
    {
        private readonly IWebDriver webDriver;

        public TimeCodeAddPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void AddTimeCode(string name, string description)
        {
            webDriver.FindElement(By.Id("Name")).SendKeys(name);
            webDriver.FindElement(By.Id("Description")).SendKeys(description);
            webDriver.FindElement(By.TagName("form")).Submit();
        }
    }
}