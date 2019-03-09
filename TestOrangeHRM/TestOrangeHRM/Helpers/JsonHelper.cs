using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TestOrangeHRM.Helpers
{
    public class JsonHelper
    {
        public async Task<TObject> JsonValue<TObject>(string filePath) where TObject : new()
        {
            FileHelper file = new FileHelper(filePath);
            return await Task.Run(() => JsonConvert.DeserializeObject<TObject>(file.GetAllText()));
        }
    }
}
