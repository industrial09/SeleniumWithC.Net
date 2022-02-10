Feature: Scenarios for Manage users page

Background: 
	Given I navigate to Landing page
	When I login to site

Scenario Outline: Validate I am able to assign a role to a user
	Given I navigate to Manage users page
	Then I assign a <role> for <user>
Examples: 
	| user    | role |
	| ibrahim | user |
	| amabel  | user |
