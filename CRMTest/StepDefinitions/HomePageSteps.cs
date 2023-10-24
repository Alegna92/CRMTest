using CRMTest.Pages;
using OpenQA.Selenium;

namespace CRMTest.StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {
        private readonly HomePage _homePage;
        public HomePageSteps(IWebDriver webDriver)
        {
            _homePage = new HomePage(webDriver);
        }

        [When("user waits till home page is loaded")]
        public void UserWaitsTillHomePageIsLoaded()
        {
            _homePage.WaitTillIsLoaded();
        }

        [When("user goes to Contacts page")]
        public void UserGoesToContatsPage()
        {
            _homePage.NavbarElement.ToContactsPage();
        }

        [When("user goes to Reports page")]
        public void UserGoesToReportsPage()
        {
            _homePage.NavbarElement.ToReportsPage();
        }
    }
}
