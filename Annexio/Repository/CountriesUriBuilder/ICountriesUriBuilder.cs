using System;

namespace Annexio.Repository.CountriesUriBuilder
{
    public interface ICountriesUriBuilder
    {
        Uri GetAllCountries();
        Uri GetCountryByName(string name);
        Uri GetCountryByCode(string code);
        Uri GetRegion(string region);
        Uri GetSubregion(string subregion);
        Uri GetFilterByModel(Type type);

    }
}
