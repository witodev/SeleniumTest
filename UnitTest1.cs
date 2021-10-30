using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumTest
{
    public class HomepageFeature
    {
        IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            var OutPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(OutPutDirectory);
        }

        [Test]
        public void TSchouldBeAbleToLogIn()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var loginButtonLocator = By.Id("login-button");
            wait.Until(ExpectedConditions.ElementIsVisible(loginButtonLocator));

            var userNameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(loginButtonLocator);

            userNameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();

            Assert.IsTrue(_driver.Url.Contains("inventory.html"));
        }
        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }


    }
}