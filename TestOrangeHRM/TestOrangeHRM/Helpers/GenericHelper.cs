using DataLib.CustomExceptions;
using DataLib.EnumTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using TestOrangeHRM.Base;
using TestOrangeHRM.Extensions;

namespace TestOrangeHRM.Helpers
{
    internal class GenericHelper : BasePage
    {
        public GenericHelper(RemoteWebDriver remotebDriver) : base(remotebDriver)
        {
        }

        private Actions _action
        {
            get
            {
                return new Actions(_remoteDriver);
            }
        }

        private bool IsElementPresent(IWebElement element)
        {
            try
            {
                if (element.Displayed || element.Enabled)
                    return element.Displayed || element.Enabled;

            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public IWebElement GetElement(IWebElement element)
        {
            try
            {
                int startCount = 0;
                const int maxCount = 8;
                if (IsElementPresent(element))
                {
                    return element;
                }
                else
                {
                    while (!(element.Displayed || element.Enabled) && startCount < maxCount)
                    {
                        _remoteDriver.WaitForElement(element, 1);
                        startCount++;
                    }
                    return element;
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element Not Found: " + e.Message);
            }
            return null;
        }

        public void KeyBoardAction(int number, KeyboardKeys keys)
        {
            for (int i = 0; i < number; i++)
            {
                WaitInSecond(1);
                switch (keys)
                {
                    case KeyboardKeys.Tab:
                        _action.SendKeys(Keys.Tab).Perform();
                        break;
                    case KeyboardKeys.Enter:
                        _action.SendKeys(Keys.Enter).Perform();
                        break;
                    case KeyboardKeys.Home:
                        _action.SendKeys(Keys.Home).Perform();
                        break;
                    case KeyboardKeys.End:
                        _action.SendKeys(Keys.End).Perform();
                        break;
                    case KeyboardKeys.Shift:
                        _action.SendKeys(Keys.Shift).Perform();
                        break;
                    case KeyboardKeys.PageDown:
                        _action.SendKeys(Keys.PageDown).Perform();
                        break;
                    case KeyboardKeys.PageUp:
                        _action.SendKeys(Keys.PageUp).Perform();
                        break;
                    default:
                        throw new NoKeyboardKeyExist("Keyborad key is not defined!");
                }
            }
        }

        public void WaitInSecond(int second)
        {
            Thread.Sleep(second * 1000);
        }

    }
}
