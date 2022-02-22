Feature: Employee List Flows

Background: 
	Given I navigate to Landing page
	When I login to site

@tag1
Scenario: Validate employee name data displayed
	Given I click Employee List tab
	Then I search for a value "Karthik"
	Then I validate data displayed includes "Karthik"

Scenario: Validate employee name data against server data
	Given I click Employee List tab
	Then I search for a value "Karthik"
	Then I validate data displayed against server data

Scenario Outline: Validate Checking Activity data
	Given I click Employee List tab
	When I create a new employee with <name>, <salary>, <durationworked>, <grade>, <email>
	Then I validate new employee has been added as <name>
Examples: 
	| name      | salary | durationworked | grade | email                      |
	| Alexander | 70000  | 12             | 6     | industrialcool@hotmail.com |

Scenario Outline: Validate employee name data against DB data
	Given I click Employee List tab
	Then I search for any value <author>
	Then I validate data displayed against database data <author>
Examples: 
	| author |
	| Karthik|