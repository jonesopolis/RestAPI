using AG.Utilities;
using AG.Data;
using AG.Dto;
using AG.Service.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace AG.Service.Tests
{
    [TestClass]
    public class HoleServiceTests : BaseTest
    {
        private HoleService _service;

        [TestInitialize]
        public void Init()
        {
            _service = new HoleService(new AsyncFactory<AgContext>(() => Context));
        }

        [TestMethod]
        public async Task GetHolesForCourse_ReturnsNotFound_IfCourseNotFound()
        {
            var response = await _service.GetHolesForCourse(9999);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseFailureType.EntityNotFound, response.FailureType);
        }

        [TestMethod]
        public async Task GetHolesForCourse_ReturnsHolesForCourse()
        {
            var response = await _service.GetHolesForCourse(1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(18, response.Item.Count);
            Assert.IsTrue(response.Item.All(i => i.CourseId == 1));
        }
    }
}
