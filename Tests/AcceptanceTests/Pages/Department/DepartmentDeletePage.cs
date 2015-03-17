using OpenQA.Selenium;

namespace AcceptanceTests.Pages
{
    public class DepartmentDeletePage
    {
        private readonly IWebDriver webDriver;

        public DepartmentDeletePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Delete()
        {
            webDriver.FindElement(By.TagName("form")).Submit();
        }
    }
}