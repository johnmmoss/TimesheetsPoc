using OpenQA.Selenium;

namespace AcceptanceTests.Pages
{
    public class TimeCodeDeletePage
    {
        private readonly IWebDriver webDriver;

        public TimeCodeDeletePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Delete()
        {
            webDriver.FindElement(By.TagName("form")).Submit();
        }
    }
}