using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumTraining
{
    [TestClass]
    public class SeleniumTest
    {
        ExtentReports extent;
        ExtentTest logger;
        public IWebDriver driver; //declare the driver object

      
        [TestInitialize]
        public void BeforeTest()
        {
            ExtentHtmlReporter reporter = new ExtentHtmlReporter("\\Personal\\Reports\\testing.html");
            //D:\\fileex\\output.txt
            extent = new ExtentReports();
            extent.AttachReporter(reporter);
            logger = extent.CreateTest("LoginTest");
            driver = new ChromeDriver(); //initialize the ChromeDriver instance
            driver.Url = "https://www.google.co.in";
        }

        [TestMethod]
        public void GoogleSearchTest()
        {

            IWebElement ele = driver.FindElement(By.XPath("//input[@title='Search']"));
            ele.SendKeys("TestHouse");
            ele.Submit();
        }
        public void  getScreenshot(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;

            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;

            Screenshot screenshot = screenshotDriver.GetScreenshot();

            screenshot.SaveAsFile(@"\\D\\Personal\\Reports\\test.html"); //D:\\Personal\\Reports\\test.html

            //        TakesScreenshotWithDate(FirefoxInstance, @"C:\FileLocation\", "File_Name_", System.Drawing.Imaging.ImageFormat.Jpeg);



            // TODO Auto-generated method stub

        }
        [TestCleanup]
        public void AfterTest()
        {
            getScreenshot(driver);
            
        }
    }
}
