using OpenQA.Selenium;

namespace CRMTest.Elements
{
    public class InputElement
    {
        private readonly IWebElement _webElement;

        public InputElement(IWebElement webElement)
        {
            _webElement = webElement;
        }

        public void SetValue(string value)
        {
            _webElement.SendKeys(value);
        }

        public string GetValue()
        {
            return _webElement.Text;
        }

    }
}
