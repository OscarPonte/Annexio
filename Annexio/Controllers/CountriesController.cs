using Annexio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Countries
        public ActionResult Index()
        {
            IEnumerable<Country> countries = null;

            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync(new Uri("https://restcountries.eu/rest/v2/all"));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Country>>();
                    readTask.Wait();

                    countries = readTask.Result;
                }
                else
                {
                    countries = Enumerable.Empty<Country>();

                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            return View(countries);
        }


    }
}