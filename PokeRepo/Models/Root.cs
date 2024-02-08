using Newtonsoft.Json;

namespace PokeRepo.Models
{
    public class Root
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

    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? BaseExperience { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }

        public int SpeciesId { get; set; }
        public Species Species { get; set; } = null!;

        public List<PokemonAbility>? PokemonAbilities { get; set; }
    }

    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<PokemonAbility>? PokemonAbilities { get; set; }
    }

    public class PokemonAbility
    {
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; } = null!;

        public int AbilityId { get; set; }
        public Ability Ability { get; set; } = null!;
    }

    public class Species
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Pokemon> Pokemons { get; set; } = null!;
    }
}
