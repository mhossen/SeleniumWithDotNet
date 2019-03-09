using System.IO;
using System.Reflection;

namespace DataLib.Model
{
    public class ResourceCollection
    {
        private static string GetResource() => Directory.GetParent(Assembly.GetExecutingAssembly().Location).ToString() + @"\Resources\";

        public static string SiteConfig = GetResource() + "siteConfig.json";
    }
}
