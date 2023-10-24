using CRMTest.Elements;
using CRMTest.Extensions;
using OpenQA.Selenium;

namespace CRMTest.Pages
{
    public class ContactPage : IPage
    {
        private readonly IWebDriver _webDriver;
        public ButtonElement CreateElement => new ButtonElement(_webDriver.FindElement(By.Name("SubPanel_create")));
        public InputElement SearchContactElement => new InputElement(_webDriver.FindElement(By.Id("filter_text")));

        //no-results element .text-help 'No results'
        //.search-clear wyczysc wyszukiwanie
        public ContactPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public void WaitTillIsLoaded()
        {
            _webDriver.WaitForElementToBeInvisible(Application.LoadingLocator);
        }
    }
}
