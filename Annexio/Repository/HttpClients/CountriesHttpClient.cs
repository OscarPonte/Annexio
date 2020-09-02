using Annexio.Models;
using Annexio.Repository.CountriesUriBuilder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Annexio.Controllers.HttpClients
{
    public class CountriesHttpClient : ICountriesHttpClient
    {
        private readonly ICountriesUriBuilder _countriesUriBuilder;

        public CountriesHttpClient(ICountriesUriBuilder countriesUriBuilder)
        {
            this._countriesUriBuilder = countriesUriBuilder ?? throw new ArgumentNullException(nameof(countriesUriBuilder));
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            using (var client = new HttpClient())
            {
                _countriesUriBuilder.GetAllCountries();
                var responseTask = await client.GetAsync(_countriesUriBuilder.GetFilterByModel(typeof(Country)));

                if (!responseTask.IsSuccessStatusCode)
                    throw new InvalidOperationException(nameof(responseTask));

                return await responseTask.Content.ReadAsAsync<IEnumerable<Country>>();
            }
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {
            using (var client = new HttpClient())
            {
                _countriesUriBuilder.GetCountryByName(name);
                var responseTask = await client.GetAsync(_countriesUriBuilder.GetFilterByModel(typeof(Country)));

                if (!responseTask.IsSuccessStatusCode)
                    throw new InvalidOperationException(nameof(responseTask));

                var result = await responseTask.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Country>>(result).FirstOrDefault();
            }
        }

        public async Task<Country> GetCountryByCodeAsync(string code)
        {
            using (var client = new HttpClient())
            {
                _countriesUriBuilder.GetCountryByCode(code);
                var responseTask = await client.GetAsync(_countriesUriBuilder.GetFilterByModel(typeof(Country)));

                if (!responseTask.IsSuccessStatusCode)
                    throw new InvalidOperationException(nameof(responseTask));

                var result = await responseTask.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Country>(result);
            }
        }
    }
}