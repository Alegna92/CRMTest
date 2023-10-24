using CRMTest.Elements;
using CRMTest.Extensions;
using OpenQA.Selenium;

namespace CRMTest.Pages
{
    public class ReportsPage : IPage
    {
        private readonly IWebDriver _webDriver;
        public TableElement TableElement => new TableElement(_webDriver.FindElement(By.Id("content-main")));
        public ReportsPage(IWebDriver webDriver)
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
