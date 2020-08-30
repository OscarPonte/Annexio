using Annexio.Controllers.HttpClients;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IRegionsHttpClient regionsHttpClient;
        public RegionsController(IRegionsHttpClient regions)
        {
            this.regionsHttpClient = regions;
        }

        public async Task<ViewResult> RegionDetails(string regionName)
        {
            var region = await regionsHttpClient.GetRegionDetailsAsync(regionName);

            return View(region);
        }

    }
}
