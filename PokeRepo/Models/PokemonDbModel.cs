using System.ComponentModel.DataAnnotations;

namespace PokeRepo.Models
{
    public class PokemonDbModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }



        public int? Height { get; set; }

        public int? Weight { get; set; }

        public List<PokemonAbilityModel> PokemonAbilityModels { get; set; }
        public SpeciesDbModel Species { get; set; }
    }
}
