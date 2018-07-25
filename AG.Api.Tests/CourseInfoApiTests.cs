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
    public class CourseInfoApiTests : BaseTest
    {
        [TestMethod]
        public async Task GetCourseInfoForCourse_ReturnsCourseInfo()
        {
            SetupTextFixture(s =>
            { 
                var mock = new Mock<ICourseInfoService>();
                mock.Setup(m => m.GetCourseInfoForCourse(1)).ReturnsAsync(ResponseMeta<CourseInfoDto>.CreateSuccess(Dtos.CourseInfoDto));

                s.AddTransient<ICourseInfoService>(_ => mock.Object);
            });

            var api = new CourseInfoApi();
            var response = await api.GetCourseInfoForCourse(1);

            Assert.IsTrue(response.Success);
            response.Item.Should().BeEquivalentTo(Dtos.CourseInfoDto);
        }

        [TestMethod]
        public async Task GetCourseInfoForCourse_BubblesErrors()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<ICourseInfoService>();
                mock.Setup(m => m.GetCourseInfoForCourse(1)).ReturnsAsync(ResponseMeta<CourseInfoDto>.CreateFailure(ResponseFailureType.IdRequired));

                s.AddTransient<ICourseInfoService>(_ => mock.Object);
            });

            var api = new CourseInfoApi();
            var response = await api.GetCourseInfoForCourse(1);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseFailureType.IdRequired, response.FailureType);            
        }
        
    }
}
