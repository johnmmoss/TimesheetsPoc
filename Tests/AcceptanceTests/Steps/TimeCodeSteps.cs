using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TimesheetPoc.Domain;
using TimesheetPoc.Persistence;

namespace AcceptanceTests
{
    [Binding]
    public class TimeCodeSteps
    {
        [Given(@"The following data in the TimeCodes table:")]
        public void GivenTheFollowingDataInTheTimeCodesTable(Table table)
        {
            using (var context = new TimesheetsContext())
            {
                foreach (var row in table.Rows)
                {
                    var timeCode = new TimeCode();
                    timeCode.Id = int.Parse(row[0]);
                    timeCode.Name = row[1];
                    timeCode.Description = row[2];

                    context.TimeCodes.Add(timeCode);
                }
                context.SaveChanges();
            }
        }

        [Then(@"the following TimeCodes are visible:")]
        public void ThenTheFollowingTimeCodesAreVisible(Table table)
        {
            var timeCodePage = ScenarioContext.Current.Get<TimeCodePage>();
            var visibleTimeCodes = timeCodePage.GetTimeCodes();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int k = 0; k < table.Rows[i].Count; k++)
                {
                    Assert.AreEqual(visibleTimeCodes[i][k], table.Rows[i][k]);
                }
            }
        }

        [Given(@"I navigate to the time codes list page")]
        public void GivenINavigateToTheTimeCodesListPage()
        {
            var homePage = ScenarioContext.Current.Get<HomePage>();
            var timeCodePage = homePage.NavigateToTimeCodePage();
            ScenarioContext.Current.Set(timeCodePage);
        }

        [Given(@"I click to create a new time code")]
        public void GivenIClickToCreateANewTimeCode()
        {
            var timeCodePage = ScenarioContext.Current.Get<TimeCodePage>();
            var timeCodeAddPage = timeCodePage.NavigateToAddPage();
            ScenarioContext.Current.Set<TimeCodeAddPage>(timeCodeAddPage);
        }

        [Given(@"I add a new time code with a name of '(.*)' and a description of '(.*)'")]
        public void GivenIAddANewTimeCodeWithANameOfAndADescriptionOf(string name, string description)
        {
            var timeCodeAddPage = ScenarioContext.Current.Get<TimeCodeAddPage>();
            timeCodeAddPage.AddTimeCode(name, description);

        }

        [Then(@"the time code with a name of '(.*)' and a description of '(.*)' was added to the system")]
        public void ThenTheTimeCodeWithANameOfAndADescriptionOfWasAddedToTheSystem(string name, string description)
        {
            var timeCodePage = ScenarioContext.Current.Get<TimeCodePage>();
            var rowValues = timeCodePage.GetTimeCodeByName(name);

            Assert.That(rowValues.Find(x => x == name), Is.Not.Null);
            Assert.That(rowValues.Find(x => x == description), Is.Not.Null);
        }

        [Given(@"I click to edit time code with a code of '(.*)'")]
        public void GivenIClickToEditTimeCodeWithACodeOf(string name)
        {
            var timeCodePage = ScenarioContext.Current.Get<TimeCodePage>();
            var timeCodeEditPage = timeCodePage.NavigateToEditPage(name);
            ScenarioContext.Current.Set<TimeCodeEditPage>(timeCodeEditPage);
        }

        [Given(@"I update this to have a name of '(.*)' and a description of '(.*)'")]
        public void GivenIUpdateThisToHaveANameOfAndADescriptionOf(string name, string description)
        {
            var timeCodeEditPage = ScenarioContext.Current.Get<TimeCodeEditPage>();
            timeCodeEditPage.EditPage(name, description);
        }

        [Then(@"the department with a name of '(.*)' and a description of '(.*)' exists in the system")]
        public void ThenTheDepartmentWithANameOfAndADescriptionOfExistsInTheSystem(string name, string description)
        {
            var timeCodePage = ScenarioContext.Current.Get<TimeCodePage>();
            var rowValues = timeCodePage.GetTimeCodeByName(name);

            Assert.That(rowValues.Find(x => x == name), Is.Not.Null);
            Assert.That(rowValues.Find(x => x == description), Is.Not.Null);
        }

        [Given(@"I click to delete a time code with a name of '(.*)'")]
        public void GivenIClickToDeleteATimeCodeWithANameOf(string name)
        {
            var timeCodePage = ScenarioContext.Current.Get<TimeCodePage>();
            var timeCodeDeletePage = timeCodePage.NavigateToDeletePage(name);
            ScenarioContext.Current.Set<TimeCodeDeletePage>(timeCodeDeletePage);
        }

        [Given(@"I click to delete the time code on the confirm screen")]
        public void GivenIClickToDeleteTheTimeCodeOnTheConfirmScreen()
        {
            var timeCodeDeletePage = ScenarioContext.Current.Get<TimeCodeDeletePage>();
            timeCodeDeletePage.Delete();

        }

        [Then(@"the time code with a name of '(.*)' no longer exists in the system")]
        public void ThenTheTimeCodeWithANameOfNoLongerExistsInTheSystem(string name)
        {
            var timeCodePage = ScenarioContext.Current.Get<TimeCodePage>();
            timeCodePage.RowExists(name);
        }

    }
}
