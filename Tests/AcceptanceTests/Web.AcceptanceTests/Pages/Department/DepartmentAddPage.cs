using OpenQA.Selenium;

namespace TimesheetsPoc.Web.AcceptanceTests.Pages
{
    public class DepartmentAddPage
    {
        private readonly IWebDriver webDriver;

        public DepartmentAddPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void AddDepartment(string code, string description)
        {
            webDriver.FindElement(By.Id("Code")).SendKeys(code);
            webDriver.FindElement(By.Id("Name")).SendKeys(description);
            webDriver.FindElement(By.Id("CreateButton")).Click();
        }
    }
}