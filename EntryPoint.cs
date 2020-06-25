using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

class EntryPoint
{
    static IWebDriver browser = new ChromeDriver(); // Inicialización del driver para abrir en este caso Google Chrome
    static IAlert alert;

    static void Main()
    {
        string url = "http://testing.todvachev.com/special-elements/alert-box/";1
        browser.Navigate().GoToUrl(url); // Abrir la página

        try
        {
            alert = browser.SwitchTo().Alert();
            Thread.Sleep(3500);
            alert.Accept();
        }
        catch (NoSuchElementException)
        {
            RedMessage("Can't Find the element");
        }

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
