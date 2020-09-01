using Annexio.Repository.Manager;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace Annexio.Controllers
{
    [OutputCache(Duration = 20, Location = OutputCacheLocation.Server, VaryByParam = "*")]
    public class SubregionsController : Controller
    {
        private readonly ISubregionsManager _subregionsManager;

        public SubregionsController(ISubregionsManager subregionsManager)
        {
            _subregionsManager = subregionsManager ?? throw new ArgumentNullException(nameof(subregionsManager));
        }

        public async Task<ViewResult> SubregionDetails(string subregionName)
        {
            return View(await _subregionsManager.GetSubregionDetails(subregionName));
        }

    }
}