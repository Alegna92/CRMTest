using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace CRMTest.Extensions
{
    public static class WebDriverExtensions
    {
        private readonly static TimeSpan _defaultTimeSpan = TimeSpan.FromSeconds(5);

        public static IWebElement WaitForElementToBeVisible(this IWebDriver webDriver, By locator)
        {
            var wait = new WebDriverWait(webDriver, _defaultTimeSpan);
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitForElementToExists(this IWebDriver webDriver, By locator)
        {
            var wait = new WebDriverWait(webDriver, _defaultTimeSpan);
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static bool WaitForElementToBeInvisible(this IWebDriver webDriver, By locator)
        {
            var wait = new WebDriverWait(webDriver, _defaultTimeSpan);
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static bool WaitForElementToBeStaleness(this IWebDriver webDriver, IWebElement webElement)
        {
            var wait = new WebDriverWait(webDriver, _defaultTimeSpan);
            return wait.Until(ExpectedConditions.StalenessOf(webElement));
        }

        public static void AcceptAllert(this IWebDriver webDriver)
        {
            var wait = new WebDriverWait(webDriver, _defaultTimeSpan);
            wait.Until(ExpectedConditions.AlertIsPresent());
            webDriver.SwitchTo().Alert().Accept();
            wait.Until(ExpectedConditions.AlertState(false));
        }

        public static ReadOnlyCollection<IWebElement> WaitForElementsToBeVisible(this IWebDriver webDriver, By locator)
        {
            var wait = new WebDriverWait(webDriver, _defaultTimeSpan);
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

    }
}
