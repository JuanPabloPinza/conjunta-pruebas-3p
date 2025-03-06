using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace ReqnrollTestProject.Reports
{
    public class ExtendReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static string _reportPath = Path.Combine(Directory.GetCurrentDirectory(), "TestResult", "ExtentReport.html");

        public static void InitReport()
        {
            string reportDir = Path.Combine(Directory.GetCurrentDirectory(), "TestResult");
            if (!Directory.Exists(reportDir))
            {
                Directory.CreateDirectory(reportDir);
            }
            _reportPath = Path.Combine(reportDir, "ExtentReport.html");
            Console.WriteLine($"El reporte se generará en: {_reportPath}");

            var sparkReporter = new ExtentSparkReporter(_reportPath);
            sparkReporter.Config.DocumentTitle = "Reporte de Pruebas";
            sparkReporter.Config.ReportName = "Reporte de Ejecución de Pruebas";

            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        public static void StartTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void LogStep(bool isSuccess, string stepDetails)
        {
            if (isSuccess)
            {
                _test.Pass(stepDetails);
            }
            else
            {
                _test.Fail(stepDetails);
            }
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
