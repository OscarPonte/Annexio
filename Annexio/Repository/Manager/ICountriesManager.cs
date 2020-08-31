using Annexio.Models;
using Annexio.Models.Dtos;
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
