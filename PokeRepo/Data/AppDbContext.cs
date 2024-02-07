using Microsoft.EntityFrameworkCore;
using PokeRepo.Models;

namespace PokeRepo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<PokemonDbModel> Pokemons { get; set; }
        public DbSet<AbilityDbModel> Abilities { get; set; }
        public DbSet<SpeciesDbModel> Species { get; set; }
        public DbSet<PokemonAbilityModel> PokemonAbilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Sätt upp many-to-many relationen (skapa en foreign key till båda klasserna) 
            modelBuilder.Entity<PokemonAbilityModel>()
            .HasKey(pa => new { pa.PokemonDbModelId, pa.AbilityDbModelId });

            modelBuilder.Entity<SpeciesDbModel>()
       .HasMany(species => species.PokemonDbModels) // En specie kan ha många Pokémon
       .WithOne(pokemon => pokemon.Species) // En Pokémon tillhör endast en specie
       .HasForeignKey(pokemon => pokemon.SpeciesId); // Foreign key. 
        }


    }
}
