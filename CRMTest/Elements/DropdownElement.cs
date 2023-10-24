using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CRMTest.Elements
{
    public class DropdownElement
    {
        private readonly IWebElement _webElement;
        private SelectElement _selectElement => new SelectElement(_webElement);

        public DropdownElement(IWebElement webElement)
        {
            _webElement = webElement;
        }

        public void SetValue(string value)
        {
            _selectElement.SelectByText(value);     
        }

        public string GetValue()
        {
            return _selectElement.SelectedOption.Text;
        }
    }
}
