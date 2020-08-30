using Annexio.Models;
using Annexio.Repository.CountriesUriBuilder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Annexio.Controllers.HttpClients
{
    public class SubregionsHttpClient : ISubregionsHttpClient
    {
        private readonly ICountriesUriBuilder _countriesUriBuilder;

        public SubregionsHttpClient(ICountriesUriBuilder countriesUriBuilder)
        {
            this._countriesUriBuilder = countriesUriBuilder ?? throw new ArgumentNullException(nameof(countriesUriBuilder));
        }

        public async Task<IEnumerable<Country>> GetSubregionDetailsAsync(string subregionName)
        {
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(_countriesUriBuilder.GetSubregion(subregionName));

                if (!responseTask.IsSuccessStatusCode)
                    throw new InvalidOperationException(nameof(responseTask));

                var result = await responseTask.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Country>>(result);
            }
        }
    }
}