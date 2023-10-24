using CRMTest.Extensions;
using CRMTest.Pages;
using OpenQA.Selenium;

namespace CRMTest.StepDefinitions
{
    [Binding]
    public class ReportsPageSteps
    {
        private readonly ReportsPage _reportsPage;
        private readonly IWebDriver _webDriver;
        private int _totalRowsCountBeforeDelete;
        private int _deletedRowsCount;

        public ReportsPageSteps(IWebDriver webDriver)
        {
            _reportsPage = new ReportsPage(webDriver);
            _webDriver = webDriver;
        }

        [When("user waits till report page is loaded")]
        public void UserWaitsTillReportPageIsLoaded()
        {
            _reportsPage.WaitTillIsLoaded();
        }

        [When("user filters reports table by: (.*)")]
        public void UserFiltersTableByX(string value)
        {
            _reportsPage.TableElement.FilterByValue("Project Profitability");
        }

        [When("user goes to (.*) report details page")]
        public void UserGoesToReportDetailsPage(string cellValue)
        {
            _reportsPage.TableElement.ClickOnCellValue(2, "Project Profitability");
        }

        [When("user clicks on delete action")]
        public void UserClicksOnXAction()
        {
            _totalRowsCountBeforeDelete = _reportsPage.TableElement.GetTotalRowCount();
            _reportsPage.TableElement.ClickOnAction("Delete");
            _webDriver.AcceptAllert();
        }

        [When("user selects (.*) reports")]
        public void UserSelectsXReports(List<int> indexes)
        {
            _deletedRowsCount = indexes.Count;
            _reportsPage.TableElement.SelectRows(indexes);
        }

        [Then("reports should be deleted")]
        public void ReportsShouldBeDeleted()
        {
            _reportsPage.WaitTillIsLoaded();
            _reportsPage.TableElement.GetTotalRowCount().Should().Be((_totalRowsCountBeforeDelete) - (_deletedRowsCount));
        }
    }
}
