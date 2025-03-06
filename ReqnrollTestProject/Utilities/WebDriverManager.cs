using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace ReqnrollTestProject.Utilities
{
    public static class WebDriverManager
    {
        public static IWebDriver Driver { get; set; }

        public static IWebDriver GetDriver(string browser)
        {
            if (Driver == null)
            {
                switch (browser.ToLower())
                {
                    case "chrome":
                        Driver = new ChromeDriver();
                        break;
                    case "firefox":
                        Driver = new FirefoxDriver();
                        break;
                    case "edge":
                        Driver = new EdgeDriver();
                        break;
                    default:
                        throw new Exception("Navegador no soportado");
                }
            }
            return Driver;
        }
    }
}
