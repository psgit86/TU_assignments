// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using UIAssignment1.BaseClass;


namespace UIAssignment1
{
    [TestFixture]
    public class TestClass : BaseTest
    {
        [Test]
        public void TestMethod() 
        {
            String loginID;
            Random random = new Random();
            int value = random.Next(10000);
            String randomNum = value.ToString();
            Console.WriteLine(value);
            loginID = "Pallavi" + randomNum;
            
            IWebElement newUsersignupButton= driver.FindElement(By.XPath("//a[@id='signin2']"));
            newUsersignupButton.Click();
            Thread.Sleep(5000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            //IWebElement modalContainer = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("modal-dialog")));
            IWebElement modalContainer = driver.FindElement(By.ClassName("modal-dialog"));

            IWebElement usernameTextField = modalContainer.FindElement(By.XPath("//input[@id='sign-username']"));
            usernameTextField.SendKeys("Pallavi"+ randomNum);
            IWebElement passwordTextField = modalContainer.FindElement(By.XPath("//input[@id='sign-password']"));
            passwordTextField.SendKeys("1234");
            IWebElement signupButton = modalContainer.FindElement(By.XPath("//button[text()='Sign up']"));
            signupButton.Click();
            Thread.Sleep(4000);
            IAlert simpleAlert = driver.SwitchTo().Alert();
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is :" + alertText);
            Assert.That(alertText,
                        Is.EqualTo("Sign up successful."));
            simpleAlert.Accept();
            Thread.Sleep(2000);


            IWebElement loginButton = driver.FindElement(By.XPath("//a[@id='login2']"));
            loginButton.Click();
            Thread.Sleep(5000);
            IWebElement loginmodalContainer = driver.FindElement(By.ClassName("modal-dialog"));
            IWebElement loginusernameTextField = loginmodalContainer.FindElement(By.XPath("//input[@id='loginusername']"));
            loginusernameTextField.SendKeys(loginID);
            IWebElement loginpasswordTextField = loginmodalContainer.FindElement(By.XPath("//input[@id='loginpassword']"));
            loginpasswordTextField.SendKeys("1234");
            IWebElement modalloginButton = loginmodalContainer.FindElement(By.XPath("//button[text()='Log in']"));
            modalloginButton.Click();
            Thread.Sleep(4000);
            String welcomeText = driver.FindElement(By.Id("nameofuser")).Text;
            Console.WriteLine(welcomeText);
            String expectedWelcomeText = "Welcome " + loginID;
            Assert.That(welcomeText,
                        Is.EqualTo(expectedWelcomeText));
            Thread.Sleep(2000);

        }
    }
}
