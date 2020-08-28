using Annexio.Controllers.HttpClients;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Controllers
{
    public class SubregionsController : Controller
    {
        public async Task<ViewResult> SubregionDetails(string subregionName)
        {
            var subregion = await new SubregionsHttpClient().GetSubregionDetailsAsync(subregionName);

            return View(subregion);
        }

    }
}