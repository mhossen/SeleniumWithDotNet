using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;
using TestOrangeHRM.Base;
using TestOrangeHRM.Extensions;
using TestOrangeHRM.Helpers;

namespace TestOrangeHRM.Pages
{
    internal class HrmLoginPage : BasePage
    {
        public HrmLoginPage(RemoteWebDriver remotebDriver) : base(remotebDriver)
        {
        }

        private GenericHelper _generic
        {
            get
            {
                return new GenericHelper(_remoteDriver);
            }
        }
        private MouseActionHelper _mouse
        {
            get
            {
                return new MouseActionHelper(_remoteDriver);
            }
        }

        private IWebElement _txtUsername => _remoteDriver.ById("txtUsername");
        private IWebElement _txtPassword => _remoteDriver.ById("txtPassword");
        private IWebElement _btnLogin => _remoteDriver.ById("btnLogin");
        private IWebElement _lnkWelcome => _remoteDriver.ById("welcome");
        private IList<IWebElement> _lnkWelcomeMenu => _remoteDriver.ElementsByXPath("//*[@id='welcome-menu']/ul/li/a");
        public IWebElement _welcomeMenuAtt => _remoteDriver.ById("welcome-menu");

        public HrmPageMenu LogIn(string username, string password)
        {
            _generic.GetElement(_txtUsername).SendKeys(username);
            _generic.GetElement(_txtPassword).SendKeys(password);
            _generic.GetElement(_btnLogin).Click();
            return PageFactory.GetPage<HrmPageMenu>(_remoteDriver);
        }

        public HrmLoginPage Logout()
        {
            _generic.GetElement(_lnkWelcome).Click();
            ClickWelcomeMenuLink("Logout");
            return PageFactory.GetPage<HrmLoginPage>(_remoteDriver);
        }

        private void ClickWelcomeMenuLink(string text)
        {
            int attemptCounter = 0;
            const int maxAttempts = 5;

            while (!_generic.GetElement(_welcomeMenuAtt).GetAttribute("style").Equals("display: block;") && attemptCounter < maxAttempts)
            {
                _remoteDriver.WaitForElement(_welcomeMenuAtt, 1);
                attemptCounter++;
            }

            var element = _lnkWelcomeMenu.Where(t => t.Text.Equals(text)).FirstOrDefault();
            if (element != null)
                _mouse.MouseHoverClick(element);
        }

    }
}
