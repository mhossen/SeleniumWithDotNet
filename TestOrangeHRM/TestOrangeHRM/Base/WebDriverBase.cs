using DataLib.Config;
using DataLib.EnumTypes;
using DataLib.Interface;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TestOrangeHRM.Extensions;

namespace TestOrangeHRM.Base
{
    [SetUpFixture]
    public class WebDriverBase
    {
        public IWebDriver Driver { get; set; }

        readonly IConfig Config = new AppConfigReader();


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
            if (Driver != null)
            {
                Driver.Close();
                Driver.Quit();
            }
        }
    }
}
