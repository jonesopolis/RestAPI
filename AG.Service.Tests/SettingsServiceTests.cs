using AG.Utilities;
using AG.Data;
using AG.Service.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AG.Service.Tests
{
    [TestClass]
    public class SettingsServiceTests : BaseTest
    {
        private SettingsService _service;

        [TestInitialize]
        public void Init()
        {
            _service = new SettingsService(new AsyncFactory<AgContext>(() => Context));
        }

        [TestMethod]
        public async Task GetSettings_ReturnsSettings()
        {
            var response = await _service.GetSettings();

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.Item.CourseImageUrl, "https://images.com/");
        }
    }
}
