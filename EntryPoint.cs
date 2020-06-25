using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

class EntryPoint
{
    static void Main()
    {
        IWebDriver browser = new ChromeDriver(); // Inicialización del driver para abrir en este caso Google Chrome
        browser.Navigate().GoToUrl("http://testing.todvachev.com/selectors/name/"); // Abrir la página
        IWebElement element = browser.FindElement(By.Name("myName")); //Buscar el elemento por su nombre
        if (element.Displayed)//Asking if the element is visible
        {
            GreenMessage("Is Visible");
        }
        else
        {
            RedMessage("Is not Visible");
        }
        Thread.Sleep(2000);
        browser.Quit();
    }

    private static void RedMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    private static void GreenMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
