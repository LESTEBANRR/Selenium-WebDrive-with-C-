using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

class EntryPoint
{
    static void Main()
    {
        string url = "http://testing.todvachev.com/selectors/class-name/";
        string className = "testClass";

        IWebDriver browser = new ChromeDriver(); // Inicialización del driver para abrir en este caso Google Chrome
        browser.Navigate().GoToUrl(url); // Abrir la página

        
        IWebElement element = browser.FindElement(By.ClassName(className)); //Buscar el elemento por su nombre

        Console.WriteLine(element.Text);

        Console.WriteLine("Press any Key to continue...");
        Console.ReadLine();
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
