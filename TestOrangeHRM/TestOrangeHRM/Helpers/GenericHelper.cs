using DataLib.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using TestOrangeHRM.CustomExceptions;

namespace TestOrangeHRM.Helpers
{
    internal class GenericHelper
    {
        private readonly IWebDriver _driver;
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

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

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
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
