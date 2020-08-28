using Annexio.CountiresUriBuilder;
using Annexio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Annexio.Controllers.HttpClients
{
    public class RegionsHttpClient
    {
        private readonly CountriesUriBuilder _uri;
        public RegionsHttpClient()
        {
            _uri = new CountriesUriBuilder();
        }

        public async Task<Region> GetRegionDetailsAsync(string regionName)
        {
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(_uri.GetRegion(regionName));

                if (responseTask.IsSuccessStatusCode)
                {
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
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
    }
}