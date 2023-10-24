Feature: Reports

Background:
	Given user has logged with username admin and password admin
	When user waits till home page is loaded
	And user goes to Reports page
	And user waits till report page is loaded

Scenario: Run report
	When user filters reports table by: Project Profitability
	And user goes to Project Profitability report details page
	And user waits till project page is loaded
	And user clicks on Run report button
	Then user should see returned report results

Scenario: Remove events from activity log
	When user selects 1,2,3 reports
	And user clicks on delete action
	Then reports should be deleted



