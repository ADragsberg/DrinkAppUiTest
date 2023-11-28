using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Edge;

namespace DrinkAppUiTest
{
    [TestClass]
    public class UserStory3Test
    {
        private static readonly string DriverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;
        private const string _url = "TODO";

        [ClassInitialize]
        public static void Setup(TestContext context) // Nok vigtigt at den er static, har TestContext som parameter.
        {
            // _driver = new ChromeDriver(DriverDirectory);
            //_driver = new FirefoxDriver(DriverDirectory);
            _driver = new EdgeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestDrinkName()
        {
            //string url = useLocal ? _localUrl : _onlineUrl;

            _driver.Navigate().GoToUrl(_url);

            string nameToBeExpected = "Mojito";
            string nameXpath = $"//*[text()[contains(.,'{nameToBeExpected}')]]";

            // Find the elements
            IWebElement element = _driver.FindElement(By.XPath(nameXpath));

            // Assert
            Assert.AreEqual(nameToBeExpected, element.Text);
        }

        [TestMethod]
        public void TestIngredientName()
        {
            //string url = useLocal ? _localUrl : _onlineUrl;

            _driver.Navigate().GoToUrl(_url);

            string nameToBeExpected = "Lime";
            string nameXpath = $"//*[text()[contains(.,'{nameToBeExpected}')]]";

            // Find the elements
            IWebElement element = _driver.FindElement(By.XPath(nameXpath));

            // Assert
            Assert.AreEqual(nameToBeExpected, element.Text);
        }

        [TestMethod]
        public void TestIngredientListExists()
        {
            //string url = useLocal ? _localUrl : _onlineUrl;

            _driver.Navigate().GoToUrl(_url);

            string idOfListToBeExpected = "Ingredientlist";

            Assert.ThrowsException<NoSuchElementException>(() => _driver.FindElement(By.Id(idOfListToBeExpected)));
        }
    }
}
