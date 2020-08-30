using Annexio.Controllers.HttpClients;
using Annexio.Repository.Manager;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IRegionsManager _regionsManager;
        public RegionsController(IRegionsManager regions)
        {
            this._regionsManager = regions;
        }

        public async Task<ViewResult> RegionDetails(string regionName)
        {            
            return View(await _regionsManager.GetRegionDetails(regionName));
        }

    }
}
