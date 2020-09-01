using Annexio.Controllers;
using Annexio.Repository.Manager;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Tests.Controllers
{
    public class CountriesControllerTest
    {
        private Mock<ICountriesManager> _mock;
        private CountriesController _controller;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ICountriesManager>();
            _controller = new CountriesController(_mock.Object);
        }

        [Test]
        public void CountriesController_Index_ReturnsAViewResult()
        {
            var result = _controller.Index();

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void CountriesController_GetCountries_ReturnsAContentResult()
        {
            var result = _controller.GetCountries().Result;

            Assert.IsInstanceOf<ContentResult>(result);
        }

        [Test]
        public void CountriesController_GetCountries_IsCallingGetAllCountriesMethod()
        {
            var result = _controller.GetCountries();

            _mock.Verify(c => c.GetAllCountries());
        }

        [Test]
        public void CountriesController_Details_ReturnsATaskOfActionResult()
        {
            var result = _controller.Details("Name");

            Assert.IsInstanceOf<Task<ActionResult>>(result);
        }

        [Test]
        public void CountriesController_Details_ReturnsAHttpNotFoundResult()
        {
            var result = _controller.Details(null).Result;

            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void CountriesController_Details_IsCallingGetCountryDetailsByNameMethod()
        {
            var countryName = "CountryName";
            var result = _controller.Details(countryName);

            _mock.Verify(c => c.GetCountryDetailsByName(countryName));
        }

        [Test]
        public void CountriesController_DetailsByCode_ReturnsATaskOfActionResult()
        {
            var result = _controller.DetailsByCode("CountryName");

            Assert.IsInstanceOf<Task<ActionResult>>(result);
        }

        [Test]
        public void CountriesController_DetailsByCode_ReturnsAHttpNotFoundResult()
        {
            var result = _controller.DetailsByCode(null).Result;

            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void CountriesController_DetailsByCode_IsCallingGetCountryDetailsByCodeMethod()
        {
            var countryCode = "CountryCode";
            var result = _controller.DetailsByCode(countryCode);

            _mock.Verify(c => c.GetCountryDetailsByCode(countryCode));
        }

    }
}
