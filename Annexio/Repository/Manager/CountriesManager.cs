using Annexio.App_Start;
using Annexio.Controllers.HttpClients;
using Annexio.Models;
using Annexio.Models.Dtos;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Annexio.Repository.Manager
{
    public class CountriesManager : ICountriesManager
    {
        private readonly ICountriesHttpClient _countriesHttpClient;
        private readonly IMapper _mapper;

        public CountriesManager(ICountriesHttpClient countriesHttpClient)
        {
            this._countriesHttpClient = countriesHttpClient ?? throw new ArgumentNullException(nameof(countriesHttpClient));
            this._mapper = new MapperConfiguration(cfg => cfg
            .AddProfile(new MappingConfig())).CreateMapper() ?? throw new ArgumentNullException(nameof(_mapper));
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountries()
        {
            var countries = await _countriesHttpClient.GetCountriesAsync();

            if (countries == null)
                throw new ArgumentNullException(nameof(countries));

            return countries.Select(_mapper.Map<Country, CountryDto>);
        }

        public async Task<Country> GetCountryDetailsByName(string name)
        {
            if (name.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(name));

            return await _countriesHttpClient.GetCountryByNameAsync(name);
        }

        public async Task<Country> GetCountryDetailsByCode(string code)
        {
            if (code.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(code));

            return await _countriesHttpClient.GetCountryByCodeAsync(code);
        }

    }
}