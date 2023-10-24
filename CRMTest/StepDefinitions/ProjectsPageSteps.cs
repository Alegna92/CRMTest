using CRMTest.Pages;
using OpenQA.Selenium;

namespace CRMTest.StepDefinitions
{
    [Binding]
    public class ProjectsPageSteps
    {
        private readonly ProjectsPage _projectsPage;
        
        public ProjectsPageSteps(IWebDriver webDriver)
        {
            _projectsPage = new ProjectsPage(webDriver);
        }

        [When("user waits till project page is loaded")]
        public void UserWaitsTillProjectPageIsLoaded()
        {
            _projectsPage.WaitTillIsLoaded();
        }

        [When ("user clicks on Run report button")]
        public void UserClicksOnRunReportButton()
        {
            _projectsPage.RunReportButton.Click();
            _projectsPage.WaitTillIsLoaded();
        }

        [Then ("user should see returned report results")]
        public void UserShouldSeeReturnedReportResults()
        {
            _projectsPage.ReportResultsElement.RowCount().Should().BeGreaterThan(0);
        }
    }
}
