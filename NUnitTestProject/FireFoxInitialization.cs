using OpenQA.Selenium.Firefox;

namespace InputAndClickInBrowsers
{
    public class FireFoxInitialization
    {
        //- Инициализация браузера — прменить паттерн синглтон для инициализации браузера   
        private static FirefoxDriver _firefoxDriverObject;

        private FireFoxInitialization() { }

        public static FirefoxDriver Instanse
        {
            get
            {
                if (_firefoxDriverObject == null)
                {
                    _firefoxDriverObject = new FirefoxDriver();
                }
                return _firefoxDriverObject;
            }
        }
    }
}
