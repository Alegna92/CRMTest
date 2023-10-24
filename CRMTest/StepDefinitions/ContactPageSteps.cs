using CRMTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;

namespace CRMTest.StepDefinitions
{
    [Binding]
    public class ContactPageSteps
    {
        private readonly ContactPage _contactPage;

        public ContactPageSteps(IWebDriver webDriver)
        {
            _contactPage = new ContactPage(webDriver);   
        }

        [When("user clicks on Create button")]
        //czy nazwa ok? 
        public void UserClicksOnCreateButton()
        {
            _contactPage.CreateElement.Click();
        }

        [When ("user searches contacts by (.*)")]
        public void UserSearchesContactsByX(string value)
        {
            _contactPage.SearchContactElement.SetValue(value);
        }

        [When ("user waits till contact page is loaded")]
        [Then ("user waits till contact page is loaded")]
        public void UserWaitsTillContactPageIsLoaded()
        {
            _contactPage.WaitTillIsLoaded();
        }


    }
}
