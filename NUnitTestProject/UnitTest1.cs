using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;


namespace NUnitTestProject
{
    public class Tests
    {
        //- Инициализация браузера — прменить паттерн синглтон для инициализации браузера
        //- Открыть www.bbc.com
        //- Ввести текст в поле поиска
        //- Кликнуть на  первую ссылку на навигации
        //- Откртыть www.bbc.com в chrome, firefox, ie
        //- Проверить ввод и клик в вышеперечисленных браузерах
        //- Провеверить статус поле поиска(isDisplayed, isEnabled) - получить значение методов

        private ChromeDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = ChromeInitialization.GetObjectChromeType();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.bbc.com/");
        }



        [Test]
        public void GoTo_BbcCom_ReturnedSearchFieldStatus()
        {
            ////Close pop-up window            
            var closePopUp = _driver.FindElementByXPath("//button[@class='sign_in-exit']");
            closePopUp.Click();

            //Find string for search            
            var bbcSearchInput = _driver.FindElementByCssSelector("[placeholder='Search']");
            bbcSearchInput.Click();
           // var x = bbcSearchInput.Displayed;

            //Writing some text to search
            bbcSearchInput.SendKeys("Today is");
            var x = bbcSearchInput.Text;

            //Click button for startingSearch
            var clickSearchButton = _driver.FindElementByXPath("//button[@id='orb-search-button']");
            clickSearchButton.Click();

            //Click first link
            Thread.Sleep(2000);
            var firstLinkInNavigation = _driver.FindElementByXPath("//a[@class='css-vh7bxp-PromoLink e1f5wbog6'][1]");
            firstLinkInNavigation.Click();

            //Assert.True(x);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(5000);
            _driver.Quit();
        }




    }
}