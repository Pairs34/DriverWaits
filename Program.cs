using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DriverWaits
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.n11.com/giris-yap");
            var email = driver.FindElementWithWait(By.Id("email"));
            if (email != null)
            {
                email.SendKeys("a.yldrm@outlook.com.tr");
            }
            else
            {
                Console.WriteLine("Email adresini bulamadım");
            }

            Console.ReadLine();
        }
        
        
    }

    static class Extensions
    {
        public static IWebElement FindElementWithWait(this IWebDriver driver,By by, int timeout = 60)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
            {
                PollingInterval = TimeSpan.FromSeconds(5)
            };
            
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            var waitElement = wait.Until(x => x.FindElement(by));

            if (waitElement != null)
            {
                return waitElement;
            }
            else
            {
                return null;
            }
        }
    }
}