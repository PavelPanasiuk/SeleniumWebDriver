using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace InputAndClickInBrowsers
{
    [TestFixture]
    public class TestsWithMultipleBrowsers
    {
        //-Инициализация браузера  - применить паттерн синглтон для инициализации
        //-Открыть www.bbc.com
        //-Ввести текст в поле поиска
        //-Кликнуть на первую ссылку на навигации
        //-Открыть www.bbc.com в chrome, Firefox, ie
        //-Проверить ввод и клик в вышеперечисленных браузерах
        //-Проверить статус поле поиска (isDisplayed, isEnable) - получить значение методов

        ChromeDriver _chromeDriver = ChromeInitialization.Instanse;
        FirefoxDriver _firefoxDriver = FireFoxInitialization.Instanse;

        //Ниже тесты на каждый из браузеров отдельно
        [SetUp]
        public void Setup()
        {
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _firefoxDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _chromeDriver.Manage().Window.Maximize();
            _firefoxDriver.Manage().Window.Maximize();
        }

        [Ignore("UseChrome_GoToBbcCom_ReturnedSearchFieldStatus")]
        [Test]
        public void UseChrome_GoToBbcCom_ReturnedSearchFieldStatus()
        {
            _chromeDriver.Navigate().GoToUrl("https://www.bbc.com/");

            var textForSearch = "this";
            //Close pop-up window            
            _chromeDriver.FindElement(By.XPath("//button[@class='sign_in-exit']")).Click();

            //Find string for search            
            var bbcSearchInput = _chromeDriver.FindElement(By.CssSelector("[placeholder='Search']"));
            if (bbcSearchInput.Displayed && bbcSearchInput.Enabled)
            {
                bbcSearchInput.Click();
            }

            //Writing some text to search
            bbcSearchInput.SendKeys(textForSearch);

            // Click button for starting Search
            _chromeDriver.FindElement(By.XPath("//button[@id='orb-search-button']")).Click();
            var textInCurrentSearchLine = _chromeDriver.FindElement(By.XPath("//input")).GetAttribute("value");            

            //Click first link              
            _chromeDriver.FindElement(By.XPath("//a[@class='css-vh7bxp-PromoLink e1f5wbog6'][1]")).Click();
            var urlOfNewPage = _chromeDriver.Url;

            Assert.IsTrue(textForSearch == textInCurrentSearchLine);
            Assert.AreEqual(urlOfNewPage, _chromeDriver.Url);
        }

        [Ignore("UseFireFox_GoToBbcCom_ReturnedSearchFieldStatus")]
        [Test]
        public void UseFireFox_GoToBbcCom_ReturnedSearchFieldStatus()
        {
            _firefoxDriver.Navigate().GoToUrl("https://www.bbc.com/");

            var textForSearch = "this";
            //Close pop-up window
            WebDriverWait webDriverWait = new WebDriverWait(_firefoxDriver, TimeSpan.FromSeconds(5));
            _firefoxDriver.FindElement(By.XPath("//button[@class='sign_in-exit']")).Click();

            //Find string for search            
            var bbcSearchInput = _firefoxDriver.FindElement(By.CssSelector("[placeholder='Search']"));
            if (bbcSearchInput.Displayed && bbcSearchInput.Enabled)
            {
                bbcSearchInput.Click();
            }

            //Writing some text to search
            bbcSearchInput.SendKeys(textForSearch);

            // Click button for starting Search
            _firefoxDriver.FindElement(By.XPath("//button[@id='orb-search-button']")).Click();
            var textInCurrentSearchLine = _firefoxDriver.FindElement(By.XPath("//input")).GetAttribute("value");
            var firstUrl = _chromeDriver.Url;

            //Click first link                                         
            _firefoxDriver.FindElement(By.XPath("//a[@class='css-vh7bxp-PromoLink e1f5wbog6'][1]")).Click();
            var urlOfNewPage = _firefoxDriver.Url;

            Assert.IsTrue(textForSearch == textInCurrentSearchLine);
            Assert.AreEqual(urlOfNewPage, _firefoxDriver.Url);
        }

        [TearDown]
        public void TearDown()
        {
            _chromeDriver.Quit();
            _firefoxDriver.Quit();
        }

        //Можно использовать два браузера в одном тесте
        static IWebDriver[] DriversForCase =
        {
            ChromeInitialization.Instanse,
            FireFoxInitialization.Instanse
        };

        [TestCaseSource(nameof(DriversForCase))]
        [Test]
        public void GoToBbcCom_ReturnedSearchFieldStatus(IWebDriver _driver)

        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.bbc.com/");

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

            //Click first link             
            _driver.FindElement(By.XPath("//a[@class='css-vh7bxp-PromoLink e1f5wbog6'][1]")).Click();
            var urlOfNewPage = _driver.Url;

            Assert.IsTrue(textForSearch == textInCurrentSearchLine);
            Assert.AreEqual(urlOfNewPage, _driver.Url);
        }       
    }
}