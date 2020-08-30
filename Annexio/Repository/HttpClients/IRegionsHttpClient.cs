using Annexio.Models;
using System.Threading.Tasks;

namespace Annexio.Controllers.HttpClients
{
    public interface IRegionsHttpClient
    {
        Task<Region> GetRegionDetailsAsync(string regionName);
    }
}
