using CRMTest.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using SolidToken.SpecFlow.DependencyInjection;

namespace CRMTest.Support
{
    public static class Registration
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateGlobalContainer()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var settings = config.Get<Appsettings>();
            var builder = new ServiceCollection();

            builder.AddScoped<Appsettings>(provider => settings);

            builder.AddScoped<IWebDriver>(provider =>
            {
                var appsettings = provider.GetService<Appsettings>();
                return WebDriverFactory.Create(appsettings);
            });
            return builder;
        }
    }
}
