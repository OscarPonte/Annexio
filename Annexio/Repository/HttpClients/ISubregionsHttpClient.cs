using Annexio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Annexio.Controllers.HttpClients
{
    public interface ISubregionsHttpClient
    {
        Task<IEnumerable<Country>> GetSubregionDetailsAsync(string subregionName);
    }
}
