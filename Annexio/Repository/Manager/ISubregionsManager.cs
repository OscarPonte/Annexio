using Annexio.Models;
using System.Threading.Tasks;

namespace Annexio.Repository.Manager
{
    public interface ISubregionsManager
    {
        Task<Subregion> GetSubregionDetails(string subregionName);
    }
}