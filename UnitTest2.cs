using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumTraining
{
    [TestClass] //this is used for test class
    public class UnitTest2

//Launch a new Chrome browser.
//Open testhouse.net
//Get Page Title name and Title length
//Print Page Title and Title length on the Console.
//Get Page URL and Page Url Length
//Print Page URL and Page Url Length on the Console.
//Get Page Source (HTML Source code) and Page Source length
//Print Page Length on Console.
//Close the Browser.
    {
       // IWebDriver driver = new ChromeDriver();
       [AssemblyInitialize]
         public static void BeforeAssembly(TestContext tc)
        {
            Console.WriteLine("Before Assembly....");
        }
        [AssemblyCleanup]
        public static void AfterAssembly()
        {
            Console.WriteLine("AFter Assembly");
        }
       [ClassInitialize]
         public static void BeforeClass(TestContext tc)
        {
            Console.WriteLine("Run b4 all the test method starts...");
        }

        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("Run b4 all the test");
        }
        [TestCleanup]
        public void AfterTest()
        {
            Console.WriteLine("Run after all the test");
        }
        
        [TestMethod,TestCategory("Exam")]
        public void FirstTest()
        {
            Console.WriteLine("Test One");
        }

        [TestMethod,TestCategory("Exam")]
        public void SecondTest()
        {
            Console.WriteLine("Test Two");
        }
        [Ignore]
        [TestMethod]
        public void ThirdTest()
        {
            Console.WriteLine("Test Three");
        }

        [ClassCleanup]
        public static void AfterClass()
        {
            Console.WriteLine("Run After all the test methods are completed...");
        }
        //[Priority(1), TestCategory("DriverCommand")]
        //[TestMethod]
        //public void DriverCommandsSignIn()
        //{
        //    // IWebDriver driver = new ChromeDriver();

        //    driver.Url = "https://www.testhouse.net";

        //    driver.Manage().Window.Maximize();
        //}
        ////[Priority(2), TestCategory("DriverCommand")]
        ////[TestMethod]
        //public void DriverCommandMethods() { 

        //    string title=driver.Title;

        //    Console.WriteLine("Title is: " + title);

        //    int titleLength = driver.Title.Length;

        //    Console.WriteLine("Title length is: "+titleLength);

        //    int urlLength = driver.Url.Length;

        //    Console.WriteLine("Url Length is: " + urlLength);

        //    int pageSourceLength=driver.PageSource.Length;
        //    Console.WriteLine("PageSourceLength is: "+pageSourceLength);



        //}
        //[Priority(3), TestCategory("DriverCommand")]
        //[TestMethod]
        //public void LogOff()
        //{
        //    driver.Quit();
        //}
    }
}
