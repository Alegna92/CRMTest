Feature: Contacts

Scenario: Create contact
Given user has logged with username admin and password admin
When user waits till home page is loaded
And user goes to Contacts page
And user waits till contact page is loaded
And user clicks on Create button
And user waits till create contact page is loaded
And user sets prefix Mrs. and first name Angela
And user sets last name Tester
And user selects Partners contact category
And user selects Business contact category
And user sets CEO business role
And user submits form
And user waits till details contact page is loaded
Then contact details are:
	| Name      | Value              |
	| Prefix    | Mrs.               |
	| FirstName | Angela             |
	| LastName  | Tester             |
	| Category  | Business, Partners |
	| Business  | CEO                | 

