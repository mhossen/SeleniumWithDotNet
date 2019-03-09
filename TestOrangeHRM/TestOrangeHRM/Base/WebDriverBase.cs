using NUnit.Framework;
using OpenQA.Selenium;

namespace TestOrangeHRM.Base
{
    [SetUpFixture]
    public class WebDriverBase
    {
        public IWebDriver Driver { get; set; }

        [OneTimeSetUp]
        public void InitOneTimeSetup()
        {
            if (Driver == null)
            {
                // do something
            }
        }

    }
}
