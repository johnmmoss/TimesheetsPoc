using TimesheetsPoc.Web.AcceptanceTests.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TimesheetPoc.Domain;
using TimesheetPoc.Persistence;

namespace TimesheetsPoc.Web.AcceptanceTests.Steps
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

        [Given(@"I click to edit department with a code of '(.*)'")]
        public void GivenIClickToEditDepartmentWithACodeOf(string code)
        {
            var departmentsPage = ScenarioContext.Current.Get<DepartmentPage>();
            var departmentsEditPage = departmentsPage.NavigateToDepartmentEditPage(code);
            ScenarioContext.Current.Set<DepartmentEditPage>(departmentsEditPage);
        }

        [Given(@"I update this to have a Code of '(.*)' and a Description of '(.*)'")]
        public void GivenIUpdateThisToHaveACodeOfAndADescriptionOf(string code, string description)
        {
            var departmentEditPage = ScenarioContext.Current.Get<DepartmentEditPage>();
            departmentEditPage.EditDepartment(code, description);
        }

        [Then(@"the department with a Code of '(.*)' and a Description of '(.*)' exists in the system")]
        public void ThenTheDepartmentWithACodeOfAndADescriptionOfExistsInTheSystem(string expectedCode, string expectedDescription)
        {
            var departmentsPage = ScenarioContext.Current.Get<DepartmentPage>();
            var rowValues = departmentsPage.GetDepartmentByCode(expectedCode);

            Assert.That(rowValues.Find(x => x == expectedCode), Is.Not.Null);
            Assert.That(rowValues.Find(x => x == expectedDescription), Is.Not.Null);
        }

        [Given(@"I click to delete a department with a code of '(.*)'")]
        public void GivenIClickToDeleteADepartmentWithACodeOf(string code)
        {
            var departmentsPage = ScenarioContext.Current.Get<DepartmentPage>();
            var departmentsDeletePage = departmentsPage.NavigateToDepartmentDeletePage(code);
            ScenarioContext.Current.Set<DepartmentDeletePage>(departmentsDeletePage);
        }

        [Given(@"I click to delete the department on the confirm screen")]
        public void GivenIClickToDeleteTheDepartmentOnTheConfirmScreen()
        {
            var departmentsDeletePage = ScenarioContext.Current.Get<DepartmentDeletePage>();
            departmentsDeletePage.Delete();
        }

        [Then(@"the department with a Code of '(.*)' no longer exists in the system")]
        public void ThenTheDepartmentWithACodeOfNoLongerExistsInTheSystem(string code)
        {
            var departmentsPage = ScenarioContext.Current.Get<DepartmentPage>();
            var rowExists = departmentsPage.RowExists(code);

            Assert.IsFalse(rowExists);
        }
    }
}
