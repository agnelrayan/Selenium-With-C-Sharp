using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace seleniumTraining
{
    // A class that contains MSTest unit tests. (Required)
    [TestClass]
    public class UnitTest4
    {
       
       
          //  [AssemblyInitialize]
            public static void AssemblyInit(TestContext context)
            {
                // Executes once before the test run. (Optional)
            }
            [ClassInitialize]
            public static void BeforeClass(TestContext context)
            {
            // Executes once for the test class. (Optional)

            Console.WriteLine("Before Class...");
            }

            [TestInitialize]
            public void BeforeTest()
            {
            // Runs before each test. (Optional)
            Console.WriteLine("Before Every Test...");
        }
         //   [AssemblyCleanup]
            public static void AssemblyCleanup()
            {
                // Executes once after the test run. (Optional)
            }

            [ClassCleanup]
            public static void AfterClass()
            {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
            Console.WriteLine("After Class...");
        }

            [TestCleanup]
            public void AfterTest()
            {
            // Runs after each test. (Optional)
            Console.WriteLine("Run after every test...");
        }
            // Mark that this is a unit test method. (Required)
            [TestMethod]
            public void FirstTestMethod()
            {
            // Your test code goes here.
            Console.WriteLine("This is first test...");
           }
        [TestMethod]
        public void SecondTestMethod()
        {
            // Your test code goes here.
            Console.WriteLine("This is second test...");
        }

    }
    }

