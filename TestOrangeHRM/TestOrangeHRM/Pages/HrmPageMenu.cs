using DataLib.EnumTypes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TestOrangeHRM.Extensions;
using TestOrangeHRM.Helpers;

namespace TestOrangeHRM.Pages
{
  public class HrmPageMenu : BasePage
  {
    public HrmPageMenu(IWebDriver driver) : base(driver)
    {
    }

    private MouseActionHelper MouseAction
    {
      get { return new MouseActionHelper(_driver); }
    }

    private GenericHelper _generic
    {
      get { return new GenericHelper(_driver); }
    }

    private IList<IWebElement> _mainMenus => _driver.ElementsByXPath("//div[@class='menu']/ul/li");

    public void GoToMainMenuPage(MenuTypes menu)
    {
      MouseAction.MouseHoverClick(
        _generic.GetElement(_mainMenus.Where(e => e.Text.Equals(menu.ToString())).FirstOrDefault()));
    }

  }
}