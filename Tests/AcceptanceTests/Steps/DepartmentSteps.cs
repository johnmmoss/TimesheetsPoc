using AcceptanceTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TimesheetPoc.Domain;
using TimesheetPoc.Persistence;

namespace AcceptanceTests.Steps
{
    [Binding]
    public class DepartmentSteps
    {
        [Given(@"The following data in the Departments table:")]
        public void GivenTheFollowingDataInTheDepartmentsTable(Table table)
        {
            using (var context = new TimesheetsContext())
            {
                foreach (var department in table.Rows)
                {
                    var dbDepartment = new Department();
                    dbDepartment.Id = int.Parse(department[0]);
                    dbDepartment.Code = department[1];
                    dbDepartment.Name = department[2];

                    context.Departments.Add(dbDepartment);
                }
                context.SaveChanges();
            }
        }

        [Given(@"I am logged in as an Administrator")]
        public void GivenIAmLoggedInAsAnAdministrator()
        {
            // TODO Implement login functionality
        }

        [Given(@"I navigate to the Departments page")]
        public void GivenINavigateToTheDepartmentsPage()
        {
            var homePage = ScenarioContext.Current.Get<HomePage>();
            var departmentsPage = homePage.NavigateToDepartmentPage();
            ScenarioContext.Current.Set<DepartmentPage>(departmentsPage);
        }

        [Then(@"the following Departments are visible:")]
        public void ThenTheFollowingDepartmentsAreVisible(Table table)
        {
            var departmentsPage = ScenarioContext.Current.Get<DepartmentPage>();
            var visibleDepartments = departmentsPage.GetDepartments();
            for(int i=0; i < table.Rows.Count; i++)
            {
                for (int k = 0; k < table.Rows[i].Count; k++)
                {
                    Assert.AreEqual(visibleDepartments[i][k], table.Rows[i][k]);
                }
            }
        }

        [Given(@"I click to create a new department")]
        public void GivenIClickToCreateANewDepartment()
        {
            var departmentsPage = ScenarioContext.Current.Get<DepartmentPage>();
            var departmentAddPage = departmentsPage.NavigateToDepartmentAddPage();
            ScenarioContext.Current.Set<DepartmentAddPage>(departmentAddPage);
        }

        [Given(@"I add a new department with a Code of '(.*)' and a Description of '(.*)'")]
        public void GivenIAddANewDepartmentWithACodeOfAndADescriptionOf(string code, string description)
        {
            var departmentAddPage = ScenarioContext.Current.Get<DepartmentAddPage>();
            departmentAddPage.AddDepartment(code, description);
        }

        [Then(@"the department with a Code of '(.*)' and a Description of '(.*)' was added to the system")]
        public void ThenTheDepartmentWithACodeOfAndADescriptionOfWasAddedToTheSystem(string code, string description)
        {
            var departmentsPage = ScenarioContext.Current.Get<DepartmentPage>();
            var rowValues = departmentsPage.GetDepartmentByCode(code);

            Assert.That(rowValues.Find(x => x == code), Is.Not.Null);
            Assert.That(rowValues.Find(x => x == description), Is.Not.Null);
        }
    }
}
