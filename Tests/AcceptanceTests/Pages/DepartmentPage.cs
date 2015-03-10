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

        public List<List<string>> GetDepartments()
        {
            var trElements = webDriver.FindElements(By.ClassName("tr-content"));
            var result = new List<List<string>>();
            foreach (var trElement in trElements)
            {
                var row = new List<string>();
                foreach (var tdElement in trElement.FindElements(By.TagName("td"))) 
                {
                    row.Add(tdElement.Text);
                }
                result.Add(row);
            }
            return result;
        }
    }
}