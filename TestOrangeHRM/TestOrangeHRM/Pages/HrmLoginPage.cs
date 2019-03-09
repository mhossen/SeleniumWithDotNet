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
        GenericHelper Generic => new GenericHelper(_driver);

        IWebElement _txtUsername => _driver.ById("txtUsername");
        IWebElement _txtPassword => _driver.ById("txtPassword");
        IWebElement _btnLogin => _driver.ById("btnLogin");


        public void LogIn(string username, string password)
        {
            Generic.GetElement(_txtUsername).SendKeys(username);
            Generic.GetElement(_txtPassword).SendKeys(password);
            Generic.GetElement(_btnLogin).Click();
        }
    }
}
