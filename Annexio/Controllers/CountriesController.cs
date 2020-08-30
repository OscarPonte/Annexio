using Annexio.Controllers.HttpClients;
using Annexio.Repository.Manager;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountriesManager countriesManager;

        public CountriesController(ICountriesManager countries)
        {
            this.countriesManager = countries ?? throw new ArgumentNullException();
        }

        public async Task<ViewResult> Index()
        {
            var countries = await countriesManager.GetAllCountries();

            return View(countries);
        }

        public async Task<ViewResult> Details(string name)
        {
            var country = await countriesManager.GetCountryDetailsByName(name);

            return View(country);
        }

        public async Task<ViewResult> DetailsByCode(string code)
        {
            var country = await countriesManager.GetCountryDetailsByCode(code);

            return View(country);
        }
    }
}