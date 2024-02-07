using Newtonsoft.Json;

namespace PokeRepo.Models
{
    public class Species
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
