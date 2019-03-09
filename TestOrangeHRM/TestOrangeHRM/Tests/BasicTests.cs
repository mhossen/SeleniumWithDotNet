using DataLib.EnumTypes;
using DataLib.Model;
using NUnit.Framework;
using System;
using System.Threading;
using TestOrangeHRM.Base;
using TestOrangeHRM.Helpers;
using TestOrangeHRM.Pages;

namespace TestOrangeHRM.Tests
{
    [TestFixture]
    public class BasicTests : WebDriverBase
    {
        JsonHelper Json
        {
            get
            {
                return new JsonHelper();
            }
        }
        [Test]
        public void BasicNavTest()
        {
            var settings = Json.JsonValue<UserSettings>(ResourceCollection.SiteConfig);
            Driver.Navigate().GoToUrl(settings.Url);

            HrmLoginPage loginPage = new HrmLoginPage(Driver);
            loginPage.LogIn(settings.Username, settings.Password);
            Thread.Sleep(2000); // not good coding standard but placing for basic test
            Console.WriteLine(Driver.Title);

            HrmPageMenu menu = new HrmPageMenu(Driver);
            menu.GoToMainMenuPage(MenuTypes.PIM);
        }
    }
}
