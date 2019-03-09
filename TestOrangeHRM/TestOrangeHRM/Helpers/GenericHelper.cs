using DataLib.CustomExceptions;
using DataLib.EnumTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace TestOrangeHRM.Helpers
{
    internal class GenericHelper
    {
        private readonly IWebDriver _driver;

        public GenericHelper(IWebDriver driver)
        {
            _driver = driver;
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
            if (IsElementPresent(element))

                return element;
            else
                throw new NoSuchElementException("Element Not Found: " + element.ToString());
        }

        public void KeyBoardAction(int number, KeyboardKeys keys)
        {
            for (int i = 0; i < number; i++)
            {
                WaitInSecond(1);
                switch (keys)
                {
                    case KeyboardKeys.Tab:
                        new Actions(_driver).SendKeys(Keys.Tab).Perform();
                        break;
                    case KeyboardKeys.Enter:
                        new Actions(_driver).SendKeys(Keys.Enter).Perform();
                        break;
                    case KeyboardKeys.Home:
                        new Actions(_driver).SendKeys(Keys.Home).Perform();
                        break;
                    case KeyboardKeys.End:
                        new Actions(_driver).SendKeys(Keys.End).Perform();
                        break;
                    case KeyboardKeys.Shift:
                        new Actions(_driver).SendKeys(Keys.Shift).Perform();
                        break;
                    case KeyboardKeys.PageDown:
                        new Actions(_driver).SendKeys(Keys.PageDown).Perform();
                        break;
                    case KeyboardKeys.PageUp:
                        new Actions(_driver).SendKeys(Keys.PageUp).Perform();
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
