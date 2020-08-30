using Annexio.Controllers.HttpClients;
using Annexio.Models;
using Annexio.Repository.Manager;
using Moq;
using NUnit.Framework;

namespace Annexio.Tests.Repository.Manager
{
    public class SubregionsManagerTest
    {
        private Mock<ISubregionsHttpClient> _mock;
        private SubregionsManager _manager;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ISubregionsHttpClient>();
            _manager = new SubregionsManager(_mock.Object);
        }

        [Test]
        public void SubregionsManager_GetSubregionDetails_ReturnsASubregion()
        {
            var result = _manager.GetSubregionDetails("Name").Result;

            Assert.IsInstanceOf<Subregion>(result);
        }

        [Test]
        public void SubregionsManager_GetSubregionsDetails_IsCallingGetSubregionDetailsAsyncMethod()
        {
            var result = _manager.GetSubregionDetails("Name");

            _mock.Verify(c => c.GetSubregionDetailsAsync("Name"));
        }
    }
}
