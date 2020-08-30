using Annexio.Controllers.HttpClients;
using Annexio.Models;
using System;
using System.Threading.Tasks;

namespace Annexio.Repository.Manager
{
    public class RegionsManager : IRegionsManager
    {
        private readonly IRegionsHttpClient _regionsHttpClient;

        public RegionsManager(IRegionsHttpClient regions)
        {
            this._regionsHttpClient = regions ?? throw new ArgumentNullException();
        }

        public async Task<Region> GetRegionDetails(string regionName)
        {
            return  await _regionsHttpClient.GetRegionDetailsAsync(regionName);
        }

    }
}