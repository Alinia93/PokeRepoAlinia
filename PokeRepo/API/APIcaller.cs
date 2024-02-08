using Newtonsoft.Json;
using PokeRepo.Models;

namespace PokeRepo.API
{
    public class APIcaller
    {
        private readonly HttpClient _client;

        public APIcaller()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }

        public async Task<PokemonApiResponse> MakeCall(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                PokemonApiResponse result = JsonConvert.DeserializeObject<PokemonApiResponse>(json);
                return result;
            }

            throw new HttpRequestException("Failed to retrieve Pokemon data.");
        }
    }
}

