using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

class EntryPoint
{
    static IWebDriver browser = new ChromeDriver(); // Inicialización del driver para abrir en este caso Google Chrome
    static IWebElement checkBox;
    
    static void Main()
    {
        string url = "http://testing.todvachev.com/special-elements/check-button-test-3/";
        string option = "3";
        
        browser.Navigate().GoToUrl(url); // Abrir la página
        string en1 = "#post-33 > div > p:nth-child(8) > input[type=\"checkbox\"]:nth-child("+option+")";

        try
        {
            checkBox = browser.FindElement(By.CssSelector(en1));
            if (checkBox.GetAttribute("checked") == "true")
            {
                GreenMessage("The box "+option+" is checked");
            }
            else
            {
                RedMessage("The box is not checked");
            }
            Console.WriteLine(checkBox.GetAttribute("value"));
            option = "1";
            checkBox = browser.FindElement(By.CssSelector("#post-33 > div > p:nth-child(8) > input[type=\"checkbox\"]:nth-child(" + option + ")"));
            Console.WriteLine(checkBox.GetAttribute("value"));
            Thread.Sleep(3000);
            checkBox.Click();
            Thread.Sleep(2000);
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
