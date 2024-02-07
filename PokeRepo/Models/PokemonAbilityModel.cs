namespace PokeRepo.Models
{
    public class PokemonAbilityModel
    {
        public PokemonDbModel PokemonDbModel { get; set; }
        public int PokemonDbModelId { get; set; }
        public AbilityDbModel AbilityDbModel { get; set; }
        public int AbilityDbModelId { get; set; }
    }
}
