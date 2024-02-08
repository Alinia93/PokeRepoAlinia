using Newtonsoft.Json;

namespace PokeRepo.API
{
    public class APIcaller
    {
        private readonly HttpClient _client;

        public APIcaller()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://pokeapi.co/api/");
        }

        public async Task<T> MakeCall<T>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                T? result = JsonConvert.DeserializeObject<T>(json);

                if (result != null)
                {
                    return result;
                }
            }

            throw new HttpRequestException("Failed to retrieve Pokemon data.");
        }
    }
}

