using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;


namespace NUnitTestProject
{
    public class Tests
    {
        //- ������������� �������� � �������� ������� �������� ��� ������������� ��������
        //- ������� www.bbc.com
        //- ������ ����� � ���� ������
        //- �������� ��  ������ ������ �� ���������
        //- �������� www.bbc.com � chrome, firefox, ie
        //- ��������� ���� � ���� � ����������������� ���������
        //- ����������� ������ ���� ������(isDisplayed, isEnabled) - �������� �������� �������

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