using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

class EntryPoint
{
    static IWebDriver browser = new ChromeDriver(); // Inicialización del driver para abrir en este caso Google Chrome
    static IWebElement textBox;
    static void Main()
    {
        string url = "http://testing.todvachev.com/special-elements/text-input-field/";
        
        browser.Navigate().GoToUrl(url); // Abrir la página
        string en1 = "username";
        try
        {
            textBox = browser.FindElement(By.Name(en1));
            textBox.SendKeys("Test text");

            Thread.Sleep(3000);

            Console.WriteLine(textBox.GetAttribute("maxlength"));            

            Thread.Sleep(3000);

        }
        catch (NoSuchElementException)
        {
            RedMessage("No se encontró el elemento"+en1);
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
