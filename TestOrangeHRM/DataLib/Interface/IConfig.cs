using DataLib.EnumTypes;

namespace DataLib.Interface
{
    public interface IConfig
    {
        BrowserTypes? GetBrowser();
        int GetPageTimeOut();
        int GetElementTimeOut();
    }
}
