using Newtonsoft.Json;

namespace PokeRepo.Models
{
    public class Ability
    {
        [JsonProperty("ability")]
        public Ability Ability1 { get; set; }

        [JsonProperty("is_hidden")]
        public bool? IsHidden { get; set; }

        [JsonProperty("slot")]
        public int? Slot { get; set; }
    }



    public class Ability2
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
