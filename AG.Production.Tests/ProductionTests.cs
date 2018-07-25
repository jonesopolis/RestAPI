using AG.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AG.Production.Tests
{
    [TestClass]
    public class ProductionTests
    {
        [TestMethod]
        public async Task CanReachProduction()
        {
            Settings.BaseUrl = "https://aerialgolfapi.azurewebsites.net";
            Settings.Client = new HttpClient { BaseAddress = new Uri(Settings.BaseUrl) };

            var courseApi = new CourseApi();
            var result = await courseApi.GetByIdAsync(1);

            Assert.IsNotNull(result);

        }
    }
}
