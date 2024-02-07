using System.ComponentModel.DataAnnotations;

namespace PokeRepo.Models
{
    public class SpeciesDbModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<PokemonDbModel> PokemonDbModels { get; set; }
        public PokemonDbModel Pokemon { get; set; }
    }
}
