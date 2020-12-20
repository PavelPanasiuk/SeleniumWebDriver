using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace InputAndClickInBrowsers
{
    public class ChromeInitialization : ChromeDriver
    {
        //- Инициализация браузера — прменить паттерн синглтон для инициализации браузера   

        private static ChromeInitialization _classObject;
       // private static ChromeDriver _chrome;

        private ChromeInitialization() { }

        public static ChromeDriver Instanse
        {
            get
            {
                if (_classObject == null)
                {
                    _classObject = new ChromeInitialization();
                   // _chrome = new ChromeDriver();
                }
                // return _chrome;
                return _classObject;
            }
        }

    }

}
