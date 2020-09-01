using Annexio.Repository.Manager;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace Annexio.Controllers
{
    [OutputCache(Duration = 20, Location = OutputCacheLocation.Server, VaryByParam = "*")]
    public class RegionsController : Controller
    {
        private readonly IRegionsManager _regionsManager;
        public RegionsController(IRegionsManager regionsManager)
        {
            this._regionsManager = regionsManager ?? throw new ArgumentNullException(nameof(regionsManager));
        }

        public async Task<ViewResult> RegionDetails(string regionName)
        {
            return View(await _regionsManager.GetRegionDetails(regionName));
        }

    }
}
