using Annexio.CountiresUriBuilder;
using Annexio.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Annexio.Controllers.HttpClients
{
    public class CountriesHttpClient
    {
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            IEnumerable<Country> countries = null;

            var _uri = new CountriesUriBuilder();

            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(_uri.GetAllCountries());

                if (responseTask.IsSuccessStatusCode)
                {
                    countries = await responseTask.Content.ReadAsAsync<IEnumerable<Country>>();
                }
                else
                {
                    countries = new List<Country>();
                }
            }
            return countries;
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            var _uri = new CountriesUriBuilder();

            using (var client = new HttpClient())
            {

                var responseTask = await client.GetAsync(_uri.GetCountryByName(name));

                var result = await responseTask.Content.ReadAsStringAsync();


                if (responseTask.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Country>>(result).FirstOrDefault();
                }
                else
                {
                    return new Country();
                }
            }
        }

        public async Task<Country> GetCountryByCodeAsync(string code)
        {
            var _uri = new CountriesUriBuilder();

            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(_uri.GetCountryByCode(code));

                var result = await responseTask.Content.ReadAsStringAsync();


                if (responseTask.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Country>(result);
                }
                else
                {
                    return new Country();
                }
            }
        }

    }
}