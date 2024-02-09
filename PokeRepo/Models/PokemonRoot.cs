using Newtonsoft.Json;

namespace PokeRepo.Models
{
    public class PokemonRoot
    {


        [JsonProperty("abilities")]
        public List<Ability>? Abilities { get; set; }

        [JsonProperty("base_experience")]
        public int? BaseExperience { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }


        [JsonProperty("id")]
        public int? Id { get; set; }


        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("species")]
        public Species? Species { get; set; }

        [JsonProperty("weight")]
        public int? Weight { get; set; }



    }
}
public class Ability
{
    public Ability2 ability { get; set; }
    public bool is_hidden { get; set; }
    public int slot { get; set; }
}

public class Ability2
{
    public string name { get; set; }
    public string url { get; set; }
}

public class Species
{
    public string name { get; set; }
    public string url { get; set; }
}



