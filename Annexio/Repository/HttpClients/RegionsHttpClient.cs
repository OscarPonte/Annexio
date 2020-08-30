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
    public class RegionsHttpClient : IRegionsHttpClient
    {
        private readonly ICountriesUriBuilder _countriesUriBuilder;

        public RegionsHttpClient(ICountriesUriBuilder countriesUriBuilder)
        {
            this._countriesUriBuilder = countriesUriBuilder ?? throw new ArgumentNullException(nameof(countriesUriBuilder));
        }

        public async Task<Region> GetRegionDetailsAsync(string regionName)
        {
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(_countriesUriBuilder.GetRegion(regionName));

                if (!responseTask.IsSuccessStatusCode)
                    throw new InvalidOperationException(nameof(responseTask));

                var result = await responseTask.Content.ReadAsStringAsync();
                var listOfCountries = JsonConvert.DeserializeObject<IEnumerable<Country>>(result);
                var region = new Region
                    {
                        Name = regionName,
                        Population = listOfCountries.Select(p => p.Population).Sum(),
                        Countries = listOfCountries,
                        Subregions = listOfCountries.Select(s => s.Subregion).Distinct()
                    };

                return region;
            }
        }
    }
}