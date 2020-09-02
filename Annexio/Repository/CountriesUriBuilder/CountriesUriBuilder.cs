using Annexio.Repository.CountriesUriBuilder;
using System;
using System.Linq;
using System.Text;
using System.Web.WebPages;

namespace Annexio.CountiresUriBuilder
{
    public class CountriesUriBuilder : ICountriesUriBuilder
    {
        private readonly UriBuilder _uriBuilder;
        private readonly StringBuilder _stringBuilder;

        public CountriesUriBuilder()
        {
            this._uriBuilder = new UriBuilder(Resources.UrlString) ?? throw new ArgumentNullException(nameof(UriBuilder));
            _stringBuilder = new StringBuilder();
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
        
        public Uri GetFilterByModel(Type type)
        {
            var properties = type.GetProperties().Select(p => p.Name.ToLower());

            _stringBuilder.Append("fields=");
            _stringBuilder.Append(string.Join(";", properties));

            _uriBuilder.Query = _stringBuilder.ToString();

            return _uriBuilder.Uri;
        }
    }
}