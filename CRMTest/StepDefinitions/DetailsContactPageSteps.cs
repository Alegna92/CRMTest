using CRMTest.Extensions;
using CRMTest.Model;
using CRMTest.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;

namespace CRMTest.StepDefinitions
{
    [Binding]
    public class DetailsContactPageSteps
    {
        private readonly ContactDetailsPage _detailsContactPage;
        private readonly IWebDriver _webDriver;
        private readonly ScenarioContext _scenarioContext;
        public DetailsContactPageSteps(IWebDriver webDriver, ScenarioContext scenarioContext)
        {
            _detailsContactPage = new ContactDetailsPage(webDriver);
            _webDriver = webDriver;
            _scenarioContext = scenarioContext;
        }

        [When("user waits till details contact page is loaded")]
        public void UserWaitsTillPageIsLoaded()
        {
            _detailsContactPage.WaitTillIsLoaded();
        }

        [Then("contact details are:")]
        public void ContactDetailsAre(Table table)
        {
            var expected = table.CreateInstance<DetailsContactModel>();
            var actual = _detailsContactPage.GetModel();
            expected.Prefix?.Should().Be(actual.Prefix);
            expected.FirstName?.Should().Be(actual.FirstName);
            _scenarioContext.GetUnique(expected.LastName)?.Should().Be(actual.LastName);
            expected.Category?.Should().Be(actual.Category);
            expected.BusinessRole?.Should().Be(actual.BusinessRole);

        }

    }
}
