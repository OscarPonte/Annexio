using Annexio.Controllers;
using Annexio.Repository.Manager;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Annexio.Tests.Controllers
{
    public class RegionsControllerTest
    {
        private Mock<IRegionsManager> _mock;
        private RegionsController _controller;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IRegionsManager>();
            _controller = new RegionsController(_mock.Object);
        }

        [Test]
        public void RegionsController_RegionDetails_ReturnsATaskOfViewResult()
        {
            var result = _controller.RegionDetails("RegionName");

            Assert.IsInstanceOf<Task<ViewResult>>(result);
        }

        [Test]
        public void RegionsController_RegionDetails_IsCallingGetRegionDetailsMethod()
        {
            var regionName = "RegionName";
            var result = _controller.RegionDetails(regionName);

            _mock.Verify(c => c.GetRegionDetails(regionName));
        }
    }
}
