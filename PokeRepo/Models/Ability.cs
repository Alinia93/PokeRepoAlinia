namespace PokeRepo.Models
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pokemon> Pokemons { get; set; }

    }
}
