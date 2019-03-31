using OpenQA.Selenium.Remote;

namespace TestOrangeHRM.Base
{
    public class BasePage
    {
        protected readonly RemoteWebDriver _remoteDriver;
        public BasePage(RemoteWebDriver remotebDriver)
        {
            _remoteDriver = remotebDriver;
        }
    }
}
