using OpenQA.Selenium;

namespace CRMTest.Extensions
{
    public static class ScenarioContextExtension
    {
        public static string? GetUnique(this ScenarioContext scenarioContext, string? value)
        {
            if (value == null)
                return value;

            return $"{value}_{scenarioContext.GetId()}";
        }

        private static string GetId(this ScenarioContext scenarioContext)
        {
            if (!scenarioContext.ContainsKey("scenarioId"))
                scenarioContext["scenarioId"] = DateTime.Now.Ticks;

            return scenarioContext["scenarioId"].ToString() ?? "";
        }
    }
}
