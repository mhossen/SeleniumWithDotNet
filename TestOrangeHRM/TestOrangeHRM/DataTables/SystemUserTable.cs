using OpenQA.Selenium;

namespace TestOrangeHRM.DataTables
{
    internal class SystemUserTable
    {
        public IWebElement CheckBox { get; set; }
        public IWebElement Username { get; set; }
        public IWebElement UserRole { get; set; }
        public IWebElement EmployeeName { get; set; }
        public IWebElement Status { get; set; }
    }
}
