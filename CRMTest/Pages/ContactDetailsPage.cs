using CRMTest.Elements;
using CRMTest.Extensions;
using CRMTest.Model;
using OpenQA.Selenium;

namespace CRMTest.Pages
{
    public class ContactDetailsPage : IPage
    {
        private readonly IWebDriver _webDriver;
        private LabelElement _summaryElement => new LabelElement(_webDriver.FindElement(By.CssSelector("#_form_header h3")));
        private LabelElement _categoryElement => new LabelElement(_webDriver.FindElement(By.CssSelector(".withLabel")));
        private LabelElement _businessRoleElement => new LabelElement(_webDriver.FindElement(By.CssSelector(".cell-business_role .form-value")));
        public ButtonElement DeleteElement => new ButtonElement(_webDriver.FindElement(By.Id("DetailForm_delete-label")));
        public ContactDetailsPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public void WaitTillIsLoaded()
        {
            var loading = _webDriver.WaitForElementToExists(Application.LoadingLocator);
            _webDriver.WaitForElementToBeInvisible(Application.LoadingLocator);
        }

        public DetailsContactModel GetModel()
        {
            var model = new DetailsContactModel();
            var splitedSummary = _summaryElement.GetText().Split(" ");
            model.Prefix = splitedSummary[0];
            model.FirstName = splitedSummary[1];
            model.LastName = splitedSummary[2];
            model.Category = _categoryElement.GetText().Replace("Category:\r\n","");
            model.BusinessRole = _businessRoleElement.GetText();
            return model;
        }
    }
}
