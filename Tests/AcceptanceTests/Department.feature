Feature: Departments
	In order to setup Timesheets
	As an Admin User
	I want to be able to add Timesheets

Background:
	Given The following data in the Departments table:
	| Id | Code  | Department    |
	| 1  | ENG01 | Engineering 1 |
	| 2  | ENG06 | Engineering 6 |
	| 3  | SUP01 | Support 1     |

Scenario: Departments list page displays all current departments
	Given I am logged in as an Administrator
	And I navigate to the Departments page
	Then the following Departments are visible:
	| Code  | Department    |
	| ENG01 | Engineering 1 |
	| ENG06 | Engineering 6 |
	| SUP01 | Support 1     |

Scenario: A Department can be added to the system
	Given I am logged in as an Administrator
	And I navigate to the Departments page
	And I click to create a new department
	And I add a new department with a Code of 'SUP02' and a Description of 'Supplier02'
	Then the department with a Code of 'SUP02' and a Description of 'Supplier02' was added to the system

Scenario: An existing Department can be edited
	Given I am logged in as an Administrator
	And I navigate to the Departments page
	And I click to edit department with a code of 'ENG01'
	And I update this to have a Code of 'ENG100' and a Description of 'UPDATED'
	Then the department with a Code of 'ENG100' and a Description of 'UPDATED' exists in the system

Scenario: An existing Department can be deleted
	Given I am logged in as an Administrator
	And I navigate to the Departments page
	And I click to delete a department with a code of 'ENG01'
	And I click to delete the department on the confirm screen
	Then the department with a Code of 'ENG01' no longer exists in the system
	
	
