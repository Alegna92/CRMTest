using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace CRMTest.StepDefinitions
{
    [Binding]
    public class ApplicationSteps
    {
        private readonly IWebDriver _webDriver;
        private readonly Appsettings _appsettings;

        private static ExtentTest _feature;
        private static ExtentTest _scenario;
        private static ExtentReports _extent;

        public ApplicationSteps(IWebDriver webDriver, Appsettings appsettings)
        {
            _webDriver = webDriver;
            _appsettings = appsettings;
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            _extent = new ExtentReports();
            _extent.AttachReporter(new ExtentSparkReporter(@"report.html"));
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            _webDriver.Navigate().GoToUrl(_appsettings.BaseUrl);
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }

            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message);
            }

        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _extent.Flush();
        }
    }
}
