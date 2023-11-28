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
        private static string _localUrl = "";
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
            IWebElement ventPÂListe = wdWait.Until(ventPÂListe => ventPÂListe.FindElement(By.Id("drinksListe")));
            ReadOnlyCollection<IWebElement> drinksListe = _driver.FindElements(By.Id("drinksListe"));

            //lav kopi af listen

            List<IWebElement> listeKopi = new List<IWebElement>(drinksListe);

            //sorter kopien TODO

            listeKopi.Sort();

            int count = 0;
            //sammenlign listerne
            foreach (IWebElement drink in drinksListe)
            {
                Assert.AreEqual(drink.Text, listeKopi[count].Text);
                count++;
            }

            ////Test at f¯rste objekt starter med a.
            //IWebElement firstInList = drinksListe[0];

            //Assert.IsTrue(firstInList.Text.ToLower().StartsWith("a"));
            ////Test at sidste objekt i listen starter med z.
            //IWebElement lastInList = _driver.FindElement(By.Id(""));
        }
        [TestMethod]
        public void TestListeSorteringKan∆ndres() 
        {

            string url = useLocal ? _localUrl : _onlineUrl;

            _driver.Navigate().GoToUrl(url);

            WebDriverWait wdWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement ventPÂListe = wdWait.Until(ventPÂListe => ventPÂListe.FindElement(By.Id("drinksListe")));
            ReadOnlyCollection<IWebElement> drinksListe = _driver.FindElements(By.Id("drinksListe"));

            IWebElement objekt1Sortering1 = drinksListe.First();
            string Data1 = objekt1Sortering1.Text;
            IWebElement objekt2Sortering1 = drinksListe.Last();
            string Data2 = objekt2Sortering1.Text;

            // ∆ndring af sortering

            IWebElement ÊndreSorteringKnap = _driver.FindElement(By.Id("sortBtnKategori"));
            ÊndreSorteringKnap.Click();

            ReadOnlyCollection<IWebElement> drinksListe2 = _driver.FindElements(By.Id("drinksListe"));

            IWebElement objekt3Sortering2 = drinksListe2.First();
            string Data3 = objekt3Sortering2.Text;
            IWebElement objekt4Sortering2 = drinksListe2.Last();
            string Data4 = objekt4Sortering2.Text;

            Assert.AreNotEqual(Data1, Data3);
            Assert.AreNotEqual(Data2, Data4);
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