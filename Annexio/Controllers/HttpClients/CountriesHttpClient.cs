using Annexio.CountiresUriBuilder;
using Annexio.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers.HttpClients
{
    public class CountriesHttpClient
    {
        private readonly CountriesUriBuilder _uri;

        public CountriesHttpClient()
        {
            _uri = new CountriesUriBuilder();
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {      
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(_uri.GetAllCountries());
                         
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
                var responseTask = await client.GetAsync(_uri.GetCountryByName(name));

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
                var responseTask = await client.GetAsync(_uri.GetCountryByCode(code));

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