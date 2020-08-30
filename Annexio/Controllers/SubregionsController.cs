using Annexio.Controllers.HttpClients;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class SubregionsController : Controller
    {
        private readonly ISubregionsHttpClient subregionsHttpClient;
        public SubregionsController(ISubregionsHttpClient subregions)
        {
            this.subregionsHttpClient = subregions ?? throw new ArgumentNullException();
        }
        public async Task<ViewResult> SubregionDetails(string subregionName)
        {
            var subregion = await subregionsHttpClient.GetSubregionDetailsAsync(subregionName);

            return View(subregion);
        }

    }
}