﻿using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumTraining
{
    [TestClass]
    public class UnitTest6
    {
       
            public IWebDriver driver;
            protected ExtentReports _extent;
            protected ExtentTest _test;

            ///For report directory creation and HTML report template creation
            ///For driver instantiation
            /// Author: Sanoj
            /// Since: 23-Sep-2018
            [ClassInitialize]
            public void BeforeClass(TestContext tc)
            {
                try
                {
                    //To create report directory and add HTML report into it

                    _extent = new ExtentReports();
                    var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                    DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
                    var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + ".html");
                    _extent.AddSystemInfo("Environment", "Journey of Quality");
                    _extent.AddSystemInfo("User Name", "Antony Rayappan");
                    _extent.AttachReporter(htmlReporter);
                }
                catch (Exception e)
                {
                    throw (e);
                }

                try
                {
                    driver = new ChromeDriver();
                }
                catch (Exception e)

                {
                    throw (e);
                }
            }

            ///Getting the name of current running test to extent report
            /// Author: Sanoj
            /// Since: 23-Sep-2018
            [TestInitialize]
            public void BeforeTest()
            {
                try
                {
                 //   _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
              //  _test = _extent.CreateTest(TestContext.Cur);
            }
                catch (Exception e)
                {
                    throw (e);
                }
            }

            [TestMethod]
            public void PassTest()
            {
                Assert.IsTrue(true);
            }
            [TestMethod]
            public void FailTest()
            {
                driver.Url ="http://google.com";
                Assert.AreEqual(driver.Title, "Journey");
            }

            /// Finish the execution and logging the detials into HTML report
            /// Author: Sanoj
            /// Since: 23-Sep-2018
            [TestCleanup]
            public void AfterTest()
            {
                try
                {
                   // var status = TestContext.CurrentContext.Result.Outcome.Status;
                    //var stacktrace = "" +TestContext.CurrentContext.Result.StackTrace + "";
                    //var errorMessage = TestContext.CurrentContext.Result.Message;
                    Status logstatus;
                
                //switch (status)
                    {
                        //case TestStatus.Failed:
                        //    logstatus = Status.Fail;
                        //    string screenShotPath = Capture(driver, TestContext.CurrentContext.Test.Name);
                        //    _test.Log(logstatus, "Test ended with " +logstatus + " – " +errorMessage);
                        //    _test.Log(logstatus, "Snapshot below: " +_test.AddScreenCaptureFromPath(screenShotPath));
                        //    break;
                        //case TaskStatus.Skipped:
                        //    logstatus = Status.Skip;
                        //    _test.Log(logstatus, "Test ended with " +logstatus);
                            //break;
                        //default:
                        //    logstatus = Status.Pass;
                        //    _test.Log(logstatus, "Test ended with " +logstatus);
                           // break;
                    }
                }
                catch (Exception e)
                {
                    throw (e);
                }
            }

            ///To flush extent report
            ///To quit driver instance
            /// /// Author: Sanoj
            /// Since: 23-Sep-2018
            [ClassCleanup]
            public void AfterClass()
            {
                try
                {
                    _extent.Flush();
                }
                catch (Exception e)
                {
                    throw (e);
                }
                driver.Quit();
            }

            /// To capture the screenshot for extent report and return actual file path
            /// Author: Sanoj
            /// Since: 23-Sep-2018
            private string Capture(IWebDriver driver, string screenShotName)
            {
                string localpath = "";
                try
                {
                    Thread.Sleep(4000);
                    ITakesScreenshot ts = (ITakesScreenshot)driver;
                    Screenshot screenshot = ts.GetScreenshot();
                    string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                    var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                    DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\");
                    string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Defect_Screenshots\\" +screenShotName + ".png";
                    localpath = new Uri(finalpth).LocalPath;
                    screenshot.SaveAsFile(localpath);
                }
                catch (Exception e)
                {
                    throw (e);
                }
                return localpath;
            }
        }
    }

