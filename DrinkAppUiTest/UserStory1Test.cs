using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace DrinkAppUiTest
{
    [TestClass]
    public class UserStory1Test
    {
        private static readonly string _driverDirectory = "C:\\webdrivers";
        private static IWebDriver _driver;
        // Url skal linke direkte til get list.
        private static string _localUrl = "http://127.0.0.1:5500/DrinkList.html";
        private static string _onlineUrl = "";
        bool useLocal = true;
        [ClassInitialize]
        // 
        public static void Setup(TestContext context)
        {
            _driver = new FirefoxDriver(_driverDirectory);
            //_driver = new ChromeDriver(_driverDirectory);
            //_driver = new EdgeDriver(_driverDirectory);
        }
        [ClassCleanup]
        // 
        public static void Cleanup()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestListenErSorteret()
        {
            string url = useLocal ? _localUrl : _onlineUrl;

            _driver.Navigate().GoToUrl(url);

            //Hent Listen
            WebDriverWait wdWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement ventPÂListe = wdWait.Until(ventPÂListe => ventPÂListe.FindElement(By.TagName("li")));

            IReadOnlyList<IWebElement> drinksListe = _driver.FindElements(By.ClassName("drinkNavn"));
            
            
            //lav kopi af listen

            Assert.AreEqual(25, drinksListe.Count);
            List<string> listeKopi1 = new List<string>();
            foreach (var drink in drinksListe)
            {
                listeKopi1.Add(drink.Text);
            }
            Assert.AreEqual(25, listeKopi1.Count);

            List<string> listeKopi2 = new List<string>(listeKopi1);
            Assert.AreEqual(25, listeKopi2.Count);


            //sorter kopien

            listeKopi2.Sort();

            //Kontroller sorteringen er ens.
            Assert.AreEqual(listeKopi2[0], listeKopi1[0]);
            Assert.AreEqual(listeKopi2[13], listeKopi1[13]);
            Assert.AreEqual(listeKopi2[24], listeKopi1[24]);


        }
        [TestMethod]
        public void TestListeSorteringKan∆ndres() 
        {
            string url = useLocal ? _localUrl : _onlineUrl;

            _driver.Navigate().GoToUrl(url);

            //Hent Listen
            WebDriverWait wdWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement ventPÂListe = wdWait.Until(ventPÂListe => ventPÂListe.FindElement(By.TagName("li")));

            IReadOnlyList<IWebElement> drinksListe = _driver.FindElements(By.ClassName("drinkNavn"));

            //lav kopi af listen

            Assert.AreEqual(25, drinksListe.Count);
            List<string> listeKopi1 = new List<string>();
            foreach (var drink in drinksListe)
            {
                listeKopi1.Add(drink.Text);
            }
            Assert.AreEqual(25, listeKopi1.Count);

            //∆ndre sortering pÂ siden
            IWebElement ÊndreSorteringKnap = _driver.FindElement(By.Id("sortByDsc"));
            ÊndreSorteringKnap.Click();

            //Lav ny liste.
            IReadOnlyList<IWebElement> drinksListe2 = _driver.FindElements(By.ClassName("drinkNavn"));
                        
            Assert.AreEqual(25, drinksListe2.Count);
            List<string> listeKopi2 = new List<string>();
            foreach (var drink in drinksListe2)
            {
                listeKopi2.Add(drink.Text);
            }
            Assert.AreEqual(25, listeKopi2.Count);

            //Sammenlign lister
            Assert.AreNotEqual(listeKopi1[0], listeKopi2[0]);
            Assert.AreNotEqual(listeKopi1[13], listeKopi2[13]);
            Assert.AreNotEqual(listeKopi1[24], listeKopi2[24]);
        }

        [TestMethod]
        public void TestBillede() 
        {
            string url = useLocal ? _localUrl : _onlineUrl;

            _driver.Navigate().GoToUrl(url);

            WebDriverWait wdWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement ventPÂListe = wdWait.Until(ventPÂListe => ventPÂListe.FindElement(By.Id("drinksListe")));
            ReadOnlyCollection<IWebElement> drinksListe = _driver.FindElements(By.Id("drinksListe"));

            // Hvis flg. kaster exception fejler testen fordi der ikke er noget billede pÂ siden.
            ReadOnlyCollection<IWebElement> billede = _driver.FindElements(By.TagName("img"));


            // Tester om der er billede i hvert object i listen.
            foreach (IWebElement element in drinksListe)
            {
                IWebElement ListObject = element.FindElement(By.TagName("img"));

                Assert.IsNotNull(ListObject);

            }

        }

        [TestMethod]
        public void TestNavne() 
        {
            string url = useLocal ? _localUrl : _onlineUrl;

            _driver.Navigate().GoToUrl(url);

            WebDriverWait wdWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement ventPÂListe = wdWait.Until(ventPÂListe => ventPÂListe.FindElement(By.Id("drinksListe")));
            ReadOnlyCollection<IWebElement> drinksListe = _driver.FindElements(By.Id("drinksListe"));

            foreach (IWebElement element in drinksListe)
            {
                IWebElement ListObject = element.FindElement(By.Id("drinkNavn"));

                Assert.IsNotNull(ListObject);

            }
        }

        [TestMethod]
        public void TestReadKnap() 
        {
            string url = useLocal ? _localUrl : _onlineUrl;

            _driver.Navigate().GoToUrl(url);

            WebDriverWait wdWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement ventPÂListe = wdWait.Until(ventPÂListe => ventPÂListe.FindElement(By.Id("drinksListe")));
            ReadOnlyCollection<IWebElement> drinksListe = _driver.FindElements(By.Id("drinksListe"));

            foreach (IWebElement element in drinksListe)
            {
                IWebElement ListObject = element.FindElement(By.TagName("button"));

                Assert.IsNotNull(ListObject);

            }

        }
    }
}