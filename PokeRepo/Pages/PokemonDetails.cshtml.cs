using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.API;
using PokeRepo.Data;
using PokeRepo.Models;

namespace PokeRepo.Pages
{
    public class PokemonDetailsModel : PageModel
    {
        private readonly AppDbContext context;
        public PokemonRoot? Pokemon { get; set; }

        public async Task OnGet(string name)
        {
            try
            {

                PokemonRoot response = await new APIcaller().MakeCall<PokemonRoot>($"v2/pokemon/{name}");
                Pokemon = response;
                context.Add(response);
                context.SaveChanges();


            }
            catch (Exception ex)
            {

            }


        }
    }
}
