using AG.Utilities;
using AG.Data;
using AG.Service.Tests.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace AG.Service.Tests
{
    [TestClass]
    public class CourseInfoServiceTests : BaseTest
    {
        private CourseInfoService _service;

        [TestInitialize]
        public void Init()
        {
            _service = new CourseInfoService(new AsyncFactory<AgContext>(() => Context));
        }

        [TestMethod]
        public async Task GetHolesForCourse_ReturnsEmptyDto_IfCourseNotFound()
        {
            var response = await _service.GetCourseInfoForCourse(9999);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(0, response.Item.CourseId);
            Assert.IsNull(response.Item.AddressInfo);
            Assert.IsNull(response.Item.ContactInfo);
            Assert.IsNull(response.Item.TextContent);
        }

        [TestMethod]
        public async Task GetHolesForCourse_ReturnsHolesForCourse()
        {
            var course = Context.Courses
                                    .Include(c => c.Address)
                                    .Include(c => c.ContactInfo)
                                    .Include(c => c.TextContent)
                                    .First(c => c.Id == 1);

            var response = await _service.GetCourseInfoForCourse(1);

            Assert.IsTrue(response.Success);
            course.Address.Should().BeEquivalentTo(response.Item.AddressInfo);
        }
    }
}
