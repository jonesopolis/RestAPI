using AG.Utilities;
using AG.Dto;
using AG.Service.Interface;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AG.Api.Tests
{
    [TestClass]
    public class CourseApiTests : BaseTest
    {
        [TestMethod]
        public async Task SearchAsync_ReturnsMatches()
        {
            var list = new List<CourseDto>
            {
                new CourseDto {Name = "Response1" },
                new CourseDto {Name = "Other Response" }
            };

            SetupTextFixture(s =>
            {
                var mock = new Mock<ICourseService>();
                mock.Setup(m => m.SearchAsync("David")).ReturnsAsync(ResponseMeta<List<CourseDto>>.CreateSuccess(list));

                s.AddTransient<ICourseService>(_ => mock.Object);
            });

            var api = new CourseApi();
            var response = await api.SearchAsync("David");

            Assert.IsTrue(response.Success);
            response.Item.Should().BeEquivalentTo(list);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsCourse()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<ICourseService>();
                mock.Setup(m => m.GetAsync(It.IsAny<long>())).ReturnsAsync(ResponseMeta<CourseDto>.CreateSuccess(Dtos.CourseDto));

                s.AddTransient<ICourseService>(_ => mock.Object);
            });

            var api = new CourseApi();
            var response = await api.GetByIdAsync(1);

            Assert.IsTrue(response.Success);
            response.Item.Should().BeEquivalentTo(Dtos.CourseDto);
        }

        [TestMethod]
        public async Task GetByIdAsync_BubblesErrors()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<ICourseService>();
                mock.Setup(m => m.GetAsync(It.IsAny<long>())).ReturnsAsync(ResponseMeta<CourseDto>.CreateFailure(ResponseFailureType.IdRequired));

                s.AddTransient<ICourseService>(_ => mock.Object);
            });

            var api = new CourseApi();
            var response = await api.GetByIdAsync(1);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseFailureType.IdRequired, response.FailureType);
        }

        [TestMethod]
        public async Task AddAsync_ReturnsSuccess()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<ICourseService>();
                mock.Setup(m => m.AddAsync(It.IsAny<CourseDto>())).ReturnsAsync(ResponseMeta.CreateSuccess());

                s.AddTransient<ICourseService>(_ => mock.Object);
            });

            var api = new CourseApi();
            var response = await api.AddAsync(Dtos.CourseDto);

            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public async Task AddAsync_BubblesErrors()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<ICourseService>();
                mock.Setup(m => m.AddAsync(It.IsAny<CourseDto>())).ReturnsAsync(ResponseMeta.CreateFailure(ResponseFailureType.IdRequired, new[] { "oh no" }));

                s.AddTransient<ICourseService>(_ => mock.Object);
            });

            var api = new CourseApi();
            var response = await api.AddAsync(new CourseDto());

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseFailureType.IdRequired, response.FailureType);
            Assert.AreEqual("oh no", response.Errors.First());

        }

        [TestMethod]
        public async Task UpdateAsync_ReturnsSuccess()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<ICourseService>();
                mock.Setup(m => m.UpdateAsync(It.IsAny<CourseDto>())).ReturnsAsync(ResponseMeta.CreateSuccess());

                s.AddTransient<ICourseService>(_ => mock.Object);
            });

            var api = new CourseApi();
            var response = await api.UpdateAsync(Dtos.CourseDto);

            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public async Task UpdateAsync_BubblesErrors()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<ICourseService>();
                mock.Setup(m => m.UpdateAsync(It.IsAny<CourseDto>())).ReturnsAsync(ResponseMeta.CreateFailure(ResponseFailureType.IdRequired, new[] { "oh no" }));

                s.AddTransient<ICourseService>(_ => mock.Object);
            });

            var api = new CourseApi();
            var response = await api.UpdateAsync(new CourseDto());

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseFailureType.IdRequired, response.FailureType);
            Assert.AreEqual("oh no", response.Errors.First());

        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsSuccess()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<ICourseService>();
                mock.Setup(m => m.DeleteAsync(555)).ReturnsAsync(ResponseMeta.CreateSuccess());

                s.AddTransient<ICourseService>(_ => mock.Object);
            });

            var api = new CourseApi();
            var response = await api.DeleteAsync(555);

            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public async Task DeleteAsync_BubblesErrors()
        {
            SetupTextFixture(s =>
            {
                var mock = new Mock<ICourseService>();
                mock.Setup(m => m.DeleteAsync(It.IsAny<long>())).ReturnsAsync(ResponseMeta.CreateFailure(ResponseFailureType.IdRequired, new[] { "oh no" }));

                s.AddTransient<ICourseService>(_ => mock.Object);
            });

            var api = new CourseApi();
            var response = await api.DeleteAsync(555);

            Assert.IsFalse(response.Success);
            Assert.AreEqual(ResponseFailureType.IdRequired, response.FailureType);
            Assert.AreEqual("oh no", response.Errors.First());

        }
    }
}
