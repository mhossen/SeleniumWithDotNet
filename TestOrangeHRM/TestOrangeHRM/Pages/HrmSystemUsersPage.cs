using OpenQA.Selenium;
using System.Collections.Generic;
using TestOrangeHRM.Extensions;

namespace TestOrangeHRM.Pages
{
    internal class HrmSystemUsersPage
    {
        private readonly IWebDriver _driver;

        public HrmSystemUsersPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IList<SystemUserTable> GetUserTabelData()
        {
            IList<SystemUserTable> tableColums = new List<SystemUserTable>();

            var table = _driver.ByTagName("tbody");

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

    internal class SystemUserTable
    {
        public IWebElement CheckBox { get; set; }
        public IWebElement Username { get; set; }
        public IWebElement UserRole { get; set; }
        public IWebElement EmployeeName { get; set; }
        public IWebElement Status { get; set; }
    }
}
