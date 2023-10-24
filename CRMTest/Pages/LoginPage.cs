using CRMTest.Elements;
using CRMTest.Extensions;
using OpenQA.Selenium;

namespace CRMTest.Pages
{
    public class LoginPage : IPage
    {
        private readonly IWebDriver _webDriver;
        public InputElement UserNameElement => new InputElement(_webDriver.FindElement(By.Id("login_user")));
        public InputElement PasswordElement => new InputElement(_webDriver.FindElement(By.Id("login_pass")));
        public DropdownElement LanguageElement => new DropdownElement(_webDriver.FindElement(By.Id("login_lang")));
        public DropdownElement ThemeElement => new DropdownElement(_webDriver.FindElement(By.Id("login_theme")));
        public ButtonElement LoginButton => new ButtonElement(_webDriver.FindElement(By.Id("login_button")));

        public LoginPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void WaitTillIsLoaded()
        {
            _webDriver.WaitForElementToExists(By.ClassName("lw-logo"));
        }
    }
}
