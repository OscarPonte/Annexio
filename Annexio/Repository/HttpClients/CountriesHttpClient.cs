using Annexio.CountiresUriBuilder;
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
        private readonly ICountriesUriBuilder countriesUriBuilder;

        public CountriesHttpClient(ICountriesUriBuilder countriesUri)
        {
            this.countriesUriBuilder = countriesUri;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(countriesUriBuilder.GetAllCountries());

                if (responseTask.IsSuccessStatusCode)
                {
                    return await responseTask.Content.ReadAsAsync<IEnumerable<Country>>();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public async Task<Country> GetCountryByNameAsync(string name)
        {

            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(countriesUriBuilder.GetCountryByName(name));

                if (responseTask.IsSuccessStatusCode)
                {
                    var result = await responseTask.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Country>>(result).FirstOrDefault();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public async Task<Country> GetCountryByCodeAsync(string code)
        {
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(countriesUriBuilder.GetCountryByCode(code));

                if (responseTask.IsSuccessStatusCode)
                {
                    var result = await responseTask.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Country>(result);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

      

      


    }
}