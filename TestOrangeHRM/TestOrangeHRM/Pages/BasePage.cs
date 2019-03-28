using OpenQA.Selenium;

namespace TestOrangeHRM.Pages
{
  public abstract class BasePage
  {
    protected readonly IWebDriver _driver;
    protected BasePage(IWebDriver driver)
    {
      _driver = driver;
    }
  }
}