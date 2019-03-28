using System;
using System.Threading;
using DataLib.EnumTypes;
using DataLib.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using TestOrangeHRM.Base;
using TestOrangeHRM.DataTables;
using TestOrangeHRM.Helpers;
using TestOrangeHRM.Pages;

namespace TestOrangeHRM.Tests
{
  [TestFixture]
  public class BasicTests : TestBase
  {
    private JsonHelper Json => new JsonHelper();

    private HrmLoginPage _loginPage => PageFactory.GetPage<HrmLoginPage>(Driver);

    private HrmPageMenu _menu => PageFactory.GetPage<HrmPageMenu>(Driver);

    private HrmSystemUsersPage _usersPage => PageFactory.GetPage<HrmSystemUsersPage>(Driver);

    [Test, Order(1)]
    public void BasicNavTest()
    {
      UserSettings settings = Json.JsonValue<UserSettings>(ResourceCollection.SiteConfig);
      Driver.Navigate().GoToUrl(settings.Url);

      _loginPage.LogIn(settings.Username, settings.Password);
      Thread.Sleep(2000); // not good coding standard but placing for basic test
      Console.WriteLine(Driver.Title);

      _menu.GoToMainMenuPage(MenuTypes.Admin);

      foreach (SystemUserTable user in _usersPage.GetUserTabelData())
      {
        if (!user.EmployeeName.Equals("Hannah Flores"))
        {
          user.CheckBox.Click();
          Console.WriteLine($"All employee Name: {user.EmployeeName.Text}");
        }
      }
    }

    public void Blah()
    {
      //var instance = Instantiator.Create<IWebDriver, HrmPageMenu>(Driver);
    }
  }
}