using CRMTest.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CRMTest.Elements
{
    public class NavbarElement
    {
        private readonly IWebDriver _webDriver;
        private readonly IWebElement _webElement;
        private readonly By _contactLocator = By.XPath("//a[text()=' Contacts']");
        private readonly By _reportsLocator = By.XPath("//a[text()=' Reports']");

        private IWebElement _salesAndMarketingElement => _webElement.FindElement(By.Id("grouptab-1"));
        private IWebElement _reportsAndSettingsElement => _webElement.FindElement(By.Id("grouptab-5"));
        private IWebElement _contactsElement => _webElement.FindElement(_contactLocator);
        private IWebElement _reportsElement => _webElement.FindElement(_reportsLocator);

        public NavbarElement(IWebElement webElement)
        {
            _webElement = webElement;
            _webDriver = webElement.GetWebDriver();
        }

        public void ToContactsPage()
        {
            Actions actions = new Actions(_webDriver);
            actions.MoveToElement(_salesAndMarketingElement).Perform();
            _webDriver.WaitForElementToBeVisible(_contactLocator);
            _contactsElement.Click();
        }

        public void ToReportsPage()
        {
            Actions actions = new Actions(_webDriver);
            actions.MoveToElement(_reportsAndSettingsElement).Perform();
            _webDriver.WaitForElementToBeVisible(_reportsLocator);
            _reportsElement.Click();
        }
    }
}
