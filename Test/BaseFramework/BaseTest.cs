using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Test.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Test.BaseFramework
{
    [SetUpFixture]
    public class BaseTest:Driver
    {
        protected ExtentReports Extent;
        protected ExtentTest Test;

        [OneTimeSetUp]
        protected void StartReport()
        {
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            //Append the html report file to current project path
            var reportPath = projectPath + "Reports\\TestRunReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        protected void StopReport()
        {
            Extent.Flush();
        }

        [SetUp]
        public void SetUp()
        {
            Test = Extent.CreateTest(TestContext.CurrentContext.Test.Name);
            StartBrowser();
        }
        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            if (status == TestStatus.Failed || status == TestStatus.Skipped)
            {
                var screenShotPath = Helpers.Capture();
                Test.Log(logstatus, "Test " + logstatus + "| " + message);
                Test.Fail("Screenshot:" + Test.AddScreenCaptureFromPath(screenShotPath));
                Extent.Flush();
                StopBrowser();
            }
            else
            {
                Test.Log(logstatus, "Test " + logstatus);
                Extent.Flush();
                StopBrowser();
            }
        }
    }
}
