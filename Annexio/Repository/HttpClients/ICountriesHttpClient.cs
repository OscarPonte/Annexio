using Annexio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Annexio.Controllers.HttpClients
{
    public interface ICountriesHttpClient
    {
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<Country> GetCountryByNameAsync(string name);
        Task<Country> GetCountryByCodeAsync(string code);

    }
}
