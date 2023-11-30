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
        private static string _localUrl = "http://127.0.0.1:5500/DrinkList.html";
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
        
        [TestMethod]
        public void TestAlkoholFilterJa()
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
            
            IWebElement filterMenu = _driver.FindElement(By.Id("dropdownMenuButton"));
            filterMenu.Click();
            
            IWebElement filterAlcoholic = _driver.FindElement(By.Id("filterAlcoholic"));
            filterAlcoholic.Click();
            
            ReadOnlyCollection<IWebElement> drinksListe2 = _driver.FindElements(By.ClassName("AlkoholJaNej"));
            Assert.AreEqual(23, drinksListe2.Count);

            List<string> listeKopi2 = new List<string>();
            foreach (var drink in drinksListe2)
            {
                listeKopi2.Add(drink.Text);
            }
            for (int i = 0; i < listeKopi2.Count; i++)
            {
                Assert.IsTrue(listeKopi2[i].Length > 0);
            }
            Assert.AreEqual(23, listeKopi2.Count);
            
        }
        
        
        
        
        
        //Lad den være som den er til linje 83. du skal stadig finde alle elementer i listen nemlig 
        //Linje 96 skal du ændre det til at finde Dropdown menuen. så den hedder filterMenu 
        //også skal den klikke. 
        //derefter skal du lave endnu en findelement med id filterAlcoholic
        //og igen klikke på den.
        //Derefter skriv noglelunde samme fra 100 til 113 
        // alt dette tager udgangspunkt i Branch us4 og klasse us1test


    }
}
