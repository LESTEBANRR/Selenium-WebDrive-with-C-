using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

class EntryPoint
{
    static void Main()
    {
        string url = "http://testing.todvachev.com/selectors/css-path/";
        string cssPath = "#post-108 > div > figure > img";
        string xPath = "//*[@id=\"post-108\"]/div/figure/img";

        IWebDriver browser = new ChromeDriver(); // Inicialización del driver para abrir en este caso Google Chrome
        browser.Navigate().GoToUrl(url); // Abrir la página


        IWebElement cssPathelement;
        IWebElement XPathelement;

        try
        {
            cssPathelement = browser.FindElement(By.CssSelector(cssPath));
            if (cssPathelement.Displayed)
            {
                GreenMessage("Css Path Element is Visible");
            }
        }
        catch (NoSuchElementException)
        {
            RedMessage("Css Path Element is not Visible");
        }
        //------------------------------------------------------------------------
        try
        {
            XPathelement = browser.FindElement(By.XPath(xPath));
            if (XPathelement.Displayed)
            {
                GreenMessage("XPath Element is Visible");
            }
        }
        catch (NoSuchElementException)
        {
            RedMessage("XPath Element is not Visible");
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
