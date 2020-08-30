using Annexio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Annexio.Repository.Manager
{
    public interface ICountriesManager
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryDetailsByName(string name);
        Task<Country> GetCountryDetailsByCode(string code);
    }
}
