using Annexio.CountiresUriBuilder;
using NUnit.Framework;
namespace Annexio.Tests.Repository.UriBuilder
{

    public class CountriesUriBuilderTest
    {
        private CountriesUriBuilder _uriBuilder;

        [SetUp]
        public void SetUp()
        {
            _uriBuilder = new CountriesUriBuilder();
        }

        [Test]
        public void CountriesUriBuilder_GetAllCountries_ReturnsAUriToGetAllCountries()
        {
            var result = _uriBuilder.GetAllCountries().ToString();

            Assert.That(result, Is.EqualTo("https://restcountries.eu/rest/v2/all"));
        }

        [Test]
        public void CountriesUriBuilder_GetCountryByName_ReturnsAUriToGetCountryDetailsByName()
        {
            var result = _uriBuilder.GetCountryByName("Name").ToString();

            Assert.That(result, Is.EqualTo("https://restcountries.eu/rest/v2/name/Name"));
        }

        [Test]
        public void CountriesUriBuilder_GetCountryByCode_ReturnsAUriToGetCountryDetailsByCode()
        {
            var result = _uriBuilder.GetCountryByCode("Code").ToString();

            Assert.That(result, Is.EqualTo("https://restcountries.eu/rest/v2/alpha/Code"));
        }

        [Test]
        public void CountriesUriBuilder_GetRegion_ReturnsAUriToGetAllCountriesByRegion()
        {
            var result = _uriBuilder.GetRegion("Region").ToString();

            Assert.That(result, Is.EqualTo("https://restcountries.eu/rest/v2/region/Region"));
        }
        [Test]
        public void CountriesUriBuilder_GetSubregion_ReturnsAUriToGetAllCountriesBySubregion()
        {
            var result = _uriBuilder.GetSubregion("Subregion").ToString();

            Assert.That(result, Is.EqualTo("https://restcountries.eu/rest/v2/subregion/Subregion"));
        }

        [Test]
        public void CountriesUriBuilder_GetFilterByModel_ReturnsAUriWhitAQueryToFilterTheResult()
        {
            var result = _uriBuilder.GetFilterByModel(typeof(string)).ToString();

            Assert.That(result, Is.EqualTo("https://restcountries.eu/?fields=chars;length"));
        }
    }
}
