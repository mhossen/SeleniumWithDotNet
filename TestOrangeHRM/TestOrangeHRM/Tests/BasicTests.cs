using System;
using System.Collections.Generic;
using System.Threading;
using DataLib.EnumTypes;
using DataLib.Model;
using NUnit.Framework;
using TestOrangeHRM.Base;
using TestOrangeHRM.DataTables;
using TestOrangeHRM.Helpers;
using TestOrangeHRM.Pages;

namespace TestOrangeHRM.Tests
{
    [TestFixture, Parallelizable]
    public class BasicTests : TestBase
    {
        
        [Test, Order(1)]
        public void BasicNavTest()
        {
            UserSettings settings = Json.JsonValue<UserSettings>(ResourceCollection.SiteConfig);
            RemoteDriver.Navigate().GoToUrl(settings.Url);

            PageFactory.GetPage<HrmLoginPage>(RemoteDriver).LogIn(settings.Username, settings.Password);
            Thread.Sleep(2000); // not good coding standard but placing for basic test
            Console.WriteLine(RemoteDriver.Title);

            PageFactory.GetPage<HrmPageMenu>(RemoteDriver).GoToMainMenuPage(MenuTypes.Admin);
            IList<SystemUserTable> users = PageFactory.GetPage<HrmSystemUsersPage>(RemoteDriver)
                .GetUserTabelData();

            // note as of 3/31/2019 user table has been changed but this code is good
            foreach (SystemUserTable user in users)
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

