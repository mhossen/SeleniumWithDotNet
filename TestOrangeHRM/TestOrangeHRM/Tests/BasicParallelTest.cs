using DataLib.Model;
using NUnit.Framework;
using TestOrangeHRM.Base;
using TestOrangeHRM.Pages;

namespace TestOrangeHRM.Tests
{
    [TestFixture, Parallelizable]
    public class BasicParallelTest : TestBase
    {
        UserSettings Settings => Json.JsonValue<UserSettings>(ResourceCollection.SiteConfig);
        [Test]
        public void AnotherLoginTest()
        {
            RemoteDriver.Navigate().GoToUrl(Settings.Url);
            PageFactory.GetPage<HrmLoginPage>(RemoteDriver).LogIn(Settings.Username, Settings.Password);
        }
    }
}
