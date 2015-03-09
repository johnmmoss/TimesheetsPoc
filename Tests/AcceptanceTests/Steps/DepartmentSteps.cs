﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            for(int i=0; i<table.Rows.Count; i++)
            {
                Assert.AreEqual(visibleDepartments[i], table.Rows[i]);
            }
        }

    }
}
