Feature: TimeCodes
	In order to setup Timesheets
	As an Admin User
	I want to be able to add Time Codes

Background:
	Given The following data in the TimeCodes table:
	| Id | Name          | Description                        |
	| 1  | Annual Leave  | Full time staff Annual Leave       |
	| 2  | Sick Leave    | Full time staff sick leave         |
	| 3  | Banks Project | General work for the banks project |

Scenario: TimeCodes list page displays all current TimeCodes
	Given I am logged in as an Administrator
	And I navigate to the time codes list page
	Then the following TimeCodes are visible:
	| Name          | Description                        |
	| Annual Leave  | Full time staff Annual Leave       |
	| Sick Leave    | Full time staff sick leave         |
	| Banks Project | General work for the banks project |

Scenario: A TimeCode can be added to the system
	Given I am logged in as an Administrator
	And I navigate to the time codes list page
	And I click to create a new time code
	And I add a new time code with a name of 'General Admin' and a description of 'Anything you want'
	Then the time code with a name of 'General Admin' and a description of 'Anything you want' was added to the system

Scenario: An existing TimeCode can be edited
	Given I am logged in as an Administrator
	And I navigate to the time codes list page
	And I click to edit time code with a code of 'Annual Leave'
	And I update this to have a name of 'xxx' and a description of 'yyy'
	Then the department with a name of 'xxx' and a description of 'yyy' exists in the system

Scenario: An existing TimeCode can be deleted
	Given I am logged in as an Administrator
	And I navigate to the time codes list page
	And I click to delete a time code with a name of 'Annual Leave'
	And I click to delete the time code on the confirm screen
	Then the time code with a name of 'Annual Leave' no longer exists in the system
	
	
