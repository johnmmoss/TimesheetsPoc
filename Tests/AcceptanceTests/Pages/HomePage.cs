using System.Configuration;
using OpenQA.Selenium;
using TimesheetsPoc.Web.AcceptanceTests.Core;

namespace TimesheetsPoc.Web.AcceptanceTests.Pages
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver webDriver;

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public DepartmentPage NavigateToDepartmentPage()
        {
            var registerLink = webDriver.FindElement(By.Id("menu-departments"));
            registerLink.Click();
            return new DepartmentPage(webDriver);
        }

        public TimeCodePage NavigateToTimeCodePage()
        {
            webDriver.FindElement(By.Id("menu-timecodes")).Click();

            return new TimeCodePage(webDriver);
        }
    }
}
