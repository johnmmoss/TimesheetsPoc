Feature: Departments
	In order to setup Timesheets
	As an Admin User
	I want to be able to add Timesheets

Background:
	Given The following data in the Departments table:
	| Id | Code  | Department    |
	| 1  | ENG01 | Engineering 1 |
	| 2  | ENG06 | Engineering 6 |
	| 1  | SUP01 | Support 1     |

Scenario: Departments list page displays all current departments
	Given I am logged in as an Administrator
	And I navigate to the Departments page
	Then the following Departments are visible:
	| Code  | Department    |
	| ENG01 | Engineering 1 |
	| SUP01 | Support 1     |
	| ENG06 | Engineering 6 |
