using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumTraining
{
    [TestClass]
    public class ExtentReportsEx
    {
        static ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter("extentUpdateReport.html");
        static ExtentReports extent = new ExtentReports();
        OpenQA.Selenium.IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            extent.AttachReporter(htmlReporter);
        }

        public static string Capture(IWebDriver driver,string ScreenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string uptobinPath = path.Substring(0, path.LastIndexOf("bin")) + "Screenshots\\" + ScreenShotName + ".png";
            string localPath = new Uri(uptobinPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }

        [TestMethod]
        public void EnvVariables()
        {
            extent.AddSystemInfo("Operating System: ","Win 10");
            extent.AddSystemInfo("HostName: ", "Computer Name");
            extent.AddSystemInfo("Browser: ","Google Chrome");
        }
        [TestMethod]
        public void PassedTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://twitter.com/");
            string screenshotpath = Capture(driver,"screenshot");
            var test = extent.CreateTest("PassedTestMethod", "<h3>This test method gets passed<h3>");
            test.Log(Status.Info, "First step of PassedTestMethod");
            test.Pass("PassedTestMethod gets completed");
            test.AddScreenCaptureFromPath(screenshotpath);
            driver.Quit();
        }
        [TestMethod]
        public void FailedTest()
        {
            var test = extent.CreateTest("FailedTestMethod", "This test method gets Fail");
            test.Log(Status.Info, "First step of FailedTest");
            test.Fail("FailTestMethod gets completed");
            
        }
        [TestMethod]
        public void SkipTest()
        {
            var test = extent.CreateTest("SkipTestMethod", "This test method gets Skip");
            test.Log(Status.Info, "First step of SkipTest");
            test.Skip("SkipTestMethod gets completed");

        }

        [TestMethod]
        public void WarningTest()
        {
            var test = extent.CreateTest("WarningTestMethod", "This test method gets Warning");
            test.Log(Status.Info, "First step of WarningTest");
            test.Warning("WarningTestMethod gets completed");

        }
        [TestMethod]
        public void CleanUp()
        {
            extent.Flush();
        }

    }
}
