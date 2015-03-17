﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18444
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AcceptanceTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("TimeCodes")]
    public partial class TimeCodesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TimeCode.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TimeCodes", "In order to setup Timesheets\r\nAs an Admin User\r\nI want to be able to add Time Cod" +
                    "es", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Description"});
            table1.AddRow(new string[] {
                        "1",
                        "Annual Leave",
                        "Full time staff Annual Leave"});
            table1.AddRow(new string[] {
                        "2",
                        "Sick Leave",
                        "Full time staff sick leave"});
            table1.AddRow(new string[] {
                        "3",
                        "Banks Project",
                        "General work for the banks project"});
#line 7
 testRunner.Given("The following data in the TimeCodes table:", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("TimeCodes list page displays all current TimeCodes")]
        public virtual void TimeCodesListPageDisplaysAllCurrentTimeCodes()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TimeCodes list page displays all current TimeCodes", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 14
 testRunner.Given("I am logged in as an Administrator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I navigate to the TimeCodes list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Description"});
            table2.AddRow(new string[] {
                        "Annual Leave",
                        "Full time staff Annual Leave"});
            table2.AddRow(new string[] {
                        "Sick Leave",
                        "Full time staff sick leave"});
            table2.AddRow(new string[] {
                        "Banks Project",
                        "General work for the banks project"});
#line 16
 testRunner.Then("the following TimeCodes are visible:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("A TimeCode can be added to the system")]
        public virtual void ATimeCodeCanBeAddedToTheSystem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A TimeCode can be added to the system", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 23
 testRunner.Given("I am logged in as an Administrator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.And("I navigate to the time codes list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("I click to create a new time code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("I add a new time code with a name of \'General Admin\' and a description of \'Anythi" +
                    "ng you want\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.Then("the time code with a name of \'General Admin\' and a description of \'Anything you w" +
                    "ant\' was added to the system", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("An existing TimeCode can be edited")]
        public virtual void AnExistingTimeCodeCanBeEdited()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("An existing TimeCode can be edited", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 30
 testRunner.Given("I am logged in as an Administrator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.And("I navigate to the time codes list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("I click to edit time code with a code of \'Annual Leave\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I update this to have a name of \'xxx\' and a description of \'yyy\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.Then("the department with a name of \'xxx\' and a description of \'yyy\' exists in the syst" +
                    "em", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("An existing TimeCode can be deleted")]
        public virtual void AnExistingTimeCodeCanBeDeleted()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("An existing TimeCode can be deleted", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 37
 testRunner.Given("I am logged in as an Administrator", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
 testRunner.And("I navigate to the time codes list page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I click to delete a time code with a name of \'Annual Leave\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("I click to delete the time code on the confirm screen", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.Then("the time code with a name of \'Annual Leave\' no longer exists in the system", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
