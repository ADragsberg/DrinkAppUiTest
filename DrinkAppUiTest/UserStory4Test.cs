using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Edge;
using System.Collections.ObjectModel;

namespace DrinkAppUiTest
{
    [TestClass]
    public class UserStory4Test
    {
        private static readonly string DriverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;
        private static string _localUrl = "http://127.0.0.1:5501/DrinkList.html";
        private static string _onlineUrl = "";
        bool useLocal = true;


        [ClassInitialize]
        public static void Setup(TestContext context) // Nok vigtigt at den er static, har TestContext som parameter.
        {
            _driver = new ChromeDriver(DriverDirectory);
            //_driver = new FirefoxDriver(DriverDirectory);
            //_driver = new EdgeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestAlkohol()
        {
            string url = useLocal ? _localUrl : _onlineUrl;
            
            _driver.Navigate().GoToUrl(url);

            WebDriverWait wdWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            
            IWebElement ventPåListe = wdWait.Until(ventPåListe => ventPåListe.FindElement(By.TagName("li")));

            ReadOnlyCollection<IWebElement> drinksListe = _driver.FindElements(By.ClassName("AlkoholJaNej"));
            Assert.AreEqual(25, drinksListe.Count);

            List<string> listeKopi = new List<string>();
            foreach (var drink in drinksListe)
            {
                listeKopi.Add(drink.Text);
            }
            for (int i = 0; i < listeKopi.Count; i++)
            {
                Assert.IsTrue(listeKopi[i].Length > 0);
            }
            Assert.AreEqual(25, listeKopi.Count);
        }

    }
}
