using CRMTest.Elements;
using CRMTest.Extensions;
using OpenQA.Selenium;

namespace CRMTest.Pages
{
    public class ProjectsPage : IPage
    {
        private readonly IWebDriver _webDriver;

        public ButtonElement RunReportButton => new ButtonElement(_webDriver.FindElement(By.Name("FilterForm_applyButton")));
        public TableElement ReportResultsElement => new TableElement(_webDriver.FindElement(By.Id("content-main")));

        public ProjectsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public void WaitTillIsLoaded()
        {
            _webDriver.WaitForElementToExists(By.Id("main-title-module"));
            _webDriver.WaitForElementToBeInvisible(Application.LoadingLocator);
        }
    }
}
