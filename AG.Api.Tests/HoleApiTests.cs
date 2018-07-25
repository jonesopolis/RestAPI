using AG.Utilities;
using AG.Dto;
using AG.Service.Interface;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AG.Api.Tests
{
    [TestClass]
    public class HoleApiTests : BaseTest
    {
        [TestMethod]
        public async Task GetHolesForCourse_ReturnsCourse()
        {
            SetupTextFixture(s =>
            { 
                var mock = new Mock<IHoleService>();
                mock.Setup(m => m.GetHolesForCourse(1)).ReturnsAsync(ResponseMeta<List<HoleDto>>.CreateSuccess(Dtos.HoleDtoList));

                s.AddTransient<IHoleService>(_ => mock.Object);
            });

            var api = new HoleApi();
            var response = await api.GetHolesForCourse(1);

            Assert.IsTrue(response.Success);
            response.Item.Should().BeEquivalentTo(Dtos.HoleDtoList);
        }

        [TestMethod]
        public async Task GetHolesForCourse_BubblesErrors()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<IHoleService>();
                mock.Setup(m => m.GetHolesForCourse(It.IsAny<long>())).ReturnsAsync(ResponseMeta<List<HoleDto>>.CreateFailure(ResponseFailureType.IdRequired));

                s.AddTransient<IHoleService>(_ => mock.Object);
            });

            var api = new HoleApi();
            var response = await api.GetHolesForCourse(1);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseFailureType.IdRequired, response.FailureType);            
        }
        
    }
}
