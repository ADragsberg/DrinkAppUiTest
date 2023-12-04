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
    public class UserStory2Test
    {
        private static readonly string _driverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;
        // Url skal linke direkte til get list.
        private static string _localUrl = "http://127.0.0.1:5501/DrinkList.html";
        private static string _onlineUrl = "";
        bool useLocal = true;

        [ClassInitialize]
        public static void Setup(TestContext context) // Nok vigtigt at den er static, har TestContext som parameter.
        {
            _driver = new ChromeDriver(_driverDirectory);
            //_driver = new FirefoxDriver(_driverDirectory);
            //_driver = new EdgeDriver(_driverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestSearchNavn()
        {
            string url = useLocal ? _localUrl : _onlineUrl;
            _driver.Navigate().GoToUrl(url);

            WebDriverWait wdWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement ventPåListe = wdWait.Until(ventPåListe => ventPåListe.FindElement(By.TagName("li")));

            ReadOnlyCollection<IWebElement> drinksListe = _driver.FindElements(By.ClassName("drinkNavn"));
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

            IWebElement search = _driver.FindElement(By.Id("searchBarNavn"));
            search.SendKeys("abc");
            search.SendKeys(Keys.Enter);

            Thread.Sleep(1000);

            ReadOnlyCollection<IWebElement> drinksListeABC = _driver.FindElements(By.ClassName("drinkNavn"));
            Assert.AreEqual(1, drinksListeABC.Count);

            search.Clear();

            
            search.SendKeys("50");
            search.SendKeys(Keys.Enter);

            Thread.Sleep(1000);

            ReadOnlyCollection<IWebElement> drinksListe50 = _driver.FindElements(By.ClassName("drinkNavn"));
            Assert.AreEqual(3, drinksListe50.Count);

        }

        [TestMethod]
        public void SøgEfterIngredientsTest1()
        {

            string url = useLocal ? _localUrl : _onlineUrl;
            _driver.Navigate().GoToUrl(url);

            WebDriverWait wdWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement ventPåListe = wdWait.Until(ventPåListe => ventPåListe.FindElement(By.TagName("li")));

            ReadOnlyCollection<IWebElement> drinksListe = _driver.FindElements(By.ClassName("Indregient1"));
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

            IWebElement search = _driver.FindElement(By.Id("searchBarIngredient"));
            search.SendKeys("gin");
            search.SendKeys(Keys.Enter);

            Thread.Sleep(1000);

            ReadOnlyCollection<IWebElement> drinksListeIndregient1 = _driver.FindElements(By.ClassName("Indregient1"));
            Assert.AreEqual(1 , drinksListeIndregient1.Count);




        }

    }
}
