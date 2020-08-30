using Annexio.Controllers.HttpClients;
using Annexio.CountiresUriBuilder;
using Annexio.Models;
using Annexio.Repository.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public async Task<IHttpActionResult> GetCountries(string query = null)
        {
            var countriesQuery = await _countriesManager.GetAllCountries();

            return Ok(countriesQuery);
        }
    }
}
