using DataLib.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TestOrangeHRM.Helpers;

namespace TestOrangeHRM.Tests
{
    [TestFixture]
    public class BasicTests
    {
        JsonHelper json = new JsonHelper();
        [Test]
        public void BasicNavTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(json.JsonValue<UserSettings>(ResourceCollection.SiteConfig).Result.Url);
            Console.WriteLine(driver.Title);
        }
    }
}
