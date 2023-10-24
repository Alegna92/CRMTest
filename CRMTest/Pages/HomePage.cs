using CRMTest.Elements;
using CRMTest.Extensions;
using OpenQA.Selenium;

namespace CRMTest.Pages
{
    public class HomePage : IPage
    {
        private readonly IWebDriver _webDriver;
        public NavbarElement NavbarElement => new NavbarElement(_webDriver.FindElement(By.ClassName("nav-wrap")));

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void WaitTillIsLoaded()
        {
            _webDriver.WaitForElementToExists(By.ClassName("nav-wrap"));
        }
    }
}
