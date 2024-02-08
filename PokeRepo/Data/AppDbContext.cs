using Microsoft.EntityFrameworkCore;
using PokeRepo.Models;

namespace PokeRepo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Pokemon1> Pokemons { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<PokemonAbility> PokemonAbilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1:N (Pokemon-Species)
            modelBuilder.Entity<Pokemon1>()
            .HasOne(p => p.Species)               // .HasOne - Varje Pokemon-entitet måste tillhöra EN Species
            .WithMany(s => s.Pokemons)            // .WithMany - men varje Species kan ha flera (M) Pokemon. 
            .HasForeignKey(p => p.SpeciesId)     // .HasForeignKey - Pokemon-entiteten bär på foreign key i relationen. 
            .IsRequired()                        // .IsRequired - Varje Pokemon måste ha EN tillhörande Species. 
             .OnDelete(DeleteBehavior.Restrict); // .OnDelete - När en Species raderas ska inga relaterade Pokemon raderas. 

            // M:N (Pokemon-Ability) 
            modelBuilder.Entity<PokemonAbility>()
                .HasKey(pa => new { pa.PokemonId, pa.AbilityId });

            modelBuilder.Entity<PokemonAbility>()
                .HasOne(pa => pa.Pokemon)
                .WithMany(p => p.PokemonAbilities)
                .HasForeignKey(pa => pa.PokemonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PokemonAbility>()
                .HasOne(pa => pa.Ability)
                .WithMany(a => a.PokemonAbilities)
                .HasForeignKey(pa => pa.AbilityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}