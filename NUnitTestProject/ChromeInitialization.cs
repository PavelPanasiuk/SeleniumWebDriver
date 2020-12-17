using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;

namespace NUnitTestProject
{
    class ChromeInitialization
    {
        //- Инициализация браузера — прменить паттерн синглтон для инициализации браузера
        private static ChromeDriver _chromeDriver;       

        public ChromeInitialization() { }

        public static ChromeDriver GetObjectChromeType()
        {
            if (_chromeDriver == null)
            {
                _chromeDriver = new ChromeDriver();
            }
            return _chromeDriver;
        }

    }
}
