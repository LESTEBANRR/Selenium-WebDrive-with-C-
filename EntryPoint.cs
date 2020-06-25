using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

class EntryPoint
{
    static void Main()
    {
        IWebDriver driver = new ChromeDriver(); // Inicialización del driver para abrir en este caso Google Chrome
        driver.Navigate().GoToUrl("http://testing.todorvachev.com/");//Abrir la pagina http://testing.todorvachev.com/
        Thread.Sleep(3000); // Esperar 3 Segundos
        driver.Quit(); // Cerrar el Navegador
    }
}
