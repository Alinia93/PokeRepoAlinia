using System.ComponentModel.DataAnnotations;

namespace PokeRepo.Models
{
    public class AbilityDbModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PokemonAbilityModel> PokemonsAbility { get; set; }
    }
}
