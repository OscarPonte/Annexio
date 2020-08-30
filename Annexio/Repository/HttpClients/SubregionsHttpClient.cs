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
        private readonly ICountriesUriBuilder countriesUriBuilder;

        public SubregionsHttpClient(ICountriesUriBuilder countriesUri)
        {
            this.countriesUriBuilder = countriesUri ?? throw new ArgumentNullException();
        }

        public async Task<Subregion> GetSubregionDetailsAsync(string subregionName)
        {
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(countriesUriBuilder.GetSubregion(subregionName));

                if (!responseTask.IsSuccessStatusCode)
                    throw new ArgumentNullException();       

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