using Annexio.Controllers.HttpClients;
using Annexio.Models;
using System;
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
            return await _subregionsHttpClient.GetSubregionDetailsAsync(subregionName);
        }
    }
}