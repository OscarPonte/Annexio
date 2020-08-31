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

        public ViewResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Details(string name)
        {
            var country = await _countriesManager.GetCountryDetailsByName(name);

            if (country == null)
                return HttpNotFound();

            return View(country);
        }

        public async Task<ActionResult> DetailsByCode(string code)
        {
            var country = await _countriesManager.GetCountryDetailsByCode(code);

            if (country == null)
                return HttpNotFound();

            return View(country);
        }
    }
}