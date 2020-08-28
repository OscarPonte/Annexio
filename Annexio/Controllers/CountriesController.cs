using Annexio.Controllers.HttpClients;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class CountriesController : Controller
    {
        public async Task<ViewResult> Index()
        {
            var countries = await new CountriesHttpClient().GetCountriesAsync();                 

            return View(countries);
        }

        public async Task<ViewResult> Details(string name)
        {
            var country = await new CountriesHttpClient().GetCountryByNameAsync(name);

            return View(country);
        }

        public async Task<ViewResult> DetailsByCode(string code)
        {
            var country = await new CountriesHttpClient().GetCountryByCodeAsync(code);

            return View(country);
        }

       public async Task<ViewResult> RegionDetails(string regionName)
        {
            var region = await new CountriesHttpClient().GetRegionDetailsAsync(regionName);

            return View(region);
        }

        public async Task<ViewResult> SubregionDetails(string subregionName)
        {
            var subregion = await new CountriesHttpClient().GetSubregionDetailsAsync(subregionName);

            return View(subregion);
        }



    }
}