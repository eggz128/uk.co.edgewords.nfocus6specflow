﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static uk.co.edgewords.nfocus6specflow.Support.StaticHelperLib;


namespace uk.co.edgewords.nfocus6specflow.Support.POMClasses
{
    internal class LoginPagePOM
    {
        private IWebDriver _driver; //Field that will hold a driver for service methods in this test to work with

        public LoginPagePOM(IWebDriver driver) //Constructor to get the driver from the test
        {
            _driver = driver; //Assigns passed driver in to private field in this class
            //Generally no assertions in the POM classes - checking you are on the right page when you instantiate the class is an allowable exception to that rule
            Assert.That(_driver.FindElement(By.TagName("h1")).Text,
                Does.Contain("Access and Authentication"),
                "Must be wrong page");
            //Assert.That(_driver.Url, Is.EqualTo("whatever"));
            //Assert.That(_driver.Title, Is.EqualTo("Page title"));
            //You could also choose to wait for something on the page that signals most/all elements are ready
        }

        //Locators
        //private IWebElement usernameField => _driver.FindElement(By.Id("username")); //But what if we need to wait for this element?...
        private IWebElement _usernameField => new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(drv => drv.FindElement(By.Id("username")));

        //private IWebElement _passwordField => _driver.FindElement(By.Id("password")); //Waiting for this element using the previously defined static helper method
        private IWebElement _passwordField
        {
            get
            {
                StaticWaitForElement(_driver, By.Id("password"), 1); //As this method does not return the found webelement it is necessary to...
                return _driver.FindElement(By.Id("password")); //...refind it for the return.
            }
        }

        private IWebElement _submitFormButton => _driver.FindElement(By.LinkText("Submit"));


        //Service methods
        public LoginPagePOM setUsername(string username)
        {
            _usernameField.Clear();
            _usernameField.SendKeys(username);
            return this;
        }

        public LoginPagePOM setPassword(string password)
        {
            _passwordField.Clear();
            _passwordField.SendKeys(password);
            return this;
        }

        public void submitForm()
        {
            _submitFormButton.Click();
        }

        //setUsername() and setPassword() is a very "Java"ish way of doing this. Can we achieve this with C# getter and setters?
        public string Username
        {
            get { return _usernameField.GetAttribute("value"); }
            set
            {
                _usernameField.Clear();
                _usernameField.SendKeys(value);
            }
        }

        //Higher level helpers
        public bool LoginExpectSuccess(string username, string password)
        {
            //setUsername(username); //"Java"ish method
            Username = username; //C#ish property setting
            setPassword(password);
            submitForm();

            //If alert is present login must have failed
            try
            {
                _driver.SwitchTo().Alert();
                return false; //Failed log
            }
            catch (NoAlertPresentException e)
            {
                return true; //Login success
            }

        }

        //For negative tests supply an alternative implimentation of Login
        public bool LoginExpectFail(string username, string password)
        {
            //setUsername(username); //"Java"ish method
            Username = username; //C#ish property setting
            setPassword(password);
            submitForm();

            //If alert is present login must have failed - as expected for this method
            try
            {
                _driver.SwitchTo().Alert();
                return true; //Failed log
            }
            catch (NoAlertPresentException e)
            {
                return false; //Login success
            }

        }
    }
}
