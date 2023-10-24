using OpenQA.Selenium;

namespace CRMTest.Elements
{
    public class LabelElement
    {
        private readonly IWebElement _webElement;
        public LabelElement(IWebElement webElement)
        {
            _webElement = webElement;
        }

        public string GetText()
        {
            return _webElement.Text;
        }
    }
}
