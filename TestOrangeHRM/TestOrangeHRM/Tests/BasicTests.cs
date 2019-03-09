using DataLib.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TestOrangeHRM.Helpers;
using TestOrangeHRM.Pages;

namespace TestOrangeHRM.Tests
{
    [TestFixture]
    public class BasicTests
    {
        JsonHelper json = new JsonHelper();
        [Test]
        public void BasicNavTest()
        {
            var settings = json.JsonValue<UserSettings>(ResourceCollection.SiteConfig).Result;

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(settings.Url);

            HrmLoginPage loginPage = new HrmLoginPage(driver);
            loginPage.LogIn(settings.Username, settings.Password);
            Thread.Sleep(2000); // not good coding standard but placing for basic test
            Console.WriteLine(driver.Title);
            driver.Close();
            driver.Quit();
        }
    }
}
