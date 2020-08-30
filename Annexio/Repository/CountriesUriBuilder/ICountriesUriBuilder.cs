using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annexio.Repository.CountriesUriBuilder
{
    public interface ICountriesUriBuilder
    {
        Uri GetAllCountries();
        Uri GetCountryByName(string name);
        Uri GetCountryByCode(string code);
        Uri GetRegion(string region);
        Uri GetSubregion(string subregion);   
    }
}
