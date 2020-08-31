using Annexio.Models;
using Annexio.Models.Dtos;
using Annexio.Repository.Manager;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Annexio.Controllers.Api
{
    public class CountriesController : ApiController
    {
        private readonly ICountriesManager _countriesManager;
        private readonly IMapper _mapper;

        public CountriesController(ICountriesManager countriesManager)
        {
            this._countriesManager = countriesManager ?? throw new ArgumentNullException(nameof(countriesManager));
            this._mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Country, CountryDto>();
            })
                .CreateMapper() ?? throw new ArgumentNullException(nameof(_mapper));
        }

        // GET /api/countries
        public async Task<IHttpActionResult> GetCountries()
        {
            var countries = await _countriesManager.GetAllCountries();

            if (countries == null)
                return NotFound();

            return Ok(countries.Select(_mapper.Map<Country, CountryDto>));
        }

    }
}
