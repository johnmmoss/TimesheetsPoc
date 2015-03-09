using System.Collections.Generic;
using OpenQA.Selenium;

namespace AcceptanceTests.Pages
{
    public class DepartmentPage
    {
        private readonly IWebDriver webDriver;

        public DepartmentPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public List<object> GetDepartments()
        {
            throw new System.NotImplementedException();
        }
    }
}