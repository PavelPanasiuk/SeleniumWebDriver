using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;


namespace InputAndClickInBrowsers
{
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class TestsWithMultipleBrowsers<TwebDriver> where TwebDriver : IWebDriver, new()
    {
        //-Инициализация браузера  - применить паттерн синглтон для инициализации
        //-Открыть www.bbc.com
        //-Ввести текст в поле поиска
        //-Кликнуть на первую ссылку на навигации
        //-Открыть www.bbc.com в chrome, Firefox, ie
        //-Проверить ввод и клик в вышеперечисленных браузерах
        //-Проверить статус поле поиска (isDisplayed, isEnable) - получить значение методов
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {

            _driver = new TwebDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.bbc.com/");
        }

        [Test]
        public void Use_GoToBbcCom_ReturnedSearchFieldStatus()
        {
            var textForSearch = "this";
            //Close pop-up window            
            _driver.FindElement(By.XPath("//button[@class='sign_in-exit']")).Click();

            //Find string for search            
            var bbcSearchInput = _driver.FindElement(By.CssSelector("[placeholder='Search']"));
            if (bbcSearchInput.Displayed && bbcSearchInput.Enabled)
            {
                bbcSearchInput.Click();
            }

            //Writing some text to search
            bbcSearchInput.SendKeys(textForSearch);

            // Click button for starting Search
            _driver.FindElement(By.XPath("//button[@id='orb-search-button']")).Click();
            var textInCurrentSearchLine = _driver.FindElement(By.XPath("//input")).GetAttribute("value");
            var firstUrl = _driver.Url;

            //Click first link                                         
            _driver.FindElement(By.XPath("//a[@class='css-vh7bxp-PromoLink e1f5wbog6'][1]")).Click();
            var urlOfNewPage = _driver.Url;

            try
            {
                Assert.IsTrue(textForSearch == textInCurrentSearchLine);
                Assert.AreNotSame(urlOfNewPage, firstUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //[Test] firefox
        //public void UseFireFox_GoToBbcCom_ReturnedSearchFieldStatus()
        //{
        //    //Close PopUp menu
        //    var closePopUp = _firefoxDriver.FindElementByXPath("//button[@class='sign_in-exit']");
        //    closePopUp.Click();

        //    //Find search line
        //    var searchLine = _firefoxDriver.FindElementByCssSelector("[placeholder = 'Search']");
        //    searchLine.Click();

        //    //Write text
        //    searchLine.SendKeys("What the");

        //    //Click button for starting search
        //    var searchButton = _firefoxDriver.FindElementByCssSelector("#orb-search-button");
        //    searchButton.Click();

        //    //Click first link
        //    var clickFirstLink = _firefoxDriver.FindElementByXPath("//a[@class='css-vh7bxp-PromoLink e1f5wbog6'][1]");
        //    clickFirstLink.Click();
        //}        

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}