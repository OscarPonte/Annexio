using Annexio.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Annexio.Controllers.HttpClients
{
    public interface IRegionsHttpClient
    {
        Task<IEnumerable<Country>> GetRegionDetailsAsync(string regionName);
    }
}
