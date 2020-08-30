using Annexio.Repository.CountriesUriBuilder;
using System;

namespace Annexio.CountiresUriBuilder
{
    public class CountriesUriBuilder : ICountriesUriBuilder
    {
        private readonly UriBuilder _uriBuilder;

        public CountriesUriBuilder()
        {
            this._uriBuilder = new UriBuilder(Resources.UrlString);
        }

        public Uri GetAllCountries()
        {
            _uriBuilder.Path = Resources.UrlStringAll;

            return _uriBuilder.Uri;
        }

        public Uri GetCountryByName(string name)
        {
            _uriBuilder.Path = Resources.UrlStringName + name;

            return _uriBuilder.Uri;
        }

        public Uri GetCountryByCode(string code)
        {
            _uriBuilder.Path = Resources.UrlStringCode + code;

            return _uriBuilder.Uri;
        }

        public Uri GetRegion(string region)
        {
            _uriBuilder.Path = Resources.UrlStringRegion + region;

            return _uriBuilder.Uri;
        }

        public Uri GetSubregion(string subregion)
        {
            _uriBuilder.Path = Resources.UrlStringSubregion + subregion;

            return _uriBuilder.Uri;
        }

    }
}