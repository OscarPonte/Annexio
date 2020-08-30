﻿using Annexio.Controllers;
using Annexio.Repository.Manager;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Annexio.Tests.Controllers
{

    public class SubregionsControllerTest
    {
        private Mock<ISubregionsManager> _mock;
        private SubregionsController _controller;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ISubregionsManager>();
            _controller = new SubregionsController(_mock.Object);
        }

        [Test]
        public void SubregionsController_SubregionDetails_ReturnsATaskOfViewResult()
        {
            var result = _controller.SubregionDetails("SubregionName");

            Assert.IsInstanceOf<Task<ViewResult>>(result);
        }

        [Test]
        public void SubregionsController_SubregionDetails_IsCallingGetSubregionDetailsMethod()
        {
            var subregionName = "SubregionName";
            var result = _controller.SubregionDetails(subregionName);

            _mock.Verify(c => c.GetSubregionDetails(subregionName));
        }
    }
}
