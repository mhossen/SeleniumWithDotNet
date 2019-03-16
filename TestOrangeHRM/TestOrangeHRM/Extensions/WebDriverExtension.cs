using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestOrangeHRM.Extensions
{
    public static class WebDriverExtension
    {
        public static IWebElement ByXPath(this IWebDriver driver, string xpath) => driver.FindElement(By.XPath(xpath));

        public static IWebElement ByName(this IWebDriver driver, string name) => driver.FindElement(By.Name(name));

        public static IWebElement ById(this IWebDriver driver, string id) => driver.FindElement(By.Id(id));

        public static IWebElement ByTagName(this IWebDriver driver, string tagName) => driver.FindElement(By.TagName(tagName));

        public static IWebElement ByLinkText(this IWebDriver driver, string linkText) => driver.FindElement(By.LinkText(linkText));

        public static IWebElement ByPartialLinkText(this IWebDriver driver, string partialLinkText) =>
            driver.FindElement(By.PartialLinkText(partialLinkText));

        public static IList<IWebElement> ElementsByXPath(this IWebDriver driver, string xpath) => driver.FindElements(By.XPath(xpath));

        public static IList<IWebElement> ElementsByName(this IWebDriver driver, string name) => driver.FindElements(By.Name(name));

        public static IList<IWebElement> ElementsById(this IWebDriver driver, string id) => driver.FindElements(By.Id(id));

        public static IList<IWebElement> ElementsByTagName(this IWebDriver driver, string tagName) => driver.FindElements(By.TagName(tagName));

        public static IList<IWebElement> ElementsByLinkText(this IWebDriver driver, string linkText) => driver.FindElements(By.LinkText(linkText));

        public static IList<IWebElement> ElementsByPartialLinkText(this IWebDriver driver, string partialLinkText) =>
            driver.FindElements(By.PartialLinkText(partialLinkText));

        public static void MaximizeBrowser(this IWebDriver driver) => driver.Manage().Window.Maximize();

        public static void PageTimeout(this IWebDriver driver, int seconds) => driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(seconds);

        public static void ImplicitTimeout(this IWebDriver driver, int seconds) => driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);

        public static IWebElement WaitForElement(this IWebDriver driver, IWebElement element, int timeOutInsec)
        {
            if (timeOutInsec > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInsec));
                return wait.Until(e => element);
            }
            return element;
        }
    }
}