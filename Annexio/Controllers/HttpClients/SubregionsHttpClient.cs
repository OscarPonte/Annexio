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
    public class SubregionsHttpClient
    {
        private readonly CountriesUriBuilder _uri;
        public SubregionsHttpClient()
        {
            _uri = new CountriesUriBuilder();
        }

        public async Task<Subregion> GetSubregionDetailsAsync(string subregionName)
        {
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(_uri.GetSubregion(subregionName));

                if (responseTask.IsSuccessStatusCode)
                {
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
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
    }
}