using AG.Utilities;
using AG.Data;
using AG.Dto;
using AG.Service.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using AG.Data.Model;

namespace AG.Service.Tests
{
    [TestClass]
    public class CourseServiceTests : BaseTest
    {
        private CourseService _service;

        [TestInitialize]
        public void Init()
        {
            _service = new CourseService(new AsyncFactory<AgContext>(() => Context));
        }

        [TestMethod]
        public async Task Dispose_IsFaked()
        {
            var x = await _service.GetAsync(1);
            var y = await _service.GetAsync(1);
            var z = await _service.GetAsync(1);
            var a = await _service.GetAsync(1);
        }

        [TestMethod]
        public async Task SearchAsync_ReturnsTop25MatchingRecs()
        {
            for(int i = 0; i < 100; i++)
            {
                Context.Courses.Add(new Course { Name = $"David{i}" });
            }

            Context.SaveChanges();

            var result = await _service.SearchAsync("David");

            Assert.IsTrue(result.Success);
            Assert.AreEqual(25, result.Item.Count);
        }

        [TestMethod]
        public async Task SearchAsync_ReturnsSuccessIfNoResults()
        {
            var result = await _service.SearchAsync("akjshakljghlkjsaf");

            Assert.IsTrue(result.Success);
            Assert.AreEqual(0, result.Item.Count);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsNotFound_IfEntityNotFound()
        {
            var result = await _service.GetAsync(9999);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(ResponseFailureType.EntityNotFound, result.FailureType);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsRec_WhenFound()
        {
            var model = await Context.Courses.FindAsync(1L);
            var result = await _service.GetAsync(1);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(1, result.Item.Id);
            Assert.AreEqual(model.Name, result.Item.Name);
            Assert.AreEqual(model.ImagePath, result.Item.ImagePath);
        }

        [TestMethod]
        public async Task AddAsync_ReturnsFailure_IfIdDefined()
        {
            var courseRec = new CourseDto();
            courseRec.Id = 999;

            var result = await _service.AddAsync(courseRec);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(ResponseFailureType.IdRequiredNull, result.FailureType);
        }

        [TestMethod]
        public async Task AddAsync_ReturnsSuccess_AndCreates()
        {
            var courseRec = new CourseDto();
            courseRec.Name = "Test";
            courseRec.ImagePath = "Test111";

            var result = await _service.AddAsync(courseRec);

            Assert.IsTrue(result.Success);

            var model = Context.Courses.OrderBy(c => c.Id).Last();
            Assert.AreEqual("Test", model.Name);
            Assert.AreEqual("Test111", model.ImagePath);
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsFailure_WhenIdIsNull()
        {
            var courseRec = new CourseDto();
            courseRec.Id = null;

            var result = await _service.UpdateAsync(courseRec);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.FailureType, ResponseFailureType.IdRequired);
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsFailure_WhenNotFound()
        {
            var courseRec = new CourseDto();
            courseRec.Id = 9999;

            var result = await _service.UpdateAsync(courseRec);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.FailureType, ResponseFailureType.EntityNotFound);
        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsSuccess_AndUpdates()
        {
            var courseRec = new CourseDto();
            courseRec.Id = 1;
            courseRec.Name = "Super new name";
            courseRec.ImagePath = "www.microsoft.com";

            var result = await _service.UpdateAsync(courseRec);

            Assert.IsTrue(result.Success);

            var course = Context.Courses.First();
            Assert.AreEqual("Super new name", course.Name);
            Assert.AreEqual("www.microsoft.com", course.ImagePath);
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsFailure_WhenNotFound()
        {
            var result = await _service.DeleteAsync(9999);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.FailureType, ResponseFailureType.EntityNotFound);
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsSuccess_AndDeletes()
        {
            var item = Context.Courses.First();

            var result = await _service.DeleteAsync(item.Id);

            Assert.IsTrue(result.Success);

            var deleted = Context.Courses.FirstOrDefault(c => c.Id == item.Id);
            Assert.IsNull(deleted);
        }
    }
}
