using System;

namespace Annexio.CountiresUriBuilder
{
    public class CountriesUriBuilder
    {
        private readonly UriBuilder uriBuilder;

        public CountriesUriBuilder()
        {
            this.uriBuilder = new UriBuilder("https://restcountries.eu");
        }

        public Uri GetAllCountries()
        {
            uriBuilder.Path = "/rest/v2/all";

            return uriBuilder.Uri;
        }

        public Uri GetCountryByName(string name)
        {
            uriBuilder.Path = "/rest/v2/name/" + name;

            return uriBuilder.Uri;
        }

        public Uri GetCountryByCode(string code)
        {
            uriBuilder.Path = "/rest/v2/alpha/" + code;

            return uriBuilder.Uri;
        }


    }
}