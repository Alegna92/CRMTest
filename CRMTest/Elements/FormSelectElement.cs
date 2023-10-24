using CRMTest.Extensions;
using OpenQA.Selenium;
using SpecFlow.Internal.Json;
using System.Text;

namespace CRMTest.Elements
{
    public class FormSelectElement
    {
        private readonly IWebElement _webElement;
        private readonly IWebDriver _webDriver;
        private readonly By _optionLocator = By.CssSelector(".option-cell.input-label");
        private readonly By _optionListLocator;

        public FormSelectElement(IWebElement webElement)
        {
            _webElement = webElement;
            _webDriver = _webElement.GetWebDriver();
            var optionListId = $"{_webElement.GetAttribute("id")}-popup";
            _optionListLocator = By.Id(optionListId);
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
        }

        public string GetValue()
        {
            return _webElement.Text;
        }




    }
}
