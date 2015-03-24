using OpenQA.Selenium;

namespace TimesheetsPoc.Web.AcceptanceTests.Pages
{
    public class DepartmentEditPage
    {
        private readonly IWebDriver webDriver;

        public DepartmentEditPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void EditDepartment(string code, string description)
        {
            var codeElement = webDriver.FindElement(By.Id("Code"));
            codeElement.Clear();
            codeElement.SendKeys(code);
         
            var descriptionElement = webDriver.FindElement(By.Id("Name"));
            descriptionElement.Clear();
            descriptionElement.SendKeys(description);

            descriptionElement.Submit();
        }
    }
}