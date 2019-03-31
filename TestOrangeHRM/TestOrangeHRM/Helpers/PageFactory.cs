using System;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;
using TestOrangeHRM.Base;

namespace TestOrangeHRM.Helpers
{
    public static class PageFactory
    {
        private static readonly Dictionary<(Type, RemoteWebDriver), BasePage> _internalDictionary = new Dictionary<(Type, RemoteWebDriver), BasePage>();
        private static readonly object _internalDictionaryLock = new object();

        public static T GetPage<T>(RemoteWebDriver driver) where T : BasePage
        {
            lock (_internalDictionaryLock)
            {
                return InternalGetPage<T>(driver);
            }
        }

        private static T InternalGetPage<T>(RemoteWebDriver driver) where T : BasePage
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
