using System.Configuration;
using OpenQA.Selenium;
using AcceptanceTests.Core;

namespace AcceptanceTests.Pages
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
            var registerLink = webDriver.FindElement(By.Id("registerLink"));
            registerLink.Click();
            return new DepartmentPage(webDriver);
        }
    }
}
