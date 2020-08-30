﻿using Annexio.Controllers;
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
        public void CountriesController_Index_ReturnsATaskOfViewResult()
        {
            var result = _controller.Index();

            Assert.IsInstanceOf<Task<ViewResult>>(result);
        }

        [Test]
        public void CountriesController_Index_IsCallingGetAllCountriesMethod()
        {
            var result = _controller.Index();

            _mock.Verify(c => c.GetAllCountries());
        }

        [Test]
        public void CountriesController_Details_ReturnsATaskOfViewResult()
        {
            var result = _controller.Details("CountryName");

            Assert.IsInstanceOf<Task<ViewResult>>(result);
        }

        [Test]
        public void CountriesController_Details_IsCallingGetCountryDetailsByNameMethod()
        {
            var countryName = "CountryName";
            var result = _controller.Details(countryName);

            _mock.Verify(c => c.GetCountryDetailsByName(countryName));
        }

        [Test]
        public void CountriesController_DetailsByCode_ReturnsATaskOfViewResult()
        {
            var result = _controller.DetailsByCode("CountryName");

            Assert.IsInstanceOf<Task<ViewResult>>(result);
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
