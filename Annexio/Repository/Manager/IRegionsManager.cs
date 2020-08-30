using Annexio.Models;
using System.Threading.Tasks;

namespace Annexio.Repository.Manager
{
    public interface IRegionsManager
    {
        Task<Region> GetRegionDetails(string regionName);
    }
}