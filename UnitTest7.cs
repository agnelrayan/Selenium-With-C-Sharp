using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace seleniumTraining
{
    [TestClass]
    public class UnitTest7
    {
        [ClassInitialize]
        public static void BeforeClass(TestContext testc)
        {
            Console.WriteLine("Before all the Method , once");
        }
        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("Before every Test Method");
        }
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("First Test Method...");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("Second Test Method...");
        }

        [TestCleanup]
        public void AfterTest()
        {
            Console.WriteLine("After every Test Method");
        }

        [ClassCleanup]
        public static void AfterClass()
        {
            Console.WriteLine("After all the Method , once");
        }
    }
}
