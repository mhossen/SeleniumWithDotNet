using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using TestOrangeHRM.Base;
using TestOrangeHRM.DataTables;
using TestOrangeHRM.Extensions;
using TestOrangeHRM.Helpers;

namespace TestOrangeHRM.Pages
{
    internal class HrmSystemUsersPage : BasePage
    {
        public HrmSystemUsersPage(RemoteWebDriver remotebDriver) : base(remotebDriver)
        {
        }
        IWebElement _userTable => _remoteDriver.ByTagName("tbody");
        public IList<SystemUserTable> GetUserTabelData()
        {
            IList<SystemUserTable> tableColums = new List<SystemUserTable>();

            var table = PageFactory.GetPage<GenericHelper>(_remoteDriver).GetElement(_userTable);
            var rows = table.FindElements(By.TagName("tr"));

            for (int i = 1; i < rows.Count; i++)
            {
                tableColums.Add(new SystemUserTable
                {
                    CheckBox = rows[i].FindElement(By.XPath($"(//td[1])[{i}]")),
                    Username = rows[i].FindElement(By.XPath($"(//td[2])[{i}]")),
                    UserRole = rows[i].FindElement(By.XPath($"(//td[3])[{i}]")),
                    EmployeeName = rows[i].FindElement(By.XPath($"(//td[4])[{i}]")),
                    Status = rows[i].FindElement(By.XPath($"(//td[5])[{i}]"))
                });
            }

            return tableColums;
        }
    }


}
