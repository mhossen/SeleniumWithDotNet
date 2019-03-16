using DataLib.Config;
using DataLib.EnumTypes;
using DataLib.Interface;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TestOrangeHRM.Extensions;
using TestOrangeHRM.Pages;

namespace TestOrangeHRM.Base
{
    [SetUpFixture]
    public class TestBase
    {
        public IWebDriver Driver { get; set; }

        readonly IConfig Config = new AppConfigReader();
        HrmLoginPage LoginPage => new HrmLoginPage(Driver);

        [OneTimeSetUp]
        public void InitOneTimeSetup()
        {
            if (Driver == null)
            {
                switch (Config.GetBrowser())
                {
                    case BrowserTypes.Chrome:
                        Driver = new ChromeDriver();
                        break;
                    case BrowserTypes.Firefox:
                        Driver = new FirefoxDriver();
                        break;
                    default:
                        throw new WebDriverException($"Driver for browser type: {Config.GetBrowser()} created");
                }

                Driver.MaximizeBrowser();
                Driver.PageTimeout(Config.GetPageTimeOut());
                Driver.ImplicitTimeout(Config.GetElementTimeOut());
            }
        }

        [SetUp]
        public void BeforeTest()
        {
            Console.WriteLine("Run something before each test methods");
        }

        [TearDown]
        public void AfterTest()
        {
            Console.WriteLine("Run something after each test methods");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            LoginPage.Logout();
            if (Driver != null)
            {
                Driver.Close();
                Driver.Quit();
            }
        }
    }
}
