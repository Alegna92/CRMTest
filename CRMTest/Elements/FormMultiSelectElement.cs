using CRMTest.Extensions;
using OpenQA.Selenium;

namespace CRMTest.Elements
{
    public class FormMultiSelectElement
    {
        private readonly IWebElement _webElement;
        private readonly IWebDriver _webDriver;
        private readonly By _optionLocator = By.CssSelector(".option-cell.input-label");
        private readonly By _optionListLocator;

        public FormMultiSelectElement(IWebElement webElement)
        {
            _webElement = webElement;
            _webDriver = _webElement.GetWebDriver();
            _optionListLocator = By.Id($"{_webElement.GetAttribute("id")}-search");
        }

        public void SetValue(string value)
        {
            _webElement.Click();
            var optionList = _webDriver.WaitForElementToExists(_optionListLocator);
            var options = optionList.FindElements(_optionLocator);
            var option = options.FirstOrDefault(o => o.Text == value);
            if (option == null)
                throw new Exception($"{value} not found in the form list");
            
            option.Click();
            _webDriver.WaitForElementToBeStaleness(optionList);
        }

        public string GetValue()
        {
            return _webElement.Text;
        }
    }
}
