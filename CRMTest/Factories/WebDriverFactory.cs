using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace CRMTest.Factories
{
    public static class WebDriverFactory
    {
        public static IWebDriver Create(Appsettings appsettings)
        {
            if (appsettings == null) throw new ArgumentNullException(nameof(appsettings));
            if (appsettings.Browser == "Chrome") return CreateChromeDriver(appsettings);
            else if (appsettings.Browser == "Edge") return new EdgeDriver();
            else if (appsettings.Browser == "Firefox") return new FirefoxDriver();
            else throw new ArgumentException($"Unknown browser {appsettings.Browser}");
        }

        private static IWebDriver CreateChromeDriver(Appsettings appsettings)
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-popup-blocking");
            if (appsettings.Incognito)
                options.AddArgument("--incognito");
            if (appsettings.RunHeadless)
                options.AddArgument("--headless");
            return new ChromeDriver(options);
        }
    }
}
