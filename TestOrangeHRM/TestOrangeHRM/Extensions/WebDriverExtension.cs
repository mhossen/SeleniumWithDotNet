﻿using OpenQA.Selenium;
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

    }
}