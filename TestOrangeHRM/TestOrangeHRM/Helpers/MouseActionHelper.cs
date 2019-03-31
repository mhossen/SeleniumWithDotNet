using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using TestOrangeHRM.Base;

namespace TestOrangeHRM.Helpers
{
    internal class MouseActionHelper : BasePage
    {
        public MouseActionHelper(RemoteWebDriver remotebDriver) : base(remotebDriver)
        {
        }

        private GenericHelper Generic
        {
            get
            {
                return new GenericHelper(_remoteDriver);
            }
        }

        private Actions _action
        {
            get
            {
                return new Actions(_remoteDriver);
            }
        }

        public void MouseHover(IWebElement element)
        {
            _action.MoveToElement(Generic.GetElement(element)).Perform();
        }

        public void MouseHoverClick(IWebElement element)
        {
            _action.MoveToElement(Generic.GetElement(element)).Perform();
            _action.Click().Perform();

        }
    }
}
