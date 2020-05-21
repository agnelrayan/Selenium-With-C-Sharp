using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace seleniumTraining
{
    [TestClass]
    public class LocatorsEx
    {
        IWebDriver driver = new ChromeDriver();
        //IWebDriver driver = new InternetExplorerDriver();

        public object SeleniumExtras { get; private set; }

        [TestMethod]
        public void TestId()
        {

            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Window.Maximize();
            //Thread.Sleep(3000);
            driver.FindElement(By.Id("email")).SendKeys("agnelrayan");
            Thread.Sleep(3000);
            driver.FindElement(By.Name("pass")).SendKeys("32323");
            //driver.Close();

        }

        [TestMethod]
        public void TestName()
        {

            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/");
            driver.Manage().Window.Maximize();
            //Thread.Sleep(3000);
            driver.FindElement(By.Name("userName")).SendKeys("agnelrayan");
            //driver.Close();

        }

        [TestMethod]
        public void TestClassName()
        {

            driver.Navigate().GoToUrl("https://www.airbnb.co.in/");
            driver.Manage().Window.Maximize();
            //Thread.Sleep(3000);
            driver.FindElement(By.ClassName("_1spzot3")).SendKeys("Trivandrum" + Keys.Enter);
            // driver.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);

            //driver.Close();

        }

        [TestMethod]
        public void TestCSSSelector()
        {

            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.TagName("input")).SendKeys("1212");

            //Thread.Sleep(3000);
            //driver.FindElement(By.CssSelector("input[id=email]")).SendKeys("agnelrayan");
            //driver.FindElement(By.CssSelector("input[name=pass]")).SendKeys("agnelrayan");
            // driver.FindElement(By.PartialLinkText("Create")).Click();

            // driver.FindElement(By.LinkText("Create a Page")).Click();
            //driver.Close();

        }

        [TestMethod]
        public void TestLinkText()
        {

            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/");
            driver.Manage().Window.Maximize();
            //Thread.Sleep(3000);
            driver.FindElement(By.LinkText("REGISTER")).Click();
            //driver.FindElement(By.CssSelector("input[id=pass]")).SendKeys("agnelrayan");
            //driver.Close();

        }

        [TestMethod]
        public void TestPartialLinkText()
        {

            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/");
            driver.Manage().Window.Maximize();
            //Thread.Sleep(3000);
            driver.FindElement(By.PartialLinkText("Car")).Click();
            //driver.FindElement(By.CssSelector("input[id=pass]")).SendKeys("agnelrayan");
            //driver.Close();

        }

        [TestMethod]
        public void TestTagNameLocator()
        {

            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/");
            driver.Manage().Window.Maximize();
            //Thread.Sleep(3000);

            //IWebElement links =driver.FindElement(By.TagName("a"));
            //string link=links.Text;

            var save = driver.FindElements(By.TagName("a"))[0];
            save.Click();

            Console.WriteLine("Link is: " + save);

            //List<IWebElement> list = driver.FindElements(By.TagName("a"));


            //links = driver.findElements(By.tagName("a")); //storing the size of the links 
            //int i = links.size(); //Printing the size of the string System.out.println(i); 
            //for (int j = 0; j < i; j++)
            //{
            //    //Printing the links 
            //    System.out.println(links.get(j).getText());
            //driver.FindElement(By.CssSelector("input[id=pass]")).SendKeys("agnelrayan");
            //driver.Close();

        }
        [TestMethod]
        public void TestBrowserCommand()
        {
            driver.Url = "https://www.testhouse.net";

            driver.Manage().Window.Maximize();

            string Expectedtitle = driver.Title;

            Console.WriteLine("Title is: " + Expectedtitle);

            string ActualTitle = "Testhouse – A Software Quality Assurance & DevOps Company";

            if (ActualTitle.Equals(Expectedtitle))
            {
                Console.WriteLine("Web page is loaded correctly");
            }

            else
            {
                Assert.Fail("Web page is not loaded correctly");
            }


            int titleLength = driver.Title.Length;

            Console.WriteLine("Title length is: " + titleLength);

            int urlLength = driver.Url.Length;

            Console.WriteLine("Url Length is: " + urlLength);

            int pageSourceLength = driver.PageSource.Length;
            Console.WriteLine("PageSourceLength is: " + pageSourceLength);

            driver.Close();



        }

        [TestMethod]
        public void TestBrowserCommandTwo()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/ ");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//a[text()='REGISTER']")).Click(); ////a[text()='REGISTER'] LinkText("REGISTER")
            Thread.Sleep(3000);
            driver.Navigate().Back();
            Thread.Sleep(3000);
            driver.Navigate().Forward();
            Thread.Sleep(3000);
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            driver.Quit();

        }

        [TestMethod]
        public void TestClear()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/ ");
            driver.Manage().Window.Maximize();

            IWebElement clearEle = driver.FindElement(By.Name("userName"));
            clearEle.SendKeys("testuser");
            Thread.Sleep(3000);
            clearEle.Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Name("userName")).SendKeys("TestUser2");
            Thread.Sleep(3000);
            driver.Close();



        }
        [TestMethod]
        public void TestDisplayed()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/ ");
            driver.Manage().Window.Maximize();

            bool register = driver.FindElement(By.LinkText("REGISTER")).Displayed;

            if (register)
            {
                Console.WriteLine("Register Button is Displayed: " + register);
            }
            else
            {
                Assert.Fail("Register Button is not Displayed: " + register);
            }

            Thread.Sleep(3000);
            driver.Close();
        }


        [TestMethod]
        public void TestEnabled()
        {
            driver.Navigate().GoToUrl("http://www.testdiary.com/training/selenium/selenium-test-page/");
            driver.Manage().Window.Maximize();

            // Declaring a local variable of type "WebElement" to initialize the
            // value of the webElement (seleniumCheckbox) and webElement
            // (restCheckbox)

            IWebElement seleniumCheckbox = driver.FindElement(By.Id("seleniumbox"));
            IWebElement restCheckbox = driver.FindElement(By.Id("restapibox"));

            Thread.Sleep(5000);

            // Declaring a local variable of type "Boolean" to initialize the
            // value of the webElement (checkSelenium) and webElement (checkRestApi)
            // Using the isSelected method we check if the check box is selected or
            // not.
            bool checkSelenium = seleniumCheckbox.Selected;
            bool checkRestApi = restCheckbox.Selected;

            // use an if condition to check if boolean returned false
            // If false then it was not selected
            // click and select the checkbox
            if (checkSelenium == false)
            {
                seleniumCheckbox.Click();
                Console.WriteLine("Test has selected Selenium checkbox");
            }
            else
            {
                Console.WriteLine("Selenium checkbox was selected on default");
            }

            //Repeat the process for checkRestAapi
            if (checkRestApi == false)
            {
                restCheckbox.Click();
                Console.WriteLine("Test has selected Rest api checkbox");
            }
            else
            {
                Console.WriteLine("Rest Api checkbox was selected on default");
            }

            // Check if Save button is displayed on the WebPage
            IWebElement saveButton = driver.FindElement(By.Id("demo"));

            bool checkSaveIsDisplayed = saveButton.Displayed;

            if (checkSaveIsDisplayed == true)
            {
                Console.WriteLine("save button is displayed");
            }

            // Check if Save button is not enabled on the WebPage

            bool checkSaveIsEnabled = saveButton.Enabled;


            if (checkSaveIsEnabled == false)
            {
                Console.WriteLine("save button is not enabled");
            }

            // Click on a radio button then check if the save button is now enabled

            IWebElement javaRadioButton = driver.FindElement(By.Id("java1"));

            Thread.Sleep(5000);

            javaRadioButton.Click();

            // check if it is now enabled
            checkSaveIsEnabled = saveButton.Enabled;
            if (checkSaveIsEnabled == true)
            {
                Console.WriteLine("save button is enabled");
            }

            driver.Close();



        }

        //IWebElement saveButton = driver.FindElement(By.Id("demo"));
        //bool checkSaveIsEnabled = saveButton.Enabled;

        //if (checkSaveIsEnabled == true)
        //{
        //    Console.WriteLine("save button is enabled:"+ checkSaveIsEnabled);
        //}


        //else
        //{
        //    Assert.Fail("save button is not enabled " + checkSaveIsEnabled);
        //}
        [TestMethod]
        public void VisibilityCondition()
        {
            string appUrl = "https://google.com";

            // launch the firefox browser and open the application url
            driver.Navigate().GoToUrl(appUrl);

            // maximize the browser window
            driver.Manage().Window.Maximize();

            // declare and initialize the variable to store the expected title of the webpage.
            string expectedTitle = "Google";

            // fetch the title of the web page and save it into a string variable
            string actualTitle = driver.Title;

            // compare the expected title of the page with the actual title of the page and print the result
            if (expectedTitle.Equals(actualTitle))
            {
                Console.WriteLine("Verification Successful - The correct title is displayed on the web page.");
            }
            else
            {
                Console.WriteLine("Verification Failed - An incorrect title is displayed on the web page.");
            }

            // verify if the “Google Search” button is displayed and print the result
            bool submitbuttonPresence = driver.FindElement(By.XPath("//input[@aria-label='Search']")).Displayed;
            Console.WriteLine(submitbuttonPresence);

            // enter the keyword in the “Google Search” text box by which we would want to make the request
            IWebElement searchTextBox = driver.FindElement(By.XPath("//input[@aria-label='Search']"));
            searchTextBox.Clear();
            searchTextBox.SendKeys("Selenium");

            // verify that the “Search button” is displayed and enabled
            bool searchIconPresence = driver.FindElement(By.XPath("//input[@aria-label='Search']")).Displayed;
            bool searchIconEnabled = driver.FindElement(By.XPath("//input[@aria-label='Search']")).Enabled;

            if (searchIconPresence == true && searchIconEnabled == true)
            {
                // click on the search button
                IWebElement searchIcon = driver.FindElement(By.XPath("//input[@aria-label='Search']"));
                searchIcon.Click();
            }

            // close the web browser
            driver.Close();
            Console.WriteLine("Test script executed successfully.");



        }

        [TestMethod]
        public void CompleteCode()
        {
            string baseUrl = "http://demo.guru99.com/test/login.html";
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();

            // Get the WebElement corresponding to the Email Address(TextField)		
            IWebElement email = driver.FindElement(By.Id("email"));

            // Get the WebElement corresponding to the Password Field		
            IWebElement password = driver.FindElement(By.Name("passwd"));

            email.SendKeys("abcd@gmail.com");

            password.SendKeys("abcdefghlkjl");
            Console.WriteLine("Text Field Set");

            // Deleting values in the text box		
            email.Clear();
            password.Clear();
            Console.WriteLine("Text Field Cleared");

            // Find the submit button		
            IWebElement login = driver.FindElement(By.Id("SubmitLogin"));

            // Using click method to submit form		
            email.SendKeys("abcd@gmail.com");
            password.SendKeys("abcdefghlkjl");
            login.Click();
            Console.WriteLine("Login Done with Click");

            //using submit method to submit the form. Submit used on password field		
            driver.Navigate().GoToUrl(baseUrl);
            driver.FindElement(By.Id("email")).SendKeys("abcd@gmail.com");
            driver.FindElement(By.Name("passwd")).SendKeys("abcdefghlkjl");
            driver.FindElement(By.Id("SubmitLogin")).Submit();
            Console.WriteLine("Login Done with Submit");

            //driver.close();
        }
        [TestMethod]
        public void TestClick()
        {
            string url = "http://www.demoqa.com";

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            IWebElement element = driver.FindElement(By.XPath("//a[@title='Widgets']"));
            element.Click();

            //Or can be written as

            //driver.FindElement(By.LinkText("ToolsQA")).Click();

        }
        [TestMethod]
        public void TestSubmit()
        {
            driver.Navigate().GoToUrl("http://only-testing-blog.blogspot.in/2014/05/form.html");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//input[@name='FirstName']")).SendKeys("MyFName");
            driver.FindElement(By.XPath("//input[@name='LastName']")).SendKeys("MyLName");
            driver.FindElement(By.XPath("//input[@name='EmailID']")).SendKeys("My Email ID");
            driver.FindElement(By.XPath("//input[@name='MobNo']")).SendKeys("My Mob No.");
            driver.FindElement(By.XPath("//input[@name='Company']")).SendKeys("My Comp Name");
            //To submit form.
            //You can use any other Input field's(First Name, Last Name etc.) xpath too In bellow given syntax.
            driver.FindElement(By.XPath("//input[@name='Company']")).Submit();

            //string alrt = driver.SwitchTo().Alert().Text;
            //driver.SwitchTo().Alert().Accept();
            //Console.WriteLine(alrt);

        }
        [TestMethod]
        public void FirstTest()
        {

            string baseUrl = "http://demo.guru99.com/test/newtours/";
            driver.Manage().Window.Maximize();
            string expectedTitle = "Welcome: Mercury Tours";
            string actualTitle = "";

            // launch Fire fox and direct it to the Base URL
            driver.Navigate().GoToUrl(baseUrl);

            // get the actual value of the title
            actualTitle = driver.Title;

            /*
             * compare the actual title of the page with the expected one and print
             * the result as "Passed" or "Failed"
             */
            if (actualTitle.Equals(expectedTitle))
            {
                Console.WriteLine("Test Passed!");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }

            //close Fire fox
            driver.Close();
        }
        [TestMethod]
        public void TestText()
        {
            driver.Navigate().GoToUrl("https://www.calculator.net/percent-calculator.html");


            // Click on Math Calculators
            //driver.FindElement(By.XPath("//[@id = 'menu']/div[3]/a")).Click();

            //Click on Percent Calculators
            //driver.FindElement(By.XPath("//[@id = 'menu']/div[4]/div[3]/a")).Click();

            // Enter value 10 in the first number of the percent Calculator
            driver.FindElement(By.Id("cpar1")).SendKeys("10");

            // Enter value 50 in the second number of the percent Calculator
            driver.FindElement(By.Id("cpar2")).SendKeys("50");

            // Click Calculate Button
            driver.FindElement(By.XPath(".//*[@id = 'content']/table/tbody/tr[2]/td/input[2]")).Click();


            // Get the Result Text based on its xpath
            string result = driver.FindElement(By.XPath(".//*[@id = 'content']/p[2]/font/b")).Text;


            // Print a Log In message to the screen
            Console.WriteLine(" The Result is " + result);

            //Close the Browser.
            driver.Close();
        }

        [TestMethod]
        public void TestTagNameElement()
        {


            string baseUrl = "http://demo.guru99.com/test/newtours/";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            string tagName = driver.FindElement(By.XPath("//input[@name='userName']")).TagName; //input
            Console.WriteLine("TagName is:" + tagName);

            string size = driver.FindElement(By.XPath("//input[@name='userName']")).GetAttribute("size"); //10
            Console.WriteLine("Size is: " + size);

            string style = driver.FindElement(By.XPath("//input[@name='submit']")).GetCssValue("font-size"); //15
            Console.WriteLine("Style is: " + style);

            driver.Close();
        }


        //Opening application
        //driver.Navigate().GoToUrl("https://www.lambdatest.com");
        //driver.Manage().Window.Maximize();

        ////storing the number of links in list
        //string links = driver.FindElements(By.TagName("a")).ToString();

        ////String sClass = driver.FindElements(By.TagName("button")).ToString();

        ////storing the size of the links
        //int i = links.Length;

        ////Printing the size of the string
        //Console.WriteLine(i);

        //for (int j = 0; j < i; j++)
        //{
        //    //Printing the links
        // // Console.WriteLine(links);
        //}

        ////Closing the browser
        //driver.Close();

        ///* //Opening application
        // driver.Navigate().GoToUrl("https://accounts.lambdatest.com/login");
        // driver.Manage().Window.Maximize();




        //    //Locating the email field element via Name tag and storing it in the webelement
        //    IWebElement email_field = driver.FindElement(By.Name("email"));

        ////Entering text into the email field
        //email_field.SendKeys("agnelrayan@gmail.com");

        //    //Locating the password field element via Name tag and storing it in the webelement
        //    IWebElement password_field = driver.FindElement(By.Name("password"));

        ////Entering text into the password field
        //password_field.SendKeys("antonyray");

        //    //Clicking on the login button to login to the application
        //    IWebElement login_button = driver.FindElement(By.XPath("//button[text()='Login']"));

        ////Clicking on the 'login' button
        //login_button.Click();

        //   //Clicking on the Settings option
        //    driver.FindElement(By.XPath("//*[@id='app']/header/aside/ul/li[8]/a")).Click();

        ////Waiting for the profile option to appear
        //Thread.Sleep(3500);

        //    //*[@id="app"]/header/aside/ul/li[8]/ul/li[1]/a
        //    //Clicking on the profile link
        //    driver.FindElement(By.XPath("//*[@id='app']/header/aside/ul/li[8]/ul/li[1]/a")).Click();

        ////Locating the element via img tag for the profile picture and storing it in the webelement
        //IWebElement image = driver.FindElement(By.TagName("img"));

        ////Printing text of Image alt attribute which is sadhvi
        //Console.WriteLine(image.GetAttribute("alt"));*/

        //  }
        [TestMethod]
        public void TextBoxInteractions()
        {


            driver.Navigate().GoToUrl("http://www.calculator.net/percent-calculator.html");
            driver.Manage().Window.Maximize();

            IWebElement el = driver.FindElement(By.Id("cpar1"));
            el.SendKeys("10");

            string result = driver.FindElement(By.Id("cpar1")).GetAttribute("value");
            // Get the text box from the application
            //String result = driver.findElement(By.id("cpar1")).getAttribute("value");
            // Print a Log In message to the screen
            Console.WriteLine(" The Result is " + result);
            // Close the Browser
            //driver.close();

        }
        [TestMethod]
        public void RadioButtonInteractions()
        {
            driver.Navigate().GoToUrl("http://www.calculator.net/mortgage-payoff-calculator.html");

            driver.Manage().Window.Maximize();

            //click on Radio Button

            //Console.WriteLine("The output of IsSelected" + driver.FindElement(By.Id("cpayoff1")).Selected);
            driver.FindElement(By.XPath("(//span[@class='rbmark'])[1]")).Click();
            //Console.WriteLine("The output of IsEnabled" + driver.FindElement(By.Id("cpayoff1")).Enabled);
            //Console.WriteLine("The output of IsDisplayed" + driver.FindElement(By.Id("cpayoff1")).Displayed);
            Console.WriteLine("The output of IsSelected" + driver.FindElement(By.XPath("(//span[@class='rbmark'])[1]")).Selected);
            Console.WriteLine("The output of IsEnabled" + driver.FindElement(By.XPath("(//span[@class='rbmark'])[1]")).Enabled);
            Console.WriteLine("The output of IsDisplayed" + driver.FindElement(By.XPath("(//span[@class='rbmark'])[1]")).Displayed);
            driver.Close();
        }

        [TestMethod]
        public void RadioButtonAndCheckBox()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/radio.html");
            driver.Manage().Window.Maximize();

            IWebElement radio1 = driver.FindElement(By.Id("vfb-7-1"));
            IWebElement radio2 = driver.FindElement(By.Id("vfb-7-2"));

            //Radio Button1 is selected		
            radio1.Click();
            Console.WriteLine("Radio Button Option 1 Selected");

            //Radio Button1 is de-selected and Radio Button2 is selected		
            radio2.Click();
            Console.WriteLine("Radio Button Option 2 Selected");

            // Selecting CheckBox		
            IWebElement option1 = driver.FindElement(By.Id("vfb-6-0"));

            // This will Toggle the Check box 		
            option1.Click();

            // Check whether the Check box is toggled on 		
            if (option1.Selected)
            {
                Console.WriteLine("Checkbox is Toggled On");

            }
            else
            {
                Console.WriteLine("Checkbox is Toggled Off");
            }



            ////Selecting Checkbox and using isSelected Method		
            //driver.Navigate().GoToUrl("http://demo.guru99.com/test/facebook.html");
            //IWebElement chkFBPersist = driver.FindElement(By.Id("persist_box"));
            //for (int i = 0; i < 2; i++)
            //{
            //    chkFBPersist.Click();
            //   Console.WriteLine("Facebook Persists Checkbox Status is -  " + chkFBPersist.Selected);
            //}
            driver.Close();
        }

        [TestMethod]
        public void CheckBoxInteractions()
        {
            //Launch website
            driver.Navigate().GoToUrl("http://www.calculator.net/mortgage-calculator.html");
            driver.Manage().Window.Maximize();


            //Click on check Box
            driver.FindElement(By.Id("caddoptional")).Click();

            Console.WriteLine("The Output of the IsSelected " +
               driver.FindElement(By.Id("caddoptional")).Selected);
            Console.WriteLine("The Output of the IsEnabled " +
               driver.FindElement(By.Id("caddoptional")).Enabled);
            Console.WriteLine("The Output of the IsDisplayed " +
               driver.FindElement(By.Id("caddoptional")).Displayed);

            driver.Close();
        }

        [TestMethod]
        public void DragAndDropInteractions()
        {
            // Launch website
            driver.Navigate().GoToUrl("http://www.keenthemes.com/preview/metronic/templates/admin/ui_tree.html");
            driver.Manage().Window.Maximize();


            //IWebElement From = driver.FindElement(By.XPath(".//*[@id='j3_7']/a")); //
            //IWebElement To = driver.FindElement(By.XPath(".//*[@id='j3_1']/a"));

            IWebElement From = driver.FindElement(By.XPath("//a[@id='j3_5_anchor']"));
            IWebElement To = driver.FindElement(By.XPath("//a[@id='j3_2_anchor']"));

            //IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            //js1.ExecuteScript("arguments[0].scrollIntoView();", From);
            //Thread.Sleep(3000);

            Actions builder1 = new Actions(driver);
            IAction dragAndDrop1 = builder1.ClickAndHold(From).MoveToElement(To).Release(To).Build();

            //builder.clickAndHold(from).moveToElement(to).release(to).build().perform();

            Thread.Sleep(3000);
            dragAndDrop1.Perform();

            //driver.Close();
        }

        [TestMethod]
        public void FindElementsTest()
        {

            driver.Navigate().GoToUrl("http://www.calculator.net");
            driver.Manage().Window.Maximize();

            IList<IWebElement> links = driver.FindElements(By.TagName("a"));
            Console.WriteLine("No of Count is:" + links.Count);



            for (int i = 0; i < links.Count; i++) // Loop through List with for
            {
                Console.WriteLine(links[i].Text);
            }


            // ReadOnlyCollection<IWebElement> listItems = driver.FindElements(By.TagName("li"));

            //int i = 0;
            //foreach (IWebElement e in links)
            //{
            //    links[i] = e;

            //    Console.WriteLine("Links in the website:" + links[i]);

            //    i++;
            //    //System.out.println("WebElements:"+e);

            //}
        }

        [TestMethod]
        public void MouseEvent()
        {
            string baseUrl = "http://demo.guru99.com/test/newtours/";
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();

            IWebElement link_home = driver.FindElement(By.LinkText("Home"));
            //link_home.click();

            IWebElement td_Home = driver
                    .FindElement(By.XPath("//html/body/div" + "/table/tbody/tr/td" + "/table/tbody/tr/td"
                    + "/table/tbody/tr/td" + "/table/tbody/tr"));

            Actions builder = new Actions(driver);
            IAction action = builder.MoveToElement(link_home).Build();
            action.Perform();
        }

        [TestMethod]
        public void TestMouseEvent()
        {
            string baseUrl = "http://demoqa.com/menu/ ";
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();

            IWebElement el = driver.FindElement(By.XPath("//a[@title='Home']"));

            Actions builder = new Actions(driver);

            IAction mouseover = builder.MoveToElement(el).Build();

            builder.Perform();
        }



        [TestMethod]
        public void TestMouseEventTwo()
        {
            driver.Navigate().GoToUrl("https://www.edureka.co/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.Id("header_topcat"))).Build().Perform();
            Thread.Sleep(3000);

            IWebElement link = driver.FindElement(By.CssSelector("#software-testing-certification-courses"));
            builder.MoveToElement(link).Build().Perform();
            Thread.Sleep(2000);


            driver.FindElement(By.XPath("//ul[@class='dropdown-menu']//li//a[text()='Software Testing']")).Click();
            Thread.Sleep(4000);


            //IWebElement act = driver.FindElement(By.Id("search-inp3"));
            //builder.MoveToElement(act).Build().Perform();
            //Thread.Sleep(3000);


            //IWebElement search = driver.FindElement(By.XPath("//span[@class='typeahead__button']"));
            //builder.MoveToElement(search).Build().Perform();
            //Thread.Sleep(3000);
            //IAction seriesOfActions;
            //seriesOfActions = builder
            //.SendKeys(act, "Selenium")
            //.KeyDown(search, Keys.Shift)
            //.KeyUp(search, Keys.Shift)
            //.Build();
            //seriesOfActions.Perform();


            Thread.Sleep(3000);
            driver.Quit();
        }

        [TestMethod]
        public void TestKeyboardEvent()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/newtours/ ");
            driver.Manage().Window.Maximize();

            IWebElement clearEle = driver.FindElement(By.Name("userName"));
            clearEle.SendKeys("testuser");
            Thread.Sleep(3000);

            IWebElement toClear = driver.FindElement(By.Name("userName"));
            toClear.SendKeys(Keys.Control + "a");
            toClear.SendKeys(Keys.Delete);

            //clearEle.Clear();
            Thread.Sleep(3000);
            driver.FindElement(By.Name("userName")).SendKeys("TestUser2");
            Thread.Sleep(3000);
            //driver.Close();
        }
        [TestMethod]
        public void TestKeyboardEventTwo()
        {

            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.Manage().Window.Maximize();

            IWebElement search = driver.FindElement(By.Name("q"));

            Actions make = new Actions(driver);

            IAction kbEvents = make.KeyDown(search, Keys.Shift).SendKeys("TestHouse")

                                .KeyUp(search, Keys.Shift).ContextClick().Build();

            kbEvents.Perform();

            Thread.Sleep(3000);

            //driver.Close();
        }
        [TestMethod]
        public void TestKeyboardEventThree()
        {
            string baseUrl = "http://www.facebook.com/";


            driver.Navigate().GoToUrl(baseUrl);
            IWebElement txtUsername = driver.FindElement(By.Id("email"));

            Actions builder = new Actions(driver);
            IAction seriesOfActions = builder
                .MoveToElement(txtUsername)
                .Click()
                .KeyDown(txtUsername, Keys.Shift)
                .SendKeys(txtUsername, "hello")
                .KeyUp(txtUsername, Keys.Shift)
                .DoubleClick(txtUsername)
                .ContextClick()
                .Build();

            seriesOfActions.Perform();
        }

        [TestMethod]
        public void FrameDemoOneTest()
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");

            driver.Manage().Window.Maximize();

            //int size = driver.FindElements(By.TagName("iframe")).Count;

            //Console.WriteLine("No. of Frames: " + size);

            IList<IWebElement> links = driver.FindElements(By.TagName("iframe"));

            Console.WriteLine("No of Frame is:" + links.Count);



            //for (int i = 0; i < links.Count; i++) // Loop through List with for
            //{
            //    Console.WriteLine(links[i].Text);
            //}
            //driver.SwitchTo().Frame(0);
            driver.SwitchTo().Frame("a077aa5e");


            driver.FindElement(By.XPath("html/body/a/img")).Click();
            Thread.Sleep(3000);

            driver.SwitchTo().DefaultContent();
            Thread.Sleep(3000);

            //string frame1 = driver.Title;
            //Console.WriteLine(frame1);

            //Thread.Sleep(3000);

            //driver.SwitchTo().DefaultContent();
            //Thread.Sleep(3000);

            //string home = driver.Title;
            //Console.WriteLine(home);

            //driver.Close();
        }

        [TestMethod]
        public void FrameDemoTwoTest()
        {

            driver.Navigate().GoToUrl("http://www.londonfreelance.org/courses/frames/index.html");
            driver.Manage().Window.Maximize();



            //Navigate to URL


            //Switch to main frame with its index (top.html)
            //top.html is in 3rd frame so its index is 2
            driver.SwitchTo().Frame(2);

            //Check the H2 tag's text is "Title bar (top.html)
            // IWebElement h2Tag = driver.FindElement(By.XPath("//h2[text()='Title bar ']"));
        }
        [TestMethod]
        public void FrameTestThree()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");
            driver.Manage().Window.Maximize();
            //driver.manage().timeouts().implicitlyWait(100, TimeUnit.SECONDS);
            int size = driver.FindElements(By.TagName("iframe")).Count;
            Console.WriteLine("Count is: " + size);

            for (int i = 0; i <= size; i++)
            {
                driver.SwitchTo().Frame(i);
                int total = driver.FindElements(By.XPath("html/body/a/img")).Count;
                Console.WriteLine(total);
                driver.SwitchTo().DefaultContent();
            }
        }

        [TestMethod]
        public void FrameTestFour()
        {
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");
            driver.Manage().Window.Maximize();

            int size = driver.FindElements(By.TagName("iframe")).Count;

            for (int i = 0; i <= size; i++)
            {
                driver.SwitchTo().Frame(i);
                int total = driver.FindElements(By.XPath("html/body/a/img")).Count;
                Console.WriteLine(total);
                driver.SwitchTo().DefaultContent(); //switching back from the iframe
            }

            //Commented the code for finding the index of the element
            driver.SwitchTo().Frame(0); //Switching to the frame
            Console.WriteLine("********We are switched to the iframe*******");
            driver.FindElement(By.XPath("html/body/a/img")).Click();

            //Clicking the element in line with Advertisement
            Console.WriteLine("*********We are done***************");
        }




        [TestMethod]
        public void ImageClickTest()
        {
            string baseUrl = "https://www.facebook.com/login/identify?ctx=recover";

            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            //click on the "Facebook" logo on the upper left portion		
            driver.FindElement(By.XPath("//a[@title='Go to Facebook home']")).Click();
            Thread.Sleep(5000);
            string title = driver.Title;
            Console.WriteLine(title);
            //verify that we are now back on Facebook's homepage		
            if (driver.Title.Equals("Facebook – log in or sign up"))
            {
                Console.WriteLine("We are back at Facebook's homepage");
            }
            else
            {
                Console.WriteLine("We are NOT in Facebook's homepage");
            }
            driver.Close();
        }
        [TestMethod]
        public void AlertTest()
        {

            driver.Navigate().GoToUrl("http://demo.guru99.com/test/delete_customer.php");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.Name("cusid")).SendKeys("53920");

            driver.FindElement(By.Name("submit")).Click();

            Thread.Sleep(3000);

            IAlert alert = driver.SwitchTo().Alert();

            string alertmsg = driver.SwitchTo().Alert().Text;

            Console.WriteLine(alertmsg);

            alert.Accept();



            //Thread.sleep(3000);



            //alert.Dismiss();

            driver.Close();
        }

        [TestMethod]
        public void DoubleClickTest()
        {
            driver.Navigate().GoToUrl("http://only-testing-blog.blogspot.in/2014/09/selectable.html");
            driver.Manage().Window.Maximize();

            IWebElement ele = driver.FindElement(By.XPath("//button[contains(.,'Double-Click Me To See Alert')]"));

            //To generate double click action on "Double-Click Me To See Alert" button.
            Actions action = new Actions(driver);
            action.DoubleClick(ele);
            action.Perform();

            Thread.Sleep(3000);
            string alert_message = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            Console.WriteLine(alert_message);
        }

        [TestMethod]
        public void ImplicityWaitTest()
        {
            string test_url = "https://www.easemytrip.com";
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = test_url;

            IWebElement from_sector = driver.FindElement(By.Id("FromSector_show"));
            from_sector.Click();
            /* from_sector.FindElement(By.XPath("//*[@id='spn2']")).Click(); */
            from_sector.FindElement(By.XPath("/html/body/form/div[10]/div/div[3]/div[1]/div[1]/div[1]/div[1]/div/div[2]/div/ul/li[1]")).Click();

            IWebElement to_sector = driver.FindElement(By.Id("Editbox13_show"));
            to_sector.Click();
            to_sector.FindElement(By.XPath("/html/body/form/div[10]/div/div[3]/div[1]/div[2]/div[1]/div/div/div/div/ul/li[2]")).Click();

            IWebElement ddate = driver.FindElement(By.Id("ddate"));
            ddate.Click();

            /* IWebElement snd_date = driver.FindElement(By.Id("snd_4_12/03/2020")); */
            IWebElement snd_date = driver.FindElement(By.Id("trd_3_18/03/2020"));
            snd_date.Click();

            IWebElement src_btn = driver.FindElement(By.ClassName("src_btn"));
            src_btn.Click();

            IWebElement booknow_btn = driver.FindElement(By.XPath("//button[text()='Book Now']"));
            booknow_btn.Click();

            /* Next Steps for booking tickets */
            IWebElement insurance_checkbox = driver.FindElement(By.XPath("//div[@id='divInsuranceTab']//div[@class='insur-no']//span[@class='checkmark-radio']"));
            /* Click on NO INSURANCE */
            insurance_checkbox.Click();

            IWebElement email_entry = driver.FindElement(By.Name("txtEmailId"));
            email_entry.SendKeys("testing@gmail.com");

            driver.FindElement(By.XPath("//span[text()='Continue Booking']")).Click();

            IWebElement title = driver.FindElement(By.Id("titleAdult0"));
            SelectElement titleTraveller = new SelectElement(title);

            titleTraveller.SelectByText("MR");
            driver.FindElement(By.XPath("//input[@placeholder='Enter First Name']")).SendKeys("Joe");
            driver.FindElement(By.XPath("//input[@placeholder='Enter Last Name']")).SendKeys("Sheth");
            driver.FindElement(By.XPath("//input[@placeholder='Mobile Number']")).SendKeys("9031111111");
            driver.FindElement(By.XPath("//div[@class='con1']/span[@class='co1']")).Click();

        }
        [TestMethod]
        public void ImplicitWaitTest()
        {

            // launch Chrome and redirect it to the Base URL
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");

            //Maximizes the browser window
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            string eTitle = "Demo Guru99 Page";
            string aTitle = "";

            //get the actual value of the title
            aTitle = driver.Title;
            //compare the actual title with the expected title
            if (aTitle.Equals(eTitle))
            {
                Console.WriteLine("Test Passed");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }
            //close browser
            driver.Close();
        }
        [TestMethod]
        public void ExplicitWaitTest()
        {
            // Start application
            driver.Navigate().GoToUrl("http://seleniumpractise.blogspot.in/2016/08/how-to-use-explicit-wait-in-selenium.html");
            driver.Manage().Window.Maximize();

            // Click on timer button to start
            driver.FindElement(By.XPath("//button[text()='Click me to start timer']")).Click();

            // Create object of WebDriverWait class and it will wait max of 20 seconds.
            // By default it will accepts in Seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            // Here we will wait until element is not visible, if element is visible then it will return web element
            // or else it will throw exception
            //IWebElement element = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//p[text()='WebDriver']")));

            IList<IWebElement> element = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//p[text()='WebDriver']")));
            // if element found then we will use- In this example I just called isDisplayed method
            // wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//tbody[@role='rowgroup']//td")));
            bool status = element.IsReadOnly;

            // if else condition
            if (status)
            {
                Console.WriteLine("===== WebDriver is visible======");
            }
            else
            {
                Console.WriteLine("===== WebDriver is not visible======");
            }
        }
        [TestMethod]
        public void ExplicitWaitTwoTest()
        {
            string test_url = "https://www.google.com/ncr";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(test_url);
            string target_xpath = "//a[text()='LambdaTest Login']";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = test_url;
            driver.FindElement(By.Name("q")).SendKeys("LambdaTest" + Keys.Enter);

            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementExists(By.XPath(target_xpath)));
            SearchResult.Click();



        }
        [TestMethod]
        public void FluentWaitTest()
        {
            string test_url = "https://www.google.com/ncr";
            driver.Navigate().GoToUrl(test_url);
            driver.Manage().Window.Maximize();
            string target_xpath = "//a[text()='LambdaTest Login']";

            /* Explicit Wait */
            /* WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); */

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";


            driver.FindElement(By.Name("q")).SendKeys("LambdaTest" + Keys.Enter);

            /* Explicit Wait */
            /* IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(target_xpath))); */
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(target_xpath)));
            searchResult.Click();

        }

        [TestMethod]
        public void ScrollTest() //scroll by pixel
        {


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Launch the application		
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //To maximize the window. This code may not work with Selenium 3 jars. If script fails you can remove the line below		
            driver.Manage().Window.Maximize();

            // This  will scroll down the page by  1000 pixel vertical		
            js.ExecuteScript("window.scrollBy(0,1000)");
        }
        [TestMethod]
        public void ScrollVisibleElementTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //Launch the application		
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //To maximize the window. This code may not work with Selenium 3 jars. If script fails you can remove the line below		
            driver.Manage().Window.Maximize();

            //Find element by link text and store in variable "Element"        		
            IWebElement Element = driver.FindElement(By.LinkText("Linux"));

            //This will scroll the page till the element is found		
            js.ExecuteScript("arguments[0].scrollIntoView();", Element);
        }

        [TestMethod]
        public void ScrollBottomPageTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //Launch the application		
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //To maximize the window. This code may not work with Selenium 3 jars. If script fails you can remove the line below		
            driver.Manage().Window.Maximize();

            //This will scroll the web page till end.		
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
        [TestMethod]
        public void ScrollHorizontalTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Launch the application		
            driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/scrolling.html");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //To maximize the window. This code may not work with Selenium 3 jars. If script fails you can remove the line below		
            driver.Manage().Window.Maximize();


            IWebElement Element = driver.FindElement(By.LinkText("VBScript"));

            //This will scroll the page Horizontally till the element is found		
            js.ExecuteScript("arguments[0].scrollIntoView();", Element);
        }

        [TestMethod]
        public void GetWindowHandlesTest()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Navigate().GoToUrl("http://demo.guru99.com/popup.php");

            driver.Manage().Window.Maximize();

            string ParentWindow = driver.CurrentWindowHandle;

            driver.FindElement(By.LinkText("Click Here")).Click();

            driver.FindElement(By.XPath("//input[@name='emailid']")).SendKeys("agn@gmal.com");

            driver.FindElement(By.XPath("//input[@name='btnLogin']")).Click();

            //string ExistingWindowHandle = driver.CurrentWindowHandle;

            //string popupHandle = string.Empty;

            //ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            foreach (string Childwindow in driver.WindowHandles)
            {
                if (Childwindow != ParentWindow)
                {
                    driver.SwitchTo().Window(Childwindow);
                    driver.FindElement(By.Name("emailid")).SendKeys("anto@gmail.com");


                    driver.FindElement(By.Name("btnLogin")).Click();

                    // Closing the Child Window.
                    driver.Close();
                }
            }


            driver.SwitchTo().Window(ParentWindow);
            driver.Close();


        }

        [TestMethod]
        public void WindowHandleTwo()
        {
            driver.Navigate().GoToUrl("https://www.naukri.com/");
            driver.Manage().Window.Maximize();
            // It will return the parent window name as a String
            String mainWindow = driver.CurrentWindowHandle;
            // It returns no. of windows opened by WebDriver and will return Set of Strings


            foreach (string Childwindow in driver.WindowHandles)
            {
                if (Childwindow != mainWindow)
                {
                    driver.SwitchTo().Window(Childwindow);
                    Console.WriteLine(driver.SwitchTo().Window(Childwindow).Title);
                    driver.Close();
                }
                // break;
            }
            // This is to switch to the main window
            driver.SwitchTo().Window(mainWindow);
        }
        [TestMethod]
        public void WindowHandleThree()
        {
            //https://javabeginnerstutorial.com/selenium/9y-webdriver-handling-multiple-windows/
            driver.Navigate().GoToUrl("https://chandanachaitanya.github.io/selenium-practice-site/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            // Get current window handle
            String parentWinHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent window handle: " + parentWinHandle);

            // Locate 'Click to open a new browser window!' button using id
            IWebElement newWindowBtn = driver.FindElement(By.Id("win1"));
            // Click the button to open a new window
            newWindowBtn.Click();
            Thread.Sleep(3000);

            //IWebElement ele = driver.FindElement(By.XPath("//input[@title='Search']"));
            //ele.SendKeys("TestHouse");
            //ele.Submit();

            // Get the window handles of all open windows
            ReadOnlyCollection<String> winHandles = driver.WindowHandles;
            // Loop through all handles
            foreach (string handle in winHandles)
            {
                if (!handle.Equals(parentWinHandle))
                {
                    driver.SwitchTo().Window(handle);
                    Thread.Sleep(1000);

                    IWebElement ele = driver.FindElement(By.XPath("//input[@title='Search']"));
                    ele.SendKeys("TestHouse");
                    ele.Submit();

                    Console.WriteLine("Title of the new window: " + driver.Title);
                    Console.WriteLine("Closing the new window...");
                    driver.Close();
                }
            }
            // Switching the control back to parent window
            driver.SwitchTo().Window(parentWinHandle);
            
            // Print the URL to the console
            Console.WriteLine("Parent window URL: " + driver.Url);

        }
        [TestMethod]
        public void UploadFileTest()
        {

            driver.Navigate().GoToUrl("http://demo.guru99.com/test/upload/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();

            IWebElement uploadElement = driver.FindElement(By.Id("uploadfile_0"));

            // enter the file path onto the file-selection input field
            uploadElement.SendKeys(@"D:\\Jio.txt");

            // check the "I accept the terms of service" check box
            driver.FindElement(By.Id("terms")).Click();

            // click the "UploadFile" button
            driver.FindElement(By.Name("send")).Click();
        }

        public void DownloadFileTest()
        {
            string baseUrl = "http://demo.guru99.com/test/yahoo.html";

            driver.Navigate().GoToUrl(baseUrl);
            IWebElement downloadButton = driver.FindElement(By.Id("messenger-download"));
            string sourceLocation = downloadButton.GetAttribute("href");
            string wget_command = "cmd /c C:\\Wget\\wget.exe -P D: --no-check-certificate " + sourceLocation;

            try
            {
                // Process exec = Runtime.getRuntime().exec(wget_command);


                // int exitVal = exec.WaitFor();

                // int exitVal = exec.WaitForExit();
                //Console.WriteLine("Exit value: " + exitVal);
            }
            catch {

            }
            driver.Close();
        }
    


  
        

        [TestMethod,TestCategory("Exam")]
        public void DatePickerTest()
        {
            //for (int i = 0; i < 30; i++)
            //{
            //    Element(driver, Control("CalendarIconUp", "CorporateCustomer")).Click();
            //}
            //Element(driver, Control("DateOfBirthSelector", "CorporateCustomer")).Click();

            //string OrderDate = DateTime.Now.AddDays(7).ToString("MM/dd/yyyy");
            //Console.WriteLine("date " + OrderDate);
            driver.Navigate().GoToUrl("https://www.flydubai.com/en/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //To maximize the window. This code may not work with Selenium 3 jars. If script fails you can remove the line below		
            driver.Manage().Window.Maximize();
            for (int i = 0; i < 30; i++)
            {
                // Element(driver, Control("CalendarIconUp", "CorporateCustomer")).Click();
                driver.FindElement(By.XPath("//img[@alt='Calendar']")).Click();
            }
            driver.FindElement(By.XPath("(//div[text()='21'])[1]")).Click();
            driver.FindElement(By.XPath("//button[@class='lightpick__close-action closeCalendar']")).Click();
            //driver.FindElement(By.XPath("//img[@alt='Calendar']")).SendKeys(OrderDate);
            //  IWebElement toClear = driver.FindElement(By.XPath("//input[@name='bdaytime']"));

            //toClear.SendKeys(Keys.Control + "a");
            //toClear.SendKeys(Keys.Delete);



        }

        [TestMethod]
        public void TestMethod1()
        {
            HomeController home = new HomeController();
            string result = home.GetEmployeeName(1);
            Assert.AreEqual(result, "Arul");
        }
        [TestMethod]
        public void TestFullName()
        {
            HomeController home = new HomeController();
            string first = "Ag";
            string last = "Ray";
            string expected = "Ag Ray";
            string actual = home.GetName(first,last);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScreenShotRemoteBrowserTest()
        {
               
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(@"D:\\sele\\ss.png",ScreenshotImageFormat.Png);
           

        }
        [TestMethod]
        public void ExtentTestCase()
        {
            var htmlReporter = new ExtentHtmlReporter("extentReport.html");
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            //Hard coding
            extent.AddSystemInfo("Operating System:", "Windows 10");
            extent.AddSystemInfo("HostName: ", "Antony Rayan");
            extent.AddSystemInfo("Browser: ", "Google Chrome");

            var test = extent.CreateTest("ExtentTestCase");
            test.Log(Status.Info, "Step 1: Test case starts.");
            test.Log(Status.Pass, "Step 2: Test case for pass");
            test.Log(Status.Fail,"Step 3: Test case failed");
            test.Pass("Screenshot",MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
            test.Pass("Screenshot").AddScreenCaptureFromPath("screenshot.png");
            extent.Flush();


        }

        public void TakeScreeshotTest()
        {
            try
            {
                driver.Navigate().GoToUrl("https://twitter.com/");
                driver.Manage().Window.Maximize();
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(DateTime.Now.ToShortDateString() + ".png", ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }


    }



}
    


