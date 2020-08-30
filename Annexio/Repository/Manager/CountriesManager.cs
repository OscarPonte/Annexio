using Annexio.Controllers.HttpClients;
using Annexio.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Annexio.Repository.Manager
{
    public class CountriesManager : ICountriesManager
    {
        private readonly ICountriesHttpClient _countriesHttpClient;

        public CountriesManager(ICountriesHttpClient countries)
        {
            this._countriesHttpClient = countries ?? throw new ArgumentNullException();
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _countriesHttpClient.GetCountriesAsync();
        }

        public async Task<Country> GetCountryDetailsByName(string name)
        {
           return await _countriesHttpClient.GetCountryByNameAsync(name);             
        }

        public async Task<Country> GetCountryDetailsByCode(string code)
        {
           return await _countriesHttpClient.GetCountryByCodeAsync(code);
        }

    }
}