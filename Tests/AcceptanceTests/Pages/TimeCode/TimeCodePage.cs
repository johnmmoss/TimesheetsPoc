using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace AcceptanceTests.Pages
{
    public class TimeCodePage
    {
        private readonly IWebDriver webDriver;

        public TimeCodePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public List<List<string>> GetTimeCodes()
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

        public TimeCodeAddPage NavigateToAddPage()
        {
            webDriver.FindElement(By.XPath("//a[text() = 'Create New']")).Click();

            return new TimeCodeAddPage(webDriver);
        }

        public List<string> GetTimeCodeByName(string name)
        {
            var rowXPath = string.Format("//tr[td[normalize-space(text())='{0}']]", name);
            var row = webDriver.FindElement(By.XPath(rowXPath));

            return row.FindElements(By.ClassName("td-content")).Select(td => td.Text).ToList();
        }

        public TimeCodeEditPage NavigateToEditPage(string name)
        {
            var xpath = string.Format("//tr[td[normalize-space(text())='{0}']]/td/a[normalize-space(text()) = \"Edit\"]", name);
            var editLink = webDriver.FindElement(By.XPath(xpath));
            editLink.Click();

            return new TimeCodeEditPage(webDriver);
        }

        public TimeCodeDeletePage NavigateToDeletePage(string name)
        {
            var xpath = string.Format("//tr[td[normalize-space(text())='{0}']]/td/a[normalize-space(text()) = \"Delete\"]", name);
            var deleteLink = webDriver.FindElement(By.XPath(xpath));
            deleteLink.Click();

            return new TimeCodeDeletePage(webDriver);
        }

        public bool RowExists(string name)
        {
            try
            {
                var rowXPath = string.Format("//tr[td[normalize-space(text())='{0}']]", name);
                webDriver.FindElement(By.XPath(rowXPath));

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
    }
}