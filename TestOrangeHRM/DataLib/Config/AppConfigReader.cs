using DataLib.CustomExceptions;
using DataLib.EnumTypes;
using DataLib.Interface;
using DataLib.Model;
using System;
using System.Configuration;

namespace DataLib.Config
{
    public class AppConfigReader : IConfig
    {
        public BrowserTypes? GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppKeySettings.Browser);
            try
            {
                return (BrowserTypes)Enum.Parse(typeof(BrowserTypes), browser);
            }
            catch (Exception ex)
            {

                throw new NoBrowserExist(ex.Message);
            }
        }

        public int GetElementTimeOut() => Convert.ToInt32(ConfigurationManager.AppSettings.Get(AppKeySettings.ElementTimeOut));

        public int GetPageTimeOut() => Convert.ToInt32(ConfigurationManager.AppSettings.Get(AppKeySettings.PageTimeOut));
    }
}
