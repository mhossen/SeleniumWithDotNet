using OpenQA.Selenium;
using TestOrangeHRM.Extensions;

namespace TestOrangeHRM.Pages
{
    public class HrmLoginPage
    {
        private IWebDriver _driver;

        public HrmLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }


        IWebElement _txtUsername => _driver.ById("txtUsername");
        IWebElement _txtPassword => _driver.ById("txtPassword");
        IWebElement _btnLogin => _driver.ById("btnLogin");

    }
}
