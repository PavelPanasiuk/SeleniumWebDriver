using System;

namespace BrowserInitialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //-Инициализация браузера — прменить паттерн синглтон для инициализации браузера
            //-Открыть www.bbc.com
            //- Ввести текст в поле поиска
            //-Кликнуть на первую ссылку на навигации
            //- Откртыть www.bbc.com в chrome, firefox, ie
            //- Проверить ввод и клик в вышеперечисленных браузерах
            //-Провеверить статус поле поиска(isDisplayed, isEnabled) - получить значение методов

            Browser.GetBrowser();
            Browser.GetBrowser();
            
        }
    }
}
