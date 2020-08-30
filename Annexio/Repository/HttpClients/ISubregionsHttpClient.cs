using Annexio.Models;
using System.Threading.Tasks;

namespace Annexio.Controllers.HttpClients
{
    public interface ISubregionsHttpClient
    {
        Task<Subregion> GetSubregionDetailsAsync(string subregionName);
    }
}
