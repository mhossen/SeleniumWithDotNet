using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestOrangeHRM.Helpers
{
    internal class MouseActionHelper
    {
        private readonly IWebDriver _driver;

        public MouseActionHelper(IWebDriver driver)
        {
            _driver = driver;
        }

        private GenericHelper Generic
        {
            get
            {
                return new GenericHelper(_driver);
            }
        }

        private Actions _action
        {
            get
            {
                return new Actions(_driver);
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
