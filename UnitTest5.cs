using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace seleniumTraining
{
    [TestClass]
    public class GoogleSearchDifferentBrowserTest
    {
        [TestMethod]
        public void TestInIE()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("http://testwisely.com/demo");
            System.Threading.Thread.Sleep(1000);
            driver.Quit();
        }
        //[TestMethod]
        //public void TestInFirefox()
        //{
        //    IWebDriver driver = new FirefoxDriver();
        //    driver.Navigate().GoToUrl("http://testwisely.com/demo");
        //    System.Threading.Thread.Sleep(1000);
        //    driver.Quit();
        //}
        [TestMethod]
        public void TestInChrome()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://testwisely.com/demo");
            System.Threading.Thread.Sleep(1000);
            driver.Quit();
        }
        //[TestMethod]
        //public void TestInEdge()
        //{
        //    // Default option, MicrosoftWebDriver.exe must be in PATH
        //    IWebDriver driver = new EdgeDriver();
        //    driver.Navigate().GoToUrl("http://testwisely.com/demo");
        //    System.Threading.Thread.Sleep(1000);
        //    driver.Quit();
        //}
    }
}
