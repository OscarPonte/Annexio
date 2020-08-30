using Annexio.Controllers.HttpClients;
using Annexio.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Annexio.Repository.Manager
{
    public class SubregionsManager : ISubregionsManager
    {
        private readonly ISubregionsHttpClient _subregionsHttpClient;

        public SubregionsManager(ISubregionsHttpClient subregionsHttpClient)
        {
            this._subregionsHttpClient = subregionsHttpClient ?? throw new ArgumentNullException(nameof(subregionsHttpClient));
        }

        public async Task<Subregion> GetSubregionDetails(string subregionName)
        {
            var listOfCountries = await _subregionsHttpClient.GetSubregionDetailsAsync(subregionName);
            var subregion = new Subregion
            {
                Name = subregionName,
                Population = listOfCountries.Select(p => p.Population).Sum(),
                Region = listOfCountries.Select(r => r.Region).FirstOrDefault(),
                Countries = listOfCountries
            };

            return subregion;
        }
    }
}