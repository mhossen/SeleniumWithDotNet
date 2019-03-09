using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TestOrangeHRM.Helpers
{
    internal class JsonHelper
    {

        private FileHelper GetFile(string path)
        {
            return new FileHelper(path);
        }

        public async Task<TObject> JsonValueAsync<TObject>(string filePath) where TObject : new()
        {
            FileHelper file = new FileHelper(filePath);
            return await Task.Run(() => JsonConvert.DeserializeObject<TObject>(file.GetAllText()));
        }

        public TObject JsonValue<TObject>(string filePath) where TObject : new()
        {
            FileHelper file = new FileHelper(filePath);
            return JsonConvert.DeserializeObject<TObject>(file.GetAllText());
        }
    }
}
