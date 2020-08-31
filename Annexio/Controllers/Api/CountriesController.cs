using Annexio.Repository.Manager;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Annexio.Controllers.Api
{
    public class CountriesController : ApiController
    {
        private readonly ICountriesManager _countriesManager;

        public CountriesController(ICountriesManager countriesManager)
        {
            this._countriesManager = countriesManager ?? throw new ArgumentNullException(nameof(countriesManager));
        }

        // GET /api/countries
        public async Task<IHttpActionResult> GetCountries()
        {
            var countries = await _countriesManager.GetAllCountries();

            if (countries == null)
                return NotFound();

            return Ok(countries);
        }

    }
}
