using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seleniumTraining
{
    class GoogleSearchDifferentBrowsersTest
    {
        [TestMethod]
        public void TestInIE()
        {
            IWebDriver driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("http://testwisely.com/demo");
            System.Threading.Thread.Sleep(1000);
            driver.Quit();
        }
        [TestMethod]
        public void TestInFirefox()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://testwisely.com/demo");
            System.Threading.Thread.Sleep(1000);
            driver.Quit();
        }
        [TestMethod]
        public void TestInChrome()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://testwisely.com/demo");
            System.Threading.Thread.Sleep(1000);
            driver.Quit();
        }
        [TestMethod]
        public void TestInEdge()
        {
            // Default option, MicrosoftWebDriver.exe must be in PATH
            IWebDriver driver = new EdgeDriver();
            driver.Navigate().GoToUrl("http://testwisely.com/demo");
            System.Threading.Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
