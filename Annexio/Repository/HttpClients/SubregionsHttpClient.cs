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
    public class SubregionsHttpClient : ISubregionsHttpClient
    {
        private readonly ICountriesUriBuilder _countriesUriBuilder;

        public SubregionsHttpClient(ICountriesUriBuilder countriesUriBuilder)
        {
            this._countriesUriBuilder = countriesUriBuilder ?? throw new ArgumentNullException(nameof(countriesUriBuilder));
        }

        public async Task<Subregion> GetSubregionDetailsAsync(string subregionName)
        {
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(_countriesUriBuilder.GetSubregion(subregionName));

                if (!responseTask.IsSuccessStatusCode)
                    throw new InvalidOperationException(nameof(responseTask));

                var result = await responseTask.Content.ReadAsStringAsync();
                var listOfCountries = JsonConvert.DeserializeObject<IEnumerable<Country>>(result);
                var subregion = new Subregion
                    {
                        Name = subregionName,
                        Population = listOfCountries.Select(p => p.Population).Sum(),
                        Region = listOfCountries.Select(r => r.Region).FirstOrDefault(),
                        Countries = listOfCountries
                    };

                return subregion;
            }
        }
    }
}