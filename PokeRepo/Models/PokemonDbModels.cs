using System.ComponentModel.DataAnnotations;

namespace PokeRepo.Models
{
    public class PokemonDbModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? BaseExperience { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }

        public int SpeciesId { get; set; }
        public SpeciesDbModel? Species { get; set; } = null!;

        public List<PokemonAbilityDbModel>? PokemonAbilities { get; set; }
    }

    public class AbilityDbModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<PokemonAbilityDbModel>? PokemonAbilities { get; set; }

    }

    public class PokemonAbilityDbModel
    {
        [Key]
        public int PokemonId { get; set; }
        public PokemonDbModel Pokemon { get; set; } = null!;

        public int AbilityId { get; set; }
        public AbilityDbModel Ability { get; set; } = null!;

    }

    public class SpeciesDbModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<PokemonDbModel> Pokemons { get; set; } = null!;
    }
}


