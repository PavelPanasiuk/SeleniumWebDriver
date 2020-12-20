using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Firefox;

namespace InputAndClickInBrowsers
{
    public class FireFoxInitialization
    {
        //- Инициализация браузера — прменить паттерн синглтон для инициализации браузера       

        private static FireFoxInitialization _classObject;
        private static FirefoxDriver _firefox;

        private FireFoxInitialization() { }

        public static FirefoxDriver Instanse
        {
            get
            {
                if (_classObject == null)
                {
                    _classObject = new FireFoxInitialization();
                   _firefox = new FirefoxDriver();
                }
                return _firefox;
            }
        }
    }
}
