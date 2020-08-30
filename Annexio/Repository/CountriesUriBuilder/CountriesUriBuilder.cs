using Annexio.Repository.CountriesUriBuilder;
using System;

namespace Annexio.CountiresUriBuilder
{
    public class CountriesUriBuilder : ICountriesUriBuilder
    {
        private readonly UriBuilder uriBuilder;

        public CountriesUriBuilder()
        {
            this.uriBuilder = new UriBuilder(Resources.UrlString);
        }

        public Uri GetAllCountries()
        {
            uriBuilder.Path = Resources.UrlStringAll;

            return uriBuilder.Uri;
        }

        public Uri GetCountryByName(string name)
        {
            uriBuilder.Path = Resources.UrlStringName + name;

            return uriBuilder.Uri;
        }

        public Uri GetCountryByCode(string code)
        {
            uriBuilder.Path = Resources.UrlStringCode + code;

            return uriBuilder.Uri;
        }

        public Uri GetRegion(string region)
        {
            uriBuilder.Path = Resources.UrlStringRegion + region;

            return uriBuilder.Uri;
        }

        public Uri GetSubregion(string subregion)
        {
            uriBuilder.Path = Resources.UrlStringSubregion + subregion;

            return uriBuilder.Uri;
        }

    }
}