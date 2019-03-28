using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;

namespace TestOrangeHRM.Pages
{
  public static class PageFactory
  {
    private static readonly Dictionary<Type, BasePage> _internalDictionary = new Dictionary<Type, BasePage>();

    public static T GetPage<T>(IWebDriver driver) where T : BasePage
    {
      if (_internalDictionary.TryGetValue(typeof(T), out var result))
      {
        return (T)result;
      }

      BasePage newPage = null;


      if (typeof(T) == typeof(HrmSystemUsersPage))
      {
        newPage = new HrmSystemUsersPage(driver);
      }
      else if (typeof(T) == typeof(HrmPageMenu))
      {
        newPage = new HrmPageMenu(driver);
      }
      else if (typeof(T) == typeof(HrmLoginPage))
      {
        newPage = new HrmLoginPage(driver);
      }

      if (newPage == null)
      {
        throw new InvalidOperationException();
      }

      _internalDictionary.Add(typeof(T),(T)newPage);

      return (T)newPage;
    }
  }
}