using AventStack.ExtentReports;
using ReqnrollTestProject.Reports;
using OpenQA.Selenium;
using ReqnrollTestProject.Utilities;
using SpecFlowBinding = TechTalk.SpecFlow.BindingAttribute;


namespace ReqnrollTestProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtendReportManager.InitReport();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ExtendReportManager.StartTest(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepInfo = _scenarioContext.StepContext.StepInfo.Text;
            bool isSuccess = _scenarioContext.TestError == null;
            ExtendReportManager.LogStep(isSuccess,
                isSuccess ? $"Paso exitoso: {stepInfo}" : $"Error: {_scenarioContext.TestError.Message}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (WebDriverManager.Driver != null)
            {
                WebDriverManager.Driver.Quit();
                WebDriverManager.Driver = null;
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtendReportManager.FlushReport();
        }
    }
}
