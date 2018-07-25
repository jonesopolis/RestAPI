using AG.Utilities;
using AG.Dto;
using AG.Service.Interface;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace AG.Api.Tests
{
    [TestClass]
    public class SettingsApiTests : BaseTest
    {
        [TestMethod]
        public async Task GetSettings_ReturnsSettings()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<ISettingsService>();
                mock.Setup(m => m.GetSettings()).ReturnsAsync(ResponseMeta<SettingsDto>.CreateSuccess(Dtos.SettingsDto));

                s.AddTransient<ISettingsService>(_ => mock.Object);
            });

            var api = new SettingsApi();
            var response = await api.GetSettings();

            Assert.IsTrue(response.Success);
            response.Item.Should().BeEquivalentTo(Dtos.SettingsDto);
        }
    }
}
