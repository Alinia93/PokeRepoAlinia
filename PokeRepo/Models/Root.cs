
using Newtonsoft.Json;

namespace PokeRepo.Models
{
    public class Root
    {

        [JsonProperty("abilities")]
        public List<Ability> Abilities { get; set; }

        [JsonProperty("base_experience")]
        public int? BaseExperience { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }


        [JsonProperty("id")]
        public int? Id { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("species")]
        public Species Species { get; set; }

        [JsonProperty("weight")]
        public int? Weight { get; set; }

    }
}
