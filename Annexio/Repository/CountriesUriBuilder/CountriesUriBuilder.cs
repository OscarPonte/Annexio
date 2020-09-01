using Annexio.Repository.CountriesUriBuilder;
using System;
using System.Linq;
using System.Web.WebPages;

namespace Annexio.CountiresUriBuilder
{
    public class CountriesUriBuilder : ICountriesUriBuilder
    {
        private readonly UriBuilder _uriBuilder;

        public CountriesUriBuilder()
        {
            this._uriBuilder = new UriBuilder(Resources.UrlString) ?? throw new ArgumentNullException(nameof(UriBuilder));
        }

        public Uri GetAllCountries()
        {
            _uriBuilder.Path = Resources.UrlStringAll;

            if (_uriBuilder.Path.IsEmpty())            
                throw new ArgumentNullException(nameof(_uriBuilder.Path));
            
            return _uriBuilder.Uri;
        }

        public Uri GetCountryByName(string name)
        {
            _uriBuilder.Path = Resources.UrlStringName + name;

            if (_uriBuilder.Path.IsEmpty())            
                throw new ArgumentNullException(nameof(_uriBuilder.Path));
            
            return _uriBuilder.Uri;
        }

        public Uri GetCountryByCode(string code)
        {
            _uriBuilder.Path = Resources.UrlStringCode + code;

            if (_uriBuilder.Path.IsEmpty())
                throw new ArgumentNullException(nameof(_uriBuilder.Path));

            return _uriBuilder.Uri;
        }

        public Uri GetRegion(string region)
        {
            _uriBuilder.Path = Resources.UrlStringRegion + region;

            if (_uriBuilder.Path.IsEmpty())
                throw new ArgumentNullException(nameof(_uriBuilder.Path));

            return _uriBuilder.Uri;
        }

        public Uri GetSubregion(string subregion)
        {
            _uriBuilder.Path = Resources.UrlStringSubregion + subregion;

            if (_uriBuilder.Path.IsEmpty())
                throw new ArgumentNullException(nameof(_uriBuilder.Path));

            return _uriBuilder.Uri;
        }

    }
}