using OpenQA.Selenium;
using AcceptanceTests.Data;
using AcceptanceTests.Pages;
using TechTalk.SpecFlow;

namespace AcceptanceTests.Core
{
    [Binding]
    public class Hooks
    {

        [BeforeFeature()]
        public static void BeforeFeature()
        {
            WebDriverManager.StartSession();
            
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            WebDriverManager.EndSession();
            DatabaseHelper.Reset();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            DatabaseHelper.TearDown();

            // At the begining of the scenario, we are on the homepage
            var webDriver = FeatureContext.Current.Get<IWebDriver>();
            var homePage = new HomePage(webDriver);
            ScenarioContext.Current.Set(homePage);
        }

        [AfterScenario]
        public void AfterScenario()
        {
        }
    }
}
