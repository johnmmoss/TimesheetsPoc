using OpenQA.Selenium;

namespace TimesheetsPoc.Web.AcceptanceTests.Pages
{
    public class TimeCodeEditPage
    {
        private readonly IWebDriver webDriver;

        public TimeCodeEditPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void EditPage(string name, string description)
        {
            var nameElement = webDriver.FindElement(By.Id("Name"));
            nameElement.Clear();
            nameElement.SendKeys(name);

            var descriptionElement = webDriver.FindElement(By.Id("Description"));
            descriptionElement.Clear();
            descriptionElement.SendKeys(description);
            
            descriptionElement.Submit();
        }
    }
}