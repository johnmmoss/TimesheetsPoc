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
                foreach (var tdElement in trElement.FindElements(By.ClassName("td-content"))) 
                {
                    row.Add(tdElement.Text);
                }
                result.Add(row);
            }
            return result;
        }

        public DepartmentAddPage NavigateToDepartmentAddPage()
        {
            webDriver.FindElement(By.Id("button-create")).Click();

            return new DepartmentAddPage(webDriver);
        }

        public List<string> GetDepartmentByCode(string code)
        {
            var xpath = string.Format("//tr[td[normalize-space(text())='{0}']]", code);
            var row = webDriver.FindElement(By.XPath(xpath));

            var result = new List<string>();

            foreach (var td in row.FindElements(By.ClassName("td-content")))
            {
                result.Add(td.Text);
            }

            return result;
        }
    }
}