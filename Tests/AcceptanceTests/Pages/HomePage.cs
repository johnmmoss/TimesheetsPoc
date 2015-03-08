using System.Configuration;
using OpenQA.Selenium;
using AcceptanceTests.Core;

namespace AcceptanceTests.Pages
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver webDriver;
        protected static string BaseUrl = ConfigurationManager.AppSettings["WebsiteUrl"];

        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
    }
}
