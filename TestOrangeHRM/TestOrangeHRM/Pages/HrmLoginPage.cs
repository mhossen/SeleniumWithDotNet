using OpenQA.Selenium;
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
        private IWebElement _txtUsername => _driver.ById("txtUsername");
        private IWebElement _txtPassword => _driver.ById("txtPassword");
        private IWebElement _btnLogin => _driver.ById("btnLogin");


        public void LogIn(string username, string password)
        {
            _generic.GetElement(_txtUsername).SendKeys(username);
            _generic.GetElement(_txtPassword).SendKeys(password);
            _generic.GetElement(_btnLogin).Click();
        }
    }
}
