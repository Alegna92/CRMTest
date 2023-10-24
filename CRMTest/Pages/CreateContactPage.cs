using CRMTest.Elements;
using CRMTest.Extensions;
using OpenQA.Selenium;

namespace CRMTest.Pages
{
    public class CreateContactPage : IPage
    {
        private readonly IWebDriver _webDriver;

        public FormSelectElement PrefixElement => new FormSelectElement(_webDriver.FindElement(By.Id("DetailFormsalutation-input")));
        public InputElement FirstNameElement => new InputElement(_webDriver.FindElement(By.Id("DetailFormfirst_name-input")));
        public InputElement LastNameElement => new InputElement(_webDriver.FindElement(By.Id("DetailFormlast_name-input")));
        public FormSelectElement BusinessRoleElement => new FormSelectElement(_webDriver.FindElement(By.Id("DetailFormbusiness_role-input")));
        public FormMultiSelectElement CategoryElement => new FormMultiSelectElement(_webDriver.FindElement(By.Id("DetailFormcategories-input")));
        public ButtonElement SaveElement => new ButtonElement(_webDriver.FindElement(By.Id("DetailForm_save")));

        public CreateContactPage(IWebDriver webDriver)
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
