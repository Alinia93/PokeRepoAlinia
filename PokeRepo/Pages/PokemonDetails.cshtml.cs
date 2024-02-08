using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.API;
using PokeRepo.Models;

namespace PokeRepo.Pages
{
    public class PokemonDetailsModel : PageModel
    {
        public PokemonRoot? Pokemon { get; set; }

        public async Task OnGet(string name)
        {
            try
            {

                PokemonRoot response = await new APIcaller().MakeCall<PokemonRoot>($"v2/pokemon/{name}");
                Pokemon = response;


            }
            catch (Exception ex)
            {

            }
        }
    }
}
