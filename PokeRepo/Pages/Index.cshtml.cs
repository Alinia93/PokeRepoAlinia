using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeRepo.API;
using PokeRepo.Models;

namespace PokeRepo.Pages
{
    public class IndexModel : PageModel
    {
        public string ErrorMessage { get; set; }
        public List<Result> Results { get; set; }


        public async Task OnGet()
        {
            try
            {
                Root response = await new APIcaller().MakeCall<Root>("v2/pokemon/");
                Results = response.Results;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

    }
}


