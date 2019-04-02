using DataLib.EnumTypes;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;
using TestOrangeHRM.Base;
using TestOrangeHRM.Extensions;
using TestOrangeHRM.Helpers;

namespace TestOrangeHRM.Pages
{
    internal class HrmPageMenu : BasePage
    {
         public HrmPageMenu(RemoteWebDriver remotebDriver) : base(remotebDriver)
        {
        }

        private MouseActionHelper MouseAction
        {
            get
            {
                return new MouseActionHelper(_remoteDriver);
            }
        }

        private GenericHelper _generic
        {
            get
            {
                return new GenericHelper(_remoteDriver);
            }
        }

        private IList<IWebElement> _mainMenus => _remoteDriver.ElementsByXPath("//div[@class='menu']/ul/li");

    public void GoToMainMenuPage(MenuTypes menu)
    {
      MouseAction.MouseHoverClick(
        _generic.GetElement(_mainMenus.Where(e => e.Text.Equals(menu.ToString())).FirstOrDefault()));
    }

  }
}