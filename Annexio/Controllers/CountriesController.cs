using Annexio.Controllers.HttpClients;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountriesHttpClient countriesHttpClient;

        public CountriesController(ICountriesHttpClient countries)
        {
            this.countriesHttpClient = countries;
        }

        public async Task<ViewResult> Index()
        {
            var countries = await countriesHttpClient.GetCountriesAsync();

            return View(countries);
        }

        public async Task<ViewResult> Details(string name)
        {
            var country = await countriesHttpClient.GetCountryByNameAsync(name);

            return View(country);
        }

        public async Task<ViewResult> DetailsByCode(string code)
        {
            var country = await countriesHttpClient.GetCountryByCodeAsync(code);

            return View(country);
        }
    }
}