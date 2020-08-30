using Annexio.Controllers.HttpClients;
using Annexio.Models;
using Annexio.Repository.Manager;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Annexio.Tests.Repository.Manager
{

    public class CountriesManagerTest
    {
        private Mock<ICountriesHttpClient> _mock;
        private CountriesManager _manager;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ICountriesHttpClient>();
            _manager = new CountriesManager(_mock.Object);
        }

        [Test]
        public void CountriesManager_GetAllCountries_ReturnsATaskIEnumerableOfCountry()
        {
            var result = _manager.GetAllCountries();

            Assert.IsInstanceOf<Task<IEnumerable<Country>>>(result);
        }

        [Test]
        public void CountriesManager_GetAllCountries_IsCallingGetCountriesAsyncMethod()
        {
            var result = _manager.GetAllCountries();

            _mock.Verify(c => c.GetCountriesAsync());
        }

        [Test]
        public void CountriesManager_GetCountriesDetailsByName_ReturnsATaskOfCountry()
        {
            var result = _manager.GetCountryDetailsByName("Name");

            Assert.IsInstanceOf<Task<Country>>(result);
        }

        [Test]
        public void CountriesManager_GetCountriesDetailsByName_IsCallingGetCountryByNameAsyncMethod()
        {
            var result = _manager.GetCountryDetailsByName("Name");

            _mock.Verify(c => c.GetCountryByNameAsync("Name"));
        }

        [Test]
        public void CountriesManager_GetCountriesDetailsByCode_ReturnsATaskOfCountry()
        {
            var result = _manager.GetCountryDetailsByCode("Code");

            Assert.IsInstanceOf<Task<Country>>(result);
        }

        [Test]
        public void CountriesManager_GetCountriesDetailsByCode_IsCallingGetCountryByCodeAsyncMethod()
        {
            var result = _manager.GetCountryDetailsByCode("Code");

            _mock.Verify(c => c.GetCountryByCodeAsync("Code"));
        }
    }
}
