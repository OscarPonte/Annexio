using Annexio.Controllers.HttpClients;
using Annexio.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Annexio.Repository.Manager
{
    public class RegionsManager : IRegionsManager
    {
        private readonly IRegionsHttpClient _regionsHttpClient;

        public RegionsManager(IRegionsHttpClient regionsHttpClient)
        {
            this._regionsHttpClient = regionsHttpClient ?? throw new ArgumentNullException(nameof(regionsHttpClient));
        }

        public async Task<Region> GetRegionDetails(string regionName)
        {
            if (regionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(regionName));

            var listOfCountries = await _regionsHttpClient.GetRegionDetailsAsync(regionName);

            var region = new Region
            {
                Name = regionName,
                Population = listOfCountries.Select(p => p.Population).Sum(),
                Countries = listOfCountries,
                Subregion = listOfCountries.Select(s => s.Subregion).Distinct()
            };

            return region;
        }

    }
}