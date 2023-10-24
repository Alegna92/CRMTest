using CRMTest.Pages;
using OpenQA.Selenium;

namespace CRMTest.StepDefinitions
{
    [Binding]
    public class LoginPageSteps
    {
        private readonly LoginPage _loginPage;
        private readonly Appsettings _appsettings;

        public LoginPageSteps(IWebDriver webDriver, Appsettings appsettings)
        {
            _appsettings = appsettings;
            _loginPage = new LoginPage(webDriver);
        }

        [Given("user has logged with username (.*) and password (.*)")]
        public void UserLogsWithUsernameXAndPasswordY(string username, string password)
        {
            _loginPage.WaitTillIsLoaded();
            _loginPage.UserNameElement.SetValue(username);
            _loginPage.PasswordElement.SetValue(password);
            _loginPage.LanguageElement.SetValue(_appsettings.Language);
            _loginPage.ThemeElement.SetValue(_appsettings.Theme);
            _loginPage.LoginButton.Click();
        }

    }
}
