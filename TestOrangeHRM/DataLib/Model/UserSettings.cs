using Newtonsoft.Json;

namespace DataLib.Model
{
    public class UserSettings
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("userName")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
