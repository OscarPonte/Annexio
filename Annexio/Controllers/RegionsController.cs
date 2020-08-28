using Annexio.Controllers.HttpClients;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class RegionsController : Controller
    {
        public async Task<ViewResult> RegionDetails(string regionName)
        {
            var region = await new RegionsHttpClient().GetRegionDetailsAsync(regionName);

            return View(region);
        }

    }
}
