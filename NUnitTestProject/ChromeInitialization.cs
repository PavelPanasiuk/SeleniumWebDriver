using OpenQA.Selenium.Chrome;


namespace InputAndClickInBrowsers
{
    public class ChromeInitialization
    {
        //- Инициализация браузера — прменить паттерн синглтон для инициализации браузера 
        private static ChromeDriver _chromeDriverObject;

        private ChromeInitialization() { }

        public static ChromeDriver Instanse
        {
            get
            {
                if (_chromeDriverObject == null)
                    _chromeDriverObject = new ChromeDriver();
                return _chromeDriverObject;
            }
        }
    }
}
