using System;
using System.Collections.Generic;
using System.Text;
using SeleniumWebDriver;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver
{
    class Browser
    {
        public void SomeBrowser()
        {
            //Open browser
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://yandex.by/");

            //Finde search string      

            var yandexSearchElement = driver.FindElementByXPath("//input[@aria-label='Запрос']");
            yandexSearchElement.Click();

            //Writing wow
            yandexSearchElement.SendKeys("wow");
            var searchButton = driver.FindElementByXPath("//div[@class='search2__button']/*");
            searchButton.Click();


            //Going to third link
            var linkToWowPage = driver.FindElementByXPath("//a[@href='https://worldofwarcraft.com/'][1]");
            linkToWowPage.Click();

            //Finde shop link
            var shopLinkOnWowPage = driver.FindElementByXPath("//span[@data-text='Магазин'][1]");
            shopLinkOnWowPage.Click();


        }

    }
}
