using Annexio.Repository.Manager;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace Annexio.Controllers
{
    [OutputCache(Duration = 20, Location = OutputCacheLocation.Server, VaryByParam = "*")]
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

        //Populate the datatable
        public async Task<ActionResult> GetCountries()
        {
            var countries = await _countriesManager.GetAllCountries();

            return Content(new JavaScriptSerializer().Serialize(countries));
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