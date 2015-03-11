using System;
using System.Collections.Generic;
using System.Linq;
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

        public DepartmentEditPage NavigateToDepartmentEditPage(string code)
        {
            var xpath = string.Format("//tr[td[normalize-space(text())='{0}']]/td/a[normalize-space(text()) = \"Edit\"]", code);
            var editLink = webDriver.FindElement(By.XPath(xpath));
            editLink.Click();

            return new DepartmentEditPage(webDriver);
        }

        public List<string> GetDepartmentByCode(string code)
        {
            var rowXPath = string.Format("//tr[td[normalize-space(text())='{0}']]", code);
            var row = webDriver.FindElement(By.XPath(rowXPath));

            return row.FindElements(By.ClassName("td-content")).Select(td => td.Text).ToList();
        }

        public bool RowExists(string code)
        {
            try
            {
                var rowXPath = string.Format("//tr[td[normalize-space(text())='{0}']]", code);
                webDriver.FindElement(By.XPath(rowXPath));

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            
        }

        public DepartmentDeletePage NavigateToDepartmentDeletePage(string code)
        {
            var xpath = string.Format("//tr[td[normalize-space(text())='{0}']]/td/a[normalize-space(text()) = \"Delete\"]", code);
            var deleteLink = webDriver.FindElement(By.XPath(xpath));
            deleteLink.Click();

            return new DepartmentDeletePage(webDriver);
        }
    }
}