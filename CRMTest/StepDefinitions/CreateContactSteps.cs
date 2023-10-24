using CRMTest.Extensions;
using CRMTest.Pages;
using OpenQA.Selenium;

namespace CRMTest.StepDefinitions
{
    [Binding]
    public class CreateContactSteps
    {
        private readonly CreateContactPage _createContactPage;
        private readonly ScenarioContext _scenarioContext;
        public CreateContactSteps(IWebDriver webDriver, ScenarioContext scenarioContext)
        {
            _createContactPage = new CreateContactPage(webDriver);
            _scenarioContext = scenarioContext;
        }

        [When ("user waits till create contact page is loaded")]
        public void UserWaitsTillCreateContactPageIsLoaded()
        {
            _createContactPage.WaitTillIsLoaded();
        }

        [When("user sets prefix (.*) and first name (.*)")]
        public void UserSetsFirstNameX(string prefix, string firstName)
        {
            _createContactPage.PrefixElement.SetValue(prefix);
            _createContactPage.FirstNameElement.SetValue(firstName);
        }

        [When("user sets last name (.*)")]
        public void UserSetsLastNameX(string lastName)
        {
            var uniqueLastName = _scenarioContext.GetUnique(lastName);
            _createContactPage.LastNameElement.SetValue(uniqueLastName);
        }

        [When ("user sets (.*) business role")]
        public void UserSetsXBusinessRole(string businessRole)
        {
            _createContactPage.BusinessRoleElement.SetValue(businessRole);
        }

        [When ("user selects (.*) contact category")]
        public void UserSelectsXContactCategory(string category)
        {
            _createContactPage.CategoryElement.SetValue(category);
        }

        [When ("user submits form")]
        public void UserSubmitsForm()
        {
            _createContactPage.SaveElement.Click();
        }

    }
}
