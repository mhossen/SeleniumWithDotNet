using DataLib.Config;
using DataLib.EnumTypes;
using DataLib.Interface;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using TestOrangeHRM.Extensions;
using TestOrangeHRM.Helpers;
using TestOrangeHRM.Pages;

namespace TestOrangeHRM.Base
{
    [SetUpFixture]
    public class TestBase
    {
        public RemoteWebDriver RemoteDriver { get; set; }
        readonly IConfig Config = new AppConfigReader();
        // HrmLoginPage LoginPage => new HrmLoginPage(RemoteDriver);

        [OneTimeSetUp]
        public void InitOneTimeSetup()
        {
            if (RemoteDriver == null)
            {
                switch (Config.GetBrowser())
                {
                    case BrowserTypes.Chrome:
                        RemoteDriver = new ChromeDriver();
                        break;
                    case BrowserTypes.Firefox:
                        RemoteDriver = new FirefoxDriver();
                        break;
                    default:
                        throw new WebDriverException($"Driver for browser type: {Config.GetBrowser()} not created");
                }

                RemoteDriver.MaximizeBrowser();
                RemoteDriver.PageTimeout(Config.GetPageTimeOut());
                //  RemoteDriver.ImplicitTimeout(Config.GetElementTimeOut());
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
            //LoginPage.Logout();
            PageFactory.GetPage<HrmLoginPage>(RemoteDriver).Logout();
            if (RemoteDriver != null)
            {
                RemoteDriver.Close();
                RemoteDriver.Quit();
            }
        }
    }
}
