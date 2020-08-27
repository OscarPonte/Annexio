using Annexio.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Countries
        public async Task<ViewResult> Index()
        {
            var countries = await GetCountriesAsync();

            return View(countries);
        }

        public async Task<ViewResult> Details(string name)
        {                        
                return View(await GetCountryByNameAsync(name)); 
        }

        public async Task<ViewResult> DetailsByCode(string code)
        {
            var country = await GetCountryByCodeAsync(code);

            return View(country);
        }


        private static async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            IEnumerable<Country> countries = null;

            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(new Uri("https://restcountries.eu/rest/v2/all"));

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

        private static async Task<Country> GetCountryByNameAsync(string name)
        {
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(new Uri("https://restcountries.eu/rest/v2/name/" + name));

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

        private static async Task<Country> GetCountryByCodeAsync(string code)
        {
            using (var client = new HttpClient())
            {
                var responseTask = await client.GetAsync(new Uri("https://restcountries.eu/rest/v2/alpha/" + code));

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