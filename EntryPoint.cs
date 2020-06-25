using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

class EntryPoint
{
    static IWebDriver browser = new ChromeDriver(); // Inicialización del driver para abrir en este caso Google Chrome
    static IWebElement dropDownMenu;
    static IWebElement elementFromDDMenu;

    static void Main()
    {
        string url = "http://testing.todvachev.com/special-elements/drop-down-menu-test/";
        string dropDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child(3)";

        browser.Navigate().GoToUrl(url); // Abrir la página

        try
        {
            dropDownMenu = browser.FindElement(By.Name("DropDownTest"));
            Console.WriteLine(dropDownMenu.GetAttribute("value"));
            elementFromDDMenu = browser.FindElement(By.CssSelector(dropDownMenuElements));
            Console.WriteLine("The third option is: "+elementFromDDMenu.GetAttribute("value"));
            //Thread.Sleep(3000);

            elementFromDDMenu.Click();
            Console.WriteLine(dropDownMenu.GetAttribute("value"));

            for (int i=1; i<=4; i++)
            {
                dropDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child("+i+")";
                elementFromDDMenu = browser.FindElement(By.CssSelector(dropDownMenuElements));
                Console.WriteLine("The option "+i+" is: " + elementFromDDMenu.GetAttribute("value"));
            }

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
