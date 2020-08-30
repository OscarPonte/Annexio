using Annexio.Controllers.HttpClients;
using Annexio.Repository.Manager;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
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
