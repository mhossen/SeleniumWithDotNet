using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestOrangeHRM.Extensions;
using TestOrangeHRM.Helpers;

namespace TestOrangeHRM.Pages
{
    public class HrmLoginPage
    {
        private IWebDriver _driver;

        public HrmLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private GenericHelper _generic
        {
            get
            {
                return new GenericHelper(_driver);
            }
        }
        private MouseActionHelper _mouse
        {
            get
            {
                return new MouseActionHelper(_driver);
            }
        }

        private IWebElement _txtUsername => _driver.ById("txtUsername");
        private IWebElement _txtPassword => _driver.ById("txtPassword");
        private IWebElement _btnLogin => _driver.ById("btnLogin");
        private IWebElement _lnkWelcome => _driver.ById("welcome");
        private IList<IWebElement> _lnkWelcomeMenu => _driver.ElementsByXPath("//*[@id='welcome-menu']/ul/li/a");
        public IWebElement _welcomeMenuAtt => _driver.ById("welcome-menu");

        public void LogIn(string username, string password)
        {
            _generic.GetElement(_txtUsername).SendKeys(username);
            _generic.GetElement(_txtPassword).SendKeys(password);
            _generic.GetElement(_btnLogin).Click();
        }

        public void Logout()
        {
            _generic.GetElement(_lnkWelcome).Click();
            ClickWelcomeMenuLink("Logout");
        }

        private void ClickWelcomeMenuLink(string text)
        {
            if (!_generic.GetElement(_welcomeMenuAtt).GetAttribute("style").Equals("display: block;"))
                _driver.WaitForElement(_welcomeMenuAtt, 1);
            _mouse.MouseHoverClick(_lnkWelcomeMenu.Where(t => t.Text.Equals(text)).FirstOrDefault());
        }

    }
}
