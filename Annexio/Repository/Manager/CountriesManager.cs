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
            var countries = await _countriesHttpClient.GetCountriesAsync();

            return countries;
        }

        public async Task<Country> GetCountryDetailsByName(string name)
        {
            var countries = await _countriesHttpClient.GetCountryByNameAsync(name);

            return countries;
        }
        public async Task<Country> GetCountryDetailsByCode(string code)
        {
            var countries = await _countriesHttpClient.GetCountryByCodeAsync(code);

            return countries;
        }

    }
}