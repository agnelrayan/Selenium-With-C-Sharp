using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumTraining
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            // driver.Navigate().GoToUrl("https://www.google.com/search?source=hp&ei=lvGvXt_3IcvorQG7s4PQDg&q=testhouse&oq=testhouse&gs_lcp=CgZwc3ktYWIQAzICCAAyAggAMgIIADICCAAyAggAMgIIADICCAAyAggAMgIIADICCAA6BQgAEIMBOg4IABDqAhC0AhCaARDlAjoECAAQClCLClinP2DVQmgFcAB4AIABhAKIAZUUkgEGMC4xMi40mAEAoAEBqgEHZ3dzLXdperABBg&sclient=psy-ab&ved=0ahUKEwjfmt6Ag5rpAhVLdCsKHbvZAOoQ4dUDCAc&uact=5");
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Manage().Window.Maximize();
            IWebElement search = driver.FindElement(By.XPath("(//input[@title='Search'])"));
            search.SendKeys("TestHouse");
            Thread.Sleep(3000);
            search.Submit();
            Thread.Sleep(3000);
            
           // search.SendKeys("TestHouse");
            driver.FindElement(By.XPath("//button[@aria-label='Google Search']")).Click();
            //Thread.Sleep(3000);
            //search.Click();
            //driver.Close();

        }
    }
}
