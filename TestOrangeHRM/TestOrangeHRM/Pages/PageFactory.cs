using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using OpenQA.Selenium;

namespace TestOrangeHRM.Pages
{
  public static class PageFactory
  {
    private static readonly Dictionary<(Type, IWebDriver), BasePage> _internalDictionary = new Dictionary<(Type, IWebDriver), BasePage>();
    private static readonly object _internalDictionaryLock = new object();

    public static T GetPage<T>(IWebDriver driver) where T : BasePage
    {
      lock (_internalDictionaryLock)
      {
        return InternalGetPage<T>(driver);
      }
    }
    private static T InternalGetPage<T>(IWebDriver driver) where T : BasePage
    {
      // Use a tuple to make a composite key of type and the driver passed. This allows different drivers to get different instances of the same page type for parallel testing.
      var key = (typeof(T), driver);
      if (_internalDictionary.TryGetValue(key, out var result))
      {
        return (T)result;
      }

      var newPage = (T)Activator.CreateInstance(typeof(T), driver);
      _internalDictionary.Add(key, newPage);
      
      return newPage;
    }
  }
}