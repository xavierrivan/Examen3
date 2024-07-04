using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Examen3.Services
{
    public class CountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all");
            var countries = JsonConvert.DeserializeObject<List<Country>>(response);
            return countries;
        }
    }
}
