using System.Collections.Generic;
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
    }
}