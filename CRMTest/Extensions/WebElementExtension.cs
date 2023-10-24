using OpenQA.Selenium;

namespace CRMTest.Extensions
{
    public static class WebElementExtension
    {
        public static IWebDriver GetWebDriver(this IWebElement webElement)
        {
            if (webElement is IWrapsDriver wrapsDriver)
            {
                return wrapsDriver.WrappedDriver;
            }
            throw new Exception("Object does not implement IWrapsDriver");
        }
    }
}
