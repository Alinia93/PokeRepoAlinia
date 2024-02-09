using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.API;
using PokeRepo.Data;
using PokeRepo.Models;

namespace PokeRepo.Pages
{
    public class PokemonDetailsModel : PageModel
    {
        private readonly AppDbContext context;
        //En lista med str�ngar f�r namnen p� abilities 
        public List<string> AbilityNames = new();
        //en lista f�r abilitites 
        public List<AbilityDbModel> Abilitys = new();
        public PokemonDetailsModel(AppDbContext context)
        {
            this.context = context;
        }
        public PokemonRoot? Pokemon { get; set; }

        public async Task OnGet(string name)
        {

            PokemonRoot response = await new APIcaller().MakeCall<PokemonRoot>($"v2/pokemon/{name}");
            Pokemon = response;

        }

        public async Task<IActionResult> OnPostAsync(string name)
        {
            try
            {

                PokemonRoot response = await new APIcaller().MakeCall<PokemonRoot>($"v2/pokemon/{name}");
                Pokemon = response;

                //skapa en ny species 

                SpeciesDbModel newSpecies = new();
                //den nya species f�r samma namn som den som kommer fr�n json
                newSpecies.Name = Pokemon.Species.name;


                //Skapa en pokemonDbModel utifr�n den som vi f�tt i json
                PokemonDbModel newPokemon = new()
                {
                    Name = Pokemon.Name,
                    Species = newSpecies,
                    Height = Pokemon.Height,
                    Weight = Pokemon.Weight,
                    BaseExperience = Pokemon.BaseExperience,
                    SpeciesId = newSpecies.Id

                };
                context.Pokemons.Add(newPokemon);

                context.SaveChanges();

                //F�r varje ability i listan p� pokemonen l�gg varje namn i en lista med strings
                foreach (var ability in Pokemon.Abilities)
                {
                    AbilityNames.Add(ability.ability.name);
                }
                //f�r varje namn i listan med string. Skapa en ability och l�gg till det namnet p� abilityn

                foreach (string abiltyName in AbilityNames)
                {
                    AbilityDbModel ability = new();
                    ability.Name = abiltyName;
                    context.Abilities.Add(ability);
                    //skapa en lista med varje ability
                    Abilitys.Add(ability);

                }
                context.SaveChanges();

                //f�r varje ability i listan skapa en pokemonAbilityDbModel och l�gg till i databasen 
                foreach (var ability in Abilitys)
                {
                    PokemonAbilityDbModel b = new()
                    {
                        PokemonId = newPokemon.Id,
                        AbilityId = ability.Id
                    };
                    context.PokemonAbilities.Add(b);
                }
                context.SaveChanges();

                return RedirectToPage("/Index");


            }
            catch (Exception ex)
            {
                return Page();
            }

        }

    }


}
