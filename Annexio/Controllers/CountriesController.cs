using Annexio.Controllers.HttpClients;
using Annexio.Repository.Manager;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountriesManager _countriesManager;

        public CountriesController(ICountriesManager countriesManager)
        {
            this._countriesManager = countriesManager ?? throw new ArgumentNullException(nameof(countriesManager));
        }

        public async Task<ViewResult> Index()
        {         
            return View(await _countriesManager.GetAllCountries());
        }

        public async Task<ViewResult> Details(string name)
        {           
            return View(await _countriesManager.GetCountryDetailsByName(name));
        }

        public async Task<ViewResult> DetailsByCode(string code)
        {
            return View( await _countriesManager.GetCountryDetailsByCode(code));
        }
    }
}