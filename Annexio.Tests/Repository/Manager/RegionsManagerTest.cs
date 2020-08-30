using Annexio.Controllers.HttpClients;
using Annexio.Models;
using Annexio.Repository.Manager;
using Moq;
using NUnit.Framework;

namespace Annexio.Tests.Repository.Manager
{
    public class RegionsManagerTest
    {
        private Mock<IRegionsHttpClient> _mock;
        private RegionsManager _manager;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IRegionsHttpClient>();
            _manager = new RegionsManager(_mock.Object);
        }

        [Test]
        public void RegionsManager_GetRegionDetails_ReturnsARegion()
        {
            var result = _manager.GetRegionDetails("Name").Result;

            Assert.IsInstanceOf<Region>(result);
        }

        [Test]
        public void RegionsManager_GetRegionsDetails_IsCallingGetRegionDetailsAsyncMethod()
        {
            var result = _manager.GetRegionDetails("Name");

            _mock.Verify(c => c.GetRegionDetailsAsync("Name"));
        }
    }
}
