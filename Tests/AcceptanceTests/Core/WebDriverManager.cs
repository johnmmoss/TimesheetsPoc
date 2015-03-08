using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Core
{
    public class WebDriverManager
    {
        private static string websiteUrl;
        public static string WebsiteUrl
        {
            get
            {
                if (string.IsNullOrEmpty(websiteUrl))
                {
                    if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["WebsiteUrl"]))
                    {
                        throw new ConfigurationErrorsException("Please set the WebsiteUrl in the App.config");
                    }
                    websiteUrl = ConfigurationManager.AppSettings["WebsiteUrl"];
                }

                return websiteUrl;
            }
        }

        private static IWebDriver _webDriver;

        public static void StartSession()
        {
            _webDriver = new FirefoxDriver();
            FeatureContext.Current.Set(_webDriver);
            _webDriver.Navigate().GoToUrl(WebsiteUrl);
        }

        public static void EndSession()
        {
            var webDriver = FeatureContext.Current.Get<IWebDriver>();
            webDriver.Quit();
            webDriver.Dispose();
        }
    }
}
