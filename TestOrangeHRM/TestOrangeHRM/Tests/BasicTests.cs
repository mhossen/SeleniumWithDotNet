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
    public class BasicTests : TestBase
    {
        JsonHelper Json
        {
            get
            {
                return new JsonHelper();
            }
        }
        HrmLoginPage _loginPage
        {
            get
            {
                return new HrmLoginPage(Driver);
            }
        }
        HrmPageMenu _menu
        {
            get
            {
                return new HrmPageMenu(Driver);
            }
        }
        HrmSystemUsersPage _usersPage
        {
            get
            {
                return new HrmSystemUsersPage(Driver);
            }
        }


        [Test, Order(1)]
        public void BasicNavTest()
        {
            var settings = Json.JsonValue<UserSettings>(ResourceCollection.SiteConfig);
            Driver.Navigate().GoToUrl(settings.Url);

            _loginPage.LogIn(settings.Username, settings.Password);
            Thread.Sleep(2000); // not good coding standard but placing for basic test
            Console.WriteLine(Driver.Title);

            _menu.GoToMainMenuPage(MenuTypes.Admin);
            var userData = _usersPage.GetUserTabelData();
            foreach (var user in userData)
            {

                if (!user.EmployeeName.Equals("Hannah Flores"))
                {

                    user.CheckBox.Click();
                    Console.WriteLine($"All employee Name: {user.EmployeeName.Text}");
                }

            }

        }


    }
}
