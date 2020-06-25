using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

class EntryPoint
{
    static IWebDriver browser = new ChromeDriver(); // Inicialización del driver para abrir en este caso Google Chrome
    static IWebElement radioButton;
    
    static void Main()
    {
        string url = "http://testing.todvachev.com/special-elements/radio-button-test/";
        string[] option = { "1","3","5" };
        
        browser.Navigate().GoToUrl(url); // Abrir la página

        for (int i = 0; i < option.Length; i++)
        {
            string en1 = "#post-10 > div > form > p:nth-child(6) > input[type=\"radio\"]:nth-child(" + option[i] + ")";

            try
            {
                radioButton = browser.FindElement(By.CssSelector(en1));

                if (radioButton.GetAttribute("checked") == "true")
                {
                    Console.WriteLine("The RadioButton "+(i+1)+" is checked");
                }
                else
                {
                    Console.WriteLine("The RadioButton "+(i+1)+" is NOT checked");
                }

            }
            catch (NoSuchElementException)
            {
                RedMessage("Can't Find the element");
            }
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
